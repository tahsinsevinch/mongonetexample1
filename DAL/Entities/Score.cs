using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DAL.Entities
{
    [BsonIgnoreExtraElements]
    public class Score:MongoEntity
    {
        public ObjectId GameId { get; set; }
        public string GameName { get; set; }
        public int ScoreValue { get; set; }
        public DateTime ScoreDateTime { get; set; }
    }
}
