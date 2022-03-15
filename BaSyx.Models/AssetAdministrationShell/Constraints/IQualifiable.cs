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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BaSyx.Models.AdminShell
{
    /// <summary>
    /// The value of a qualifiable element may be further qualified by one or more qualifiers or complex formulas. 
    /// </summary>
    public interface IQualifiable
    {
        /// <summary>
        /// A constraint is used to further qualify an element. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "qualifiers")]
        IEnumerable<IConstraint> Constraints { get; }
    }
}
