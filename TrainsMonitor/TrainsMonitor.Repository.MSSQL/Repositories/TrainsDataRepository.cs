using System.Collections.Generic;
using System.Linq;
using Dapper;
using Ninject;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Factories;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

namespace TrainsMonitor.Repository.MSSQL.Repositories
{
    public class TrainsDataRepository : IRepository<TrainDataEntity>
    {
        [Inject]
        public IDbConnectionFactory DbConnectionFactory { get; set; }
        
        public IEnumerable<TrainDataEntity> GetAll()
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                var query = "SELECT * FROM [dbo].[TrainData]";

                return dbConnection.Query<TrainDataEntity>(query);
            }
        }

        public int Save(TrainDataEntity entity)
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                const string columnNames = "[PackageNumber], [SystemSerialNumber], [ProviderName], [IsSystemWorking], [MeasurementDateTime], [EnvironmentTemperature], [Radiator1Temperature], [Radiator2Temperature], [FootstepTemperature], [TurbineTemperature], [OilTemperature], [TransformatorTemperature], [CabinTemperature], [VoltageAKB], [Heater1FuelConsumption], [Heater2FuelConsumption], [AirHeaterFuelConsumption], [Heater1Flags], [Heater2Flags], [AirHeaterFlags], [SystemFlags], [Latitude], [Longtitude]";

                const string values = "@PackageNumber, @SystemSerialNumber, @ProviderName, @IsSystemWorking, @MeasurementDateTime, @EnvironmentTemperature, @Radiator1Temperature, @Radiator2Temperature, @FootstepTemperature, @TurbineTemperature, @OilTemperature, @TransformatorTemperature, @CabinTemperature, @VoltageAkb, @Heater1FuelConsumption, @Heater2FuelConsumption, @AirHeaterFuelConsumption, @Heater1Flags, @Heater2Flags, @AirHeaterFlags, @SystemFlags, @Latitude, @Longtitude";

                entity.Id = dbConnection.Query<int>(@"insert [dbo].[TrainData] (" + columnNames + ") " +
                                                    "values (" + values + ") " +
                                                    "select cast(scope_identity() as int)", entity).First();
            }

            return entity.Id;
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(TrainDataEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public TrainDataEntity GetByRecordId(int id)
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                var query = "SELECT * FROM [dbo].[TrainData]" +
                            "WHERE [Id] = @id";

                return dbConnection.Query<TrainDataEntity>(query, id).FirstOrDefault();
            }
        }
    }
}