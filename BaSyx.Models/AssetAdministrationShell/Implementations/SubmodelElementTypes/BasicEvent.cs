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
    [DataContract]
    public class BasicEvent : Event, IBasicEvent
    {
        public override ModelType ModelType => ModelType.BasicEvent;

        public IReference Observed { get; set; }
        public BasicEvent(string idShort) : base(idShort)
        {
            Get = element => { return new ElementValue(Observed, new DataType(DataObjectType.AnyType)); };
            Set = (element, value) => { Observed = value.Value as IReference; };
        }
    }
}
