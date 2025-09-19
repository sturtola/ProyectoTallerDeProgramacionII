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
            // Verificar que no exista el DNI en la BD
            if (datos.ExisteDni(u.DNI))
                throw new Exception("El DNI ya está registrado.");

            // Reglas de negocio adicionales (por ej. validar fortaleza de contraseña) pueden ir aquí
            datos.Insertar(u);
        }
    }
}
