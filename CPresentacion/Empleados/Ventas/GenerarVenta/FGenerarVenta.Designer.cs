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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            PVenta = new Panel();
            CBRetiro = new CheckBox();
            CBEfectivo = new CheckBox();
            CBTarjeta = new CheckBox();
            CBTransf = new CheckBox();
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
            colMenos = new DataGridViewButtonColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colMas = new DataGridViewButtonColumn();
            colPrecioTotal = new DataGridViewTextBoxColumn();
            colStockOculto = new DataGridViewTextBoxColumn();
            LTotalTexto = new Label();
            LTotalValor = new Label();
            BRealizarVenta = new Button();
            LTitulo = new Label();
            PVenta.SuspendLayout();
            PDatosCliente.SuspendLayout();
            PItemsVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGItemsVenta).BeginInit();
            SuspendLayout();
            // 
            // PVenta
            // 
            PVenta.BackColor = Color.Transparent;
            PVenta.Controls.Add(CBRetiro);
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
            // CBRetiro
            // 
            CBRetiro.AutoSize = true;
            CBRetiro.Font = new Font("Century Gothic", 14.25F);
            CBRetiro.ForeColor = Color.LightGray;
            CBRetiro.Location = new Point(20, 492);
            CBRetiro.Name = "CBRetiro";
            CBRetiro.Size = new Size(187, 26);
            CBRetiro.TabIndex = 9;
            CBRetiro.Text = "Retiro en sucursal";
            CBRetiro.UseVisualStyleBackColor = true;
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
            // CBTarjeta
            // 
            CBTarjeta.AutoSize = true;
            CBTarjeta.Font = new Font("Century Gothic", 14.25F);
            CBTarjeta.ForeColor = Color.LightGray;
            CBTarjeta.Location = new Point(221, 492);
            CBTarjeta.Name = "CBTarjeta";
            CBTarjeta.Size = new Size(229, 26);
            CBTarjeta.TabIndex = 7;
            CBTarjeta.Text = "Tarjeta débito/crédito";
            CBTarjeta.UseVisualStyleBackColor = true;
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
            CBCliente.Size = new Size(360, 29);
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
            CBEnvio.Font = new Font("Century Gothic", 14.25F);
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
            dataGridViewCellStyle1.BackColor = Color.FromArgb(100, 100, 100);
            dataGridViewCellStyle1.ForeColor = Color.LightGray;
            DGItemsVenta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DGItemsVenta.BackgroundColor = Color.FromArgb(64, 64, 64);
            DGItemsVenta.BorderStyle = BorderStyle.None;
            DGItemsVenta.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 12F);
            dataGridViewCellStyle2.ForeColor = Color.LightGray;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGItemsVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DGItemsVenta.ColumnHeadersHeight = 32;
            DGItemsVenta.Columns.AddRange(new DataGridViewColumn[] { colVer, colProducto, colPrecioUnitario, colMenos, colCantidad, colMas, colPrecioTotal, colStockOculto });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(100, 100, 100);
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = Color.LightGray;
            dataGridViewCellStyle10.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle10.SelectionForeColor = Color.White;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            DGItemsVenta.DefaultCellStyle = dataGridViewCellStyle10;
            DGItemsVenta.Dock = DockStyle.Fill;
            DGItemsVenta.EnableHeadersVisualStyles = false;
            DGItemsVenta.GridColor = Color.Black;
            DGItemsVenta.Location = new Point(40, 23);
            DGItemsVenta.MultiSelect = false;
            DGItemsVenta.Name = "DGItemsVenta";
            DGItemsVenta.RowHeadersVisible = false;
            DGItemsVenta.RowTemplate.Height = 35;
            DGItemsVenta.ScrollBars = ScrollBars.Vertical;
            DGItemsVenta.Size = new Size(972, 306);
            DGItemsVenta.TabIndex = 0;
            // 
            // colVer
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.LightSkyBlue;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 13F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            colVer.DefaultCellStyle = dataGridViewCellStyle3;
            colVer.FlatStyle = FlatStyle.Flat;
            colVer.HeaderText = "A";
            colVer.Name = "colVer";
            colVer.Text = "Ver";
            colVer.UseColumnTextForButtonValue = true;
            colVer.Width = 60;
            // 
            // colProducto
            // 
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 14F);
            colProducto.DefaultCellStyle = dataGridViewCellStyle4;
            colProducto.FlatStyle = FlatStyle.Flat;
            colProducto.HeaderText = "Producto";
            colProducto.Name = "colProducto";
            colProducto.Width = 400;
            // 
            // colPrecioUnitario
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new Font("Century Gothic", 14F);
            dataGridViewCellStyle5.Format = "N2";
            colPrecioUnitario.DefaultCellStyle = dataGridViewCellStyle5;
            colPrecioUnitario.HeaderText = "Precio Unitario";
            colPrecioUnitario.Name = "colPrecioUnitario";
            colPrecioUnitario.ReadOnly = true;
            colPrecioUnitario.Width = 162;
            // 
            // colMenos
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            colMenos.DefaultCellStyle = dataGridViewCellStyle6;
            colMenos.HeaderText = "";
            colMenos.Name = "colMenos";
            colMenos.Text = "–";
            colMenos.UseColumnTextForButtonValue = true;
            colMenos.Width = 45;
            // 
            // colCantidad
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new Font("Century Gothic", 14F);
            colCantidad.DefaultCellStyle = dataGridViewCellStyle7;
            colCantidad.HeaderText = "Cant.";
            colCantidad.Name = "colCantidad";
            colCantidad.Width = 70;
            // 
            // colMas
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            colMas.DefaultCellStyle = dataGridViewCellStyle8;
            colMas.HeaderText = "";
            colMas.Name = "colMas";
            colMas.Text = "+";
            colMas.UseColumnTextForButtonValue = true;
            colMas.Width = 45;
            // 
            // colPrecioTotal
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new Font("Century Gothic", 14F);
            dataGridViewCellStyle9.Format = "N2";
            colPrecioTotal.DefaultCellStyle = dataGridViewCellStyle9;
            colPrecioTotal.HeaderText = "Subtotal";
            colPrecioTotal.Name = "colPrecioTotal";
            colPrecioTotal.ReadOnly = true;
            colPrecioTotal.Width = 189;
            // 
            // colStockOculto
            // 
            colStockOculto.HeaderText = "StockOculto";
            colStockOculto.Name = "colStockOculto";
            colStockOculto.Visible = false;
            // 
            // LTotalTexto
            // 
            LTotalTexto.AutoSize = true;
            LTotalTexto.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            LTotalTexto.ForeColor = Color.LightGray;
            LTotalTexto.Location = new Point(648, 456);
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
            LTotalValor.Location = new Point(727, 456);
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
            BRealizarVenta.Location = new Point(648, 492);
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
        private DataGridViewButtonColumn colMenos;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewButtonColumn colMas;
        private DataGridViewTextBoxColumn colPrecioTotal;
        private DataGridViewTextBoxColumn colStockOculto;

        private CheckBox CBEnvio;
        private CheckBox CBRetiro;
        private Label LTotalTexto;
        private Label LTotalValor;
        private Button BRealizarVenta;
        private CheckBox CBTransf;
        private CheckBox CBEfectivo;
        private CheckBox CBTarjeta;
    }
}
