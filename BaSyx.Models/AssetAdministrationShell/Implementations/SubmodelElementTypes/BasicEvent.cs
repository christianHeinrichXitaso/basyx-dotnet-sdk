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
