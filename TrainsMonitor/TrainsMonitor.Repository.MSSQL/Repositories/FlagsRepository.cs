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
    public class FlagsRepository : IRepository<Flags>
    {
        [Inject]
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public IEnumerable<Flags> GetAll()
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                return dbConnection.Query<Flags>("Select * From [dbo].[Flags]");
            }
        }

        public int Save(Flags entity)
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                const string columnNames = "[Heater1Flags], [Heater2Flags], [AirHeaterFlags], [SystemFlags], [RecordId]";

                const string values = "@Heater1Flags, @Heater2Flags, @AirHeaterFlags, @SystemFlags, @RecordId";

                entity.Id = dbConnection.Query<int>(@"insert [dbo].[Flags] (" + columnNames + ") " +
                                                    "values (" + values + ") " +
                                                    "select cast(scope_identity() as int)", entity).First();
            }

            return entity.Id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Flags entity)
        {
            throw new NotImplementedException();
        }
    }
}
