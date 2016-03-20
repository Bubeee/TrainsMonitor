using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainsMonitor.Controllers
{
    public class TrainsController : ApiController
    {
        // GET: api/Trains
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "World!", "Motherfucker!", "Ahahahah!" };
        }

        // GET: api/Trains/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Trains
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Trains/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Trains/5
        public void Delete(int id)
        {
        }
    }
}
