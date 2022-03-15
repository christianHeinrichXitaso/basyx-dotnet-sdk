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
    public class ReferenceElement : SubmodelElement, IReferenceElement
    {
        public override ModelType ModelType => ModelType.ReferenceElement;
        public IReference Value { get; set; }

        public ReferenceElement(string idShort) : base(idShort) 
        {
            Get = element => { return new ElementValue(Value, new DataType(DataObjectType.AnyType)); };
            Set = (element, value) => { Value = value?.Value as IReference; };
        }
    }
}
