using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AurenPadelStore.CDatos
{
    public static class Conexion
    {
        // Ajusta la cadena según tu instancia/BD
        private static string ObtenerConexioncadena =
            "Server=DESKTOP-1HCDQL3;Database=AurenPadelBD;Encrypt=False;TrustServerCertificate=True;Trusted_Connection=True;";

        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(ObtenerConexioncadena);
        }
    }
}
