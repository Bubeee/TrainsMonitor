using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public int Save(Coordinates entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Coordinates entity)
        {
            throw new NotImplementedException();
        }
    }
}
