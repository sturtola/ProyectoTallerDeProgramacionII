using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados.Ventas
{
    public partial class FGenerarVenta : Form
    {
        private Panel? _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);

        private class Prod
        {
            public string Nombre { get; set; } = "";
            public decimal Precio { get; set; }
            public override string ToString() => Nombre;
        }

        private readonly List<Prod> _catalogo = new()
        {
            new Prod{Nombre="Elite Woman",    Precio=365000.50m},
            new Prod{Nombre="Equation Light", Precio=168590.90m}
        };

        public FGenerarVenta()
        {
            InitializeComponent();

            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();

            CargarClientes();
            ConfigurarColumnaProducto();

            BAgregarProducto.Click += (_, __) => AgregarFilaVacia();

            DGItemsVenta.CellValueChanged += DGItemsVenta_CellValueChanged;
            DGItemsVenta.CurrentCellDirtyStateChanged += DGItemsVenta_CurrentCellDirtyStateChanged;
            DGItemsVenta.EditingControlShowing += DGItemsVenta_EditingControlShowing;

            DGItemsVenta.RowsAdded += DGItemsVenta_RowsAdded;
            DGItemsVenta.CellContentClick += DGItemsVenta_CellContentClick;

            CBEnvio.CheckedChanged += (_, __) => ActualizarTotalGeneral();

            ActualizarTotalGeneral();
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
                var c = this.Controls[0];
                this.Controls.RemoveAt(0);
                _scrollHost.Controls.Add(c);
            }

            this.Controls.Add(_scrollHost);
            _scrollHost.AutoScrollMinSize = _designContentSize;
            UpdateScrollbars();
        }

        private void UpdateScrollbars()
        {
            if (_scrollHost == null) return;

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

        private void CargarClientes()
        {
            var clientes = new[]
            {
                "Romina Álvarez - 40123456",
                "Diego Mansilla - 40999888"
            }.ToList();

            CBCliente.DisplayMember = null; 
            CBCliente.ValueMember = null;
            CBCliente.DataSource = clientes;

            CBCliente.DropDownStyle = ComboBoxStyle.DropDown;
            CBCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            CBCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            DTPFecha.Value = DateTime.Today;
        }

        private void ConfigurarColumnaProducto()
        {
            if (colProducto is DataGridViewComboBoxColumn c)
            {
                c.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                c.FlatStyle = FlatStyle.Flat;
                c.DataSource = _catalogo.Select(p => p.Nombre).ToList();
            }
        }

        private void AgregarFilaVacia()
        {
            int row = DGItemsVenta.Rows.Add();
            DGItemsVenta.Rows[row].Cells[colCantidad.Name].Value = 1;
            RecalcularFila(row);
        }

        private void DGItemsVenta_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (DGItemsVenta.IsCurrentCellDirty)
                DGItemsVenta.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DGItemsVenta_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = DGItemsVenta.Columns[e.ColumnIndex].Name;

            if (colName == colProducto.Name)
            {
                string? nombre = DGItemsVenta.Rows[e.RowIndex].Cells[colProducto.Name].Value?.ToString();
                var p = _catalogo.FirstOrDefault(x => x.Nombre.Equals(nombre ?? "", StringComparison.OrdinalIgnoreCase));
                DGItemsVenta.Rows[e.RowIndex].Cells[colPrecioUnitario.Name].Value = p?.Precio ?? 0m;
                RecalcularFila(e.RowIndex);
            }
            else if (colName == colCantidad.Name)
            {
                RecalcularFila(e.RowIndex);
            }
        }

        private void DGItemsVenta_RowsAdded(object? sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                var r = DGItemsVenta.Rows[e.RowIndex + i];
                var btnCell = r.Cells[colVer.Name];
                btnCell.Style.BackColor = Color.LightSkyBlue;
                btnCell.Style.ForeColor = Color.Black;
                btnCell.Style.SelectionBackColor = Color.SteelBlue;
                btnCell.Style.SelectionForeColor = Color.White;
            }
        }

        private void DGItemsVenta_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (DGItemsVenta.Columns[e.ColumnIndex].Name == colVer.Name)
            {
                var row = DGItemsVenta.Rows[e.RowIndex];
                string? nombre = row.Cells[colProducto.Name].Value?.ToString();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Primero debes seleccionar un producto.", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var p = _catalogo.FirstOrDefault(x => x.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
                if (p == null)
                {
                    MessageBox.Show("No se encontró el producto seleccionado.", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string detalle = $"Producto: {p.Nombre}\n" +
                                 $"Precio: {p.Precio:N2}";
                MessageBox.Show(detalle, "Características del producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DGItemsVenta_EditingControlShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DGItemsVenta.CurrentCell == null) return;

            var colName = DGItemsVenta.Columns[DGItemsVenta.CurrentCell.ColumnIndex].Name;

            if (colName == colCantidad.Name && e.Control is TextBox tb)
            {
                tb.KeyPress -= SoloEnteros_KeyPress;
                tb.KeyPress += SoloEnteros_KeyPress;
            }

            if (colName == colProducto.Name && e.Control is ComboBox cb)
            {
                cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.AutoCompleteSource = AutoCompleteSource.ListItems;
                cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb.Font = new Font("Century Gothic", 14F, FontStyle.Regular);
            }

            
        }

        private void SoloEnteros_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void RecalcularFila(int rowIndex)
        {
            var row = DGItemsVenta.Rows[rowIndex];
            if (row.IsNewRow) return;

            decimal.TryParse(row.Cells[colPrecioUnitario.Name].Value?.ToString(), out var precio);
            int.TryParse(row.Cells[colCantidad.Name].Value?.ToString(), out var cantidad);
            if (cantidad <= 0) cantidad = 1;

            row.Cells[colCantidad.Name].Value = cantidad;
            row.Cells[colPrecioTotal.Name].Value = precio * cantidad;

            ActualizarTotalGeneral();
        }

        private void ActualizarTotalGeneral()
        {
            decimal subtotal = 0m;
            foreach (DataGridViewRow r in DGItemsVenta.Rows)
            {
                if (r.IsNewRow) continue;
                if (decimal.TryParse(r.Cells[colPrecioTotal.Name].Value?.ToString(), out var t))
                    subtotal += t;
            }
            decimal envio = CBEnvio.Checked ? 5000m : 0m;
            decimal total = subtotal + envio;

            LTotalValor.Text = total.ToString("N2");
        }
    }
}
