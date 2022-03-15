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
    /// An IdentifierKeyValuePair describes a generic identifier as key-value pair.
    /// </summary>
    [DataContract]
    public class IdentifierKeyValuePair : IHasSemantics
    {
        /// <summary>
        /// Key of the identifier. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "key")]
        public string Key { get; set; }

        /// <summary>
        /// The value of the identifier with the corresponding key.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "value")]
        public string Value { get; set; }

        /// <summary>
        /// The (external) subject the key belongs to or has meaning to.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "externalSubjectId")]
        public IReference ExternalSubjectId { get; set; }

        public IReference SemanticId { get; set; }
    }
}
