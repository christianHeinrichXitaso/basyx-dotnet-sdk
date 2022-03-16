/*******************************************************************************
* Copyright (c) 2022 Bosch Rexroth AG
* Author: Constantin Ziesche (constantin.ziesche@bosch.com)
*
* This program and the accompanying materials are made available under the
* terms of the MIT License which is available at
* https://github.com/eclipse-basyx/basyx-dotnet/blob/main/LICENSE
*
* SPDX-License-Identifier: MIT
*******************************************************************************/
using BaSyx.API.Http;
using BaSyx.Models.Connectivity;
using BaSyx.Utils.Extensions;
using BaSyx.Utils.Network;
using BaSyx.Utils.Settings;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace BaSyx.API.ServiceProvider
{
    public static class DefaultEndpointRegistration
    {
        private static readonly ILogger logger = LoggingExtentions.CreateLogger("DefaultEndpointRegistration");
        public static void UseAutoEndpointRegistration(this IAssetAdministrationShellRepositoryServiceProvider serviceProvider, ServerConfiguration serverConfiguration)
        {
            string multiUrl = serverConfiguration.Hosting.Urls.Find(u => u.Contains("+"));
            if (!string.IsNullOrEmpty(multiUrl))
            {
                Uri uri = new Uri(multiUrl.Replace("+", "localhost"));
                bool includeIPv6 = false;
                if (serverConfiguration.Hosting.EnableIPv6.HasValue && serverConfiguration.Hosting.EnableIPv6.Value)
                    includeIPv6 = true;

                List<IEndpoint> endpoints = GetNetworkInterfaceBasedEndpoints(uri.Scheme, uri.Port, includeIPv6);
                serviceProvider.UseDefaultEndpointRegistration(endpoints);
            }
            else
            {
                List<IEndpoint> endpoints = serverConfiguration.Hosting.Urls.ConvertAll(EndpointConverter);
                serviceProvider.UseDefaultEndpointRegistration(endpoints);
            }
        }

        public static void UseAutoEndpointRegistration(this ISubmodelRepositoryServiceProvider serviceProvider, ServerConfiguration serverConfiguration)
        {
            string multiUrl = serverConfiguration.Hosting.Urls.Find(u => u.Contains("+"));
            if (!string.IsNullOrEmpty(multiUrl))
            {
                Uri uri = new Uri(multiUrl.Replace("+", "localhost"));
                bool includeIPv6 = false;
                if (serverConfiguration.Hosting.EnableIPv6.HasValue && serverConfiguration.Hosting.EnableIPv6.Value)
                    includeIPv6 = true;

                List<IEndpoint> endpoints = GetNetworkInterfaceBasedEndpoints(uri.Scheme, uri.Port, includeIPv6);
                serviceProvider.UseDefaultEndpointRegistration(endpoints);
            }
            else
            {
                List<IEndpoint> endpoints = serverConfiguration.Hosting.Urls.ConvertAll(EndpointConverter);
                serviceProvider.UseDefaultEndpointRegistration(endpoints);
            }
        }

        private static IEndpoint EndpointConverter(string input)
        {
            try
            {
                Uri uri = new Uri(input);
                return EndpointFactory.CreateEndpoint(uri, null);
            }
            catch (Exception e)
            {
                logger.LogWarning(e, "Error converting input string: " + input + " - Message: " + e.Message);
                return null;
            }
            
        }

        public static void UseAutoEndpointRegistration(this IAssetAdministrationShellServiceProvider serviceProvider, ServerConfiguration serverConfiguration)
        {
            string multiUrl = serverConfiguration.Hosting.Urls.Find(u => u.Contains("+"));
            if (!string.IsNullOrEmpty(multiUrl))
            {
                Uri uri = new Uri(multiUrl.Replace("+", "localhost"));
                bool includeIPv6 = false;
                if (serverConfiguration.Hosting.EnableIPv6.HasValue && serverConfiguration.Hosting.EnableIPv6.Value)
                    includeIPv6 = true;

                List<IEndpoint> endpoints = GetNetworkInterfaceBasedEndpoints(uri.Scheme, uri.Port, includeIPv6);
                serviceProvider.UseDefaultEndpointRegistration(endpoints);
            }
            else
            {
                List<IEndpoint> endpoints = serverConfiguration.Hosting.Urls.ConvertAll(EndpointConverter);
                serviceProvider.UseDefaultEndpointRegistration(endpoints);
            }
        }

        public static void UseAutoEndpointRegistration(this ISubmodelServiceProvider serviceProvider, ServerConfiguration serverConfiguration)
        {
            string multiUrl = serverConfiguration.Hosting.Urls.Find(u => u.Contains("+"));
            if (!string.IsNullOrEmpty(multiUrl))
            {
                Uri uri = new Uri(multiUrl.Replace("+", "localhost"));
                bool includeIPv6 = false;
                if (serverConfiguration.Hosting.EnableIPv6.HasValue && serverConfiguration.Hosting.EnableIPv6.Value)
                    includeIPv6 = true;

                List<IEndpoint> endpoints = GetNetworkInterfaceBasedEndpoints(uri.Scheme, uri.Port, includeIPv6);
                serviceProvider.UseDefaultEndpointRegistration(endpoints);
            }
            else
            {
                List<IEndpoint> endpoints = serverConfiguration.Hosting.Urls.ConvertAll(EndpointConverter);
                serviceProvider.UseDefaultEndpointRegistration(endpoints);
            }
        }

        private static List<IEndpoint> GetNetworkInterfaceBasedEndpoints(string endpointType, int port, bool includeIPv6)
        {
            IEnumerable<IPAddress> ipAddresses = NetworkUtils.GetIPAddresses(includeIPv6);
            List<IEndpoint> aasEndpoints = new List<IEndpoint>();
            foreach (var ipAddress in ipAddresses)
            {
                if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    string address = endpointType + "://" + ipAddress.ToString() + ":" + port;
                    aasEndpoints.Add(EndpointFactory.CreateEndpoint(endpointType, address, null));
                    logger.LogInformation($"Using {address} as endpoint");
                }
                else if (includeIPv6 && ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    string address = endpointType + "://[" + ipAddress.ToString() + "]:" + port;
                    aasEndpoints.Add(EndpointFactory.CreateEndpoint(endpointType, address, null));
                    logger.LogInformation($"Using {address} as endpoint");
                }
                else
                    continue;
            }
            return aasEndpoints;
        }

        public static void UseDefaultEndpointRegistration(this IAssetAdministrationShellRepositoryServiceProvider serviceProvider, IEnumerable<IEndpoint> endpoints)
        {
            List<IEndpoint> repositoryEndpoints = new List<IEndpoint>();
            foreach (var endpoint in endpoints)
            {
                string epAddress = endpoint.Address;
                if (!epAddress.EndsWith(AssetAdministrationShellRepositoryRoutes.SHELLS))
                    epAddress = epAddress.TrimEnd('/') + AssetAdministrationShellRepositoryRoutes.SHELLS;

                repositoryEndpoints.Add(EndpointFactory.CreateEndpoint(endpoint.Type, epAddress, endpoint.Security));
            }

            serviceProvider.ServiceDescriptor.AddEndpoints(repositoryEndpoints);
            var aasRepositoryDescriptor = serviceProvider.ServiceDescriptor;
            foreach (var aasDescriptor in aasRepositoryDescriptor.AssetAdministrationShellDescriptors.Values)
            {
                List<IEndpoint> aasEndpoints = new List<IEndpoint>();
                foreach (var endpoint in repositoryEndpoints)
                {
                    var ep = EndpointFactory.CreateEndpoint(endpoint.Type, GetAssetAdministrationShellEndpoint(endpoint, aasDescriptor.Identification.Id), endpoint.Security);
                    aasEndpoints.Add(ep);
                }
                aasDescriptor.AddEndpoints(aasEndpoints);

                foreach (var submodelDescriptor in aasDescriptor.SubmodelDescriptors.Values)
                {
                    List<IEndpoint> submodelEndpoints = new List<IEndpoint>();
                    foreach (var endpoint in aasEndpoints)
                    {
                        var ep = EndpointFactory.CreateEndpoint(endpoint.Type, GetSubmodelEndpoint(endpoint, submodelDescriptor.Identification.Id), endpoint.Security);
                        submodelEndpoints.Add(ep);
                    }
                    submodelDescriptor.AddEndpoints(submodelEndpoints);
                }
            }
        }

        public static void UseDefaultEndpointRegistration(this ISubmodelRepositoryServiceProvider serviceProvider, IEnumerable<IEndpoint> endpoints)
        {
            List<IEndpoint> repositoryEndpoints = new List<IEndpoint>();
            foreach (var endpoint in endpoints)
            {
                string epAddress = endpoint.Address;
                if (!epAddress.EndsWith(SubmodelRepositoryRoutes.SUBMODELS))
                    epAddress = epAddress.TrimEnd('/') + SubmodelRepositoryRoutes.SUBMODELS;

                repositoryEndpoints.Add(EndpointFactory.CreateEndpoint(endpoint.Type, epAddress, endpoint.Security));
            }

            serviceProvider.ServiceDescriptor.AddEndpoints(repositoryEndpoints);
            var submodelRepositoryDescriptor = serviceProvider.ServiceDescriptor;
            foreach (var submodelDescriptor in submodelRepositoryDescriptor.SubmodelDescriptors.Values)
            {
                List<IEndpoint> submodelEndpoints = new List<IEndpoint>();
                foreach (var endpoint in repositoryEndpoints)
                {
                    var ep = EndpointFactory.CreateEndpoint(endpoint.Type, GetSubmodelInRepositoryEndpoint(endpoint, submodelDescriptor.Identification.Id), endpoint.Security);
                    submodelEndpoints.Add(ep);
                }
                submodelDescriptor.AddEndpoints(submodelEndpoints);                
            }
        }

        public static void UseDefaultEndpointRegistration(this IAssetAdministrationShellServiceProvider serviceProvider, IEnumerable<IEndpoint> endpoints)
        {
            List<IEndpoint> aasEndpoints = new List<IEndpoint>();
            foreach (var endpoint in endpoints)
            {
                string epAddress = endpoint.Address;
                if (!epAddress.EndsWith(AssetAdministrationShellRoutes.AAS))
                    epAddress = epAddress.TrimEnd('/') + AssetAdministrationShellRoutes.AAS;

                aasEndpoints.Add(EndpointFactory.CreateEndpoint(endpoint.Type, epAddress, endpoint.Security));
            }

            serviceProvider.ServiceDescriptor.AddEndpoints(aasEndpoints);
            var aasDescriptor = serviceProvider.ServiceDescriptor;
            foreach (var submodel in aasDescriptor.SubmodelDescriptors.Values)
            {
                List<IEndpoint> spEndpoints = new List<IEndpoint>();
                foreach (var endpoint in aasEndpoints)
                {
                    var ep = EndpointFactory.CreateEndpoint(endpoint.Type, GetSubmodelEndpoint(endpoint, submodel.Identification.Id), endpoint.Security);
                    spEndpoints.Add(ep);
                }
                submodel.AddEndpoints(spEndpoints);
            }
        }

        public static void UseDefaultEndpointRegistration(this ISubmodelServiceProvider serviceProvider, IEnumerable<IEndpoint> endpoints)
        {
            List<IEndpoint> submodelEndpoints = new List<IEndpoint>();
            foreach (var endpoint in endpoints)
            {
                string epAddress = endpoint.Address;
                if (!epAddress.EndsWith(SubmodelRoutes.SUBMODEL))
                    epAddress = epAddress.TrimEnd('/') + SubmodelRoutes.SUBMODEL;

                submodelEndpoints.Add(EndpointFactory.CreateEndpoint(endpoint.Type, epAddress, endpoint.Security));
            }

            serviceProvider.ServiceDescriptor.AddEndpoints(submodelEndpoints);         
        }

        public static string GetSubmodelInRepositoryEndpoint(IEndpoint endpoint, string submodelId)
        {
            string epAddress = endpoint.Address;
            if (!epAddress.EndsWith(SubmodelRepositoryRoutes.SUBMODELS))
                epAddress = epAddress.TrimEnd('/') + SubmodelRepositoryRoutes.SUBMODELS;

            submodelId = StringOperations.Base64UrlEncode(submodelId);

            return epAddress + "/" + submodelId + SubmodelRoutes.SUBMODEL;
        }

        public static string GetSubmodelEndpoint(IEndpoint endpoint, string submodelId)
        {
            string epAddress = endpoint.Address;
            if (!epAddress.EndsWith(AssetAdministrationShellRoutes.AAS))
                epAddress = epAddress.TrimEnd('/') + AssetAdministrationShellRoutes.AAS;

            submodelId = StringOperations.Base64UrlEncode(submodelId);

            return epAddress + SubmodelRepositoryRoutes.SUBMODELS + "/" + submodelId + SubmodelRoutes.SUBMODEL;
        }

        public static string GetAssetAdministrationShellEndpoint(IEndpoint endpoint, string aasId)
        {
            string epAddress = endpoint.Address;
            if (!epAddress.EndsWith(AssetAdministrationShellRepositoryRoutes.SHELLS))
                epAddress = epAddress.TrimEnd('/') + AssetAdministrationShellRepositoryRoutes.SHELLS;

            aasId = StringOperations.Base64UrlEncode(aasId);

            return epAddress + "/" + aasId + AssetAdministrationShellRoutes.AAS;
        }
    }
}
