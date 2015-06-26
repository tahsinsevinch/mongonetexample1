using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DAL.Entities
{
    [BsonIgnoreExtraElements]
    public class Player:MongoEntity
    {
        public Player()
        {
            Scores = new List<Score>();
        }
        public string Name { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Gender Gender { get; set; }
        public List<Score> Scores { get; set; }
    }
}
