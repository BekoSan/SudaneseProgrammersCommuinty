using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace SudaneseProgComLibrary.DataAccess
{
    public class MongoDBConnector : INoSqlDataConnection
    {
        private const string DB = "SudaneseProgComDB";

        private IMongoDatabase db;

        public MongoDBConnector(string dataBase)
        {
            var client = new MongoClient();
            db = client.GetDatabase(dataBase);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public IEnumerable<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToEnumerable();
        }
    }
}