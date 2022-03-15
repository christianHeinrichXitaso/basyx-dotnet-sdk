/*******************************************************************************
* Copyright (c) 2020, 2021 Robert Bosch GmbH
* Author: Constantin Ziesche (constantin.ziesche@bosch.com)
*
* This program and the accompanying materials are made available under the
* terms of the Eclipse Public License 2.0 which is available at
* http://www.eclipse.org/legal/epl-2.0
*
* SPDX-License-Identifier: EPL-2.0
*******************************************************************************/
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System;

namespace BaSyx.Models.AdminShell
{
    /// <summary>
    /// An AssetAdministration Shell. 
    /// </summary>
    public interface IAssetAdministrationShell : IIdentifiable, IModelElement, IHasDataSpecification
    {
        /// <summary>
        /// The reference to the AAS the AAS was derived from.
        /// </summary>
        [JsonProperty, DataMember(EmitDefaultValue = false, IsRequired = false, Name = "derivedFrom")]
        IReference<IAssetAdministrationShell> DerivedFrom { get; }

        /// <summary>
        /// The asset the AAS is representing. 
        /// </summary>
        [Obsolete]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "asset")]
        IAsset Asset { get; }


        /// <summary>
        /// The asset the AAS is representing. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "assetInformation")]
        IAssetInformation AssetInformation { get; }

        /// <summary>
        /// The resolved Submodels
        /// </summary>
        [IgnoreDataMember]
        IElementContainer<ISubmodel> Submodels { get; set; }

        /// <summary>
        /// The asset of an AAS is typically described by one or more submodels. 
        /// Temporarily no submodel might be assigned to the AAS
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "submodels")]
        IEnumerable<IReference<ISubmodel>> SubmodelReferences { get; }

        /// <summary>
        /// If needed stakeholder specific views can be defined on the elements of the AAS. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "views")]
        IElementContainer<IView> Views { get; }

        /// <summary>
        /// An AAS max have one or more concept dictionaries assigned to it.  
        /// The concept dictionaries typically contain only descriptions for elements that are also used within the AAS (via HasSemantics). 
        /// </summary>
        [Obsolete]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "conceptDictionaries")]
        IElementContainer<IConceptDictionary> ConceptDictionaries { get; }
    }
}
