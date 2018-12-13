using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreWebApp.Repositories
{
    public interface IGenericRepository <T>
    {
        bool EntityExists(string entityName);
        IEnumerable<T> GetEntities();
        T GetEntity(int entityId);
        T GetEntity(string entityName);
        void AddEntity(T entity);
        void DeleteEntity(T entity);
        void UpdateEntity(T entity);
        bool Save();
    }
}
