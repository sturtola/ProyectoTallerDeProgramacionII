using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados.Clientes
{
    public partial class FClientes : Form
    {
        private Panel _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);

        public FClientes()
        {
            InitializeComponent();
            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();

            // Handlers de grilla
            DGListaClientes.CellContentClick += DGListaClientes_CellContentClick;

            // Ejemplos estáticos
            CargarClientesDeEjemplo();

            // Habilitacion segun rol
            this.Load += FClientes_Load;
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

        private void FClientes_Load(object sender, EventArgs e)
        {

            // Si es Gerente → inhabilitar panel
            if (SesionActual.Rol.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
            {
                InhabilitarPanelVisual(PAgregarCliente, "Solo el/los Vendedor/es están habilitados para esta función.");
            }
        }

        // Método helper
        private void InhabilitarPanelVisual(Panel panel, string tooltip = "")
        {
            panel.Enabled = false;                  // No deja interactuar
           
        }

        private void CargarClientesDeEjemplo()
        {
            // Activo
            int r1 = DGListaClientes.Rows.Add(
                "Romina",        // Nombre
                "Álvarez",       // Apellido
                "40123456",      // DNI
                "Av. Siempre...",// Dirección
                "romialv@mail.com",
                "3794000000",
                "Activo",        // Estado
                "Editar",
                ""               // Acción se setea abajo
            );
            SetAccionSegunEstado(DGListaClientes.Rows[r1]);

            // Inactivo
            int r2 = DGListaClientes.Rows.Add(
                "Diego",
                "Mansilla",
                "40999888",
                "Calle 9 #234",
                "diego@mail.com",
                "3794555555",
                "Inactivo",
                "Editar",
                ""
            );
            SetAccionSegunEstado(DGListaClientes.Rows[r2]);
        }

        private void BAgregarCliente_Click(object sender, EventArgs e)
        {
            // ---- Validar campos obligatorios ----
            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text) ||
                string.IsNullOrWhiteSpace(TBDni.Text) ||
                string.IsNullOrWhiteSpace(TBDireccion.Text) ||
                string.IsNullOrWhiteSpace(TBCorreo.Text) ||
                string.IsNullOrWhiteSpace(TBTelefono.Text))
            {
                MessageBox.Show("Por favor, completá todos los campos.",
                                "Campos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Solo letras en nombre y apellido
            var soloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
            if (!soloLetras.IsMatch(TBNombre.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBNombre.Focus();
                return;
            }
            if (!soloLetras.IsMatch(TBApellido.Text))
            {
                MessageBox.Show("El apellido solo puede contener letras.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBApellido.Focus();
                return;
            }

            // DNI solo números
            if (!long.TryParse(TBDni.Text, out _))
            {
                MessageBox.Show("El DNI debe ser numérico.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBDni.Focus();
                return;
            }

            // Validar correo rudimentario
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(TBCorreo.Text))
            {
                MessageBox.Show("El correo no tiene un formato válido.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBCorreo.Focus();
                return;
            }

            // Teléfono solo números (puede tener + o espacios)
            var telRegex = new Regex(@"^[0-9+\s]+$");
            if (!telRegex.IsMatch(TBTelefono.Text))
            {
                MessageBox.Show("El teléfono solo puede contener números, + o espacios.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBTelefono.Focus();
                return;
            }

            // ---- Agregar a la grilla (simulado) ----
            int idx = DGListaClientes.Rows.Add(
                TBNombre.Text.Trim(),
                TBApellido.Text.Trim(),
                TBDni.Text.Trim(),
                TBDireccion.Text.Trim(),
                TBCorreo.Text.Trim(),
                TBTelefono.Text.Trim(),
                "Activo",   // Estado por defecto
                "Editar",
                ""          // Acción se setea abajo
            );
            SetAccionSegunEstado(DGListaClientes.Rows[idx]);

            MessageBox.Show("Cliente agregado correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            LimpiarCampos();
            TBNombre.Focus();
        }

        private void TBNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void LimpiarCampos()
        {
            TBNombre.Clear();
            TBApellido.Clear();
            TBDni.Clear();
            TBDireccion.Clear();
            TBCorreo.Clear();
            TBTelefono.Clear();
        }

        // === Estado / Acción ===

        private void DGListaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var grid = DGListaClientes;
            var colName = grid.Columns[e.ColumnIndex].Name;

            if (colName == "colAccion")
            {
                var row = grid.Rows[e.RowIndex];
                string estado = row.Cells["colEstado"].Value?.ToString() ?? "Activo";

                if (string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase))
                {
                    // Inactivar
                    row.Cells["colEstado"].Value = "Inactivo";
                }
                else
                {
                    // Activar
                    row.Cells["colEstado"].Value = "Activo";
                }
                // Actualizar el botón y estilo
                SetAccionSegunEstado(row);
            }
            else if (colName == "colEditar")
            {
                
                MessageBox.Show("Editar cliente (lógica pendiente).", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetAccionSegunEstado(DataGridViewRow row)
        {
            string estado = row.Cells["colEstado"].Value?.ToString() ?? "Activo";
            var accionCell = row.Cells["colAccion"] as DataGridViewButtonCell;

            if (string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase))
            {
                accionCell.Value = "Inactivar";
                accionCell.Style.BackColor = Color.LightCoral;   // rojo claro
                accionCell.Style.ForeColor = Color.Black;
            }
            else
            {
                accionCell.Value = "Activar";
                accionCell.Style.BackColor = Color.LightSkyBlue; // azul claro
                accionCell.Style.ForeColor = Color.Black;
            }
        }
    }
}
