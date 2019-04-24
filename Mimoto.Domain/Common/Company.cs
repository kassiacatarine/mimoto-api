using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mimoto.Domain.Common
{
    public class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
    }
}