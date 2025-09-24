using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AurenPadelStore.CDatos;
using AurenPadelStore.CEntidades;
using AurenPadelStore.CPresentacion.Administrador;
using AurenPadelStore.CPresentacion.Empleados;

namespace AurenPadelStore.CPresentacion.InicioSesion
{
    public partial class FInicioSesion : Form
    {
        private readonly UsuarioDatos _usuarioDatos = new UsuarioDatos();
        private List<Usuario> _usuariosCache = new List<Usuario>();

        public FInicioSesion()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                // Traemos todos para tener nombre, rol y estado en memoria
                _usuariosCache = _usuarioDatos.ObtenerTodos() ?? new List<Usuario>();

                if (_usuariosCache.Count == 0)
                {
                    CBUsuarios.DataSource = null;
                    MessageBox.Show("No se encontraron usuarios.",
                                    "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Enlazamos el combo: muestra Nombre y Apellido, y guarda DNI
                CBUsuarios.DataSource = _usuariosCache;
                CBUsuarios.DisplayMember = "NombreMostrar"; // propiedad: $"{Nombre} {Apellido}"
                CBUsuarios.ValueMember = "DNI";
                CBUsuarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (CBUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dni = CBUsuarios.SelectedValue?.ToString() ?? "";
            string contraseña = TBContraseña.Text.Trim();

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Debe ingresar la contraseña.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscamos el usuario elegido en el caché para leer Estado, Nombre y Rol
            var usuario = _usuariosCache.FirstOrDefault(u => u.DNI == dni);
            if (usuario == null)
            {
                MessageBox.Show("El usuario no existe.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si está inactivo, lo avisamos ANTES de validar contraseña
            if (!usuario.Estado)
            {
                MessageBox.Show("El usuario seleccionado está INACTIVO. Consulte con un administrador.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar credenciales
            string? rol = _usuarioDatos.ValidarUsuario(dni, contraseña);

            if (rol == null)
            {
                MessageBox.Show("El usuario no existe.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rol == "")
            {
                MessageBox.Show("Contraseña incorrecta.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Guardamos la sesión
            SesionActual.DNI = usuario.DNI;
            SesionActual.Nombre = usuario.NombreMostrar; // "Nombre Apellido"
            SesionActual.Rol = rol; // "Administrador", "Gerente" o "Vendedor"

            // Redirección por rol
            this.Hide();
            if (rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                var menuAdmin = new FMenuAdmin();
                menuAdmin.Show();
            }
            else if (rol.Equals("Gerente", StringComparison.OrdinalIgnoreCase) ||
                     rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                var menuEmp = new FMenuEmpleados();
                menuEmp.Show();
            }
            else
            {
                MessageBox.Show("Rol no reconocido.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Show();
            }
        }
    }
}
