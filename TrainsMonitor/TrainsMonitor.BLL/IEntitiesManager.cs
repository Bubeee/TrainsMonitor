using System.Collections.Generic;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

namespace TrainsMonitor.BLL
{
    public interface IEntitiesManager<T> where T : Entity
    {
        IRepository<T> Repository { get; set; }

        IEnumerable<T> GetAll();

        void Save(T entity);
    }
}