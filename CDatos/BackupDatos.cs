using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace AurenPadelStore.CDatos
{
    public class BackupDatos
    {
        private const string NOMBRE_BD = "AurenPadelBD";

        /// <summary>
        /// Ejecuta BACKUP DATABASE hacia el archivo indicado (.bak).
        /// </summary>
        public void HacerBackup(string rutaArchivoBak)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivoBak))
                throw new ArgumentException("Ruta de backup inválida.");

            // Escapar comillas simples en la ruta por seguridad T-SQL
            var rutaSql = rutaArchivoBak.Replace("'", "''");

            var tsql = $@"
USE master;
BACKUP DATABASE [{NOMBRE_BD}]
TO DISK = N'{rutaSql}'
WITH COPY_ONLY, INIT, STATS = 10;
";

            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(tsql, cn)
            {
                CommandType = CommandType.Text,
                // Por si el backup tarda (archivos grandes)
                CommandTimeout = 60 * 10 // 10 minutos
            };

            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
