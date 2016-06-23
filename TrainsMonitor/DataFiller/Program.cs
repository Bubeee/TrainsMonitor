using System;
using System.Configuration;
using System.Diagnostics;
using Ninject;
using Ninject.Modules;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Factories;
using TrainsMonitor.Repository.MSSQL.Repositories;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

namespace DataFiller
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new MyNinjectModule());
            var repo = kernel.Get<TrainsDataRepository>();
            var rand = new Random(DateTime.Now.DayOfYear * 121 - 111);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                var entity = GetEntity(i, rand);
                repo.Save(entity);
                Console.WriteLine("Elapsed = {0}, Record No = {1}", sw.Elapsed, i);
            }

            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadKey();
        }

        private static TrainDataEntity GetEntity(int packNumber, Random rand)
        {
            return new TrainDataEntity
            {
                MeasurementDateTime = DateTime.Now,

                PackageNumber = packNumber,
                SystemSerialNumber = rand.Next(1, 30),
                ProviderName = "Velcom.by",
                IsSystemWorking = true,
                EnvironmentTemperature = rand.Next(-20, 40),
                Radiator1Temperature = rand.Next(10, 1510) / 10,
                Radiator2Temperature = rand.Next(10, 1510) / 10,
                FootstepTemperature = rand.Next(10, 1510) / 10,
                TurbineTemperature = rand.Next(10, 1510) / 10,
                OilTemperature = rand.Next(10, 1510) / 10,
                TransformatorTemperature = rand.Next(10, 1510) / 10,
                CabinTemperature = rand.Next(10, 300) / 10,
                VoltageAkb = rand.Next(220, 2200) / 10,
                Heater1FuelConsumption = rand.Next(10, 150) / 10,
                Heater2FuelConsumption = rand.Next(10, 150) / 10,
                AirHeaterFuelConsumption = rand.Next(10, 150) / 10,

                Heater1Flags = rand.Next(10, 150) / 10,
                Heater2Flags = rand.Next(10, 150) / 10,
                AirHeaterFlags = rand.Next(10, 150) / 10,

                SystemFlags = (byte)rand.Next(1, 256)
            };
        }
    }

    public class MyNinjectModule : NinjectModule
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
