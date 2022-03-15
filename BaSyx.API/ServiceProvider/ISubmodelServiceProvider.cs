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
using BaSyx.Utils.Client;
using BaSyx.Models.AdminShell;
using BaSyx.Utils.ResultHandling;
using System;
using BaSyx.Models.Connectivity;
using BaSyx.API.Interfaces;

namespace BaSyx.API.ServiceProvider
{
    public delegate void EventDelegate(ISubmodelServiceProvider submodelServiceProvider, IEventMessage eventMessage);
    /// <summary>
    /// Provides basic functions for a Submodel
    /// </summary>
    public interface ISubmodelServiceProvider : IServiceProvider<ISubmodel, ISubmodelDescriptor>, ISubmodelInterface
    {
        /// <summary>
        /// Subscribe to value updates of a specific SubmodelElement
        /// </summary>
        /// <param name="pathToSubmodelElement">IdShort-Path to the SubmodelElement</param>
        /// <param name="updateFunction">Callback function</param>
        void SubscribeUpdates(string pathToSubmodelElement, Action<IValue> updateFunction);

        /// <summary>
        /// Publishes value updates to subscribers
        /// </summary>
        /// <param name="pathToSubmodelElement">IdShort-Path to the SubmodelElement</param>
        /// <param name="value">New value</param>
        void PublishUpdate(string pathToSubmodelElement, IValue value);

        /// <summary>
        /// Publishs an Event
        /// </summary>
        /// <param name="eventMessage">The event to publish</param>
        /// <returns></returns>
        IResult PublishEvent(IEventMessage eventMessage);

        /// <summary>
        /// Returns the SubmodelElementHandler for a specific SubmodelElement
        /// </summary>
        /// <param name="pathToElement">IdShort-Path to the SubmodelElement</param>
        /// <returns></returns>
        SubmodelElementHandler RetrieveSubmodelElementHandler(string pathToElement);

        /// <summary>
        /// Registers a new SubmodelElementHandler for a specific SubmodelElement
        /// </summary>
        /// <param name="pathToElement">IdShort-Path to the SubmodelElement</param>
        /// <param name="elementHandler">SubmodelElementHandler</param>
        void RegisterSubmodelElementHandler(string pathToElement, SubmodelElementHandler elementHandler);

        /// <summary>
        /// Returns the MethodCalledHandler for a specific Operation
        /// </summary>
        /// <param name="pathToOperation">IdShort-Path to the Operation</param>
        /// <returns></returns>
        MethodCalledHandler RetrieveMethodCalledHandler(string pathToOperation);

        /// <summary>
        /// Registers a new MethodCalledHandler for a specific Operation
        /// </summary>
        /// <param name="pathToOperation">IdShort-Path to the Operation</param>
        /// <param name="methodCalledHandler">MethodCalledHandler</param>
        void RegisterMethodCalledHandler(string pathToOperation, MethodCalledHandler methodCalledHandler);

        /// <summary>
        /// Registers a new EventDelegate for a specific Event
        /// </summary>
        /// <param name="pathToEvent">IdShort-Path to the Event</param>
        /// <param name="eventDelegate">EventDelegate</param>
        void RegisterEventDelegate(string pathToEvent, EventDelegate eventDelegate);

        /// <summary>
        /// Configures the SubmodelServiceProvider with a MessageClient for the Events
        /// </summary>
        /// <param name="messageClient">MessageClient</param>
        void ConfigureEventHandler(IMessageClient messageClient);
    }

    public static class SubmodelServiceProviderExtensions
    {
        public static ISubmodelServiceProvider CreateServiceProvider(this ISubmodel submodel)
        {
            InternalSubmodelServiceProvider sp = new InternalSubmodelServiceProvider(submodel);

            return sp;
        }
    }
}