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
    /// Element that can have a semantic definition. 
    /// </summary>
    public interface IHasSemantics
    {
        /// <summary>
        /// Identifier of the semantic definition of the element. It is called semantic id of the element.
        /// The semantic id may either reference an external global id or it may reference a referable model element of kind = Template that defines the semantics of the element.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "semanticId")]
        IReference SemanticId { get; }
    }
}
