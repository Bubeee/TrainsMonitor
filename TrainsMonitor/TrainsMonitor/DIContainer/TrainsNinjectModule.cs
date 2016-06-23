using System.Configuration;
using Ninject.Modules;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Factories;
using TrainsMonitor.Repository.MSSQL.Repositories;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

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

            Bind<IRepository<TrainDataEntity>>().To<TrainsDataRepository>();
        }
    }
}