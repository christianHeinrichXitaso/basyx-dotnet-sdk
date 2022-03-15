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
    /// An entity is a submodel element that is used to model entities. 
    /// </summary>
    public interface IEntity : ISubmodelElement
    {
        /// <summary>
        /// Describes statements applicable to the entity by a set of submodel elements, typically with a qualified value.
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "statements")]
        IElementContainer<ISubmodelElement> Statements { get; }

        /// <summary>
        /// Describes whether the entity is a comanaged entity or a self-managed entity. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "entityType")]
        EntityType EntityType { get; }

        /// <summary>
        /// Reference to the asset the entity is representing. 
        /// </summary>
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "asset")]
        IReference<IAsset> Asset { get; }
    }

    /// <summary>
    /// Enumeration for denoting whether an entity is a self-managed entity or a comanaged entity. 
    /// </summary>
    [DataContract]
    public enum EntityType
    {
        [EnumMember(Value = "CoManagedEntity")]
        CoManagedEntity,
        [EnumMember(Value = "SelfManagedEntity")]
        SelfManagedEntity
    }
}
