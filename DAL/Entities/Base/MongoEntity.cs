using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Entities
{
    public class MongoEntity:IMongoEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
