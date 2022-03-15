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
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace BaSyx.Models.Connectivity
{
    public class OpcUaEndpoint : IEndpoint
    {
        public string Address { get; }

        [IgnoreDataMember]
        public string BrowsePath { get; }
        [IgnoreDataMember]
        public string Authority { get; }
        public string Type => EndpointType.OPC_UA;

        public IEndpointSecurity Security { get; set; }

        [JsonConstructor]
        public OpcUaEndpoint(string address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Uri uri = new Uri(address);
            BrowsePath = uri.AbsolutePath;
            Authority = uri.Authority;
        }

        public OpcUaEndpoint(Uri uri) : this(uri?.ToString())
        { }

    }
}
