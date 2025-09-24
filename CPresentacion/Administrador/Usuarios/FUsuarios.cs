using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AurenPadelStore.CDatos;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CPresentacion.Administrador.Usuarios
{
    public partial class FUsuarios : Form
    {
        // Scroll host para barras cuando el MDI es más chico que el diseño
        private Panel _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);

        private readonly UsuarioDatos _datos = new UsuarioDatos();
        private bool _modoEdicion = false;
        private string _dniOriginalEdicion = null;

        public FUsuarios()
        {
            InitializeComponent();

            // Alinear en (0,0) dentro del MDI (cuando se muestra)
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Shown += (_, __) => this.Location = new Point(0, 0);

            // Scrollbars
            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();

            // Eventos
            this.Load += FUsuarios_Load;
            BAgregarUsuario.Click += BAgregarUsuario_Click;

            DGListaUsuarios.CellContentClick += DGListaUsuarios_CellContentClick;
            DGListaUsuarios.CellMouseEnter += DGListaUsuarios_CellMouseEnter;
            DGListaUsuarios.CellMouseLeave += DGListaUsuarios_CellMouseLeave;

            TBBuscarU.TextChanged += (_, __) => RefrescarGrilla();
            CBFiltroU.SelectedIndexChanged += (_, __) => RefrescarGrilla();
            BBuscarU.Click += (_, __) => RefrescarGrilla();

            // Validación de DNI solo números desde código (por si no lo asignaste en el designer)
            TBDniU.KeyPress += TBNumerico_KeyPress;

            // Combo de Roles
            CBRol.Items.Clear();
            CBRol.Items.AddRange(new[] { "Administrador", "Gerente", "Vendedor" });
            if (CBRol.Items.Count > 0) CBRol.SelectedIndex = 0;
        }

        // ===== Scroll =====
        private void PrepararScrollHost()
        {
            _scrollHost = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = this.BackColor
            };

            // mover todo el contenido del form dentro del host
            while (this.Controls.Count > 0)
            {
                Control c = this.Controls[0];
                this.Controls.RemoveAt(0);
                _scrollHost.Controls.Add(c);
            }

            this.Controls.Add(_scrollHost);

            // tamaño mínimo de contenido para forzar barras cuando no hay espacio
            _scrollHost.AutoScrollMinSize = _designContentSize;
            UpdateScrollbars();
        }

        private void UpdateScrollbars()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                _scrollHost.AutoScrollMinSize = Size.Empty;     // sin barras
                _scrollHost.AutoScrollPosition = Point.Empty;   // reset desplazamiento
            }
            else
            {
                _scrollHost.AutoScrollMinSize = _designContentSize; // barras si hace falta
                // opcional: volver al origen
                _scrollHost.AutoScrollPosition = Point.Empty;
            }
        }

        // ===== Carga inicial =====
        private void FUsuarios_Load(object sender, EventArgs e)
        {
            if (CBFiltroU.Items.Count > 0 && CBFiltroU.SelectedIndex < 0)
                CBFiltroU.SelectedIndex = 0; // "Nombre A-Z" por ejemplo

            RefrescarGrilla();
            _scrollHost.AutoScrollPosition = Point.Empty;
        }

        // ===== Grilla =====
        private void RefrescarGrilla()
        {
            try
            {
                List<Usuario> lista = _datos.ObtenerTodos();

                // Buscar
                string q = (TBBuscarU.Text ?? "").Trim().ToLower();
                if (!string.IsNullOrEmpty(q))
                {
                    lista = lista.FindAll(u =>
                        (u.Nombre ?? "").ToLower().Contains(q) ||
                        (u.Apellido ?? "").ToLower().Contains(q) ||
                        (u.DNI ?? "").ToLower().Contains(q));
                }

                // Filtros
                string f = CBFiltroU.SelectedItem?.ToString() ?? "";
                switch (f)
                {
                    case "Nombre A-Z":
                        lista.Sort((a, b) => string.Compare(a.Nombre, b.Nombre, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "Nombre Z-A":
                        lista.Sort((a, b) => -string.Compare(a.Nombre, b.Nombre, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "Apellido A-Z":
                        lista.Sort((a, b) => string.Compare(a.Apellido, b.Apellido, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "Apellido Z-A":
                        lista.Sort((a, b) => -string.Compare(a.Apellido, b.Apellido, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "Administrador":
                        lista = lista.FindAll(u => (u.Rol ?? "").Equals("Administrador", StringComparison.OrdinalIgnoreCase));
                        break;
                    case "Gerente":
                        lista = lista.FindAll(u => (u.Rol ?? "").Equals("Gerente", StringComparison.OrdinalIgnoreCase));
                        break;
                    case "Vendedor":
                        lista = lista.FindAll(u => (u.Rol ?? "").Equals("Vendedor", StringComparison.OrdinalIgnoreCase));
                        break;
                    case "Activos":
                        lista = lista.FindAll(u => u.Estado);
                        break;
                    case "Inactivos":
                        lista = lista.FindAll(u => !u.Estado);
                        break;
                }

                DGListaUsuarios.Rows.Clear();
                foreach (var u in lista)
                {
                    int idx = DGListaUsuarios.Rows.Add(
                        u.Nombre,
                        u.Apellido,
                        u.DNI,
                        u.Rol,
                        u.Estado ? "Activo" : "Inactivo",
                        "Editar",
                        null // el texto del botón lo setea SetAccionEstadoRow
                    );
                    SetAccionEstadoRow(DGListaUsuarios.Rows[idx], u.Estado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetAccionEstadoRow(DataGridViewRow row, bool activo)
        {
            var accion = row.Cells["colUAccion"] as DataGridViewButtonCell;
            if (accion == null) return;

            if (activo)
            {
                accion.Value = "Inactivar";
                accion.Style.BackColor = Color.LightCoral;
                accion.Style.ForeColor = Color.Black;
                row.Cells["colUEstado"].Value = "Activo";
            }
            else
            {
                accion.Value = "Activar";
                accion.Style.BackColor = Color.LightSkyBlue;
                accion.Style.ForeColor = Color.Black;
                row.Cells["colUEstado"].Value = "Inactivo";
            }
        }

        private void DGListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string col = DGListaUsuarios.Columns[e.ColumnIndex].Name;

            if (col == "colUEditar")
            {
                var row = DGListaUsuarios.Rows[e.RowIndex];

                TBNombreU.Text = row.Cells["colUNombre"].Value?.ToString() ?? "";
                TBApellidoU.Text = row.Cells["colUApellido"].Value?.ToString() ?? "";
                TBDniU.Text = row.Cells["colUDni"].Value?.ToString() ?? "";
                _dniOriginalEdicion = TBDniU.Text;

                // set rol
                string rol = row.Cells["colURol"].Value?.ToString() ?? "Vendedor";
                if (!string.IsNullOrEmpty(rol))
                    CBRol.SelectedItem = rol;

                // vaciar contraseñas para no mostrar
                TBContrasena.Clear();
                TBRepetirContrasena.Clear();

                _modoEdicion = true;
                BAgregarUsuario.Text = "Guardar Cambios";
                return;
            }

            if (col == "colUAccion")
            {
                var row = DGListaUsuarios.Rows[e.RowIndex];
                string dni = row.Cells["colUDni"].Value?.ToString() ?? "";
                bool actualmenteActivo = string.Equals(row.Cells["colUEstado"].Value?.ToString(), "Activo", StringComparison.OrdinalIgnoreCase);

                string pregunta = actualmenteActivo
                    ? "¿Está seguro que desea INACTIVAR este usuario?"
                    : "¿Está seguro que desea ACTIVAR este usuario?";

                var dr = MessageBox.Show(pregunta, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                try
                {
                    _datos.CambiarEstado(dni, !actualmenteActivo);
                    // Reflejar inmediatamente en la fila
                    SetAccionEstadoRow(row, !actualmenteActivo);
                    MessageBox.Show("Estado actualizado correctamente.", "OK",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cambiar estado: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
        }

        private void DGListaUsuarios_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            DGListaUsuarios.Cursor = Cursors.Default;
        }

        private void DGListaUsuarios_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DGListaUsuarios.Cursor = Cursors.Default;
        }

        // ===== Alta / Edición =====
        private void BAgregarUsuario_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(TBNombreU.Text) ||
                string.IsNullOrWhiteSpace(TBApellidoU.Text) ||
                string.IsNullOrWhiteSpace(TBDniU.Text) ||
                string.IsNullOrWhiteSpace(TBContrasena.Text) ||
                string.IsNullOrWhiteSpace(TBRepetirContrasena.Text))
            {
                MessageBox.Show("Complete todos los campos.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TBContrasena.Text != TBRepetirContrasena.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dniRegex = new Regex(@"^\d{8}$");
            if (!dniRegex.IsMatch(TBDniU.Text.Trim()))
            {
                MessageBox.Show("El DNI debe tener exactamente 8 números.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBDniU.Focus();
                return;
            }

            try
            {
                if (_modoEdicion)
                {
                    var dr = MessageBox.Show("¿Confirmar la edición de este usuario?",
                                             "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr != DialogResult.Yes)
                    {
                        // Canceló la edición → limpiar y volver a modo alta
                        LimpiarPanel();
                        _modoEdicion = false;
                        _dniOriginalEdicion = null;
                        BAgregarUsuario.Text = "Agregar Usuario";
                        return;
                    }

                    var u = new Usuario
                    {
                        DNI = TBDniU.Text.Trim(),
                        Nombre = TBNombreU.Text.Trim(),
                        Apellido = TBApellidoU.Text.Trim(),
                        Contrasena = TBContrasena.Text,
                        Rol = CBRol.SelectedItem?.ToString() ?? "Vendedor",
                        Estado = true // no se toca aquí
                    };

                    _datos.Actualizar(u, _dniOriginalEdicion);
                    MessageBox.Show("Usuario actualizado correctamente.", "OK",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _modoEdicion = false;
                    _dniOriginalEdicion = null;
                    BAgregarUsuario.Text = "Agregar Usuario";
                    LimpiarPanel();
                    RefrescarGrilla();
                }
                else
                {
                    var u = new Usuario
                    {
                        DNI = TBDniU.Text.Trim(),
                        Nombre = TBNombreU.Text.Trim(),
                        Apellido = TBApellidoU.Text.Trim(),
                        Contrasena = TBContrasena.Text,
                        Rol = CBRol.SelectedItem?.ToString() ?? "Vendedor",
                        Estado = true
                    };

                    _datos.Insertar(u);
                    MessageBox.Show("Usuario agregado correctamente.", "OK",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarPanel();
                    RefrescarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarPanel()
        {
            TBNombreU.Clear();
            TBApellidoU.Clear();
            TBDniU.Clear();
            TBContrasena.Clear();
            TBRepetirContrasena.Clear();
            if (CBRol.Items.Count > 0) CBRol.SelectedIndex = 0;
        }

        // Sólo números en DNI
        private void TBNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
