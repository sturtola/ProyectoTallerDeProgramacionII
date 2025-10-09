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
                _usuariosCache = _usuarioDatos.ObtenerTodos() ?? new List<Usuario>();

                CBUsuarios.DataSource = null;            // limpiar bindings previos
                CBUsuarios.DisplayMember = null;
                CBUsuarios.ValueMember = null;
                CBUsuarios.FormattingEnabled = true;     // por si el diseñador lo cambió

                if (_usuariosCache.Count == 0)
                {
                    MessageBox.Show("No se encontraron usuarios.",
                                    "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Proyección explícita: Display = "Nombre Apellido", Value = DNI
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
            if (CBUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tomamos el DNI (ValueMember es int)
            if (!(CBUsuarios.SelectedValue is int dniSeleccionado))
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

            // Buscar en caché por DNI INT
            var usuario = _usuariosCache.FirstOrDefault(u => u.Dni_Usuario == dniSeleccionado);
            if (usuario == null)
            {
                MessageBox.Show("El usuario no existe.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar estado antes de validar credenciales
            if (!usuario.Estado_Usuario)
            {
                MessageBox.Show("El usuario seleccionado está INACTIVO. Consulte con un administrador.",
                                "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar credenciales contra la BD
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

            // Guardar sesión (ajustá tipos según tu clase SesionActual)
            SesionActual.DNI = dniSeleccionado.ToString();   // si tu SesionActual.DNI es string
            SesionActual.Nombre = usuario.NombreMostrar;
            SesionActual.Rol = rol; // "Administrador" / "Gerente" / "Vendedor"

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
