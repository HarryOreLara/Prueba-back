using back_prueba.Gestores.Auth;
using back_prueba.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace back_prueba.Controllers.Auth
{
    public class AuthController : ApiController
    {
        // GET: api/Auth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auth
        public bool Post([FromBody]Usuario usuario)
        {
            GestorAuth gestorAuth = new GestorAuth();
            return gestorAuth.Add_Usuario(usuario);
        }

        // PUT: api/Auth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auth/5
        public void Delete(int id)
        {
        }
    }
}
