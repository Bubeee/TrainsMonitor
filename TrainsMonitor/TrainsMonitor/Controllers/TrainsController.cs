using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainsMonitor.Models;

namespace TrainsMonitor.Controllers
{
    public class TrainsController : ApiController
    {
        // GET: api/Trains
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "World!", "Motherfucker!", "Ahahahah!", "piypiy" };
        }

        // GET: api/Trains/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Trains
        public HttpResponseMessage Post([FromBody]string value)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, new ResponseModel
            {
                Message = "Everithing is fine ^_^"
            });

            return response;
        }
    }
}
                                    