using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using DataAccess;

namespace NFLPicker
{
    public class Entity : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
