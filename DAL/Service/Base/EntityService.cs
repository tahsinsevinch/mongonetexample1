using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using DAL.Entities;
using DAL.Conn;

namespace DAL.Service
{
    public abstract class EntityService<T>:IEntityService<T> where T:IMongoEntity
    {
        protected readonly MongoCollectionHandler<T> MongoCollectionHandler;
        protected EntityService()
        {
            MongoCollectionHandler = new MongoCollectionHandler<T>();
        }

        public virtual void Create(T Entity)
        {
            var result = this.MongoCollectionHandler.MongoCollection.Save(Entity, new MongoInsertOptions
            {
                WriteConcern = WriteConcern.Acknowledged
            });
            if (result.HasLastErrorMessage)
            {
            }
        }

        public virtual void Delete(string id)
        {
            var result = this.MongoCollectionHandler.MongoCollection.Remove(Query<T>.EQ(e => e.Id, new ObjectId(id)), RemoveFlags.None, WriteConcern.Acknowledged);
            if (result.HasLastErrorMessage)
            {

            }
        }

        public virtual T GetById(string id)
        {
            var entityQuery = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return this.MongoCollectionHandler.MongoCollection.FindOne(entityQuery);
        }

        public abstract void Update(T Entity);
    }
}
