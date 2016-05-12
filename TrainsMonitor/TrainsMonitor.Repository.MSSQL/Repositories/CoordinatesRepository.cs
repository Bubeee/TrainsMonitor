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
    public class CoordinatesRepository : IRepository<Coordinates>
    {
        [Inject]
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        public IEnumerable<Coordinates> GetAll()
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                return dbConnection.Query<Coordinates>("Select * From [dbo].[Coordinates]");
            }
        }

        public int Save(Coordinates entity)
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                const string columnNames = "[Latitude], [Longtitude], [RecordId]";

                const string values = "@Latitude, @Longtitude, @RecordId";

                entity.Id = dbConnection.Query<int>(@"insert [dbo].[Coordinates] (" + columnNames + ") " +
                                                    "values (" + values + ") " +
                                                    "select cast(scope_identity() as int)", entity).First();
            }

            return entity.Id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Coordinates entity)
        {
            throw new NotImplementedException();
        }

        public Coordinates GetByRecordId(int id)
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                var query = "SELECT * FROM [Coordinates] WHERE [RecordId] = @id";
                return dbConnection.Query<Coordinates>(query, id).FirstOrDefault();
            }
        }
    }
}
