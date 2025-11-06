
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AurenPadelStore.CDatos;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CLogica
{
    public class ClienteLogica
    {
        private readonly ClienteDatos datos = new ClienteDatos();

        private static bool Texto(string s) => !string.IsNullOrWhiteSpace(s);

        private readonly ClienteDatos _datos = new ClienteDatos();
        public List<Cliente> ObtenerTodosActivos() => _datos.ObtenerTodosActivos();
        public List<Cliente> Listar() => datos.ObtenerTodos();

        private void ValidarCliente(Cliente c)
        {
            if (!Texto(c.Nombre_Cliente) || !Texto(c.Apellido_Cliente) ||
                !Texto(c.Direccion_Cliente) || !Texto(c.Telefono_Cliente))
                throw new Exception("Nombre, apellido, dirección y teléfono son obligatorios.");

            if (c.Dni_Cliente < 1000000 || c.Dni_Cliente > 99999999)
                throw new Exception("El DNI ingresado no es válido.");

            // Validación simple para el correo (si se ingresó uno)
            if (!string.IsNullOrEmpty(c.Correo_Cliente) && !c.Correo_Cliente.Contains("@"))
                throw new Exception("El formato del correo electrónico no es válido.");
        }

        public void Registrar(Cliente c)
        {
            ValidarCliente(c);
            datos.Insertar(c);
        }

        public void Actualizar(Cliente c)
        {
            if (c.id_Cliente <= 0) throw new Exception("Cliente inválido para actualizar.");
            ValidarCliente(c);
            datos.Actualizar(c);
        }

        public void CambiarEstado(int idCliente, bool activar, string rol)
        {
            // Se mantiene la lógica de que solo un rol específico puede hacer esto
            if (!string.Equals(rol, "Gerente", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(rol, "Administrador", StringComparison.OrdinalIgnoreCase))
                throw new Exception("Solo un Gerente o Administrador puede activar/inactivar clientes.");

            datos.CambiarEstado(idCliente, activar);
        }

        public Cliente Obtener(int id) => datos.ObtenerPorId(id);
    }
}

