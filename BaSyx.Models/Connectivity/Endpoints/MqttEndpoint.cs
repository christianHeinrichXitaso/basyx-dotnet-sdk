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
using Newtonsoft.Json;
using System;

namespace BaSyx.Models.Connectivity
{
    public class MqttEndpoint : IEndpoint
    {
        public string Address { get; }

        public Uri BrokerUri { get; }

        public string Topic { get; }

        public string Type => EndpointType.MQTT;

        public IEndpointSecurity Security { get; set; }

        [JsonConstructor]
        public MqttEndpoint(string address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Uri uri = new Uri(address);
            BrokerUri = new Uri(uri.AbsoluteUri);
            Topic = uri.AbsolutePath;
        }

        public MqttEndpoint(Uri uri) : this(uri?.ToString())
        { }
    }
}
