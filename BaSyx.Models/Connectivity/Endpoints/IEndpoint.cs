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
using System.Runtime.Serialization;

namespace BaSyx.Models.Connectivity
{
    [JsonConverter(typeof(EndpointConverter))]
    public interface IEndpoint
    {
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "address")]
        string Address { get; }
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "type")]
        string Type { get; }
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "security")]
        IEndpointSecurity Security { get; }
    }
}
