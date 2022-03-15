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
    /// A relationship element is used to define a relationship between two referable elements.
    /// </summary>
    public interface IRelationshipElement : ISubmodelElement
    {
        /// <summary>
        /// First element in the relationship taking the role of the subject.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "first")]
        IReference First { get; }

        /// <summary>
        /// Second element in the relationship taking the role of the object. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "second")]
        IReference Second { get; }
    }
}
