﻿using System.Collections.Generic;
using System.Web.Http;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

namespace TrainsMonitor.Controllers
{
    public class SystemDataController : ApiController
    {
        private readonly IRepository<SystemData> _repository;

        public SystemDataController(IRepository<SystemData> repository)
        {
            _repository = repository;
        }

        // GET api/<controller>
        public IEnumerable<SystemData> Get()
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