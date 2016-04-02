using System.Collections.Generic;

namespace TrainsMonitor.Repository.MSSQL.Repositories
{
    public interface IRepository<T> where T : new()
    {
        IEnumerable<T> GetAll();
        int Save(T entity);
        bool Delete(int id);
        bool Delete(T entity);
    }
}
