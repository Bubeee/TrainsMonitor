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
    public class FuelConsumptionsRepository : IRepository<FuelConsumptions>
    {
        [Inject]
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public IEnumerable<FuelConsumptions> GetAll()
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                return dbConnection.Query<FuelConsumptions>("Select * From [dbo].[FuelConsumptions]");
            }
        }

        public int Save(FuelConsumptions entity)
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                const string columnNames = "[Heater1FuelConsumption], [Heater2FuelConsumption], [AirHeaterFuelConsumption], [RecordId]";

                const string values = "@Heater1FuelConsumption, @Heater2FuelConsumption, @AirHeaterFuelConsumption, @RecordId";
                entity.Id = dbConnection.Query<int>(@"insert [dbo].[FuelConsumptions] (" + columnNames + ") " +
                                                    "values (" + values + ") " +
                                                    "select cast(scope_identity() as int)", entity).First();
            }

            return entity.Id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(FuelConsumptions entity)
        {
            throw new NotImplementedException();
        }
    }
}
