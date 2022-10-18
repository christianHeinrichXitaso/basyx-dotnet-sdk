using System;
using BaSyx.Models.AdminShell;
using BaSyx.Utils.DependencyInjection;
using BaSyx.Utils.Json;
using BaSyx.Utils.ResultHandling;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace BaSyx.API.ServiceProvider
{
    public class DatabaseAssetAdministrationShellServiceProvider : AssetAdministrationShellServiceProvider
    {
        private static JsonSerializer _serializer =
            JsonSerializer.Create(new DependencyInjectionJsonSerializerSettings());

        private IAssetAdministrationShell _aas;

        private static readonly ILogger logger =
            LoggingExtentions.CreateLogger<DatabaseAssetAdministrationShellServiceProvider>();

        public DatabaseAssetAdministrationShellServiceProvider(IAssetAdministrationShell aas)
        {
            _aas = aas;
            Console.WriteLine("Store AAS to database");
            Console.WriteLine("Serialized:");
            WriteAasToDb(aas);
        }

        private void WriteAasToDb(IAssetAdministrationShell aas)
        {
            DefaultJsonSerializerSettings jsonSerializerSettings = new DefaultJsonSerializerSettings();
            var aasId = _aas.Identification.Id;
            var json = JsonConvert.SerializeObject(aas, jsonSerializerSettings);
            Console.WriteLine(json);
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("shells");
            var collection = database.GetCollection<BsonDocument>("bar");

            var bsonDocument = BsonSerializer.Deserialize<BsonDocument>(json);
            bsonDocument["_id"] = aasId;
            var filter = Builders<BsonDocument>.Filter.Eq("_id", aasId);
            collection.ReplaceOne(filter, bsonDocument,new ReplaceOptions() {IsUpsert = true} );
        }

        public override IAssetAdministrationShell BuildAssetAdministrationShell()
        {
            logger.Log(LogLevel.Debug, "Build AAS");
            return _aas;
        }

        public override IResult UpdateAssetAdministrationShell(IAssetAdministrationShell aas)
        {
            logger.Log(LogLevel.Debug, "Update AAS");
            WriteAasToDb(aas);
            return base.UpdateAssetAdministrationShell(aas);
        }
    }
}