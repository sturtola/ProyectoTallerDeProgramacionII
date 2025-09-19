using System;
using AurenPadelStore.CEntidades;
using AurenPadelStore.CDatos;

namespace AurenPadelStore.CLogica
{
    public class UsuarioLogica
    {
        private readonly UsuarioDatos datos = new UsuarioDatos();

        public void RegistrarUsuario(Usuario u)
        {
            // Verificar que no exista el DNI en BD
            if (datos.ExisteDni(u.DNI))
                throw new Exception("El DNI ya está registrado.");

            // Aquí podrías agregar más reglas de negocio (password segura, etc.)
            datos.Insertar(u);
        }
    }
}
