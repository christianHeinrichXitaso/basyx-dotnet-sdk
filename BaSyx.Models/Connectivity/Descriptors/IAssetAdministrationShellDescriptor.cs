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

namespace BaSyx.Models.Connectivity
{
    public interface IAssetAdministrationShellDescriptor : IServiceDescriptor, IModelElement
    {
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "asset")]
        IAsset Asset { get; set; }
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = "submodels")]
        IElementContainer<ISubmodelDescriptor> SubmodelDescriptors { get; set; }
    }
}
