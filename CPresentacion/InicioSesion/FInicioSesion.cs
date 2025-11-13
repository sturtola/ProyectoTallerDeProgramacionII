using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AurenPadelStore.CDatos;
using AurenPadelStore.CEntidades; // SesionActual
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

            // UX
            BIngresar.Click += btnIngresar_Click;
            TBContraseña.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) btnIngresar_Click(s, e); };
            chkMostrarContrasena.CheckedChanged += chkMostrarContrasena_CheckedChanged;

            // Enter en todo el form confirma login
            this.AcceptButton = BIngresar;

            // Carga inicial
            CargarUsuarios();
        }

        private void chkMostrarContrasena_CheckedChanged(object? sender, EventArgs e)
        {
            // Mostrar/ocultar password
            TBContraseña.UseSystemPasswordChar = !chkMostrarContrasena.Checked;
        }

        private void CargarUsuarios()
        {
            try
            {
                _usuariosCache = _usuarioDatos.ObtenerTodos() ?? new List<Usuario>();

                // Limpiar bindings previos
                CBUsuarios.DataSource = null;
                CBUsuarios.DisplayMember = null;
                CBUsuarios.ValueMember = null;

                if (_usuariosCache.Count == 0)
                {
                    CBUsuarios.Items.Clear();
                    CBUsuarios.SelectedIndex = -1;
                    return;
                }

                var items = _usuariosCache
                    .Select(u => new
                    {
                        Display = $"{u.Nombre_Usuario} {u.Apellido_Usuario}",
                        Value = u.Dni_Usuario
                    })
                    .ToList();

                CBUsuarios.DisplayMember = "Display";
                CBUsuarios.ValueMember = "Value";
                CBUsuarios.DataSource = items;

                CBUsuarios.SelectedIndex = CBUsuarios.Items.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CBUsuarios.DataSource = null;
                CBUsuarios.Items.Clear();
                CBUsuarios.SelectedIndex = -1;
            }
        }

        private void btnIngresar_Click(object? sender, EventArgs e)
        {
            if (CBUsuarios.DataSource == null || CBUsuarios.Items.Count == 0)
            {
                MessageBox.Show("No hay usuarios para iniciar sesión.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CBUsuarios.SelectedIndex < 0 || CBUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dniSeleccionado;
            try
            {
                dniSeleccionado = Convert.ToInt32(CBUsuarios.SelectedValue);
            }
            catch
            {
                MessageBox.Show("No se pudo obtener el DNI del usuario seleccionado.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string contraseña = TBContraseña.Text.Trim();
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Debe ingresar la contraseña.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuario = _usuariosCache.FirstOrDefault(u => u.Dni_Usuario == dniSeleccionado);
            if (usuario == null)
            {
                MessageBox.Show("El usuario seleccionado no existe.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (usuario.Estado_Usuario == false)
            {
                MessageBox.Show("El usuario seleccionado está INACTIVO. Consulte con un administrador.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string? rol = _usuarioDatos.ValidarUsuario(dniSeleccionado, contraseña);

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

            // Guardar sesión
            SesionActual.Id_UsuarioActual = usuario.id_Usuario;
            SesionActual.NombreCompleto = $"{usuario.Nombre_Usuario} {usuario.Apellido_Usuario}";
            SesionActual.Rol = rol;

            // Redirigir por rol
            this.Hide();
            if (rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                var menuAdmin = new FMenuAdmin();
                menuAdmin.FormClosed += (_, __) => this.Close();
                menuAdmin.Show();
            }
            else if (rol.Equals("Gerente", StringComparison.OrdinalIgnoreCase) ||
                     rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                var menuEmp = new FMenuEmpleados();
                menuEmp.FormClosed += (_, __) => this.Close();
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
