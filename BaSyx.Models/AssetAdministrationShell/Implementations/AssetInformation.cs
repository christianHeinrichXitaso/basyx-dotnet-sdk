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
