using System;
using System.Globalization;
using System.Windows.Forms;
using AurenPadelStore.CDatos;
using System.Drawing.Printing; // <-- Necesario para imprimir
using System.Drawing; // <-- Necesario para imprimir

namespace AurenPadelStore.CPresentacion.Empleados.Facturas
{
    public partial class FVerFactura : Form
    {
        private readonly CultureInfo _esAR = new("es-AR");
        private readonly VentaDatos _ventaDatos = new();

        // --- Para Impresión ---
        private PrintDocument _printDoc = new PrintDocument();
        private int _idVentaFactura; // Guardamos el ID para imprimir
        // --- Fin Impresión ---

        // ctor para diseñador
        public FVerFactura()
        {
            InitializeComponent();
            PrepararGrilla();

            // --- Conectar eventos de impresión ---
            _printDoc.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            BImprimiFact.Click += BImprimiFact_Click;
            // --- Fin Conexión ---
        }

        // ctor real: pasás el id de venta
        public FVerFactura(int idVenta) : this()
        {
            _idVentaFactura = idVenta; // <-- Guardar ID
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
            TBNroFact.Text = f.IdVenta.ToString("D6"); // Formateado
            TBFechaFact.Text = f.Fecha.ToString("dd/MM/yyyy");
            TBMetodoPago.Text = f.MetodoPago;
            TBVendedor.Text = $"{f.UsuarioNombre} {f.UsuarioApellido}";

            // Cliente
            TBNyAC.Text = $"{f.ClienteNombre} {f.ClienteApellido}";
            TBDniC.Text = f.ClienteDni.ToString();
            TBDirecC.Text = f.ClienteDireccion;
            TBTelC.Text = f.ClienteTelefono;

            // Importes
            TBSubtotal.Text = f.Subtotal.ToString("C2", _esAR);
            TBEnvio.Text = f.CostoEnvio.ToString("C2", _esAR);
            TBImporteT.Text = f.Total.ToString("C2", _esAR);

            // Ítems
            DGProdFact.Rows.Clear();
            foreach (var it in f.Items)
            {
                DGProdFact.Rows.Add(
                    it.NombreProducto,
                    it.PrecioUnitario, // Dejar que la grilla formatee
                    it.Cantidad,
                    (it.PrecioUnitario * it.Cantidad) // Dejar que la grilla formatee
                );
            }
        }

        // --- Métodos de Impresión ---

        /// <summary>
        /// Manejador del botón Imprimir. Abre la vista previa.
        /// </summary>
        private void BImprimiFact_Click(object? sender, EventArgs e)
        {
            if (_idVentaFactura <= 0)
            {
                MessageBox.Show("No hay una factura cargada para imprimir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Configurar el documento
            _printDoc.DocumentName = $"Factura_VTA-{_idVentaFactura:D6}";

            // Usar un PrintPreviewDialog
            using (var ppd = new PrintPreviewDialog())
            {
                ppd.Document = _printDoc;
                ppd.WindowState = FormWindowState.Maximized; // Maximizar la vista previa
                ppd.ShowDialog(this);
            }
        }

        /// <summary>
        /// Dibuja la factura en la página de impresión.
        /// </summary>
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            // 1. Validar
            if (_idVentaFactura <= 0 || e.Graphics == null) return;

            // 2. Recargar datos (más seguro que leer los textboxes)
            FacturaDto f;
            try
            {
                f = _ventaDatos.ObtenerFacturaPorId(_idVentaFactura);
            }
            catch (Exception ex)
            {
                e.Graphics.DrawString($"Error al cargar factura: {ex.Message}", new Font("Arial", 10), Brushes.Red, 50, 50);
                return;
            }

            // 3. Configurar fuentes y brochas
            using var fontTitulo = new Font("Arial", 16, FontStyle.Bold);
            using var fontSubtitulo = new Font("Arial", 12, FontStyle.Underline | FontStyle.Bold);
            using var fontHeader = new Font("Arial", 10, FontStyle.Bold);
            using var fontBody = new Font("Arial", 10, FontStyle.Regular);
            using var fontGridHeader = new Font("Arial", 9, FontStyle.Bold);
            using var fontGridBody = new Font("Arial", 9, FontStyle.Regular);
            var brush = Brushes.Black;

            // 4. Definir márgenes y posición
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float currentY = topMargin;
            float pageRight = e.MarginBounds.Right;

            // --- INICIO DIBUJO ---

            // A. Cabecera (Logo y Nro Factura)
            try
            {
                if (PBLogoAuren.BackgroundImage != null)
                {
                    e.Graphics.DrawImage(PBLogoAuren.BackgroundImage, leftMargin, currentY, 120, 100);
                }
                else
                {
                    throw new Exception("Logo no encontrado");
                }
            }
            catch
            {
                e.Graphics.DrawString("Auren Padel Store", fontTitulo, brush, leftMargin, currentY);
                currentY += 30;
            }

            string nroFactura = $"FACTURA N°: {f.IdVenta:D6}";
            var factSize = e.Graphics.MeasureString(nroFactura, fontTitulo);
            e.Graphics.DrawString(nroFactura, fontTitulo, brush, pageRight - factSize.Width, currentY + 10);

            string fechaFactura = $"Fecha: {f.Fecha:dd/MM/yyyy}";
            var fechaSize = e.Graphics.MeasureString(fechaFactura, fontHeader);
            e.Graphics.DrawString(fechaFactura, fontHeader, brush, pageRight - fechaSize.Width, currentY + factSize.Height + 15);

            currentY += 110; // Bajar después del logo

            // B. Datos Tienda
            e.Graphics.DrawString("Datos de la Tienda", fontSubtitulo, brush, leftMargin, currentY);
            currentY += 30;
            e.Graphics.DrawString($"Razón Social: Auren Padel Store", fontBody, brush, leftMargin, currentY);
            e.Graphics.DrawString($"Vendedor: {f.UsuarioNombre} {f.UsuarioApellido}", fontBody, brush, leftMargin + 300, currentY);
            currentY += 20;
            e.Graphics.DrawString($"CUIT: 27-12345678-5", fontBody, brush, leftMargin, currentY);
            e.Graphics.DrawString($"Dirección: Junín 575", fontBody, brush, leftMargin + 300, currentY);
            currentY += 20;
            e.Graphics.DrawString($"Teléfono: +54 3794 123456", fontBody, brush, leftMargin, currentY);
            currentY += 30;

            // C. Datos Cliente
            e.Graphics.DrawLine(Pens.Black, leftMargin, currentY, pageRight, currentY);
            currentY += 10;
            e.Graphics.DrawString("Datos del Cliente", fontSubtitulo, brush, leftMargin, currentY);
            currentY += 30;
            e.Graphics.DrawString($"Nombre y Apellido: {f.ClienteNombre} {f.ClienteApellido}", fontBody, brush, leftMargin, currentY);
            e.Graphics.DrawString($"Documento: {f.ClienteDni}", fontBody, brush, leftMargin + 300, currentY);
            currentY += 20;
            e.Graphics.DrawString($"Teléfono: {f.ClienteTelefono}", fontBody, brush, leftMargin, currentY);
            e.Graphics.DrawString($"Dirección: {f.ClienteDireccion}", fontBody, brush, leftMargin + 300, currentY);
            currentY += 30;

            // D. Items (Grid)
            e.Graphics.DrawLine(Pens.Black, leftMargin, currentY, pageRight, currentY);
            currentY += 10;

            float colNombreX = leftMargin;
            float colPrecioX = leftMargin + 320;
            float colCantX = leftMargin + 440;
            float colSubtotalX = leftMargin + 510;

            e.Graphics.DrawString("Producto", fontGridHeader, brush, colNombreX, currentY);
            e.Graphics.DrawString("P. Unitario", fontGridHeader, brush, colPrecioX, currentY);
            e.Graphics.DrawString("Cant.", fontGridHeader, brush, colCantX, currentY);
            e.Graphics.DrawString("Subtotal", fontGridHeader, brush, colSubtotalX, currentY);
            currentY += 25;
            e.Graphics.DrawLine(Pens.Gray, leftMargin, currentY, pageRight, currentY);
            currentY += 5;

            foreach (var item in f.Items)
            {
                var rectNombre = new RectangleF(colNombreX, currentY, colPrecioX - colNombreX - 5, 40);
                e.Graphics.DrawString(item.NombreProducto, fontGridBody, brush, rectNombre);

                e.Graphics.DrawString(item.PrecioUnitario.ToString("C", _esAR), fontGridBody, brush, colPrecioX, currentY);
                e.Graphics.DrawString(item.Cantidad.ToString(), fontGridBody, brush, colCantX, currentY);
                e.Graphics.DrawString(item.Subtotal.ToString("C", _esAR), fontGridBody, brush, colSubtotalX, currentY);

                float alturaFila = e.Graphics.MeasureString(item.NombreProducto, fontGridBody, (int)rectNombre.Width).Height;
                currentY += Math.Max(20, alturaFila + 5);
            }

            // E. Totales
            currentY += 20;
            e.Graphics.DrawLine(Pens.Black, leftMargin + 300, currentY, pageRight, currentY);
            currentY += 10;

            float totalsX_Label = leftMargin + 400;
            float totalsX_Value = leftMargin + 510;

            e.Graphics.DrawString("Subtotal:", fontHeader, brush, totalsX_Label, currentY);
            e.Graphics.DrawString(f.Subtotal.ToString("C", _esAR), fontHeader, brush, totalsX_Value, currentY);
            currentY += 25;

            e.Graphics.DrawString("Costo de Envío:", fontBody, brush, totalsX_Label, currentY);
            e.Graphics.DrawString(f.CostoEnvio.ToString("C", _esAR), fontBody, brush, totalsX_Value, currentY);
            currentY += 25;

            e.Graphics.DrawString("TOTAL:", fontTitulo, brush, totalsX_Label, currentY);
            e.Graphics.DrawString(f.Total.ToString("C", _esAR), fontTitulo, brush, totalsX_Value, currentY);
            currentY += 30;

            // F. Pie de página
            e.Graphics.DrawString($"Método de Pago: {f.MetodoPago}", fontBody, brush, leftMargin, currentY);

            // 5. Finalizar
            e.HasMorePages = false;
        }
    }
}