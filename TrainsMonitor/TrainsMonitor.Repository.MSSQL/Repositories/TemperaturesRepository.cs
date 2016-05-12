using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Ninject;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Factories;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

namespace TrainsMonitor.Repository.MSSQL.Repositories
{
    public class TemperaturesRepository : IRepository<Temperatures>
    {
        [Inject]
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public IEnumerable<Temperatures> GetAll()
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                return dbConnection.Query<Temperatures>("Select * From [dbo].[Temperatures]");
            }
        }

        public int Save(Temperatures entity)
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                const string columnNames = "[EnvironmentTemperature], [Radiator1Temperature], [Radiator2Temperature], [FootstepTemperature], [TurbineTemperature], [OilTemperature], [TransformatorTemperature], [CabinTemperature], [RecordId]";

                const string values = "@EnvironmentTemperature, @Radiator1Temperature, @Radiator2Temperature, @FootstepTemperature, @TurbineTemperature, @OilTemperature, @TransformatorTemperature, @CabinTemperature, @RecordId";

                entity.Id = dbConnection.Query<int>(@"insert [dbo].[Temperatures] (" + columnNames + ") " +
                                                    "values (" + values + ") " +
                                                    "select cast(scope_identity() as int)", entity).First();
            }

            return entity.Id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Temperatures entity)
        {
            throw new NotImplementedException();
        }
    }
}
