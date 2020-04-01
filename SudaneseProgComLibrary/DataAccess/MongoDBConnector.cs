using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace SudaneseProgComLibrary.DataAccess
{
    public class MongoDBConnector : INoSqlDataConnection
    {
        private const string DB = "SudaneseProgComDB";

        private IMongoDatabase db;

        private IMongoCollection<T> LoadCollection<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection;
        }

        public MongoDBConnector(string dataBase)
        {
            var client = new MongoClient();
            db = client.GetDatabase(dataBase);
        }

        public void InsertRecord<T>(string table, T record)
        {
            LoadCollection<T>(table).InsertOne(record);
        }

        public T LoadRecordById<T>(string table, int Id)
        {
            var filter = Builders<T>.Filter.Eq("Id", Id);
            return LoadCollection<T>(table).Find(filter).First();
        }

        public IEnumerable<T> LoadRecords<T>(string table)
        {
            return LoadCollection<T>(table).Find(new BsonDocument()).ToEnumerable();
        }

        public void UpdateRecord<T>(string table, int Id, T record)
        {
            LoadCollection<T>(table).ReplaceOne(
                new BsonDocument("_id", Id),
                record,
                new UpdateOptions { IsUpsert = true });
        }
    }
}