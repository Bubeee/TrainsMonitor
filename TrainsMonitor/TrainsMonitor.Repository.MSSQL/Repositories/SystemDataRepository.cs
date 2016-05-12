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
    public class SystemDataRepository : IRepository<SystemData>
    {
        [Inject]
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public IEnumerable<SystemData> GetAll()
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                return dbConnection.Query<SystemData>("Select * From [dbo].[SystemData]");
            }
        }

        public int Save(SystemData entity)
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                const string columnNames =
                    "[PackageNumber],[SystemSerialNumber],[ProviderName],[IsSystemWorking],[MeasurementDateTime],[VoltageAKB]";

                const string values =
                    "@PackageNumber, @SystemSerialNumber, @ProviderName, @IsSystemWorking, @MeasurementDateTime, @VoltageAkb";

                entity.Id = dbConnection.Query<int>(@"insert [dbo].[SystemData] (" + columnNames + ") " +
                                                    "values (" + values + ") " +
                                                    "select cast(scope_identity() as int)", entity).First();
            }

            return entity.Id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SystemData entity)
        {
            throw new NotImplementedException();
        }
    }
}
