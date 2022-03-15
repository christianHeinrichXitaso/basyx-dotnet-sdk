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
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace BaSyx.Models.AdminShell
{
    /// <summary>
    ///An Asset describes meta data of an asset that is represented by an AAS. The asset may either represent an asset type or an asset instance. 
    ///The asset has a globally unique identifier plus – if needed – additional domain specific(proprietary) identifiers
    /// </summary>
    public interface IAsset : IIdentifiable, IModelElement, IHasDataSpecification
    {
        /// <summary>
        /// A reference to a Submodel that defines the handling of additional domain specific (proprietary) Identifiers for the asset like e.g. serial number etc. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "assetIdentificationModel")]
        IReference<ISubmodel> AssetIdentificationModel { get; }

        /// <summary>
        /// Bill of material of the asset represented by a submodel of the same AAS. This submodel contains a set of entities describing the material used to compose the composite I4.0 Component.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "billOfMaterial")]
        IReference<ISubmodel> BillOfMaterial { get; }

        /// <summary>
        /// Denotes whether the Asset of of kind “Type” or “Instance”. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "kind")]
        [JsonConverter(typeof(StringEnumConverter))]
        AssetKind Kind { get; }
    }
}
