using Mimoto.Domain.Common;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Mimoto.Infrastructure
{
    public class MimotoContext
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public MimotoContext(string connectionString, string databaseName)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(databaseName);
            Map();
        }

        internal IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("users");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}