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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BaSyx.Models.AdminShell
{
    /// <summary>
    ///  A formula is used to describe constraints by a logical expression.
    /// </summary>
    public interface IFormula : IConstraint
    {
        /// <summary>
        /// A formula may depend on referable or even external global elements that are used in the logical expression. 
        ///The value of the referenced elements needs to be accessible so that it can be evaluated in the formula to true or false in the corresponding logical expression it is used in.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "dependsOn")]
        IEnumerable<IReference> DependsOn { get; }
    }
}
