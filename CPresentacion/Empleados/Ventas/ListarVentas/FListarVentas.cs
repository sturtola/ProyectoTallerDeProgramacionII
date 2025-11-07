using AurenPadelStore.CDatos;
using AurenPadelStore.CLogica;
using AurenPadelStore.CPresentacion.Empleados.Facturas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados.Ventas.ListarVentas
{
    public partial class FListarVentas : Form
    {
        private Panel _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);

        private readonly string _rolActual;
        private readonly int _idUsuarioActual;
        private readonly CultureInfo _esAR = new CultureInfo("es-AR");

        private readonly VentaLogica _ventaLogica = new VentaLogica();
        private List<VentaListado> _ventasBase = new();
        private List<VentaListado> _vista = new();

        // ===== Constructores =====
        public FListarVentas() : this(SafeRol(), SafeIdUsuario()) { }
        public FListarVentas(string rolUsuario) : this(rolUsuario, SafeIdUsuario()) { }
        public FListarVentas(string rolUsuario, int idUsuario)
        {
            InitializeComponent();

            _rolActual = rolUsuario ?? string.Empty;
            _idUsuarioActual = idUsuario;

            DGListaVentas.EnableHeadersVisualStyles = false;
            DGListaVentas.RowHeadersVisible = false;

            // Columna oculta para ID de venta (si no está en el diseñador)
            EnsureHiddenIdColumn();

            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();

            ConfigurarFiltros();
            FormatearColumnas();
            WireEventos();

            CargarVentasDesdeBD();
            RefrescarGrid();
            AplicarRestriccionesPorRol();
        }

        // ===== Sesión segura =====
        private static string SafeRol()
        {
            try { return AurenPadelStore.CEntidades.SesionActual.Rol ?? string.Empty; }
            catch { return string.Empty; }
        }
        private static int SafeIdUsuario()
        {
            try { return AurenPadelStore.CEntidades.SesionActual.Id_UsuarioActual; }
            catch { return 0; }
        }

        // ===== Columnas / formato =====
        private void EnsureHiddenIdColumn()
        {
            if (!DGListaVentas.Columns.Contains("colIdVenta"))
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "colIdVenta",
                    HeaderText = "IdVenta",
                    Visible = false
                };
                DGListaVentas.Columns.Add(col);
            }
        }

        private void ConfigurarFiltros()
        {
            CBFiltroV.Items.Clear();
            CBFiltroV.Items.AddRange(new object[] {
                "Sin filtro",
                "Fecha (más reciente)",
                "Fecha (más antigua)",
                "Importe (mayor a menor)",
                "Importe (menor a mayor)",
                "Nombre A-Z",
                "Nombre Z-A",
                "Apellido A-Z",
                "Apellido Z-A"
            });
            CBFiltroV.SelectedIndex = 0;
        }

        private void FormatearColumnas()
        {
            var colImporte = DGListaVentas.Columns["colImporte"] as DataGridViewTextBoxColumn;
            if (colImporte != null)
            {
                colImporte.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colImporte.DefaultCellStyle.FormatProvider = _esAR;
                colImporte.DefaultCellStyle.Format = "C2";
            }

            var colFecha = DGListaVentas.Columns["colFecha"] as DataGridViewTextBoxColumn;
            if (colFecha != null)
                colFecha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGListaVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // ===== Eventos UI =====
        private void WireEventos()
        {
            TBBuscarV.TextChanged -= TBBuscarV_TextChanged;
            TBBuscarV.TextChanged += TBBuscarV_TextChanged;

            CBFiltroV.SelectedIndexChanged -= CBFiltroV_SelectedIndexChanged;
            CBFiltroV.SelectedIndexChanged += CBFiltroV_SelectedIndexChanged;

            DGListaVentas.CellContentClick -= DGListaVentas_CellContentClick;
            DGListaVentas.CellContentClick += DGListaVentas_CellContentClick;
        }

        // ===== Carga desde BD =====
        private void CargarVentasDesdeBD()
        {
            _ventasBase = _ventaLogica.ListadoPorUsuario(_idUsuarioActual) ?? new List<VentaListado>();
            _vista = _ventasBase.ToList();
        }

        // ===== Buscar / ordenar =====
        private void TBBuscarV_TextChanged(object? sender, EventArgs e) => AplicarBusquedaYOrden();
        private void CBFiltroV_SelectedIndexChanged(object? sender, EventArgs e) => AplicarBusquedaYOrden();

        private void AplicarBusquedaYOrden()
        {
            string q = (TBBuscarV.Text ?? "").Trim().ToLowerInvariant();

            var filtrado = _ventasBase.Where(v =>
                   (v.Nombre_Cliente ?? "").ToLower().Contains(q)
                || (v.Apellido_Cliente ?? "").ToLower().Contains(q)
                || v.Dni_Cliente.ToString().Contains(q)
                || v.id_Venta.ToString().Contains(q));

            _vista = Ordenar(filtrado.ToList(), CBFiltroV.SelectedItem?.ToString());
            RefrescarGrid();
        }

        private List<VentaListado> Ordenar(List<VentaListado> src, string? criterio)
        {
            return criterio switch
            {
                "Fecha (más reciente)" => src.OrderByDescending(v => v.Fecha_Venta).ToList(),
                "Fecha (más antigua)" => src.OrderBy(v => v.Fecha_Venta).ToList(),
                "Importe (mayor a menor)" => src.OrderByDescending(v => v.ImporteTotal).ToList(),
                "Importe (menor a mayor)" => src.OrderBy(v => v.ImporteTotal).ToList(),
                "Nombre A-Z" => src.OrderBy(v => v.Nombre_Cliente).ThenBy(v => v.Apellido_Cliente).ToList(),
                "Nombre Z-A" => src.OrderByDescending(v => v.Nombre_Cliente).ThenByDescending(v => v.Apellido_Cliente).ToList(),
                "Apellido A-Z" => src.OrderBy(v => v.Apellido_Cliente).ThenBy(v => v.Nombre_Cliente).ToList(),
                "Apellido Z-A" => src.OrderByDescending(v => v.Apellido_Cliente).ThenByDescending(v => v.Nombre_Cliente).ToList(),
                _ => src
            };
        }

        // ===== Render en grilla =====
        private void RefrescarGrid()
        {
            DGListaVentas.SuspendLayout();
            DGListaVentas.Rows.Clear();

            foreach (var v in _vista)
            {
                // Nota: colNroVenta es visible con el formato “VTA-000123”
                //       colIdVenta (oculta) guarda el entero real para abrir factura
                int rowIndex = DGListaVentas.Rows.Add(
                    $"VTA-{v.id_Venta:D6}",                 // colNroVenta
                    v.Fecha_Venta.ToString("dd/MM/yyyy"),   // colFecha
                    $"{v.Nombre_Cliente} {v.Apellido_Cliente}", // colCliente
                    v.Dni_Cliente.ToString(),               // colDni
                    v.CantidadProductos,                    // colCantidad
                    v.ImporteTotal                          // colImporte
                );
                DGListaVentas.Rows[rowIndex].Cells["colIdVenta"].Value = v.id_Venta; // oculta
            }

            DGListaVentas.ResumeLayout();
        }

        // ===== Botones por fila (UN SOLO HANDLER) =====
        private void DGListaVentas_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var colName = DGListaVentas.Columns[e.ColumnIndex].Name;

            if (colName == "colVerV")
            {
                var idCell = DGListaVentas.Rows[e.RowIndex].Cells["colIdVenta"].Value;
                if (idCell == null || !int.TryParse(idCell.ToString(), out int idVenta) || idVenta <= 0)
                {
                    MessageBox.Show("No se pudo obtener el N° de venta.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var f = new FVerFactura(idVenta);
                f.ShowDialog(this);
            }
            else if (colName == "colEliminar")
            {
                if (_rolActual.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El rol VENDEDOR no puede eliminar ventas.",
                        "Acción bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // TODO: Implementar eliminación si corresponde
                MessageBox.Show("Eliminar (pendiente de implementar).", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ===== Scroll host =====
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

        // ===== Restricciones por rol =====
        private void AplicarRestriccionesPorRol()
        {
            if (_rolActual.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                var colEliminar = DGListaVentas.Columns["colEliminar"] as DataGridViewButtonColumn;
                if (colEliminar != null)
                {
                    DGListaVentas.CellClick += (s, e) =>
                    {
                        if (e.RowIndex >= 0 && e.ColumnIndex == colEliminar.Index)
                        {
                            MessageBox.Show("El rol VENDEDOR no puede eliminar ventas.",
                                            "Acción bloqueada",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                    };

                    DGListaVentas.CellMouseEnter += (s, e) =>
                    {
                        if (e.RowIndex >= 0 && e.ColumnIndex == colEliminar.Index)
                            DGListaVentas.Cursor = Cursors.No;
                    };
                    DGListaVentas.CellMouseLeave += (s, e) =>
                    {
                        if (e.RowIndex >= 0 && e.ColumnIndex == colEliminar.Index)
                            DGListaVentas.Cursor = Cursors.Default;
                    };
                }
            }

            // Manito para otros botones
            DGListaVentas.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0 &&
                    DGListaVentas.Columns[e.ColumnIndex] is DataGridViewButtonColumn btnCol &&
                    btnCol.Name != "colEliminar")
                {
                    DGListaVentas.Cursor = Cursors.Hand;
                }
            };
            DGListaVentas.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0 &&
                    DGListaVentas.Columns[e.ColumnIndex] is DataGridViewButtonColumn btnCol &&
                    btnCol.Name != "colEliminar")
                {
                    DGListaVentas.Cursor = Cursors.Default;
                }
            };
        }
    }
}
