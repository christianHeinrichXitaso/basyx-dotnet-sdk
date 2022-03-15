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
using BaSyx.Models.AdminShell;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections;

namespace BaSyx.Models.Connectivity
{
    [DataContract]
    public class AssetAdministrationShellRepositoryDescriptor : IAssetAdministrationShellRepositoryDescriptor
    {
        [IgnoreDataMember]
        public Identifier Identification { get; set; }
        [IgnoreDataMember]
        public AdministrativeInformation Administration { get; set; }
        [IgnoreDataMember]
        public string IdShort { get; set; }
        [IgnoreDataMember]
        public LangStringSet Description { get; set; }
        [IgnoreDataMember]
        public LangStringSet DisplayName { get; set; }
        public IEnumerable<IEndpoint> Endpoints { get; internal set; }

        [IgnoreDataMember]
        public IReferable Parent { get; set; }
        [IgnoreDataMember]
        public string Category => null;

        public ModelType ModelType => ModelType.AssetAdministrationShellRepositoryDescriptor;

        public IElementContainer<IAssetAdministrationShellDescriptor> AssetAdministrationShellDescriptors { get; set; }

        public AssetAdministrationShellRepositoryDescriptor(IEnumerable<IEndpoint> endpoints) 
        {
            Endpoints = endpoints ?? new List<IEndpoint>();
            AssetAdministrationShellDescriptors = new ElementContainer<IAssetAdministrationShellDescriptor>(this);
        }
     
        [JsonConstructor]
        public AssetAdministrationShellRepositoryDescriptor(IEnumerable<IAssetAdministrationShell> shells, IEnumerable<IEndpoint> endpoints) : this(endpoints)
        {
            if (shells?.Count() > 0)
                foreach (var shell in shells)
                {
                    AddAssetAdministrationShell(shell);
                }
        }

        public void AddAssetAdministrationShell(IAssetAdministrationShell aas)
        {
            AssetAdministrationShellDescriptor assetAdministrationShellDescriptor = new AssetAdministrationShellDescriptor(aas, Endpoints.ToList());
            if (aas.Submodels?.Count() > 0)
                foreach (var submodel in aas.Submodels.Values)
                {
                    assetAdministrationShellDescriptor.SubmodelDescriptors.Create(new SubmodelDescriptor(submodel, Endpoints.ToList()));
                }
               
            AssetAdministrationShellDescriptors.Create(assetAdministrationShellDescriptor);
        }

        public void AddEndpoints(IEnumerable<IEndpoint> endpoints)
        {
            foreach (var endpoint in endpoints)
            {
                (Endpoints as IList).Add(endpoint);
            }
        }

        public void SetEndpoints(IEnumerable<IEndpoint> endpoints)
        {
            Endpoints = endpoints;
        }
    }
}
