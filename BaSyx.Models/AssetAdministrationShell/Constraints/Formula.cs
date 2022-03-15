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

namespace BaSyx.Models.AdminShell
{
    public class Formula : Constraint, IFormula
    {
        public IEnumerable<IReference> DependsOn { get; set; }
        public override ModelType ModelType => ModelType.Formula;

        [JsonConstructor]
        public Formula()
        {
            DependsOn = new List<IReference>();
        }
    }
}
