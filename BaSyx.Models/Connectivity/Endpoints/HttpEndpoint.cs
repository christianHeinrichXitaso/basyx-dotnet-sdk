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
using System.Runtime.Serialization;

namespace BaSyx.Models.Connectivity
{
    public class HttpEndpoint : IEndpoint
    {
        public string Address { get; }

        [IgnoreDataMember]
        public Uri Url { get; }

        public string Type { get; }

        public IEndpointSecurity Security { get; set;}

        [JsonConstructor]
        public HttpEndpoint(string address)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Url = new Uri(address);
            Type = Url.Scheme;
        }

        public HttpEndpoint(Uri uri) : this(uri?.ToString())
        { }
    }
}
