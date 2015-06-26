using DAL.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Conn
{
    //public class Conn
    //{
    //    private MongoDatabase db;
    //    public MongoDatabase Database
    //    {
    //        get
    //        {
    //            if (db == null)
    //            {
    //                string connectionString = "mongodb://localhost:27017";
    //                MongoClient client = new MongoClient(connectionString);
    //                MongoServer server = client.GetServer();
    //                MongoDatabase database = server.GetDatabase("MongoTestDB");
    //                db = database;
    //            }
    //            return db;
    //        }
    //    } 
    //}

    public class MongoCollectionHandler<T> where T : IMongoEntity
    {
        public MongoCollection<T> MongoCollection { get; private set; }
        public MongoCollectionHandler()
        {
            const string connectionstring = "mongodb://localhost";
            const string databaseName = "MongoTestDB";

            var mongoClient = new MongoClient(connectionstring);
            var mongoserver = mongoClient.GetServer();
            var db = mongoserver.GetDatabase(databaseName);
            MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower());
        }
    }
}
