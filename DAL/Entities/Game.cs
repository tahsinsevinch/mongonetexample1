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
    public class Game:MongoEntity
    {
        public Game()
        {
            Categories = new List<string>();
        }
        public string Name { get; set; }
        [BsonDateTimeOptions(DateOnly=true)]
        public DateTime ReleaseDate { get; set; }
        public List<string> Categories { get; set; }
        public bool Played { get; set; }
    }
}
