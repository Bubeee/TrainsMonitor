using System.Collections.Generic;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

namespace TrainsMonitor.BLL
{
    public class TrainsEntitiesManager<T> : IEntitiesManager<T> where T : Entity
    {
        public IRepository<T> Repository { get; set; }

        public IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public void Save(T entity)
        {
            Repository.Save(entity);
        }
    }
}