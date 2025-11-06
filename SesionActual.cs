using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Corregido: Movido al namespace de Entidades para consistencia
namespace AurenPadelStore.CEntidades
{
    public static class SesionActual
    {
        public static int Id_UsuarioActual { get; set; }
        public static string NombreCompleto { get; set; } = string.Empty;
        public static string Rol { get; set; } = string.Empty;

        // Método para limpiar la sesión al cerrar
        public static void CerrarSesion()
        {
            Id_UsuarioActual = 0;
            NombreCompleto = string.Empty;
            Rol = string.Empty;
        }
    }
}