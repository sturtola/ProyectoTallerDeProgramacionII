namespace AurenPadelStore.CPresentacion.Empleados.Facturas.VerFactura
{
    partial class FVerFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FVerFactura));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            PDatosFact = new Panel();
            TBFechaFact = new TextBox();
            TBNroFact = new TextBox();
            PBLogoAuren = new PictureBox();
            LFechaFact = new Label();
            LNroFact = new Label();
            PDatosC = new Panel();
            label16 = new Label();
            LDniC = new Label();
            LDirecC = new Label();
            LTelC = new Label();
            LNyAC = new Label();
            TBTelC = new TextBox();
            TBDniC = new TextBox();
            TBNyAC = new TextBox();
            TBDirecC = new TextBox();
            PImportes = new Panel();
            TBSubtotal = new TextBox();
            TBEnvio = new TextBox();
            TBImporteT = new TextBox();
            LImporteT = new Label();
            LEnvio = new Label();
            LSubtotal = new Label();
            PDatosTienda = new Panel();
            LDirecT2 = new Label();
            LTelefonoT2 = new Label();
            LCuitT2 = new Label();
            LRazonST2 = new Label();
            LTelefonoT = new Label();
            LDirecT = new Label();
            LCuitT = new Label();
            LRazonST = new Label();
            LDatosTienda = new Label();
            PProdFact = new Panel();
            DGProdFact = new DataGridView();
            ColNombre = new DataGridViewTextBoxColumn();
            ColPrecioUnitario = new DataGridViewTextBoxColumn();
            ColCantidad = new DataGridViewTextBoxColumn();
            ColSubtotal = new DataGridViewTextBoxColumn();
            BImprimiFact = new Button();
            LMetodoPago = new Label();
            textBox1 = new TextBox();
            PDatosFact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBLogoAuren).BeginInit();
            PDatosC.SuspendLayout();
            PImportes.SuspendLayout();
            PDatosTienda.SuspendLayout();
            PProdFact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGProdFact).BeginInit();
            SuspendLayout();
            // 
            // PDatosFact
            // 
            PDatosFact.BorderStyle = BorderStyle.FixedSingle;
            PDatosFact.Controls.Add(TBFechaFact);
            PDatosFact.Controls.Add(TBNroFact);
            PDatosFact.Controls.Add(PBLogoAuren);
            PDatosFact.Controls.Add(LFechaFact);
            PDatosFact.Controls.Add(LNroFact);
            PDatosFact.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PDatosFact.ForeColor = Color.Black;
            PDatosFact.Location = new Point(12, 12);
            PDatosFact.Name = "PDatosFact";
            PDatosFact.Size = new Size(533, 63);
            PDatosFact.TabIndex = 0;
            // 
            // TBFechaFact
            // 
            TBFechaFact.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBFechaFact.Location = new Point(154, 36);
            TBFechaFact.Name = "TBFechaFact";
            TBFechaFact.Size = new Size(100, 22);
            TBFechaFact.TabIndex = 1;
            // 
            // TBNroFact
            // 
            TBNroFact.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBNroFact.Location = new Point(131, 5);
            TBNroFact.Name = "TBNroFact";
            TBNroFact.Size = new Size(100, 26);
            TBNroFact.TabIndex = 2;
            // 
            // PBLogoAuren
            // 
            PBLogoAuren.BackColor = Color.Transparent;
            PBLogoAuren.BackgroundImage = (Image)resources.GetObject("PBLogoAuren.BackgroundImage");
            PBLogoAuren.BackgroundImageLayout = ImageLayout.Stretch;
            PBLogoAuren.Location = new Point(381, -33);
            PBLogoAuren.Name = "PBLogoAuren";
            PBLogoAuren.Size = new Size(147, 126);
            PBLogoAuren.TabIndex = 3;
            PBLogoAuren.TabStop = false;
            // 
            // LFechaFact
            // 
            LFechaFact.AutoSize = true;
            LFechaFact.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LFechaFact.Location = new Point(12, 36);
            LFechaFact.Name = "LFechaFact";
            LFechaFact.Size = new Size(136, 18);
            LFechaFact.TabIndex = 1;
            LFechaFact.Text = "Fecha de emisión:";
            // 
            // LNroFact
            // 
            LNroFact.AutoSize = true;
            LNroFact.Font = new Font("Arial", 14.25F, FontStyle.Bold);
            LNroFact.Location = new Point(12, 5);
            LNroFact.Name = "LNroFact";
            LNroFact.Size = new Size(114, 22);
            LNroFact.TabIndex = 0;
            LNroFact.Text = "Factura N°:";
            // 
            // PDatosC
            // 
            PDatosC.BorderStyle = BorderStyle.FixedSingle;
            PDatosC.Controls.Add(label16);
            PDatosC.Controls.Add(LDniC);
            PDatosC.Controls.Add(LDirecC);
            PDatosC.Controls.Add(LTelC);
            PDatosC.Controls.Add(LNyAC);
            PDatosC.Controls.Add(TBTelC);
            PDatosC.Controls.Add(TBDniC);
            PDatosC.Controls.Add(TBNyAC);
            PDatosC.Controls.Add(TBDirecC);
            PDatosC.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PDatosC.Location = new Point(12, 186);
            PDatosC.Name = "PDatosC";
            PDatosC.Size = new Size(533, 108);
            PDatosC.TabIndex = 0;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Arial", 14.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label16.Location = new Point(177, 8);
            label16.Name = "label16";
            label16.Size = new Size(155, 22);
            label16.TabIndex = 13;
            label16.Text = "Datos del Cliente";
            // 
            // LDniC
            // 
            LDniC.AutoSize = true;
            LDniC.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            LDniC.Location = new Point(16, 72);
            LDniC.Name = "LDniC";
            LDniC.Size = new Size(93, 18);
            LDniC.TabIndex = 12;
            LDniC.Text = "Documento:";
            // 
            // LDirecC
            // 
            LDirecC.AutoSize = true;
            LDirecC.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            LDirecC.Location = new Point(265, 72);
            LDirecC.Name = "LDirecC";
            LDirecC.Size = new Size(80, 18);
            LDirecC.TabIndex = 11;
            LDirecC.Text = "Dirección:";
            // 
            // LTelC
            // 
            LTelC.AutoSize = true;
            LTelC.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            LTelC.Location = new Point(331, 44);
            LTelC.Name = "LTelC";
            LTelC.Size = new Size(75, 18);
            LTelC.TabIndex = 9;
            LTelC.Text = "Teléfono:";
            // 
            // LNyAC
            // 
            LNyAC.AutoSize = true;
            LNyAC.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            LNyAC.Location = new Point(16, 44);
            LNyAC.Name = "LNyAC";
            LNyAC.Size = new Size(139, 18);
            LNyAC.TabIndex = 8;
            LNyAC.Text = "Nombre y Apellido:";
            // 
            // TBTelC
            // 
            TBTelC.Font = new Font("Arial", 9.75F);
            TBTelC.Location = new Point(412, 42);
            TBTelC.Name = "TBTelC";
            TBTelC.Size = new Size(117, 22);
            TBTelC.TabIndex = 5;
            // 
            // TBDniC
            // 
            TBDniC.Font = new Font("Arial", 9.75F);
            TBDniC.Location = new Point(115, 70);
            TBDniC.Name = "TBDniC";
            TBDniC.Size = new Size(131, 22);
            TBDniC.TabIndex = 4;
            // 
            // TBNyAC
            // 
            TBNyAC.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBNyAC.Location = new Point(161, 44);
            TBNyAC.Name = "TBNyAC";
            TBNyAC.Size = new Size(164, 22);
            TBNyAC.TabIndex = 6;
            // 
            // TBDirecC
            // 
            TBDirecC.Font = new Font("Arial", 9.75F);
            TBDirecC.Location = new Point(351, 72);
            TBDirecC.Name = "TBDirecC";
            TBDirecC.Size = new Size(178, 22);
            TBDirecC.TabIndex = 7;
            // 
            // PImportes
            // 
            PImportes.BorderStyle = BorderStyle.FixedSingle;
            PImportes.Controls.Add(textBox1);
            PImportes.Controls.Add(LMetodoPago);
            PImportes.Controls.Add(TBSubtotal);
            PImportes.Controls.Add(TBEnvio);
            PImportes.Controls.Add(TBImporteT);
            PImportes.Controls.Add(LImporteT);
            PImportes.Controls.Add(LEnvio);
            PImportes.Controls.Add(LSubtotal);
            PImportes.Location = new Point(12, 602);
            PImportes.Name = "PImportes";
            PImportes.Size = new Size(533, 115);
            PImportes.TabIndex = 0;
            // 
            // TBSubtotal
            // 
            TBSubtotal.Font = new Font("Arial", 9.75F);
            TBSubtotal.Location = new Point(358, 22);
            TBSubtotal.Name = "TBSubtotal";
            TBSubtotal.Size = new Size(153, 22);
            TBSubtotal.TabIndex = 9;
            // 
            // TBEnvio
            // 
            TBEnvio.Font = new Font("Arial", 9.75F);
            TBEnvio.Location = new Point(411, 52);
            TBEnvio.Name = "TBEnvio";
            TBEnvio.Size = new Size(100, 22);
            TBEnvio.TabIndex = 8;
            // 
            // TBImporteT
            // 
            TBImporteT.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBImporteT.Location = new Point(358, 80);
            TBImporteT.Name = "TBImporteT";
            TBImporteT.Size = new Size(153, 26);
            TBImporteT.TabIndex = 7;
            // 
            // LImporteT
            // 
            LImporteT.AutoSize = true;
            LImporteT.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LImporteT.Location = new Point(11, 80);
            LImporteT.Name = "LImporteT";
            LImporteT.Size = new Size(114, 19);
            LImporteT.TabIndex = 6;
            LImporteT.Text = "Importe Total:";
            // 
            // LEnvio
            // 
            LEnvio.AutoSize = true;
            LEnvio.Font = new Font("Arial", 11.25F);
            LEnvio.Location = new Point(11, 54);
            LEnvio.Name = "LEnvio";
            LEnvio.Size = new Size(109, 17);
            LEnvio.TabIndex = 5;
            LEnvio.Text = "Costo de envío:";
            // 
            // LSubtotal
            // 
            LSubtotal.AutoSize = true;
            LSubtotal.Font = new Font("Arial", 11.25F);
            LSubtotal.Location = new Point(11, 27);
            LSubtotal.Name = "LSubtotal";
            LSubtotal.Size = new Size(65, 17);
            LSubtotal.TabIndex = 4;
            LSubtotal.Text = "Subtotal:";
            // 
            // PDatosTienda
            // 
            PDatosTienda.BorderStyle = BorderStyle.FixedSingle;
            PDatosTienda.Controls.Add(LDirecT2);
            PDatosTienda.Controls.Add(LTelefonoT2);
            PDatosTienda.Controls.Add(LCuitT2);
            PDatosTienda.Controls.Add(LRazonST2);
            PDatosTienda.Controls.Add(LTelefonoT);
            PDatosTienda.Controls.Add(LDirecT);
            PDatosTienda.Controls.Add(LCuitT);
            PDatosTienda.Controls.Add(LRazonST);
            PDatosTienda.Controls.Add(LDatosTienda);
            PDatosTienda.Font = new Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PDatosTienda.Location = new Point(12, 81);
            PDatosTienda.Name = "PDatosTienda";
            PDatosTienda.Size = new Size(533, 99);
            PDatosTienda.TabIndex = 0;
            // 
            // LDirecT2
            // 
            LDirecT2.AutoSize = true;
            LDirecT2.Font = new Font("Arial", 9.75F);
            LDirecT2.Location = new Point(345, 63);
            LDirecT2.Name = "LDirecT2";
            LDirecT2.Size = new Size(62, 16);
            LDirecT2.TabIndex = 8;
            LDirecT2.Text = "Junín 575";
            // 
            // LTelefonoT2
            // 
            LTelefonoT2.AutoSize = true;
            LTelefonoT2.Font = new Font("Arial", 9.75F);
            LTelefonoT2.Location = new Point(404, 36);
            LTelefonoT2.Name = "LTelefonoT2";
            LTelefonoT2.Size = new Size(107, 16);
            LTelefonoT2.TabIndex = 7;
            LTelefonoT2.Text = "+54 3794 123456";
            // 
            // LCuitT2
            // 
            LCuitT2.AutoSize = true;
            LCuitT2.Font = new Font("Arial", 9.75F);
            LCuitT2.Location = new Point(62, 65);
            LCuitT2.Name = "LCuitT2";
            LCuitT2.Size = new Size(92, 16);
            LCuitT2.TabIndex = 6;
            LCuitT2.Text = "27-12345678-5";
            // 
            // LRazonST2
            // 
            LRazonST2.AutoSize = true;
            LRazonST2.Font = new Font("Arial", 9.75F);
            LRazonST2.Location = new Point(118, 36);
            LRazonST2.Name = "LRazonST2";
            LRazonST2.Size = new Size(113, 16);
            LRazonST2.TabIndex = 5;
            LRazonST2.Text = "Auren Padel Store";
            // 
            // LTelefonoT
            // 
            LTelefonoT.AutoSize = true;
            LTelefonoT.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            LTelefonoT.Location = new Point(330, 36);
            LTelefonoT.Name = "LTelefonoT";
            LTelefonoT.Size = new Size(75, 18);
            LTelefonoT.TabIndex = 4;
            LTelefonoT.Text = "Teléfono:";
            // 
            // LDirecT
            // 
            LDirecT.AutoSize = true;
            LDirecT.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            LDirecT.Location = new Point(264, 63);
            LDirecT.Name = "LDirecT";
            LDirecT.Size = new Size(80, 18);
            LDirecT.TabIndex = 3;
            LDirecT.Text = "Dirección:";
            // 
            // LCuitT
            // 
            LCuitT.AutoSize = true;
            LCuitT.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            LCuitT.Location = new Point(15, 64);
            LCuitT.Name = "LCuitT";
            LCuitT.Size = new Size(46, 18);
            LCuitT.TabIndex = 2;
            LCuitT.Text = "CUIT:";
            // 
            // LRazonST
            // 
            LRazonST.AutoSize = true;
            LRazonST.Font = new Font("Arial", 11.25F, FontStyle.Bold);
            LRazonST.Location = new Point(15, 36);
            LRazonST.Name = "LRazonST";
            LRazonST.Size = new Size(104, 18);
            LRazonST.TabIndex = 1;
            LRazonST.Text = "Razón Social:";
            // 
            // LDatosTienda
            // 
            LDatosTienda.AutoSize = true;
            LDatosTienda.Font = new Font("Arial", 14.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            LDatosTienda.Location = new Point(176, 2);
            LDatosTienda.Name = "LDatosTienda";
            LDatosTienda.Size = new Size(168, 22);
            LDatosTienda.TabIndex = 1;
            LDatosTienda.Text = "Datos de la Tienda";
            // 
            // PProdFact
            // 
            PProdFact.BorderStyle = BorderStyle.FixedSingle;
            PProdFact.Controls.Add(DGProdFact);
            PProdFact.Location = new Point(12, 300);
            PProdFact.Name = "PProdFact";
            PProdFact.Size = new Size(533, 296);
            PProdFact.TabIndex = 0;
            // 
            // DGProdFact
            // 
            DGProdFact.AllowUserToAddRows = false;
            DGProdFact.AllowUserToDeleteRows = false;
            DGProdFact.AllowUserToResizeRows = false;
            DGProdFact.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGProdFact.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGProdFact.BackgroundColor = Color.White;
            DGProdFact.BorderStyle = BorderStyle.None;
            DGProdFact.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DGProdFact.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGProdFact.Columns.AddRange(new DataGridViewColumn[] { ColNombre, ColPrecioUnitario, ColCantidad, ColSubtotal });
            DGProdFact.Dock = DockStyle.Fill;
            DGProdFact.EnableHeadersVisualStyles = false;
            DGProdFact.Location = new Point(0, 0);
            DGProdFact.MultiSelect = false;
            DGProdFact.Name = "DGProdFact";
            DGProdFact.ReadOnly = true;
            DGProdFact.RowHeadersVisible = false;
            DGProdFact.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGProdFact.Size = new Size(531, 294);
            DGProdFact.TabIndex = 0;
            // 
            // ColNombre
            // 
            ColNombre.FillWeight = 48F;
            ColNombre.HeaderText = "Nombre del Producto";
            ColNombre.MinimumWidth = 120;
            ColNombre.Name = "ColNombre";
            ColNombre.ReadOnly = true;
            // 
            // ColPrecioUnitario
            // 
            ColPrecioUnitario.FillWeight = 18F;
            ColPrecioUnitario.HeaderText = "Precio Unitario";
            ColPrecioUnitario.MinimumWidth = 90;
            ColPrecioUnitario.Name = "ColPrecioUnitario";
            ColPrecioUnitario.ReadOnly = true;
            // 
            // ColCantidad
            // 
            ColCantidad.FillWeight = 14F;
            ColCantidad.HeaderText = "Cantidad";
            ColCantidad.MinimumWidth = 70;
            ColCantidad.Name = "ColCantidad";
            ColCantidad.ReadOnly = true;
            // 
            // ColSubtotal
            // 
            ColSubtotal.FillWeight = 20F;
            ColSubtotal.HeaderText = "Subtotal";
            ColSubtotal.MinimumWidth = 90;
            ColSubtotal.Name = "ColSubtotal";
            ColSubtotal.ReadOnly = true;
            // 
            // BImprimiFact
            // 
            BImprimiFact.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BImprimiFact.Location = new Point(470, 723);
            BImprimiFact.Name = "BImprimiFact";
            BImprimiFact.Size = new Size(75, 23);
            BImprimiFact.TabIndex = 1;
            BImprimiFact.Text = "Imprimir";
            BImprimiFact.UseVisualStyleBackColor = true;
            // 
            // LMetodoPago
            // 
            LMetodoPago.AutoSize = true;
            LMetodoPago.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LMetodoPago.Location = new Point(11, 8);
            LMetodoPago.Name = "LMetodoPago";
            LMetodoPago.Size = new Size(98, 15);
            LMetodoPago.TabIndex = 10;
            LMetodoPago.Text = "Método de pago:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(115, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 21);
            textBox1.TabIndex = 11;
            // 
            // FVerFactura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 749);
            Controls.Add(BImprimiFact);
            Controls.Add(PDatosC);
            Controls.Add(PImportes);
            Controls.Add(PDatosTienda);
            Controls.Add(PProdFact);
            Controls.Add(PDatosFact);
            Name = "FVerFactura";
            Text = "Factura";
            PDatosFact.ResumeLayout(false);
            PDatosFact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PBLogoAuren).EndInit();
            PDatosC.ResumeLayout(false);
            PDatosC.PerformLayout();
            PImportes.ResumeLayout(false);
            PImportes.PerformLayout();
            PDatosTienda.ResumeLayout(false);
            PDatosTienda.PerformLayout();
            PProdFact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGProdFact).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PDatosFact;
        private Panel PDatosC;
        private Panel PImportes;
        private Panel PDatosTienda;
        private Panel PProdFact;
        private Label LNroFact;
        private Label LFechaFact;
        private TextBox TBFechaFact;
        private TextBox TBNroFact;
        private PictureBox PBLogoAuren;
        private Label LDatosTienda;
        private Label LDirecT;
        private Label LCuitT;
        private Label LRazonST;
        private TextBox TBDniC;
        private TextBox TBTelC;
        private TextBox TBDirecC;
        private TextBox TBNyAC;
        private Label LDirecT2;
        private Label LTelefonoT2;
        private Label LCuitT2;
        private Label LRazonST2;
        private Label LTelefonoT;
        private Label label16;
        private Label LDniC;
        private Label LDirecC;
        private Label LTelC;
        private Label LNyAC;
        private Button BImprimiFact;
        private Label LImporteT;
        private Label LEnvio;
        private Label LSubtotal;
        private TextBox TBSubtotal;
        private TextBox TBEnvio;
        private TextBox TBImporteT;
        private DataGridView DGProdFact;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn ColPrecioUnitario;
        private DataGridViewTextBoxColumn ColCantidad;
        private DataGridViewTextBoxColumn ColSubtotal;
        private TextBox textBox1;
        private Label LMetodoPago;
    }
}