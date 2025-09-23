using System;
using System.Collections.Generic;
using AurenPadelStore.CEntidades;
using AurenPadelStore.CDatos;

namespace AurenPadelStore.CLogica
{
    public class UsuarioLogica
    {
        private readonly UsuarioDatos datos = new UsuarioDatos();

        public void RegistrarUsuario(Usuario u)
        {
            if (string.IsNullOrWhiteSpace(u.DNI) ||
                string.IsNullOrWhiteSpace(u.Nombre) ||
                string.IsNullOrWhiteSpace(u.Apellido) ||
                string.IsNullOrWhiteSpace(u.Contrasena) ||
                string.IsNullOrWhiteSpace(u.Rol))
                throw new Exception("Todos los campos son obligatorios.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(u.DNI ?? "", @"^\d{8}$"))
                throw new Exception("El DNI debe contener exactamente 8 números.");

            if (datos.ExisteDni(u.DNI))
                throw new Exception("El DNI ya está registrado.");

            datos.Insertar(u);
        }

        public void ActualizarUsuario(Usuario u, string dniOriginal)
        {
            if (string.IsNullOrWhiteSpace(dniOriginal))
                throw new Exception("DNI original inválido.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(u.DNI ?? "", @"^\d{8}$"))
                throw new Exception("El DNI debe contener exactamente 8 números.");

            // Si cambió el DNI, verificar que no exista
            if (!string.Equals(u.DNI, dniOriginal, StringComparison.Ordinal) && datos.ExisteDni(u.DNI))
                throw new Exception("El nuevo DNI ya existe.");

            datos.Actualizar(u, dniOriginal);
        }

        public void EliminarUsuario(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("DNI inválido.");
            datos.Eliminar(dni);
        }

        public List<Usuario> ListarUsuarios() => datos.ObtenerTodos();

        public Usuario ObtenerPorDni(string dni) => datos.ObtenerPorDni(dni);
    }
}
