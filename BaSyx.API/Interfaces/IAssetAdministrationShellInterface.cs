/*******************************************************************************
* Copyright (c) 2020, 2021 Robert Bosch GmbH
* Author: Constantin Ziesche (constantin.ziesche@bosch.com)
*
* This program and the accompanying materials are made available under the
* terms of the Eclipse Public License 2.0 which is available at
* http://www.eclipse.org/legal/epl-2.0
*
* SPDX-License-Identifier: EPL-2.0
*******************************************************************************/
using BaSyx.Models.AdminShell;
using BaSyx.Utils.ResultHandling;
using System.Collections.Generic;

namespace BaSyx.API.Interfaces
{
    public interface IAssetAdministrationShellInterface
    {
        IResult<IAssetAdministrationShell> RetrieveAssetAdministrationShell(RequestContent content);

        IResult UpdateAssetAdministrationShell(IAssetAdministrationShell aas);

        IResult<IAssetInformation> RetrieveAssetInformation();

        IResult UpdateAssetInformation(IAssetInformation assetInformation);

        IResult<IEnumerable<IReference<ISubmodel>>> RetrieveAllSubmodelReferences();

        IResult<IReference> CreateSubmodelReference(IReference submodelRef);

        IResult DeleteSubmodelReference(string submodelIdentifier);
    }
}
