using Microsoft.AspNetCore.Mvc;
using mvcVistaWeb.DAOs;
using mvcVistaWeb.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcVistaWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {

            var usuarios = UsuarioDAO.getInstancia().verPersonas();
            return Content(JsonConvert.SerializeObject(usuarios),"application/json");

        }

        // GET api/<controller>/5
        [HttpGet("{usuario}")]
        public ActionResult Get(string usuario)
        {
            var personas = UsuarioDAO.getInstancia().getUsuarioByUsuario(usuario);

            return Content(JsonConvert.SerializeObject(personas),"application/json");
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Usuario usuario)
        {

            UsuarioDAO.getInstancia().add(usuario);

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Usuario usuario)
        {

            UsuarioDAO.getInstancia().reemplazarUsuario(id, usuario);

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            UsuarioDAO.getInstancia().eliminarUsuario(id);
            //return JsonConvert.SerializeObject(personas);

        }
    }
}
