using System.Collections.Generic;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Factories;

namespace TrainsMonitor.Repository.MSSQL.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IDbConnectionFactory DbConnectionFactory { get; set; }
        IEnumerable<T> GetAll();
        int Save(T entity);
        bool Delete(int id);
        bool Delete(T entity);
    }
}