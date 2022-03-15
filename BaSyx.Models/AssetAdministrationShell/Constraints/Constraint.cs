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

namespace BaSyx.Models.AdminShell
{
    [JsonConverter(typeof(ConstraintConverter))]
    public interface IConstraint : IModelElement
    { } 

    public abstract class Constraint : IConstraint
    {
        public abstract ModelType ModelType { get; }
    }
}
