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
using System.Collections.Generic;
using System.Runtime.Serialization;
using BaSyx.Models.Extensions;
using System.Linq;

namespace BaSyx.Models.AdminShell
{
    [DataContract]
    public class AssetAdministrationShell : Identifiable, IAssetAdministrationShell
    {
        public IAsset Asset { get; set; }
        public IAssetInformation AssetInformation { get; set; }
        public IElementContainer<ISubmodel> Submodels { get; set; }

        private List<IReference<ISubmodel>> _submodelRefs;
        public IEnumerable<IReference<ISubmodel>> SubmodelReferences 
        { 
            get 
            {
                if (_submodelRefs == null 
                    || _submodelRefs.Count < Submodels.Count
                    || (Submodels.Count > 0 && Submodels.ToList().TrueForAll(sm => _submodelRefs.Any(smRef => sm.Identification.Id == smRef.First.Value))))
                {
                    _submodelRefs = new List<IReference<ISubmodel>>();
                    foreach (var submodel in Submodels)
                    {
                        var reference = submodel.CreateReference();
                        _submodelRefs.Add(reference);
                    }
                }
                return _submodelRefs;
            }
            set
            {
                _submodelRefs = value.ToList();
            }
        }
        public IReference<IAssetAdministrationShell> DerivedFrom { get; set; }     
        public IElementContainer<IView> Views { get; set; }
        public ModelType ModelType => ModelType.AssetAdministrationShell;
        public IEnumerable<IEmbeddedDataSpecification> EmbeddedDataSpecifications { get; }
        public IConceptDescription ConceptDescription { get; set; }
     

        [JsonConstructor]
        public AssetAdministrationShell(string idShort, Identifier identification) : base(idShort, identification)
        {
            Submodels = new ElementContainer<ISubmodel>(this);
            Views = new ElementContainer<IView>(this);
            MetaData = new Dictionary<string, string>();
            EmbeddedDataSpecifications = new List<IEmbeddedDataSpecification>();
        }
    }
}
