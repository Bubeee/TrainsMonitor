using System.Configuration;
using Ninject.Modules;
using TrainsMonitor.Repository.MSSQL;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Factories;
using TrainsMonitor.Repository.MSSQL.Repositories;

namespace TrainsMonitor.DIContainer
{
    public class TrainsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbConnectionFactory>()
                .To<SqlConnectionFactory>()
                .WithConstructorArgument("connectionString",
                    ConfigurationManager.ConnectionStrings["azureSqlConnectionString"].ConnectionString);

            Bind<IRepository<TrainDataEntity>>().To<MssqlTrainsRepository>();
        }
    }
}