using System;
using MongoDB.Bson;

namespace DAL.Entities
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
