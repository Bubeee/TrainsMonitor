using System.Data;

namespace TrainsMonitor.Repository.MSSQL.Factories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}