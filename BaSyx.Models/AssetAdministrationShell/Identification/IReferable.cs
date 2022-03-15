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

namespace BaSyx.Models.AdminShell
{
    /// <summary>
    /// An element that is referable by its idShort. This id is not globally unique. This id is unique within the name space of the element.
    /// </summary>
    public interface IReferable
    {
        /// <summary>
        /// Identifying string of the element within its name space.
        /// </summary>
        [JsonProperty(Order = -2), DataMember(Order = 0, EmitDefaultValue = false, IsRequired = false, Name = "idShort")]
        string IdShort { get; }

        /// <summary>
        /// The category is a value that gives further meta information w.r.t. to the class of the element. It affects the expected existence of attributes and the applicability of constraints.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "category")]
        string Category { get; }

        /// <summary>
        /// Description or comments on the element. The description can be provided in several languages.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "description")]
        LangStringSet Description { get; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "displayName")]
        LangStringSet DisplayName { get; }

        [IgnoreDataMember]
        IReferable Parent { get; set; }
    }
}
