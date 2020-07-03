using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcVistaWeb.DAOs;
using mvcVistaWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace mvcVistaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarUsuarioSinAjax(IFormCollection form)
        {

            // Creo vista a devolver
            ViewResult vista = View("Index");

            // Obtengo id traido del form
            var usuario = form["usuarioIdSinAjax"].ToString();

            // Busco usuario en DAO
            Usuario user = UsuarioDAO.getInstancia().getUsuarioByUsuario(usuario);
            vista.ViewData.Add("usuario", user);

            return vista;

        }
        
        [HttpPost]
        public JsonResult BuscarUsuarioConAjax([FromBody] JsonUsuario jsonUsuario)
        {

            // Busco usuario en DAO
            Usuario user = UsuarioDAO.getInstancia().getUsuarioByUsuario(jsonUsuario.usuario);

            var jsonResult = JsonConvert.SerializeObject(user);

            return Json(jsonResult);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public class JsonUsuario {
            public int id { get; set; }
            public string usuario { get; set; }
            public string contrasena { get; set; }
            public int puntaje { get; set; }
            public int partidasJugadas { get; set; }

            public int partidasGanadas { get; set; }
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(IFormCollection form)
        {
            ViewResult vista = View("Index");

            var usuario = Convert.ToString(form["usuario"]);
            var contrasena = Convert.ToString(form["contrasena"]);

            Usuario user = new Usuario(UsuarioDAO.getInstancia().largoLista()+1, usuario,contrasena,1000,0,0);

            UsuarioDAO.getInstancia().add(user);

            return vista;
        }
      
       
    }
}
