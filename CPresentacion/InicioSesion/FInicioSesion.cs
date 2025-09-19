using AurenPadelStore.CDatos;
using AurenPadelStore.CPresentacion.Administrador;
using AurenPadelStore.CPresentacion.Empleados;
using System;
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
                var usuarios = usuarioDatos.ListarUsuarios();
                if (usuarios != null && usuarios.Count > 0)
                    CBUsuarios.DataSource = usuarios;
                else
                    MessageBox.Show("No se encontraron usuarios.");
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

            string usuarioSeleccionado = CBUsuarios.SelectedItem.ToString();
            string contraseña = TBContraseña.Text.Trim();

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Debe ingresar la contraseña.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? rol = usuarioDatos.ValidarUsuario(usuarioSeleccionado, contraseña);

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

            // Login correcto → abrir formulario según rol
            this.Hide();
            if (rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                FMenuAdmin menuAdmin = new FMenuAdmin();
                menuAdmin.Show();
            }
            else if (rol.Equals("Gerente", StringComparison.OrdinalIgnoreCase) ||
                     rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                FMenuEmpleados menuEmp = new FMenuEmpleados();
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
