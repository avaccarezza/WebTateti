using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcVistaWeb.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public int puntaje { get; set; }
        public int partidas_ganadas { get; set; }
        public int partidas_jugadas { get; set; }

        public Usuario(int id,string usuario, string contrasena, int puntaje, int partidas_ganadas, int partidas_jugadas)
        {
            this.id = id;
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.puntaje = puntaje;
            this.partidas_ganadas = partidas_ganadas;
            this.partidas_jugadas = partidas_jugadas;
        }



    }
}
