using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainsMonitor.Helpers;
using TrainsMonitor.Models;
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
        public HttpResponseMessage Post()
        {
            var content = Request.Content;
            var contentStrings = content.ReadAsStringAsync().Result.Split('=');

            var model = new TrainDataEntity();
            var newId = -1;

            try
            {
                model = ParameterParser.GetDataModelFromInputString(
                    contentStrings[0].Substring(4),
                    contentStrings[1], model);

                newId = _repository.Save(model);
            }
            catch (Exception)
            {
                throw;
                model.CrcData = 0;
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, new ResponseModel
            {
                Message = $"Is successful received: {newId != -1}; CRC: {model.CrcData}",
                NewEntityId = newId,
                ComputedCrc = model.CrcData
            });

            return response;
        }
    }
}
