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
using System.Runtime.Serialization;

namespace BaSyx.Models.AdminShell
{
    /// <summary>
    /// A submodel element collection is a set or list of submodel elements.
    /// </summary>
    public interface ISubmodelElementCollection : ISubmodelElement
    {
        /// <summary>
        /// If allowDuplicates=true then it is allowed that the collection contains the same element several times. Default = false 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "allowDuplicates")]
        bool AllowDuplicates { get; set; }

        /// <summary>
        /// If ordered=false then the elements in the property collection are not ordered. If ordered=true then the elements in the collection are ordered.Default = false 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "ordered")]
        bool Ordered { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "value")]
        IElementContainer<ISubmodelElement> Value { get; set; }
    }
}
