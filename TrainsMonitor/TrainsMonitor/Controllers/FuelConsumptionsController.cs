using System.Collections.Generic;
using System.Web.Http;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

namespace TrainsMonitor.Controllers
{
    public class FuelConsumptionsController : ApiController
    {
        private readonly IRepository<FuelConsumptions> _repository;

        public FuelConsumptionsController(IRepository<FuelConsumptions> repository)
        {
            _repository = repository;
        }

        // GET api/<controller>
        public IEnumerable<FuelConsumptions> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}