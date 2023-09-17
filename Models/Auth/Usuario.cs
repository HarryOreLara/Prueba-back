using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_prueba.Models.Auth
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Estado { get; set; }
        public DateTime Creacion { get; set; }


        public Usuario() { }

        public Usuario(int idUsuario, string username, string password, string estado, DateTime creacion)
        {
            IdUsuario = idUsuario;
            Username = username;
            Password = password;
            Estado = estado;
            Creacion = creacion;
        }


        public Usuario( string username, string password, string estado, DateTime creacion)
        {

            Username = username;
            Password = password;
            Estado = estado;
            Creacion = creacion;
        }

        public Usuario(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}