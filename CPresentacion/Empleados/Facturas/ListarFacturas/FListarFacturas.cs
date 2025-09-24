using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados.Facturas.ListarFacturas
{
    public partial class FListarFacturas : Form
    {
        private Panel _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);

        private readonly string rolActual;

        // 👇 Constructor usado en tiempo de diseño y por código viejo sin rol
        public FListarFacturas() : this(SafeRol()) { }

        // 👇 Constructor principal con rol explícito
        public FListarFacturas(string rolUsuario)
        {
            InitializeComponent();

            rolActual = rolUsuario ?? string.Empty;

            DGListaFacturas.EnableHeadersVisualStyles = false;
            DGListaFacturas.RowHeadersVisible = false;

            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();

            FormatearColumnaImporte();
            CargarFacturasDeEjemplo();

            // 🔒 restricciones por rol
            AplicarRestriccionesPorRol();
        }

        private static string SafeRol()
        {
            // Intentamos leer SesionActual.Rol pero sin romper el diseñador
            try
            {
                return AurenPadelStore.SesionActual.Rol ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private void FormatearColumnaImporte()
        {
            var col = DGListaFacturas.Columns.Cast<DataGridViewColumn>()
                           .FirstOrDefault(c => c.Name == "colImporte") as DataGridViewTextBoxColumn;
            if (col != null)
            {
                col.DefaultCellStyle.Format = "N2";
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Encabezados centrados
            DGListaFacturas.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }

        private void CargarFacturasDeEjemplo()
        {
            DGListaFacturas.Rows.Add(
                "F-0001-00000001",
                new DateTime(2025, 9, 1).ToShortDateString(),
                "A",
                "Romina Álvarez",
                "40123456",
                "VTA-000123",
                125000.00m
            );

            DGListaFacturas.Rows.Add(
                "F-0001-00000002",
                new DateTime(2025, 9, 3).ToShortDateString(),
                "B",
                "Diego Mansilla",
                "40999888",
                "VTA-000124",
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
            if (rolActual.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                var colEliminar = DGListaFacturas.Columns["colEliminar"] as DataGridViewButtonColumn;
                if (colEliminar != null)
                {
                    // Bloqueamos la acción de clic
                    DGListaFacturas.CellClick += (s, e) =>
                    {
                        if (e.RowIndex >= 0 && e.ColumnIndex == colEliminar.Index)
                        {
                            MessageBox.Show("El rol VENDEDOR no puede eliminar facturas.",
                                            "Acción bloqueada",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                        }
                    };

                    // Cambiamos el cursor cuando se pasa por encima
                    DGListaFacturas.CellMouseEnter += (s, e) =>
                    {
                        if (e.RowIndex >= 0 && e.ColumnIndex == colEliminar.Index)
                            DGListaFacturas.Cursor = Cursors.No;
                    };

                    DGListaFacturas.CellMouseLeave += (s, e) =>
                    {
                        if (e.RowIndex >= 0 && e.ColumnIndex == colEliminar.Index)
                            DGListaFacturas.Cursor = Cursors.Default;
                    };
                }
            }
        }



    }
}
