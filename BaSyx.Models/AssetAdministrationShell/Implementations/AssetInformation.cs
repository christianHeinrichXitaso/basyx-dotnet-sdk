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
using System.Collections.Generic;

namespace BaSyx.Models.AdminShell
{
    public class AssetInformation : IAssetInformation
    {
        public AssetKind Kind { get; set; }

        public IReference<ISubmodel> BillOfMaterial { get; set; }

        public IReference GlobalAssetId { get; set; }

        public IEnumerable<IdentifierKeyValuePair> SpecificAssetIds { get; set; }

        public IFileElement DefaultThumbnail { get; set; }

        public AssetInformation()
        {
            SpecificAssetIds = new List<IdentifierKeyValuePair>();
        }
    }
}
