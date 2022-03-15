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
using BaSyx.Models.Extensions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace BaSyx.Models.AdminShell
{
    [JsonConverter(typeof(DataSpecificationConverter))]
    public interface IEmbeddedDataSpecification
    {
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "hasDataSpecification")]
        IReference HasDataSpecification { get; }
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "dataSpecificationContent")]
        IDataSpecificationContent DataSpecificationContent { get; }
    }
}