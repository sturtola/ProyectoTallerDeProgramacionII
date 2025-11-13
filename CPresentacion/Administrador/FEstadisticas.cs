using AurenPadelStore.CLogica;
using System;
using System.Drawing; // ← necesario para Point/Size
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AurenPadelStore.CPresentacion.Administrador
{
    public partial class FEstadisticas : Form
    {
        private readonly EstadisticasLogica _logica = new EstadisticasLogica();

        // Layout: márgenes y alto de la fila de filtros
        private const int M = 12;   // margen general
        private const int FH = 48;  // alto fila de filtros

        public FEstadisticas()
        {
            InitializeComponent();

            // Formato corto (evita textos largos/cortados)
            dtDesde.Format = DateTimePickerFormat.Custom;
            dtDesde.CustomFormat = "dd/MM/yyyy";
            dtDesde.Width = 120;

            dtHasta.Format = DateTimePickerFormat.Custom;
            dtHasta.CustomFormat = "dd/MM/yyyy";
            dtHasta.Width = 120;

            // No permitir fechas futuras
            dtDesde.MaxDate = DateTime.Today;
            dtHasta.MaxDate = DateTime.Today;

            // Mantener rango válido
            dtDesde.ValueChanged += ValidarRangoFechas;
            dtHasta.ValueChanged += ValidarRangoFechas;

            // Valores iniciales
            dtDesde.Value = DateTime.Today.AddDays(-30);
            dtHasta.Value = DateTime.Today;

            // Cargar datos
            Cargar();

            // Abrir maximizado en el MDI y recalcular layout
            this.Load += (_, __) => { this.WindowState = FormWindowState.Maximized; Reflow(); };
            this.Resize += (_, __) => Reflow();

            // Botón a la derecha; los demás controles de filtros a la izquierda
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.Anchor = label2.Anchor = label3.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            dtDesde.Anchor = dtHasta.Anchor = numTop.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Por si no lo pusiste en el Designer
            this.MinimumSize = new Size(1000, 650);
        }

        private void Cargar()
        {
            var topN = (int)numTop.Value;
            var (porDia, top, porMes, resumen) = _logica.ObtenerDash(dtDesde.Value, dtHasta.Value, topN);

            // Ventas por día
            chartDia.Series.Clear();
            var sDia = new Series("Importe por día") { ChartType = SeriesChartType.Column };
            foreach (var x in porDia)
                sDia.Points.AddXY(x.Fecha.ToString("dd/MM"), (double)x.ImporteTotal);
            chartDia.Series.Add(sDia);

            // Top productos (torta)
            chartTop.Series.Clear();
            var sTop = new Series("Top productos") { ChartType = SeriesChartType.Pie };
            foreach (var t in top)
            {
                var p = sTop.Points.Add((double)t.CantidadVendida);
                p.LegendText = t.Nombre;
                p.Label = $"{t.Porcentaje:N2}%";
            }
            chartTop.Series.Add(sTop);

            // Ventas por mes (año actual)
            chartMes.Series.Clear();
            var sMes = new Series("Importe por mes") { ChartType = SeriesChartType.Column };
            foreach (var m in porMes.OrderBy(x => x.Mes))
                sMes.Points.AddXY(new DateTime(m.Anio, m.Mes, 1).ToString("MMM"),
                                  (double)m.ImporteTotal);
            chartMes.Series.Add(sMes);

            // Resumen
            lblVentas.Text = resumen.CantidadVentas.ToString();
            lblProductos.Text = resumen.CantidadProductos.ToString();
            lblImporte.Text = $"$ {resumen.ImporteTotal:N2}";
            lblTicket.Text = $"$ {resumen.TicketPromedio:N2}";
        }

        private void ValidarRangoFechas(object? sender, EventArgs e)
        {
            // Clamp a hoy (evita futuras)
            if (dtHasta.Value.Date > DateTime.Today)
                dtHasta.Value = DateTime.Today;
            if (dtDesde.Value.Date > DateTime.Today)
                dtDesde.Value = DateTime.Today;

            // Asegura coherencia: desde <= hasta
            if (dtDesde.Value.Date > dtHasta.Value.Date)
                dtDesde.Value = dtHasta.Value.Date;
        }

        // === Layout responsivo (2x2): Día | Top  /  Mes | Resumen ===
        private void Reflow()
        {
            // Área útil dentro del form
            int usableW = Math.Max(800, this.ClientSize.Width - (M * 3));
            int usableH = Math.Max(400, this.ClientSize.Height - (FH + M * 3));

            int colW = usableW / 2;  // mitad de ancho (dos columnas)
            int rowH = usableH / 2;  // mitad de alto (dos filas)

            // Fila 1
            chartDia.Location = new Point(M, FH);
            chartDia.Size = new Size(colW, rowH);

            chartTop.Location = new Point(M * 2 + colW, FH);
            chartTop.Size = new Size(colW, rowH);

            // Fila 2
            chartMes.Location = new Point(M, FH + rowH + M);
            chartMes.Size = new Size(colW, rowH);

            grpResumen.Location = new Point(M * 2 + colW, FH + rowH + M);
            grpResumen.Size = new Size(colW, rowH);

            // Botón “Actualizar” pegado a la derecha
            btnActualizar.Location = new Point(this.ClientSize.Width - btnActualizar.Width - M, 9);
        }

        private void btnActualizar_Click(object sender, EventArgs e) => Cargar();
    }
}
