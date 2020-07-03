using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using mvcVistaWeb.Models;

namespace mvcVistaWeb.DAOs
{
    public class UsuarioDAO
    {

        public static UsuarioDAO instancia = null;
        public List<Usuario> usuarios = new List<Usuario>();

        private UsuarioDAO() {

            usuarios.Add(new Usuario(1, "pepito@gmail.com", "1234", 1000,0,0));
            usuarios.Add(new Usuario(2, "juan_hernesto@yahoo.com", "1234", 1000,0,0));
            usuarios.Add(new Usuario(3, "admin@admin.com", "admin", 1000,0, 0));
       
        }

        public static UsuarioDAO getInstancia() { 
        
            if(instancia == null){
                instancia = new UsuarioDAO();
            }

            return instancia;

        }

        public UsuarioDAO add(Usuario user)
        {
            if (validarRegistro(user))
            {
                usuarios.Add(user);
            }
            return this;

        }
        public bool validarRegistro(Usuario usuario)
        {
            bool valida = true;
            foreach (var user in usuarios)
            {
                if (user.usuario == usuario.usuario)
                {
                    return false;
                }
            }
            return valida;

        }

        public Usuario getUsuarioByUsuario(string usuario)
        {
            return usuarios.Find(x => x.usuario == usuario);
        }

        public List<Usuario> verPersonas()
        {
            return usuarios;
        }
        public void eliminarUsuario(int id)
        {
            usuarios.RemoveAll(x => x.id == id);
        }
        public void reemplazarUsuario(int id,Usuario usuario)
        {
            this.eliminarUsuario(id);
            this.add(usuario);
        }
        public int largoLista()
        {
            return usuarios.Count;
        }

    }


}
