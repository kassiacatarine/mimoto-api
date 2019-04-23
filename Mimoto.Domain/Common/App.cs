using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mimoto.Domain.Common
{
    public class App
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("alias")]
        public string Alias { get; set; }
    }
}