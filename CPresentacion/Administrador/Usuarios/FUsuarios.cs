using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AurenPadelStore.CLogica;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CPresentacion.Administrador.Usuarios
{
    public partial class FUsuarios : Form
    {
        private readonly UsuarioLogica _logica = new UsuarioLogica();

        // Estado de edición
        private bool _editMode = false;
        private string _dniOriginal = null;
        private Panel _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);

        // Cache de usuarios para aplicar búsqueda/filtros/orden
        private List<Usuario> _usuariosCache = new List<Usuario>();

        public FUsuarios()
        {
            InitializeComponent();
            CargarRoles();
            PrepararEventosUI();
            PoblarComboFiltros();
            RefrescarGrillaDesdeBD();   // carga cache y pinta grilla
            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();
        }

        private void PrepararScrollHost()
        {
            _scrollHost = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = this.BackColor
            };

            while (this.Controls.Count > 0)
            {
                Control c = this.Controls[0];
                this.Controls.RemoveAt(0);
                _scrollHost.Controls.Add(c);
            }

            this.Controls.Add(_scrollHost);
            _scrollHost.AutoScrollMinSize = _designContentSize;
            UpdateScrollbars();
        }

        private void UpdateScrollbars()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                _scrollHost.AutoScrollMinSize = Size.Empty;
                _scrollHost.AutoScrollPosition = Point.Empty;
            }
            else
            {
                _scrollHost.AutoScrollMinSize = _designContentSize;
            }
        }

        private void CargarRoles()
        {
            CBRol.Items.Clear();
            CBRol.Items.AddRange(new object[] { "Administrador", "Gerente", "Vendedor" });
            if (CBRol.Items.Count > 0) CBRol.SelectedIndex = 0;
        }

        private void PoblarComboFiltros()
        {
            CBFiltroU.Items.Clear();
            CBFiltroU.Items.AddRange(new object[]
            {
                "Nombre A-Z",
                "Nombre Z-A",
                "Apellido A-Z",
                "Apellido Z-A",
                "Vendedor",
                "Administrador",
                "Gerente"
            });
            CBFiltroU.SelectedIndex = 0; // por defecto ordenar por Nombre A-Z
        }

        private void PrepararEventosUI()
        {
            // Grilla
            DGListaUsuarios.CellContentClick += DGListaUsuarios_CellContentClick;

            // Búsqueda
            BBuscarU.Click += (_, __) => ApplyFilters();
            TBBuscarU.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    ApplyFilters();
                }
            };

            // Filtro/orden
            CBFiltroU.SelectedIndexChanged += (_, __) => ApplyFilters();
        }

        // Carga y pintado de grilla
        private void RefrescarGrillaDesdeBD()
        {
            _usuariosCache = _logica.ListarUsuarios() ?? new List<Usuario>();
            ApplyFilters(); // pinta según búsqueda/filtro actuales
        }

        private void PintarGrilla(IEnumerable<Usuario> data)
        {
            DGListaUsuarios.Rows.Clear();
            foreach (var u in data)
            {
                DGListaUsuarios.Rows.Add(
                    u.Nombre,
                    u.Apellido,
                    u.DNI,
                    "••••••",   // nunca mostramos contraseña
                    u.Rol,
                    "Editar",
                    "Eliminar"
                );
            }
        }

        // Búsqueda + Filtros + Orden
        private void ApplyFilters()
        {
            IEnumerable<Usuario> query = _usuariosCache;

            // 1) Búsqueda (Nombre / Apellido / DNI contiene)
            var q = (TBBuscarU.Text ?? string.Empty).Trim();
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(u =>
                    (u.Nombre ?? "").IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (u.Apellido ?? "").IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    (u.DNI ?? "").IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
                );
            }

            // 2) Filtro/Orden según combo
            string sel = CBFiltroU.SelectedItem?.ToString() ?? "Nombre A-Z";
            switch (sel)
            {
                // Ordenamiento global
                case "Nombre A-Z":
                    query = query.OrderBy(u => u.Nombre).ThenBy(u => u.Apellido);
                    break;
                case "Nombre Z-A":
                    query = query.OrderByDescending(u => u.Nombre).ThenByDescending(u => u.Apellido);
                    break;
                case "Apellido A-Z":
                    query = query.OrderBy(u => u.Apellido).ThenBy(u => u.Nombre);
                    break;
                case "Apellido Z-A":
                    query = query.OrderByDescending(u => u.Apellido).ThenByDescending(u => u.Nombre);
                    break;

                // Filtro por rol (con orden por apellido por defecto)
                case "Vendedor":
                case "Administrador":
                case "Gerente":
                    query = query
                        .Where(u => string.Equals(u.Rol, sel, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(u => u.Apellido).ThenBy(u => u.Nombre);
                    break;

                default:
                    // fallback
                    query = query.OrderBy(u => u.Nombre).ThenBy(u => u.Apellido);
                    break;
            }

            PintarGrilla(query);
        }

        // Validaciones UI
        private bool ValidarUI()
        {
            if (string.IsNullOrWhiteSpace(TBNombreU.Text) ||
                string.IsNullOrWhiteSpace(TBApellidoU.Text) ||
                string.IsNullOrWhiteSpace(TBDniU.Text) ||
                string.IsNullOrWhiteSpace(TBContrasena.Text) ||
                string.IsNullOrWhiteSpace(TBRepetirContrasena.Text) ||
                CBRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completá todos los campos.", "Campos incompletos",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var soloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
            if (!soloLetras.IsMatch(TBNombreU.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras.", "Dato inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNombreU.Focus(); return false;
            }
            if (!soloLetras.IsMatch(TBApellidoU.Text))
            {
                MessageBox.Show("El apellido solo puede contener letras.", "Dato inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBApellidoU.Focus(); return false;
            }
            // DNI exactamente 8 dígitos
            if (!Regex.IsMatch(TBDniU.Text, @"^\d{8}$"))
            {
                MessageBox.Show("El DNI debe contener exactamente 8 números.",
                                "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBDniU.Focus(); return false;
            }
            if (TBContrasena.Text.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Dato inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBContrasena.Focus(); return false;
            }
            if (TBContrasena.Text != TBRepetirContrasena.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Dato inválido",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBRepetirContrasena.Focus(); return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            TBNombreU.Clear();
            TBApellidoU.Clear();
            TBDniU.Clear();
            TBContrasena.Clear();
            TBRepetirContrasena.Clear();
            if (CBRol.Items.Count > 0) CBRol.SelectedIndex = 0;

            _editMode = false;
            _dniOriginal = null;
            BAgregarUsuario.Text = "Agregar Usuario";
            BAgregarUsuario.BackColor = Color.YellowGreen;
            BAgregarUsuario.ForeColor = Color.Black;
        }

        private void TBNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Alta / Edición con confirmación
        private void BAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarUI()) return;

            var u = new Usuario(
                dni: TBDniU.Text.Trim(),
                nombre: TBNombreU.Text.Trim(),
                apellido: TBApellidoU.Text.Trim(),
                contrasena: TBContrasena.Text,
                rol: CBRol.SelectedItem?.ToString() ?? ""
            );

            try
            {
                if (_editMode)
                {
                    var r = MessageBox.Show(
                        "¿Confirmás la edición de este usuario?",
                        "Confirmar edición",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2
                    );

                    if (r == DialogResult.Yes)
                    {
                        _logica.ActualizarUsuario(u, _dniOriginal);
                        MessageBox.Show("Usuario actualizado correctamente.", "Éxito",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefrescarGrillaDesdeBD();
                        LimpiarCampos();
                        TBNombreU.Focus();
                    }
                    else
                    {
                        LimpiarCampos();
                        MessageBox.Show("Edición cancelada.", "Cancelado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }

                // Alta
                _logica.RegistrarUsuario(u);
                MessageBox.Show("Usuario agregado correctamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarGrillaDesdeBD(); // recarga cache y aplica filtros
                LimpiarCampos();
                TBNombreU.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Editar / Eliminar desde la grilla
        private void DGListaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var grid = DGListaUsuarios;
            var colName = grid.Columns[e.ColumnIndex].Name;

            if (colName == "colUEditar")
            {
                string dni = grid.Rows[e.RowIndex].Cells["colUDni"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(dni)) return;

                try
                {
                    var u = _logica.ObtenerPorDni(dni);
                    if (u == null)
                    {
                        MessageBox.Show("No se encontró el usuario en la base de datos.",
                                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    TBNombreU.Text = u.Nombre;
                    TBApellidoU.Text = u.Apellido;
                    TBDniU.Text = u.DNI;
                    TBContrasena.Text = u.Contrasena;
                    TBRepetirContrasena.Text = u.Contrasena;
                    CBRol.SelectedItem = u.Rol;

                    _editMode = true;
                    _dniOriginal = u.DNI;
                    BAgregarUsuario.Text = "Guardar cambios";
                    BAgregarUsuario.BackColor = Color.SteelBlue;
                    BAgregarUsuario.ForeColor = Color.White;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (colName == "colUEliminar")
            {
                string dni = grid.Rows[e.RowIndex].Cells["colUDni"].Value?.ToString();
                string nombre = grid.Rows[e.RowIndex].Cells["colUNombre"].Value?.ToString();
                string apellido = grid.Rows[e.RowIndex].Cells["colUApellido"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(dni)) return;

                var r = MessageBox.Show(
                    $"¿Seguro que querés eliminar al usuario {nombre} {apellido} (DNI {dni})?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (r != DialogResult.Yes) return;

                try
                {
                    _logica.EliminarUsuario(dni);
                    if (_editMode && string.Equals(_dniOriginal, dni, StringComparison.Ordinal))
                        LimpiarCampos();

                    RefrescarGrillaDesdeBD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
