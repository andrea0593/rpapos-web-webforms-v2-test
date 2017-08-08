using rpapos_web_webforms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rpapos_web_webforms
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public UnidadMedida Get()
        {
             
            var u = new UnidadMedida();
            u.Descripcion = "caca";
            u.Simbolo = "m";
            return u;
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