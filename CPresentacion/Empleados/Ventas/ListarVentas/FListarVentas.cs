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

        public FListarVentas() : this(SafeRol(), SafeIdUsuario()) { }
        public FListarVentas(string rolUsuario) : this(rolUsuario, SafeIdUsuario()) { }
        public FListarVentas(string rolUsuario, int idUsuario)
        {
            InitializeComponent();

            _rolActual = rolUsuario ?? string.Empty;
            _idUsuarioActual = idUsuario;

            DGListaVentas.EnableHeadersVisualStyles = false;
            DGListaVentas.RowHeadersVisible = false;

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

        #region Setup (Carga, Config, Scroll, Rol)
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

            if (_rolActual.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
            {
                CBFiltroV.Items.Add("Vendedor A-Z");
                CBFiltroV.Items.Add("Vendedor Z-A");
            }

            CBFiltroV.SelectedIndex = 0;
        }

        private void FormatearColumnas()
        {
            if (_rolActual.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
            {
                if (!DGListaVentas.Columns.Contains("colVendedor"))
                {
                    var colVendedor = new DataGridViewTextBoxColumn
                    {
                        Name = "colVendedor",
                        HeaderText = "Vendedor",
                        Width = 180,
                        DisplayIndex = 4
                    };
                    DGListaVentas.Columns.Add(colVendedor);
                }
            }

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

        private void WireEventos()
        {
            TBBuscarV.TextChanged -= TBBuscarV_TextChanged;
            TBBuscarV.TextChanged += TBBuscarV_TextChanged;

            CBFiltroV.SelectedIndexChanged -= CBFiltroV_SelectedIndexChanged;
            CBFiltroV.SelectedIndexChanged += CBFiltroV_SelectedIndexChanged;

            DGListaVentas.CellContentClick -= DGListaVentas_CellContentClick;
            DGListaVentas.CellContentClick += DGListaVentas_CellContentClick;
        }

        private void CargarVentasDesdeBD()
        {
            try
            {
                int idParaFiltrar = 0;
                if (!_rolActual.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
                {
                    idParaFiltrar = _idUsuarioActual;
                }
                _ventasBase = _ventaLogica.ListadoPorUsuario(idParaFiltrar) ?? new List<VentaListado>();
                _vista = _ventasBase.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el listado de ventas. Verifique la conexión.\n\nDetalle: " + ex.Message,
                                "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ventasBase = new List<VentaListado>();
                _vista = new List<VentaListado>();
            }
        }
        #endregion

        #region Filtro, Orden y Refresh (Sin Cambios)
        private void TBBuscarV_TextChanged(object? sender, EventArgs e) => AplicarBusquedaYOrden();
        private void CBFiltroV_SelectedIndexChanged(object? sender, EventArgs e) => AplicarBusquedaYOrden();

        private void AplicarBusquedaYOrden()
        {
            string q = (TBBuscarV.Text ?? "").Trim();
            string qLower = q.ToLowerInvariant();

            IEnumerable<VentaListado> filtrado = _ventasBase;

            if (!string.IsNullOrEmpty(q))
            {
                filtrado = _ventasBase.Where(v =>
                       (v.Nombre_Cliente ?? "").ToLowerInvariant().Contains(qLower)
                    || (v.Apellido_Cliente ?? "").ToLowerInvariant().Contains(qLower)
                    || v.Dni_Cliente.ToString().Contains(q)
                    || v.id_Venta.ToString().Contains(q)
                    || $"VTA-{v.id_Venta:D6}".IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0
                    || (_rolActual.Equals("Gerente", StringComparison.OrdinalIgnoreCase) &&
                        (v.VendedorNombreCompleto ?? "").ToLowerInvariant().Contains(qLower))
                    );
            }

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
                "Vendedor A-Z" => src.OrderBy(v => v.VendedorNombreCompleto).ToList(),
                "Vendedor Z-A" => src.OrderByDescending(v => v.VendedorNombreCompleto).ToList(),
                _ => src
            };
        }

        private void RefrescarGrid()
        {
            DGListaVentas.SuspendLayout();
            DGListaVentas.Rows.Clear();

            foreach (var v in _vista)
            {
                int rowIndex = DGListaVentas.Rows.Add();
                var row = DGListaVentas.Rows[rowIndex];

                row.Cells["colIdVenta"].Value = v.id_Venta;
                row.Cells["colNroVenta"].Value = $"VTA-{v.id_Venta:D6}";
                row.Cells["colFecha"].Value = v.Fecha_Venta.ToString("dd/MM/yyyy");
                row.Cells["colCliente"].Value = $"{v.Nombre_Cliente} {v.Apellido_Cliente}";
                row.Cells["colDni"].Value = v.Dni_Cliente.ToString();
                row.Cells["colCantidad"].Value = v.CantidadProductos;
                row.Cells["colImporte"].Value = v.ImporteTotal;

                if (_rolActual.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
                {
                    row.Cells["colVendedor"].Value = v.VendedorNombreCompleto;
                }
            }

            DGListaVentas.ResumeLayout();
        }
        #endregion

        // ---------- ¡¡¡MÉTODO MODIFICADO!!! ----------
        private void DGListaVentas_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var colName = DGListaVentas.Columns[e.ColumnIndex].Name;
            var row = DGListaVentas.Rows[e.RowIndex]; // Obtenemos la fila

            if (colName == "colVerV")
            {
                var idCell = row.Cells["colIdVenta"].Value; // Usamos 'row'
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
                // 1. (Validación de rol que ya tenías)
                if (_rolActual.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El rol VENDEDOR no puede eliminar ventas.",
                        "Acción bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Obtener el ID
                var idCell = row.Cells["colIdVenta"].Value;
                if (idCell == null || !int.TryParse(idCell.ToString(), out int idVenta) || idVenta <= 0)
                {
                    MessageBox.Show("No se pudo obtener el N° de venta para anular.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3. Confirmación
                string nroVentaFormateado = row.Cells["colNroVenta"].Value?.ToString() ?? $"ID {idVenta}";
                var confirmacion = MessageBox.Show(
                    $"¿Está seguro de que desea ANULAR la venta {nroVentaFormateado}?\n\n" +
                    "Esta acción es irreversible y devolverá el stock de los productos al inventario.",
                    "Confirmar Anulación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning); // Ícono de advertencia

                if (confirmacion != DialogResult.Yes)
                {
                    return; // El usuario canceló
                }

                // 4. Ejecución
                try
                {
                    // Llamamos a la lógica que llama a los datos (que borra la Venta)
                    _ventaLogica.AnularVenta(idVenta);

                    MessageBox.Show($"Venta {nroVentaFormateado} anulada con éxito. El stock ha sido restaurado.",
                                    "Anulación Completa",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // 5. Refrescar la grilla (ya no vemos la venta)
                    CargarVentasDesdeBD();
                    RefrescarGrid();
                }
                catch (Exception ex)
                {
                    // Mensaje de error amigable
                    MessageBox.Show("Ocurrió un error al anular la venta. Es posible que ya haya sido procesada o eliminada.\n\nDetalle: " + ex.Message,
                                    "Error de Anulación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        #region Scroll y Layout (Sin Cambios)
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
        #endregion
    }
}