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
using BaSyx.Utils.ResultHandling;
using BaSyx.API.Interfaces;

namespace BaSyx.API.Clients
{
    public interface ISubmodelClient : ISubmodelInterface
    {

    }

    public static class SubmodelClientExtensions
    {
        public static IResult<ISubmodel> RetrieveSubmodel(this ISubmodelClient submodelClient)
        {
            return submodelClient.RetrieveSubmodel(RequestLevel.Deep, RequestContent.Normal, RequestExtent.WithoutBlobValue);
        }
    }
}
