using System.Collections.Generic;
using System.Web.Http;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

namespace TrainsMonitor.Controllers
{
    public class TemperaturesController : ApiController
    {
        private readonly IRepository<Temperatures> _repository;

        public TemperaturesController(IRepository<Temperatures> repository)
        {
            _repository = repository;
        }

        // GET api/<controller>
        public IEnumerable<Temperatures> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<controller>/5
        public Temperatures Get(int id)
        {
            return _repository.GetByRecordId(id);
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