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

        private bool _bloquearEstadoPorRol = false;

        public FClientes()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Shown += (_, __) => this.Location = new Point(0, 0);

            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();

            DGListaClientes.CellContentClick += DGListaClientes_CellContentClick;
            DGListaClientes.CellMouseEnter += DGListaClientes_CellMouseEnter;
            DGListaClientes.CellMouseLeave += DGListaClientes_CellMouseLeave;

            CargarClientesDeEjemplo();

            this.Load += FClientes_Load;
        }

        private void FClientes_Load(object sender, EventArgs e)
        {
            if (SesionActual.Rol.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
            {
                BloquearInteraccionSinCambiarEstilo(PAgregarCliente, BAgregarCliente,
                    "Solo Vendedor/es pueden agregar clientes.");
            }

            _bloquearEstadoPorRol = SesionActual.Rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase);

            _scrollHost.AutoScrollPosition = Point.Empty;
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
                _scrollHost.AutoScrollPosition = Point.Empty;
            }
        }

        private void BloquearInteraccionSinCambiarEstilo(Panel panel, Button botonAgregar, string tooltip = "")
        {
            foreach (Control c in panel.Controls)
            {
                if (c is TextBox tb)
                {
                    var color = tb.BackColor;     
                    tb.ReadOnly = true;           
                    tb.BackColor = color;         
                    tb.TabStop = false;
                    tb.Cursor = Cursors.No;
                    tb.GotFocus += (s, e) => DGListaClientes.Focus(); 
                    tb.ShortcutsEnabled = false;  
                }
                else if (c is ComboBox cb)
                {
                    
                    cb.Enabled = false;          
                    cb.TabStop = false;
                }
                else if (c is Button b && !ReferenceEquals(b, botonAgregar))
                {
                    b.Enabled = false;
                    b.TabStop = false;
                }
                else
                {
                    c.TabStop = false;
                }
            }

            if (botonAgregar != null)
            {
                botonAgregar.Enabled = false; 
                if (!string.IsNullOrWhiteSpace(tooltip))
                {
                    var tt = new ToolTip();
                    tt.SetToolTip(botonAgregar, tooltip);
                }
            }

            panel.TabStop = false;
            panel.Cursor = Cursors.No;

            if (!string.IsNullOrWhiteSpace(tooltip))
            {
                var tt = new ToolTip();
                tt.SetToolTip(panel, tooltip);
                foreach (Control c in panel.Controls) tt.SetToolTip(c, tooltip);
            }

            panel.MouseDown += (s, e) => DGListaClientes.Focus();
        }

        private void CargarClientesDeEjemplo()
        {
            int r1 = DGListaClientes.Rows.Add(
                "Romina", "Álvarez", "40123456", "Av. Siempre...",
                "romialv@mail.com", "3794000000", "Activo", "Editar", ""
            );
            SetAccionSegunEstado(DGListaClientes.Rows[r1]);

            int r2 = DGListaClientes.Rows.Add(
                "Diego", "Mansilla", "40999888", "Calle 9 #234",
                "diego@mail.com", "3794555555", "Inactivo", "Editar", ""
            );
            SetAccionSegunEstado(DGListaClientes.Rows[r2]);
        }

        private void BAgregarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text) ||
                string.IsNullOrWhiteSpace(TBDni.Text) ||
                string.IsNullOrWhiteSpace(TBDireccion.Text) ||
                string.IsNullOrWhiteSpace(TBCorreo.Text) ||
                string.IsNullOrWhiteSpace(TBTelefono.Text))
            {
                MessageBox.Show("Por favor, completá todos los campos.",
                                "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var soloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
            if (!soloLetras.IsMatch(TBNombre.Text)) { MessageBox.Show("El nombre solo puede contener letras."); TBNombre.Focus(); return; }
            if (!soloLetras.IsMatch(TBApellido.Text)) { MessageBox.Show("El apellido solo puede contener letras."); TBApellido.Focus(); return; }

            if (!long.TryParse(TBDni.Text, out _)) { MessageBox.Show("El DNI debe ser numérico."); TBDni.Focus(); return; }

            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(TBCorreo.Text)) { MessageBox.Show("El correo no tiene un formato válido."); TBCorreo.Focus(); return; }

            var telRegex = new Regex(@"^[0-9+\s]+$");
            if (!telRegex.IsMatch(TBTelefono.Text)) { MessageBox.Show("El teléfono solo puede contener números, + o espacios."); TBTelefono.Focus(); return; }

            int idx = DGListaClientes.Rows.Add(
                TBNombre.Text.Trim(), TBApellido.Text.Trim(), TBDni.Text.Trim(),
                TBDireccion.Text.Trim(), TBCorreo.Text.Trim(), TBTelefono.Text.Trim(),
                "Activo", "Editar", ""
            );
            SetAccionSegunEstado(DGListaClientes.Rows[idx]);

            MessageBox.Show("Cliente agregado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            TBNombre.Focus();
        }

        private void TBNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
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

        private void DGListaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var grid = DGListaClientes;
            var colName = grid.Columns[e.ColumnIndex].Name;

            if (colName == "colAccion")
            {
                if (_bloquearEstadoPorRol)
                {
                    MessageBox.Show("No tenés permisos para cambiar el estado del cliente.",
                                    "Permisos insuficientes",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = grid.Rows[e.RowIndex];
                string estado = row.Cells["colEstado"].Value?.ToString() ?? "Activo";

                row.Cells["colEstado"].Value =
                    string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase) ? "Inactivo" : "Activo";

                SetAccionSegunEstado(row);
            }
            else if (colName == "colEditar")
            {
                MessageBox.Show("Editar cliente (lógica pendiente).", "Info",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DGListaClientes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_bloquearEstadoPorRol && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DGListaClientes.Columns[e.ColumnIndex].Name == "colAccion")
                    DGListaClientes.Cursor = Cursors.No;
            }
        }

        private void DGListaClientes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DGListaClientes.Cursor = Cursors.Default;
        }

        private void SetAccionSegunEstado(DataGridViewRow row)
        {
            string estado = row.Cells["colEstado"].Value?.ToString() ?? "Activo";
            var accionCell = row.Cells["colAccion"] as DataGridViewButtonCell;

            if (string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase))
            {
                accionCell.Value = "Inactivar";
                accionCell.Style.BackColor = Color.LightCoral;   
                accionCell.Style.ForeColor = Color.Black;
            }
            else
            {
                accionCell.Value = "Activar";
                accionCell.Style.BackColor = Color.LightSkyBlue; 
                accionCell.Style.ForeColor = Color.Black;
            }
        }
    }
}
