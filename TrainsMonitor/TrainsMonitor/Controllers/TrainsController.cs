using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainsMonitor.Models;
using TrainsMonitor.Repository.MSSQL;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Repositories;

namespace TrainsMonitor.Controllers
{
    public class TrainsController : ApiController
    {
        private readonly IRepository<TrainDataEntity> _repository;

        public TrainsController(IRepository<TrainDataEntity> repository)
        {
            _repository = repository;
        }

        // GET: api/Trains
        public IEnumerable<TrainDataEntity> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Trains/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Trains
        public HttpResponseMessage Post([FromBody]RequestModel data)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, new ResponseModel
            {
                Message = "Successful received" + data.Data
            });

            return response;
        }
    }
}
                                    