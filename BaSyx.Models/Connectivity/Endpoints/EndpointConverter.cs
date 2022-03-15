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
using Newtonsoft.Json.Linq;
using System;

namespace BaSyx.Models.Connectivity
{
    public class EndpointConverter : JsonConverter<IEndpoint>
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;

        public override IEndpoint ReadJson(JsonReader reader, Type objectType, IEndpoint existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jObject;

            try
            {
                jObject = JObject.Load(reader);
            }
            catch (Exception)
            {
                return null;
            }
           
            var endpointType = jObject.SelectToken("type")?.ToObject<string>();
            var address = jObject.SelectToken("address")?.ToObject<string>();


            IEndpoint endpoint = null;
            if (!string.IsNullOrEmpty(endpointType) && !string.IsNullOrEmpty(address))
            {
                endpoint = EndpointFactory.CreateEndpoint(endpointType, address, null);
                serializer.Populate(jObject.CreateReader(), endpoint);
            }

            return endpoint;            
        }

        public override void WriteJson(JsonWriter writer, IEndpoint value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
