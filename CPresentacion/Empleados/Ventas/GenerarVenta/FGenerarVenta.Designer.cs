using System.Windows.Forms;
using System.Drawing;

namespace AurenPadelStore.CPresentacion.Empleados.Ventas
{
    partial class FGenerarVenta
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle16 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            PVenta = new Panel();
            PDatosCliente = new Panel();
            LCliente = new Label();
            CBCliente = new ComboBox();
            DTPFecha = new DateTimePicker();
            BAgregarProducto = new Button();
            CBEnvio = new CheckBox();
            PItemsVenta = new Panel();
            DGItemsVenta = new DataGridView();
            colVer = new DataGridViewButtonColumn();
            colProducto = new DataGridViewComboBoxColumn();
            colPrecioUnitario = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colPrecioTotal = new DataGridViewTextBoxColumn();
            LTotalTexto = new Label();
            LTotalValor = new Label();
            BRealizarVenta = new Button();
            LTitulo = new Label();
            CBTransf = new CheckBox();
            CBTarjeta = new CheckBox();
            CBEfectivo = new CheckBox();
            PVenta.SuspendLayout();
            PDatosCliente.SuspendLayout();
            PItemsVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGItemsVenta).BeginInit();
            SuspendLayout();
            // 
            // PVenta
            // 
            PVenta.BackColor = Color.Transparent;
            PVenta.Controls.Add(CBEfectivo);
            PVenta.Controls.Add(CBTarjeta);
            PVenta.Controls.Add(CBTransf);
            PVenta.Controls.Add(PDatosCliente);
            PVenta.Controls.Add(CBEnvio);
            PVenta.Controls.Add(PItemsVenta);
            PVenta.Controls.Add(LTotalTexto);
            PVenta.Controls.Add(LTotalValor);
            PVenta.Controls.Add(BRealizarVenta);
            PVenta.Location = new Point(137, 88);
            PVenta.Name = "PVenta";
            PVenta.Size = new Size(1059, 559);
            PVenta.TabIndex = 0;
            // 
            // PDatosCliente
            // 
            PDatosCliente.BackColor = Color.FromArgb(64, 64, 64);
            PDatosCliente.Controls.Add(LCliente);
            PDatosCliente.Controls.Add(CBCliente);
            PDatosCliente.Controls.Add(DTPFecha);
            PDatosCliente.Controls.Add(BAgregarProducto);
            PDatosCliente.Location = new Point(0, 0);
            PDatosCliente.Name = "PDatosCliente";
            PDatosCliente.Size = new Size(1057, 80);
            PDatosCliente.TabIndex = 0;
            // 
            // LCliente
            // 
            LCliente.AutoSize = true;
            LCliente.Font = new Font("Century Gothic", 16F);
            LCliente.ForeColor = Color.LightGray;
            LCliente.Location = new Point(20, 26);
            LCliente.Name = "LCliente";
            LCliente.Size = new Size(95, 25);
            LCliente.TabIndex = 0;
            LCliente.Text = "Cliente:";
            // 
            // CBCliente
            // 
            CBCliente.BackColor = Color.LightGray;
            CBCliente.Font = new Font("Century Gothic", 12F);
            CBCliente.ForeColor = Color.Black;
            CBCliente.Location = new Point(121, 26);
            CBCliente.Name = "CBCliente";
            CBCliente.Size = new Size(315, 29);
            CBCliente.TabIndex = 1;
            // 
            // DTPFecha
            // 
            DTPFecha.CalendarForeColor = Color.Black;
            DTPFecha.CalendarMonthBackground = Color.White;
            DTPFecha.Font = new Font("Century Gothic", 12F);
            DTPFecha.Format = DateTimePickerFormat.Short;
            DTPFecha.Location = new Point(568, 26);
            DTPFecha.Name = "DTPFecha";
            DTPFecha.Size = new Size(140, 27);
            DTPFecha.TabIndex = 2;
            // 
            // BAgregarProducto
            // 
            BAgregarProducto.BackColor = Color.YellowGreen;
            BAgregarProducto.Cursor = Cursors.Hand;
            BAgregarProducto.FlatStyle = FlatStyle.Popup;
            BAgregarProducto.Font = new Font("Century Gothic", 14.25F);
            BAgregarProducto.ForeColor = Color.Black;
            BAgregarProducto.Location = new Point(836, 22);
            BAgregarProducto.Name = "BAgregarProducto";
            BAgregarProducto.Size = new Size(200, 33);
            BAgregarProducto.TabIndex = 3;
            BAgregarProducto.Text = "Agregar Producto";
            BAgregarProducto.UseVisualStyleBackColor = false;
            // 
            // CBEnvio
            // 
            CBEnvio.AutoSize = true;
            CBEnvio.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBEnvio.ForeColor = Color.LightGray;
            CBEnvio.Location = new Point(20, 460);
            CBEnvio.Name = "CBEnvio";
            CBEnvio.Size = new Size(180, 26);
            CBEnvio.TabIndex = 2;
            CBEnvio.Text = "Envío a domicilio";
            CBEnvio.UseVisualStyleBackColor = true;
            // 
            // PItemsVenta
            // 
            PItemsVenta.BackColor = Color.FromArgb(64, 64, 64);
            PItemsVenta.Controls.Add(DGItemsVenta);
            PItemsVenta.Location = new Point(0, 90);
            PItemsVenta.Name = "PItemsVenta";
            PItemsVenta.Padding = new Padding(40, 23, 45, 23);
            PItemsVenta.Size = new Size(1057, 352);
            PItemsVenta.TabIndex = 1;
            // 
            // DGItemsVenta
            // 
            DGItemsVenta.AllowUserToAddRows = false;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(100, 100, 100);
            dataGridViewCellStyle9.ForeColor = Color.LightGray;
            DGItemsVenta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            DGItemsVenta.BackgroundColor = Color.FromArgb(64, 64, 64);
            DGItemsVenta.BorderStyle = BorderStyle.None;
            DGItemsVenta.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle10.Font = new Font("Century Gothic", 12F);
            dataGridViewCellStyle10.ForeColor = Color.LightGray;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            DGItemsVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            DGItemsVenta.ColumnHeadersHeight = 32;
            DGItemsVenta.Columns.AddRange(new DataGridViewColumn[] { colVer, colProducto, colPrecioUnitario, colCantidad, colPrecioTotal });
            dataGridViewCellStyle16.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = Color.FromArgb(100, 100, 100);
            dataGridViewCellStyle16.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle16.ForeColor = Color.LightGray;
            dataGridViewCellStyle16.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle16.SelectionForeColor = Color.White;
            dataGridViewCellStyle16.WrapMode = DataGridViewTriState.False;
            DGItemsVenta.DefaultCellStyle = dataGridViewCellStyle16;
            DGItemsVenta.Dock = DockStyle.Fill;
            DGItemsVenta.EnableHeadersVisualStyles = false;
            DGItemsVenta.GridColor = Color.Black;
            DGItemsVenta.Location = new Point(40, 23);
            DGItemsVenta.MultiSelect = false;
            DGItemsVenta.Name = "DGItemsVenta";
            DGItemsVenta.RowHeadersVisible = false;
            DGItemsVenta.RowTemplate.Height = 40;
            DGItemsVenta.ScrollBars = ScrollBars.Vertical;
            DGItemsVenta.Size = new Size(972, 306);
            DGItemsVenta.TabIndex = 0;
            // 
            // colVer
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = Color.LightSkyBlue;
            dataGridViewCellStyle11.Font = new Font("Century Gothic", 14F);
            dataGridViewCellStyle11.ForeColor = Color.Black;
            colVer.DefaultCellStyle = dataGridViewCellStyle11;
            colVer.FlatStyle = FlatStyle.Flat;
            colVer.HeaderText = "A";
            colVer.Name = "colVer";
            colVer.Text = "Ver";
            colVer.UseColumnTextForButtonValue = true;
            colVer.Width = 60;
            // 
            // colProducto
            // 
            dataGridViewCellStyle12.Font = new Font("Century Gothic", 14F);
            colProducto.DefaultCellStyle = dataGridViewCellStyle12;
            colProducto.FlatStyle = FlatStyle.Flat;
            colProducto.HeaderText = "Producto";
            colProducto.Name = "colProducto";
            colProducto.Width = 430;
            // 
            // colPrecioUnitario
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new Font("Century Gothic", 14F);
            dataGridViewCellStyle13.Format = "N2";
            colPrecioUnitario.DefaultCellStyle = dataGridViewCellStyle13;
            colPrecioUnitario.HeaderText = "Precio Unitario";
            colPrecioUnitario.Name = "colPrecioUnitario";
            colPrecioUnitario.ReadOnly = true;
            colPrecioUnitario.Width = 170;
            // 
            // colCantidad
            // 
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.Font = new Font("Century Gothic", 14F);
            colCantidad.DefaultCellStyle = dataGridViewCellStyle14;
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.Width = 130;
            // 
            // colPrecioTotal
            // 
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Font = new Font("Century Gothic", 14F);
            dataGridViewCellStyle15.Format = "N2";
            colPrecioTotal.DefaultCellStyle = dataGridViewCellStyle15;
            colPrecioTotal.HeaderText = "Precio Total";
            colPrecioTotal.Name = "colPrecioTotal";
            colPrecioTotal.ReadOnly = true;
            colPrecioTotal.Width = 180;
            // 
            // LTotalTexto
            // 
            LTotalTexto.AutoSize = true;
            LTotalTexto.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            LTotalTexto.ForeColor = Color.LightGray;
            LTotalTexto.Location = new Point(624, 456);
            LTotalTexto.Name = "LTotalTexto";
            LTotalTexto.Size = new Size(73, 28);
            LTotalTexto.TabIndex = 3;
            LTotalTexto.Text = "Total:";
            // 
            // LTotalValor
            // 
            LTotalValor.AutoSize = true;
            LTotalValor.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            LTotalValor.ForeColor = Color.LightGray;
            LTotalValor.Location = new Point(703, 456);
            LTotalValor.Name = "LTotalValor";
            LTotalValor.Size = new Size(58, 28);
            LTotalValor.TabIndex = 4;
            LTotalValor.Text = "0,00";
            // 
            // BRealizarVenta
            // 
            BRealizarVenta.BackColor = Color.YellowGreen;
            BRealizarVenta.Cursor = Cursors.Hand;
            BRealizarVenta.FlatStyle = FlatStyle.Popup;
            BRealizarVenta.Font = new Font("Century Gothic", 14.25F);
            BRealizarVenta.ForeColor = Color.Black;
            BRealizarVenta.Location = new Point(624, 501);
            BRealizarVenta.Name = "BRealizarVenta";
            BRealizarVenta.Size = new Size(388, 38);
            BRealizarVenta.TabIndex = 5;
            BRealizarVenta.Text = "Realizar Venta";
            BRealizarVenta.UseVisualStyleBackColor = false;
            // 
            // LTitulo
            // 
            LTitulo.AutoSize = true;
            LTitulo.BackColor = Color.Transparent;
            LTitulo.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LTitulo.ForeColor = Color.LightGray;
            LTitulo.Location = new Point(560, 34);
            LTitulo.Name = "LTitulo";
            LTitulo.Size = new Size(204, 33);
            LTitulo.TabIndex = 1;
            LTitulo.Text = "Realizar Venta";
            // 
            // CBTransf
            // 
            CBTransf.AutoSize = true;
            CBTransf.Font = new Font("Century Gothic", 14.25F);
            CBTransf.ForeColor = Color.LightGray;
            CBTransf.Location = new Point(221, 460);
            CBTransf.Name = "CBTransf";
            CBTransf.Size = new Size(151, 26);
            CBTransf.TabIndex = 6;
            CBTransf.Text = "Transferencia";
            CBTransf.UseVisualStyleBackColor = true;
            // 
            // CBTarjeta
            // 
            CBTarjeta.AutoSize = true;
            CBTarjeta.Font = new Font("Century Gothic", 14.25F);
            CBTarjeta.ForeColor = Color.LightGray;
            CBTarjeta.Location = new Point(221, 492);
            CBTarjeta.Name = "CBTarjeta";
            CBTarjeta.Size = new Size(91, 26);
            CBTarjeta.TabIndex = 7;
            CBTarjeta.Text = "Tarjeta";
            CBTarjeta.UseVisualStyleBackColor = true;
            // 
            // CBEfectivo
            // 
            CBEfectivo.AutoSize = true;
            CBEfectivo.Font = new Font("Century Gothic", 14.25F);
            CBEfectivo.ForeColor = Color.LightGray;
            CBEfectivo.Location = new Point(221, 524);
            CBEfectivo.Name = "CBEfectivo";
            CBEfectivo.Size = new Size(104, 26);
            CBEfectivo.TabIndex = 8;
            CBEfectivo.Text = "Efectivo";
            CBEfectivo.UseVisualStyleBackColor = true;
            // 
            // FGenerarVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1334, 659);
            Controls.Add(PVenta);
            Controls.Add(LTitulo);
            Name = "FGenerarVenta";
            Text = "Generar Venta";
            PVenta.ResumeLayout(false);
            PVenta.PerformLayout();
            PDatosCliente.ResumeLayout(false);
            PDatosCliente.PerformLayout();
            PItemsVenta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGItemsVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PVenta;
        private Label LTitulo;

        private Panel PDatosCliente;
        private Label LCliente;
        private ComboBox CBCliente;
        private DateTimePicker DTPFecha;
        private Button BAgregarProducto;

        private Panel PItemsVenta;
        private DataGridView DGItemsVenta;
        private DataGridViewButtonColumn colVer;
        private DataGridViewComboBoxColumn colProducto;
        private DataGridViewTextBoxColumn colPrecioUnitario;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colPrecioTotal;

        private CheckBox CBEnvio;
        private Label LTotalTexto;
        private Label LTotalValor;
        private Button BRealizarVenta;
        private CheckBox CBTransf;
        private CheckBox CBEfectivo;
        private CheckBox CBTarjeta;
    }
}
