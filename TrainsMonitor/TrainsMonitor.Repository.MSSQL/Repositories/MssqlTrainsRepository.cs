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

        public MssqlTrainsRepository(IRepository<SystemData> systemDataRepository)
        {
            _systemDataRepository = systemDataRepository;
        }

        public IEnumerable<TrainDataEntity> GetAll()
        {
            using (var dbConnection = DbConnectionFactory.CreateConnection())
            {
                return dbConnection.Query<TrainDataEntity>("Select * From [dbo].[TrainData]");
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

            using (DbConnectionFactory.CreateConnection())
            {
                var recordId = _systemDataRepository.Save(systemDataModel);
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
