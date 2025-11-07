using System;
using System.Globalization;
using System.Windows.Forms;
using AurenPadelStore.CDatos;

namespace AurenPadelStore.CPresentacion.Empleados.Facturas
{
    public partial class FVerFactura : Form
    {
        private readonly CultureInfo _esAR = new("es-AR");
        private readonly VentaDatos _ventaDatos = new();

        // ctor para diseñador
        public FVerFactura()
        {
            InitializeComponent();
            PrepararGrilla();
        }

        // ctor real: pasás el id de venta
        public FVerFactura(int idVenta) : this()
        {
            CargarFactura(idVenta);
        }

        private void PrepararGrilla()
        {
            DGProdFact.Rows.Clear();
            DGProdFact.Columns["ColPrecioUnitario"].DefaultCellStyle.Format = "C2";
            DGProdFact.Columns["ColSubtotal"].DefaultCellStyle.Format = "C2";
        }

        private void CargarFactura(int idVenta)
        {
            var f = _ventaDatos.ObtenerFacturaPorId(idVenta);

            // Cabecera
            TBNroFact.Text = f.IdVenta.ToString();
            TBFechaFact.Text = f.Fecha.ToString("dd/MM/yyyy");
            TBMetodoPago.Text = f.MetodoPago;
            TBVendedor.Text = $"{f.UsuarioNombre} {f.UsuarioApellido}";

            // Cliente
            TBNyAC.Text = $"{f.ClienteNombre} {f.ClienteApellido}";
            TBDniC.Text = f.ClienteDni.ToString();
            TBDirecC.Text = f.ClienteDireccion;
            TBTelC.Text = f.ClienteTelefono;

            // Importes (ya vienen calculados con la regla del envío fijo)
            TBSubtotal.Text = f.Subtotal.ToString("C2", _esAR);
            TBEnvio.Text = f.CostoEnvio.ToString("C2", _esAR);
            TBImporteT.Text = f.Total.ToString("C2", _esAR);

            // Ítems
            DGProdFact.Rows.Clear();
            foreach (var it in f.Items)
            {
                DGProdFact.Rows.Add(
                    it.NombreProducto,
                    it.PrecioUnitario.ToString("C2", _esAR),
                    it.Cantidad,
                    (it.PrecioUnitario * it.Cantidad).ToString("C2", _esAR)
                );
            }
        }
    }
}
