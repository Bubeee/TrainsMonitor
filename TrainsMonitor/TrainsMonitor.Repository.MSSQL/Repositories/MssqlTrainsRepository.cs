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
                return dbConnection.Query<TrainDataEntity>("Select * From [dbo].[TrainData]");
            }
        }

        public int Save(TrainDataEntity entity)
        {
            using (var dbConnection = _dbConnectionFactory.CreateConnection())
            {
                //    return dbConnection.Execute("INSERT INTO [dbo].[TrainData] " +
                //                                     "()");
                const string columnNames = "[PackageNumber], [SystemSerialNumber], [ProviderName], [IsSystemWorking], [DateTime], [EnvironmentTemperature], [Radiator1Temperature], [Radiator2Temperature], [FootstepTemperature], [TurbineTemperature], [OilTemperature], [TransformatorTemperature], [CabinTemperature], [Voltage], [Heater1FuelConsumption], [Heater2FuelConsumption], [AirHeaterFuelConsumption], [Heater1Flags], [Heater2Flags], [AirHeaterFlags], [SystemFlags]";

                const string values = "@PackageNumber, @SystemSerialNumber, @ProviderName, @IsSystemWorking, @DateTime, @EnvironmentTemperature, @Radiator1Temperature, @Radiator2Temperature, @FootstepTemperature, @TurbineTemperature, @OilTemperature, @TransformatorTemperature, @CabinTemperature, @Voltage, @Heater1FuelConsumption, @Heater2FuelConsumption, @AirHeaterFuelConsumption, @Heater1Flags, @Heater2Flags, @AirHeaterFlags, @SystemFlags";

                entity.Id = dbConnection.Query<int>(@"insert [dbo].[TrainData] (" + columnNames + ") " +
                                                    "values (" + values + ") " +
                                                    "select cast(scope_identity() as int)", new
                                                    {
                                                        entity.PackageNumber,
                                                        entity.SystemSerialNumber,
                                                        entity.ProviderName,
                                                        entity.IsSystemWorking,
                                                        entity.DateTime,
                                                        entity.EnvironmentTemperature,
                                                        entity.Radiator1Temperature,
                                                        entity.Radiator2Temperature,
                                                        entity.FootstepTemperature,
                                                        entity.TurbineTemperature,
                                                        entity.OilTemperature,
                                                        entity.TransformatorTemperature,
                                                        entity.CabinTemperature,
                                                        entity.Voltage,
                                                        entity.Heater1FuelConsumption,
                                                        entity.Heater2FuelConsumption,
                                                        entity.AirHeaterFuelConsumption,
                                                        entity.Heater1Flags,
                                                        entity.Heater2Flags,
                                                        entity.AirHeaterFlags,
                                                        entity.SystemFlags
                                                    }).First();

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
    }
}
