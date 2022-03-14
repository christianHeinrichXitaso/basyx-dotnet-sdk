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
using BaSyx.Models.Connectivity.Descriptors;
using BaSyx.Models.Core.Common;
using BaSyx.Utils.ResultHandling;
using System;

namespace BaSyx.API.Interfaces
{
    /// <summary>
    /// Submodel Registry Interface
    /// </summary>
    public interface ISubmodelRegistryInterface
    {
        /// <summary>
        /// Creates a new Submodel registration
        /// </summary>
        /// <param name="submodelDescriptor">The Submodel Descriptor</param>
        /// <returns>Result object with embedded Submodel Descriptor</returns>
        IResult<ISubmodelDescriptor> CreateSubmodelRegistration(ISubmodelDescriptor submodelDescriptor);

        /// <summary>
        /// Updates an existing Submodel registration
        /// </summary>
        /// <param name="submodelId">The Submodel's unique id</param>
        /// <param name="submodelDescriptor">The Submodel Descriptor</param>
        /// <returns>Result object with embedded Submodel Descriptor</returns>
        IResult<ISubmodelDescriptor> UpdateSubmodelRegistration(string submodelId, ISubmodelDescriptor submodelDescriptor);

        /// <summary>
        /// Retrieves all Submodel registrations
        /// </summary>
        /// <param name="predicate">The predicate to explicitly look for specific Asset Administration Shell Descriptors</param>
        /// <returns>Result object with embedded list of Asset Administration Shell Descriptors</returns>
        IResult<IQueryableElementContainer<ISubmodelDescriptor>> RetrieveAllSubmodelRegistrations();

        /// <summary>
        /// Retrieves all Submodel registrations with a certain search predicate
        /// </summary>
        /// <param name="predicate">The predicate to explicitly look for specific Asset Administration Shell Descriptors</param>
        /// <returns>Result object with embedded list of Asset Administration Shell Descriptors</returns>
        IResult<IQueryableElementContainer<ISubmodelDescriptor>> RetrieveAllSubmodelRegistrations(Predicate<ISubmodelDescriptor> predicate);

        /// <summary>
        /// Retrieves the Submodel registration
        /// </summary>
        /// <param name="submodelId">The Submodel's unique id</param>
        /// <returns>Result object with embedded Submodel Descriptor</returns>
        IResult<ISubmodelDescriptor> RetrieveSubmodelRegistration(string submodelId);

        /// <summary>
        /// De-registers the Submodel
        /// </summary>
        /// <param name="submodelId">The Submodel's unique id</param>
        /// <returns>Result object returning only the success of the operation</returns>
        IResult DeleteSubmodelRegistration(string submodelId);
    }
}
