using AurenPadelStore.CDatos;
using AurenPadelStore.CEntidades; // <-- para acceder a Usuario
using AurenPadelStore.CPresentacion.Administrador;
using AurenPadelStore.CPresentacion.Empleados;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.InicioSesion
{
    public partial class FInicioSesion : Form
    {
        private readonly UsuarioDatos usuarioDatos = new UsuarioDatos();

        public FInicioSesion()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                // Traemos usuarios completos para mostrar nombre y tener el DNI como value
                List<Usuario> usuarios = usuarioDatos.ObtenerTodos();

                if (usuarios != null && usuarios.Count > 0)
                {
                    CBUsuarios.DataSource = usuarios;
                    CBUsuarios.DisplayMember = "NombreMostrar"; // lo que se ve
                    CBUsuarios.ValueMember = "DNI";             // lo que usamos para validar
                    CBUsuarios.SelectedIndex = 0;
                }
                else
                {
                    CBUsuarios.DataSource = null;
                    MessageBox.Show("No se encontraron usuarios.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (CBUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 👇 Tomamos el DNI desde el ValueMember
            string dniSeleccionado = CBUsuarios.SelectedValue?.ToString() ?? "";
            string contraseña = TBContraseña.Text.Trim();

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Debe ingresar la contraseña.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validamos con DNI + contraseña (no cambia tu método)
            string? rol = usuarioDatos.ValidarUsuario(dniSeleccionado, contraseña);

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

            // Setear sesión con datos reales
            var usuario = usuarioDatos.ObtenerPorDni(dniSeleccionado);
            SesionActual.DNI = dniSeleccionado;
            SesionActual.Nombre = usuario != null ? $"{usuario.Nombre} {usuario.Apellido}" : "";
            SesionActual.Rol = rol; // "Administrador", "Gerente", "Vendedor"

            // Limpieza visual del login (opcional)
            TBContraseña.Clear();

            // Login correcto → abrir formulario según rol
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
