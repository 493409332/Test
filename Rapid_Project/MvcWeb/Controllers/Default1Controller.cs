using Complex.Entity;
using Complex.Logical.ILogical;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcWeb.Controllers
{
    public class Default1Controller : ApiController
    {
        // GET api/default1
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Dependency("Login")]
        public ILogin Login { get; set; }
        // GET api/default1/5
        public string Get(int id)
        {
          //  Login.IsLogin(new test2());
            return "value";
        }

        // POST api/default1
        public void Post([FromBody]string value)
        {
        }

        // PUT api/default1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/default1/5
        public void Delete(int id)
        {
        }
    }
}
