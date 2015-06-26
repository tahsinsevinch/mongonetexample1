using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Service
{
    public interface IEntityService<T> where T:IMongoEntity
    {
        void Create(T Entity);
        void Delete(string id);
        T GetById(string id);
        void Update(T Entity);
    }
}
