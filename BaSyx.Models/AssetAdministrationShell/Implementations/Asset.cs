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

namespace BaSyx.Models.AdminShell
{
    [DataContract]
    public class Asset : Identifiable, IAsset
    {
        public AssetKind Kind { get; set; }
        public IReference<ISubmodel> AssetIdentificationModel { get; set; }
        public IReference<ISubmodel> BillOfMaterial { get; set; }
        public IReference SemanticId { get; set; }
        public IEnumerable<IEmbeddedDataSpecification> EmbeddedDataSpecifications { get; }
        public IConceptDescription ConceptDescription { get; set; }
        public ModelType ModelType => ModelType.Asset;

        [JsonConstructor]
        public Asset(string idShort, Identifier identification) : base(idShort, identification)
        {
            Kind = AssetKind.Instance;
            EmbeddedDataSpecifications = new List<IEmbeddedDataSpecification>();
        }
    }
}
