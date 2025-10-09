using System;
using System.Collections.Generic;
using AurenPadelStore.CEntidades;
using AurenPadelStore.CDatos;

namespace AurenPadelStore.CLogica
{
    public class UsuarioLogica
    {
        private readonly UsuarioDatos datos = new UsuarioDatos();

        private static bool DniValido(int dni) => dni >= 10000000 && dni <= 99999999;
        private static bool Texto(string s) => !string.IsNullOrWhiteSpace(s);

        public void RegistrarUsuario(Usuario u)
        {
            if (!DniValido(u.Dni_Usuario) ||
                !Texto(u.Nombre_Usuario) ||
                !Texto(u.Apellido_Usuario) ||
                !Texto(u.Contraseña_Usuario) ||
                !Texto(u.Rol_Usuario))
                throw new Exception("Todos los campos son obligatorios y el DNI debe tener 8 dígitos.");

            if (u.Contraseña_Usuario.Length < 8)
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");

            if (!(u.Rol_Usuario == "Vendedor" || u.Rol_Usuario == "Administrador" || u.Rol_Usuario == "Gerente"))
                throw new Exception("Rol inválido. Valores permitidos: Vendedor, Administrador, Gerente.");

            if (datos.ExisteDni(u.Dni_Usuario))
                throw new Exception("El DNI ya está registrado.");

            datos.Insertar(u);
        }

        public void ActualizarUsuario(Usuario u, int dniOriginal)
        {
            if (!DniValido(dniOriginal))
                throw new Exception("DNI original inválido.");

            if (!DniValido(u.Dni_Usuario))
                throw new Exception("El DNI debe contener exactamente 8 números.");

            if (!Texto(u.Nombre_Usuario) ||
                !Texto(u.Apellido_Usuario) ||
                !Texto(u.Contraseña_Usuario) ||
                !Texto(u.Rol_Usuario))
                throw new Exception("Todos los campos son obligatorios.");

            if (u.Contraseña_Usuario.Length < 8)
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");

            if (u.Dni_Usuario != dniOriginal && datos.ExisteDni(u.Dni_Usuario))
                throw new Exception("El nuevo DNI ya existe.");

            datos.Actualizar(u, dniOriginal);
        }

        public List<Usuario> ListarUsuarios() => datos.ObtenerTodos();

        public Usuario ObtenerPorDni(int dni)
        {
            if (!DniValido(dni)) return null;
            return datos.ObtenerPorDni(dni);
        }

        public string? ValidarUsuario(int dni, string contraseña)
        {
            if (!DniValido(dni)) return null;
            if (string.IsNullOrWhiteSpace(contraseña)) return "";
            return datos.ValidarUsuario(dni, contraseña);
        }
    }
}
