using System.Collections.Generic;
using System.Linq;
using Dapper;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Factories;

namespace TrainsMonitor.Repository.MSSQL.Repositories
{
    public class MssqlTrainsRepository : IRepository<TrainDataEntity>
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public MssqlTrainsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public IEnumerable<TrainDataEntity> GetAll()
        {
            using (var dbConnection = _dbConnectionFactory.CreateConnection())
            {
                return dbConnection.Query<TrainDataEntity>("Select * From [dbo.TrainData]").AsQueryable();
                
            }
        }

        public bool Save(TrainDataEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(TrainDataEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
