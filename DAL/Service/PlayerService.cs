using DAL.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class PlayerService: EntityService<Player>
    {
        public void AddScore(string playerId, Score score)
        {
            var oPlayerId = new ObjectId(playerId);
            var updateResult = this.MongoCollectionHandler.MongoCollection.Update(
                Query<Player>.EQ(p => p.Id, oPlayerId),
                Update<Player>.Push(p => p.Scores, score),
                new MongoUpdateOptions
                {
                    WriteConcern = WriteConcern.Acknowledged
                });
            if (updateResult.HasLastErrorMessage)
            {

            }
        }

        public IEnumerable<Player> GetPlayers(int limit,int skip)
        {
            var players = this.MongoCollectionHandler.MongoCollection.FindAllAs<Player>()
                .SetSortOrder(SortBy<Player>.Ascending(p => p.Name))
                .SetLimit(limit)
                .SetSkip(skip)
                .SetFields(Fields<Player>.Include(p => p.Id, p => p.Name));
            return players;

        }

        public override void Update(Player Entity)
        {
            var updateResult = this.MongoCollectionHandler.MongoCollection.Update(
                Query<Player>.EQ(p=>p.Id,Entity.Id),
                Update<Player>
                    .Set(p=>p.Name,Entity.Name)
                    .Set(p=>p.Gender,Entity.Gender),
                    new MongoUpdateOptions
                    {
                        WriteConcern=WriteConcern.Acknowledged
                    }
                );
            if (updateResult.DocumentsAffected == 0)
            {

            }
        }
    }
}
