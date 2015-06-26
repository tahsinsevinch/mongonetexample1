using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Conn;
using MongoDB.Driver.Builders;

namespace DAL.Service
{
    public class GameService:EntityService<Game>
    {
        public IEnumerable<Game> List(int limit, int skip)
        {
            var data = this.MongoCollectionHandler.MongoCollection.FindAllAs<Game>()
                .SetSortOrder(SortBy<Game>.Descending(m => m.ReleaseDate))
                .SetLimit(limit)
                .SetSkip(skip)
                .SetFields(Fields<Game>.Include(m => m.Id, m => m.Name, m => m.ReleaseDate));
            return data;
        }

        public override void Update(Game Entity)
        {
            throw new NotImplementedException();
        }
    }
}
