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
    /// <summary>
    /// A dictionary contains elements that can be reused. The concept dictionary contains concept descriptions. 
    /// Typically a concept description dictionary of an AAS contains only concept descriptions of elements used within submodels of the AAS. 
    /// </summary>
    public interface IConceptDictionary : IReferable, IModelElement
    {
        /// <summary>
        /// Concept description defines a concept.
        /// </summary>
        List<IReference<IConceptDescription>> ConceptDescriptions { get; }       
    }
}
