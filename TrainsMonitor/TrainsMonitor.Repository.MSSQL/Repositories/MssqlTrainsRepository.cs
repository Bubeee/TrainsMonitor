using System.Collections.Generic;
using System.Linq;
using Dapper;
using Ninject;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Factories;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

namespace TrainsMonitor.Repository.MSSQL.Repositories
{
    public class MssqlTrainsRepository : IRepository<TrainDataEntity>
    {
        [Inject]
        public IDbConnectionFactory DbConnectionFactory { get; set; }
        private readonly IRepository<SystemData> _systemDataRepository;
        private readonly IRepository<Temperatures> _temperaturesRepository;
        private readonly IRepository<Flags> _flagsRepository;
        private readonly IRepository<FuelConsumptions> _fuelConsumptionsRepository;
        private readonly IRepository<Coordinates> _coordinatesRepository;

        public MssqlTrainsRepository(
            IRepository<SystemData> systemDataRepository,
            IRepository<Coordinates> coordinatesRepository,
            IRepository<FuelConsumptions> fuelConsumptionsRepository,
            IRepository<Flags> flagsRepository,
            IRepository<Temperatures> temperaturesRepository)
        {
            _systemDataRepository = systemDataRepository;
            _coordinatesRepository = coordinatesRepository;
            _fuelConsumptionsRepository = fuelConsumptionsRepository;
            _flagsRepository = flagsRepository;
            _temperaturesRepository = temperaturesRepository;
        }

        public IEnumerable<TrainDataEntity> GetAll()
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                var query = "SELECT * FROM [dbo].[SystemData] AS [SD] " +
                            "INNER JOIN [Temperatures] AS [T] ON [SD].[Id] = [T].[RecordId] " +
                            "INNER JOIN [Flags] AS [F] ON [SD].[Id] = [F].[RecordId] " +
                            "INNER JOIN [FuelConsumptions] AS [FC] ON [SD].[Id] = [FC].[RecordId] " +
                            "INNER JOIN [Coordinates] AS [C] ON [SD].[Id] = [C].[RecordId]";

                return dbConnection.Query<TrainDataEntity>(query);
            }
        }

        public int Save(TrainDataEntity entity)
        {
            var systemDataModel = new SystemData
            {
                SystemSerialNumber = entity.SystemSerialNumber,
                ProviderName = entity.ProviderName,
                PackageNumber = entity.PackageNumber,
                IsSystemWorking = entity.IsSystemWorking,
                MeasurementDateTime = entity.MeasurementDateTime,
                VoltageAkb = entity.VoltageAkb
            };

            entity.Id = _systemDataRepository.Save(systemDataModel);

            var temperatureModel = new Temperatures
            {
                RecordId = entity.Id,
                Radiator1Temperature = entity.Radiator1Temperature,
                Radiator2Temperature = entity.Radiator2Temperature,
                TransformatorTemperature = entity.TransformatorTemperature,
                TurbineTemperature = entity.TurbineTemperature,
                EnvironmentTemperature = entity.EnvironmentTemperature,
                OilTemperature = entity.OilTemperature,
                FootstepTemperature = entity.FootstepTemperature,
                CabinTemperature = entity.CabinTemperature
            };

            var flagsModel = new Flags
            {
                RecordId = entity.Id,
                Heater1Flags = entity.Heater1Flags,
                Heater2Flags = entity.Heater2Flags,
                AirHeaterFlags = entity.AirHeaterFlags,
                SystemFlags = entity.SystemFlags
            };

            var fuelConsumptionModel = new FuelConsumptions
            {
                RecordId = entity.Id,
                AirHeaterFuelConsumption = entity.AirHeaterFuelConsumption,
                Heater1FuelConsumption = entity.Heater1FuelConsumption,
                Heater2FuelConsumption = entity.Heater2FuelConsumption
            };

            var coordinatesModel = new Coordinates
            {
                RecordId = entity.Id,
                Latitude = 55.6620945,
                Longtitude = 38.3203129
            };

            _temperaturesRepository.Save(temperatureModel);
            _flagsRepository.Save(flagsModel);
            _fuelConsumptionsRepository.Save(fuelConsumptionModel);
            _coordinatesRepository.Save(coordinatesModel);

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
                var query = "SELECT * FROM[dbo].[SystemData] AS [SD] " +
                            "INNER JOIN [Temperatures] AS [T] ON [SD].[Id] = [T].[RecordId] " +
                            "INNER JOIN [Flags] AS [F] ON [SD].[Id] = [F].[RecordId] " +
                            "INNER JOIN [FuelConsumptions] AS [FC] ON [SD].[Id] = [FC].[RecordId] " +
                            "INNER JOIN [Coordinates] AS [C] ON [SD].[Id] = [C].[RecordId]" +
                            "WHERE [SD].[Id] = @id";

                return dbConnection.Query<TrainDataEntity>(query, id).FirstOrDefault();
            }
        }
    }
}