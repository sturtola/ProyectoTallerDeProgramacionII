using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados.Ventas.ListarVentas
{
    public partial class FListarVentas : Form
    {
        private Panel _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);

        private readonly string rolActual;

        // Constructor usado por el diseñador / compatibilidad
        public FListarVentas() : this(SafeRol()) { }

        // Constructor principal con rol
        public FListarVentas(string rolUsuario)
        {
            InitializeComponent();

            rolActual = rolUsuario ?? string.Empty;

            DGListaVentas.EnableHeadersVisualStyles = false;
            DGListaVentas.RowHeadersVisible = false;

            // Scroll como en los otros forms
            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();

            // Formato y datos de ejemplo
            FormatearColumnas();
            CargarVentasDeEjemplo();

            // Restricciones por rol
            AplicarRestriccionesPorRol();
        }

        private static string SafeRol()
        {
            try { return AurenPadelStore.SesionActual.Rol ?? string.Empty; }
            catch { return string.Empty; }
        }

        private void FormatearColumnas()
        {
            // Importe al centro y con dos decimales
            var colImporte = DGListaVentas.Columns["colImporte"] as DataGridViewTextBoxColumn;
            if (colImporte != null)
            {
                colImporte.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colImporte.DefaultCellStyle.Format = "N2";
            }

            // Headers centrados
            DGListaVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CargarVentasDeEjemplo()
        {
            // Nro Venta, Fecha, Cliente, Documento, Cantidad, Importe
            DGListaVentas.Rows.Add(
                "VTA-000123",
                new DateTime(2025, 9, 1).ToShortDateString(),
                "Romina Álvarez",
                "40123456",
                3,               // cantidad de productos
                125000.00m
            );

            DGListaVentas.Rows.Add(
                "VTA-000124",
                new DateTime(2025, 9, 3).ToShortDateString(),
                "Diego Mansilla",
                "40999888",
                2,               // cantidad de productos
                86500.50m
            );
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
            // El VENDEDOR NO puede eliminar ventas
            if (rolActual.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                var colEliminar = DGListaVentas.Columns["colEliminar"] as DataGridViewButtonColumn;
                if (colEliminar != null)
                {
                    // Bloquear acción de clic en eliminar
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

                    // Cursor de prohibido al pasar por encima del botón eliminar
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

            // Cursor "manito" para botones habilitados (por ejemplo, Ver)
            DGListaVentas.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0 &&
                    DGListaVentas.Columns[e.ColumnIndex] is DataGridViewButtonColumn btnCol &&
                    btnCol.Name != "colEliminar") // excepto eliminar (que puede estar bloqueado)
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
