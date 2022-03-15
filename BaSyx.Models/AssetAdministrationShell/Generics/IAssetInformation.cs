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
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BaSyx.Models.AdminShell
{
    public interface IAssetInformation
    {
        /// <summary>
        /// Denotes whether the Asset of of kind “Type” or “Instance”. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "kind")]
        [JsonConverter(typeof(StringEnumConverter))]
        AssetKind Kind { get; }

        /// <summary>
        /// Bill of material of the asset represented by a submodel of the same AAS. This submodel contains a set of entities describing the material used to compose the composite I4.0 Component.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "billOfMaterial")]
        IReference<ISubmodel> BillOfMaterial { get; }

        /// <summary>
        /// Reference to either an Asset object or a global reference to the asset the AAS is representing. 
        /// This attribute is required as soon as the AAS is exchanged via partners in the life cycle of the asset.
        /// In a first phase of the life cycle the asset might not yet have a global id but already an internal identifier.
        /// The internal identifier would be modelled via “specificAssetId”.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "globalAssetId")]
        IReference GlobalAssetId { get; }

        /// <summary>
        /// Additional domain specific specific, typically proprietary Identifier for the asset, e.g., serial number.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "specificAssetIds")]
        IEnumerable<IdentifierKeyValuePair> SpecificAssetIds { get; }

        /// <summary>
        /// Thumbnail of the asset represented by the asset administration shell. Used as default.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "defaultThumbnail")]
        IFileElement DefaultThumbnail { get; }
    }
}
