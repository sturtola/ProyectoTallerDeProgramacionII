using AurenPadelStore.CDatos;
using System;

namespace AurenPadelStore.CLogica
{
    public class BackupLogica
    {
        private readonly BackupDatos _datos = new BackupDatos();

        public void EjecutarBackup(string rutaArchivoBak)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivoBak))
                throw new ArgumentException("Debe seleccionar una ruta válida.");

            _datos.HacerBackup(rutaArchivoBak);
        }
    }
}
