using Microsoft.Extensions.Options;
using Mimoto.Domain.Common;
using Mimoto.Infrastructure.Data;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Mimoto.Infrastructure
{
    public class MimotoContext : IMimotoContext
    {
        private readonly IMongoDatabase _db;

        public MimotoContext(IOptions<DbSettings> settings, IMongoClient client)
        {
            _db = client.GetDatabase(settings.Value.Database);
            // Map();
        }

        public IMongoCollection<User> Users => _db.GetCollection<User>("users");
        public IMongoCollection<App> Apps => _db.GetCollection<App>("apps");
        public IMongoCollection<Company> Companies => _db.GetCollection<Company>("companies");

        // private void Map()
        // {
        //     BsonClassMap.RegisterClassMap<User>(cm =>
        //     {
        //         cm.AutoMap();
        //     });
        // }
    }
}