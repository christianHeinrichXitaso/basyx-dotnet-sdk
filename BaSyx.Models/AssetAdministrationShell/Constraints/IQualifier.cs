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

namespace BaSyx.Models.AdminShell
{
    /// <summary>
    /// A qualifier is a type-value-pair that makes additional statements w.r.t. the value of the element.
    /// </summary>
    public interface IQualifier : IConstraint, IHasSemantics, IValue
    {
        /// <summary>
        /// The qualifier type describes the type of the qualifier that is applied to the element. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "type")]
        string Type { get; }


        /// <summary>
        /// Reference to the global unqiue id of a coded value.  
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "valueId")]
        IReference ValueId { get; }
    }
}
