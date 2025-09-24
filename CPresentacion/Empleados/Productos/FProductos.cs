using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados.Productos
{
    public partial class FProductos : Form
    {
        private Panel _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);

        public FProductos()
        {
            InitializeComponent();

            // Datos de ejemplo
            CargarProductoDePrueba();

            // Eventos de grilla
            DGListaProd.CellContentClick += DGListaProd_CellContentClick;
            DGListaProd.RowsAdded += (s, e) =>
            {
                for (int i = 0; i < e.RowCount; i++)
                    SetAccionSegunEstado(DGListaProd.Rows[e.RowIndex + i]);
            };
            DGListaProd.CellMouseMove += DGListaProd_CellMouseMove;
            DGListaProd.CellMouseLeave += (s, e) => DGListaProd.Cursor = Cursors.Default;

            // Scroll host (barras cuando el MDI está chico; sin barras al maximizar)
            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();

            // Permisos por rol
            this.Load += FProductos_Load;
        }

        private void FProductos_Load(object sender, EventArgs e)
        {
            // GERENTE: ver panel igual, pero no interactuar (solo botón gris)
            if (SesionActual.Rol != null &&
                SesionActual.Rol.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
            {
                BloquearInteraccionSinCambiarEstilo(PAgregarProducto, BAgregarProducto,
                    "Solo Vendedor/es o Administrador/es pueden agregar productos.");
            }
        }

        // ====== UI helpers ======

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

        /// <summary>
        /// Bloquea la interacción del panel sin modificar su estilo visual.
        /// TextBox -> ReadOnly conservando BackColor; sin TabStop ni caret.
        /// Botón principal -> Disabled (gris). Cursor "No" y tooltip opcional.
        /// </summary>
        private void BloquearInteraccionSinCambiarEstilo(Panel panel, Button botonPrincipal, string tooltip = "")
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
                    tb.GotFocus += (s, e) => DGListaProd.Focus();
                    tb.ShortcutsEnabled = false;
                }
                else
                {
                    c.TabStop = false;
                }
            }

            if (botonPrincipal != null)
            {
                botonPrincipal.Enabled = false; // se verá gris por ser Button estándar
                if (!string.IsNullOrWhiteSpace(tooltip))
                {
                    var tt = new ToolTip();
                    tt.SetToolTip(botonPrincipal, tooltip);
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

            panel.MouseDown += (s, e) => DGListaProd.Focus();
        }

        // ====== Datos de ejemplo ======

        private void CargarProductoDePrueba()
        {
            // Ajustá las rutas si fuese necesario
            Image imgAct = Image.FromFile(@"C:\Proyecto de Escritorio\ProyectoTallerDeProgramacionII\img\bullpadelEliteWoman.png");
            Image imgIna = Image.FromFile(@"C:\Proyecto de Escritorio\ProyectoTallerDeProgramacionII\img\noxEquationLightAdvanced.png");

            int r1 = DGListaProd.Rows.Add(
                imgAct, "Elite Woman", "BullPadel", "Goma Eva",
                "Descripción de prueba", "Activo", 32, 365000.50m
            );
            SetAccionSegunEstado(DGListaProd.Rows[r1]);

            int r2 = DGListaProd.Rows.Add(
                imgIna, "Equation Light", "Nox", "Goma Eva",
                "Descripción de prueba", "Inactivo", 12, 168590.90m
            );
            SetAccionSegunEstado(DGListaProd.Rows[r2]);
        }

        // ====== Lógica de estado / acción ======

        private void SetAccionSegunEstado(DataGridViewRow row)
        {
            var estado = (row.Cells["colEstado"].Value?.ToString() ?? "Activo").Trim();
            var accionCell = row.Cells["colAccion"] as DataGridViewButtonCell;
            if (accionCell == null) return;

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

        private bool AccionBloqueadaPorRol =>
            SesionActual.Rol != null &&
            SesionActual.Rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase);

        private void DGListaProd_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Si es la columna Acción y el rol es VENDEDOR → cursor de bloqueo
            if (DGListaProd.Columns[e.ColumnIndex].Name == "colAccion" && AccionBloqueadaPorRol)
            {
                DGListaProd.Cursor = Cursors.No;
                var tt = new ToolTip();
                tt.SetToolTip(DGListaProd, "No tenés permisos para cambiar el estado.");
            }
            else
            {
                DGListaProd.Cursor = Cursors.Default;
            }
        }

        private void DGListaProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = DGListaProd.Columns[e.ColumnIndex].Name;

            if (colName == "colAccion")
            {
                // VENDEDOR: bloquear acción (sin modificar estética)
                if (AccionBloqueadaPorRol)
                {
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("No tenés permisos para activar/inactivar productos.",
                                    "Permisos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var row = DGListaProd.Rows[e.RowIndex];
                string estado = row.Cells["colEstado"].Value?.ToString() ?? "Activo";

                // Toggle de estado
                if (string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase))
                    row.Cells["colEstado"].Value = "Inactivo";
                else
                    row.Cells["colEstado"].Value = "Activo";

                // Refrescar texto y color del botón
                SetAccionSegunEstado(row);
            }
        }

        // ====== Alta (validaciones visuales) ======

        private void BAgregarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBNombreP.Text) ||
                string.IsNullOrWhiteSpace(TBDescP.Text) ||
                string.IsNullOrWhiteSpace(TBMarcaP.Text) ||
                string.IsNullOrWhiteSpace(TBMaterialP.Text) ||
                string.IsNullOrWhiteSpace(TBPrecioP.Text) ||
                string.IsNullOrWhiteSpace(TBStockP.Text))
            {
                MessageBox.Show("Por favor, completá todos los campos obligatorios.",
                                "Campos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            var soloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
            if (!soloLetras.IsMatch(TBNombreP.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBNombreP.Focus();
                return;
            }

            var letrasNumeros = new Regex(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s.,-]*$");
            if (!letrasNumeros.IsMatch(TBDescP.Text) ||
                !letrasNumeros.IsMatch(TBMarcaP.Text) ||
                !letrasNumeros.IsMatch(TBMaterialP.Text))
            {
                MessageBox.Show("Algún campo contiene caracteres inválidos.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(TBPrecioP.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número mayor a 0.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBPrecioP.Focus();
                return;
            }

            if (!int.TryParse(TBStockP.Text, out int stock) || stock <= 0)
            {
                MessageBox.Show("El stock debe ser un número entero mayor a 0.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBStockP.Focus();
                return;
            }

            int r = DGListaProd.Rows.Add(
                null,
                TBNombreP.Text.Trim(),
                TBMarcaP.Text.Trim(),
                TBMaterialP.Text.Trim(),
                TBDescP.Text.Trim(),
                "Activo",
                stock,
                precio
            );
            SetAccionSegunEstado(DGListaProd.Rows[r]);

            MessageBox.Show("Producto agregado correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            LimpiarCampos();
            TBNombreP.Focus();
        }

        private void TBPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void TBStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void LimpiarCampos()
        {
            TBNombreP.Clear();
            TBDescP.Clear();
            TBMarcaP.Clear();
            TBMaterialP.Clear();
            TBPrecioP.Clear();
            TBStockP.Clear();
        }
    }
}
