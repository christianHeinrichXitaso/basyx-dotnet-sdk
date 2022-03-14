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
    /// The Asset Administration Shell Registry Interface
    /// </summary>
    public interface IAssetAdministrationShellRegistryInterface
    {
        /// <summary>
        /// Creates a new Asset Administration Shell registration at the Registry
        /// </summary>
        /// <param name="aasDescriptor">The Asset Administration Shell Descriptor</param>
        /// <returns>Result object with embedded Asset Administration Shell Descriptor</returns>
        IResult<IAssetAdministrationShellDescriptor> CreateAssetAdministrationShellRegistration(IAssetAdministrationShellDescriptor aasDescriptor);

        /// <summary>
        /// Updates an existing Asset Administration Shell registration at the Registry
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell's unique id</param>
        /// <param name="aasDescriptor">The Asset Administration Shell Descriptor</param>
        /// <returns>Result object with embedded Asset Administration Shell Descriptor</returns>
        IResult<IAssetAdministrationShellDescriptor> UpdateAssetAdministrationShellRegistration(string aasIdentifier, IAssetAdministrationShellDescriptor aasDescriptor);
        
        /// <summary>
        /// Retrieves the Asset Administration Shell registration from the Registry
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell's unique id</param>
        /// <returns>Result object with embedded Asset Administration Shell Descriptor</returns>
        IResult<IAssetAdministrationShellDescriptor> RetrieveAssetAdministrationShellRegistration(string aasIdentifier);

        /// <summary>
        /// Retrieves all Asset Administration Shell registrations from the Registry
        /// </summary>
        /// <param name="predicate">The predicate to explicitly look for specific Asset Administration Shell Descriptors</param>
        /// <returns>Result object with embedded list of Asset Administration Shell Descriptors</returns>
        IResult<IQueryableElementContainer<IAssetAdministrationShellDescriptor>> RetrieveAllAssetAdministrationShellRegistrations();
        /// <summary>
        /// Retrieves all Asset Administration Shell registrations from the Registry with a certain search predicate
        /// </summary>
        /// <param name="predicate">The predicate to explicitly look for specific Asset Administration Shell Descriptors</param>
        /// <returns>Result object with embedded list of Asset Administration Shell Descriptors</returns>
        IResult<IQueryableElementContainer<IAssetAdministrationShellDescriptor>> RetrieveAllAssetAdministrationShellRegistrations(Predicate<IAssetAdministrationShellDescriptor> predicate);

        /// <summary>
        /// Deletes the Asset Administration Shell registration from the Registry
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell's unique id</param>
        /// <returns>Result object returning only the success of the operation</returns>
        IResult DeleteAssetAdministrationShellRegistration(string aasIdentifier);

        /// <summary>
        /// Creates a new Submodel registration
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell�s unique id</param>
        /// <param name="submodelDescriptor">The Submodel Descriptor</param>
        /// <returns>Result object with embedded Submodel Descriptor</returns>
        IResult<ISubmodelDescriptor> CreateSubmodelRegistration(string aasIdentifier, ISubmodelDescriptor submodelDescriptor);

        /// <summary>
        /// Updates an existing Submodel registration
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell�s unique id</param>
        /// <param name="submodelIdentifier">The Submodel's unique id</param>
        /// <param name="submodelDescriptor">The Submodel Descriptor</param>
        /// <returns>Result object with embedded Submodel Descriptor</returns>
        IResult<ISubmodelDescriptor> UpdateSubmodelRegistration(string aasIdentifier, string submodelIdentifier, ISubmodelDescriptor submodelDescriptor);

        /// <summary>
        /// Retrieves all Submodel registrations
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell�s unique id</param>
        /// <param name="predicate">The predicate to explicitly look for specific Asset Administration Shell Descriptors</param>
        /// <returns>Result object with embedded list of Asset Administration Shell Descriptors</returns>
        IResult<IQueryableElementContainer<ISubmodelDescriptor>> RetrieveAllSubmodelRegistrations(string aasIdentifier);

        /// <summary>
        /// Retrieves all Submodel registrations with a certain search predicate
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell�s unique id</param>
        /// <param name="predicate">The predicate to explicitly look for specific Asset Administration Shell Descriptors</param>
        /// <returns>Result object with embedded list of Asset Administration Shell Descriptors</returns>
        IResult<IQueryableElementContainer<ISubmodelDescriptor>> RetrieveAllSubmodelRegistrations(string aasIdentifier, Predicate<ISubmodelDescriptor> predicate);

        /// <summary>
        /// Retrieves the Submodel registration
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell�s unique id</param>
        /// <param name="submodelIdentifier">The Submodel's unique id</param>
        /// <returns>Result object with embedded Submodel Descriptor</returns>
        IResult<ISubmodelDescriptor> RetrieveSubmodelRegistration(string aasIdentifier, string submodelIdentifier);

        /// <summary>
        /// De-registers the Submodel
        /// </summary>
        /// <param name="aasIdentifier">The Asset Administration Shell�s unique id</param>
        /// <param name="submodelIdentifier">The Submodel's unique id</param>
        /// <returns>Result object returning only the success of the operation</returns>
        IResult DeleteSubmodelRegistration(string aasIdentifier, string submodelIdentifier);
    }
}