using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainsMonitor.Helpers;
using TrainsMonitor.Models;
using TrainsMonitor.Repository.MSSQL.Entities;
using TrainsMonitor.Repository.MSSQL.Repositories.Interfaces;

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
            // Достать из зарпоса контент
            var content = Request.Content;
            // Разделить контент на 2 части
            var contentStrings = content.ReadAsStringAsync().Result.Split('=');

            // Создать модель данных
            TrainDataEntity model = new TrainDataEntity();
            var newId = -1;
            ushort serverCrc;

            // Попробовать разобрать контент и преобразовать в объект
            try
            {
                model = ParameterParser.GetDataModelFromInputString(
                    contentStrings[0].Substring(4),
                    contentStrings[1], out serverCrc);

                // Если CRC совпадает - сохранить данные в базу
                if (serverCrc == model.CrcData)
                {
                    newId = _repository.Save(model);
                }
            }
            catch (Exception exception)
            {
                serverCrc = 0;
            }

            // Отправить ответ источнику запроса
            var response = Request.CreateResponse(HttpStatusCode.OK, new ResponseModel
            {
                Message = $"Is successful received: {newId != -1}; computed CRC: {serverCrc}; actual CRC: {model.CrcData}; new Id is: {newId}"
            });

            return response;
        }
    }
}
