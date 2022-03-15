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
using System.Runtime.Serialization;

namespace BaSyx.Models.AdminShell
{
    public enum RequestContent : int
    {
        [EnumMember(Value = "normal")]
        Normal = 0,
        [EnumMember(Value = "trimmed")]
        Trimmed = 1,
        [EnumMember(Value = "value")]
        Value = 2,
        [EnumMember(Value = "reference")]
        Reference = 3,
        [EnumMember(Value = "path")]
        Path = 4
    }
}
