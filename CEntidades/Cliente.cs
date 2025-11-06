using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenPadelStore.CEntidades
{
    public class Cliente
    {
        public int id_Cliente { get; set; }
        public int Dni_Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Apellido_Cliente { get; set; }
        public string Direccion_Cliente { get; set; }
        public string Correo_Cliente { get; set; } // Admite nulos
        public string Telefono_Cliente { get; set; }
        public bool Estado_Cliente { get; set; } = true;

        // Propiedad para mostrar el nombre completo fácilmente
        public string NombreCompleto => $"{Apellido_Cliente}, {Nombre_Cliente}";

        // NUEVO: útil para búsqueda por texto en el combo
        public string Documento_Cliente => Dni_Cliente.ToString();

        // NUEVO: string “lindo” para DisplayMember del combo
        public string Mostrar =>
            $"{Apellido_Cliente}, {Nombre_Cliente} - {Documento_Cliente} (ID:{id_Cliente})";
    }
}