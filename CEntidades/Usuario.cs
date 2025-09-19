using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenPadelStore.CEntidades
{
    public class Usuario
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }

        // Constructor vacío
        public Usuario() { }

        public Usuario(string dni, string nombre, string apellido, string contrasena, string rol)
        {
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;
            Contrasena = contrasena;
            Rol = rol;
        }
    }
}
