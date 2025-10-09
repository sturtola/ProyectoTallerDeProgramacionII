using System.Windows.Forms;
using System.Drawing;

namespace AurenPadelStore.CPresentacion.Empleados.Facturas.ListarFacturas
{
    partial class FListarFacturas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            LTitulo = new Label();
            PListaFacturas = new Panel();
            CBFiltroF = new ComboBox();
            LFiltrar = new Label();
            TBBuscarF = new TextBox();
            DGListaFacturas = new DataGridView();
            colNro = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colDni = new DataGridViewTextBoxColumn();
            colVenta = new DataGridViewTextBoxColumn();
            colImporte = new DataGridViewTextBoxColumn();
            colVerF = new DataGridViewButtonColumn();
            colEliminar = new DataGridViewButtonColumn();
            LBuscarF = new Label();
            PListaFacturas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaFacturas).BeginInit();
            SuspendLayout();
            // 
            // LTitulo
            // 
            LTitulo.AutoSize = true;
            LTitulo.BackColor = Color.Transparent;
            LTitulo.Font = new Font("Century Gothic", 20.25F);
            LTitulo.ForeColor = Color.LightGray;
            LTitulo.Location = new Point(547, 60);
            LTitulo.Name = "LTitulo";
            LTitulo.Size = new Size(232, 33);
            LTitulo.TabIndex = 0;
            LTitulo.Text = "Lista de Facturas";
            // 
            // PListaFacturas
            // 
            PListaFacturas.BackColor = Color.Transparent;
            PListaFacturas.Controls.Add(LBuscarF);
            PListaFacturas.Controls.Add(CBFiltroF);
            PListaFacturas.Controls.Add(LFiltrar);
            PListaFacturas.Controls.Add(TBBuscarF);
            PListaFacturas.Controls.Add(DGListaFacturas);
            PListaFacturas.Location = new Point(125, 107);
            PListaFacturas.Name = "PListaFacturas";
            PListaFacturas.Size = new Size(1098, 503);
            PListaFacturas.TabIndex = 1;
            // 
            // CBFiltroF
            // 
            CBFiltroF.BackColor = Color.LightGray;
            CBFiltroF.Cursor = Cursors.Hand;
            CBFiltroF.DropDownStyle = ComboBoxStyle.DropDownList;
            CBFiltroF.Font = new Font("Century Gothic", 12F);
            CBFiltroF.FormattingEnabled = true;
            CBFiltroF.Items.AddRange(new object[] { "Sin filtro", "Fecha (más reciente)", "Fecha (más antigua)", "Cliente A-Z", "Cliente Z-A" });
            CBFiltroF.Location = new Point(933, 16);
            CBFiltroF.Name = "CBFiltroF";
            CBFiltroF.Size = new Size(162, 29);
            CBFiltroF.TabIndex = 2;
            // 
            // LFiltrar
            // 
            LFiltrar.AutoSize = true;
            LFiltrar.Font = new Font("Century Gothic", 14.25F);
            LFiltrar.ForeColor = Color.LightGray;
            LFiltrar.Location = new Point(856, 18);
            LFiltrar.Name = "LFiltrar";
            LFiltrar.Size = new Size(62, 22);
            LFiltrar.TabIndex = 3;
            LFiltrar.Text = "Filtrar:";
            // 
            // TBBuscarF
            // 
            TBBuscarF.BackColor = Color.FromArgb(64, 64, 64);
            TBBuscarF.BorderStyle = BorderStyle.FixedSingle;
            TBBuscarF.Cursor = Cursors.IBeam;
            TBBuscarF.Font = new Font("Century Gothic", 12F);
            TBBuscarF.ForeColor = Color.LightGray;
            TBBuscarF.Location = new Point(113, 16);
            TBBuscarF.Name = "TBBuscarF";
            TBBuscarF.PlaceholderText = "  Factura...";
            TBBuscarF.Size = new Size(218, 27);
            TBBuscarF.TabIndex = 1;
            // 
            // DGListaFacturas
            // 
            DGListaFacturas.AllowUserToAddRows = false;
            DGListaFacturas.BackgroundColor = Color.FromArgb(64, 64, 64);
            DGListaFacturas.BorderStyle = BorderStyle.None;
            DGListaFacturas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F);
            dataGridViewCellStyle1.ForeColor = Color.LightGray;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            DGListaFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGListaFacturas.ColumnHeadersHeight = 32;
            DGListaFacturas.Columns.AddRange(new DataGridViewColumn[] { colNro, colFecha, colTipo, colCliente, colDni, colVenta, colImporte, colVerF, colEliminar });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 100, 100);
            dataGridViewCellStyle5.Font = new Font("Century Gothic", 11F);
            dataGridViewCellStyle5.ForeColor = Color.LightGray;
            dataGridViewCellStyle5.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            DGListaFacturas.DefaultCellStyle = dataGridViewCellStyle5;
            DGListaFacturas.EnableHeadersVisualStyles = false;
            DGListaFacturas.GridColor = Color.Black;
            DGListaFacturas.Location = new Point(0, 57);
            DGListaFacturas.MultiSelect = false;
            DGListaFacturas.Name = "DGListaFacturas";
            DGListaFacturas.RowHeadersVisible = false;
            DGListaFacturas.RowTemplate.Height = 40;
            DGListaFacturas.Size = new Size(1100, 446);
            DGListaFacturas.TabIndex = 0;
            // 
            // colNro
            // 
            colNro.HeaderText = "Nro Factura";
            colNro.Name = "colNro";
            colNro.Width = 150;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.Width = 120;
            // 
            // colTipo
            // 
            colTipo.HeaderText = "Tipo";
            colTipo.Name = "colTipo";
            colTipo.Width = 80;
            // 
            // colCliente
            // 
            colCliente.HeaderText = "Cliente";
            colCliente.Name = "colCliente";
            colCliente.Width = 200;
            // 
            // colDni
            // 
            colDni.HeaderText = "Documento";
            colDni.Name = "colDni";
            colDni.Width = 120;
            // 
            // colVenta
            // 
            colVenta.HeaderText = "Nro Venta";
            colVenta.Name = "colVenta";
            colVenta.Width = 150;
            // 
            // colImporte
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N2";
            colImporte.DefaultCellStyle = dataGridViewCellStyle2;
            colImporte.HeaderText = "Importe Total";
            colImporte.Name = "colImporte";
            colImporte.Width = 130;
            // 
            // colVerF
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.LightSkyBlue;
            dataGridViewCellStyle3.ForeColor = Color.Black;
            colVerF.DefaultCellStyle = dataGridViewCellStyle3;
            colVerF.FlatStyle = FlatStyle.Flat;
            colVerF.HeaderText = "A";
            colVerF.Name = "colVerF";
            colVerF.Text = "Ver";
            colVerF.UseColumnTextForButtonValue = true;
            colVerF.Width = 59;
            // 
            // colEliminar
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.LightCoral;
            dataGridViewCellStyle4.ForeColor = Color.Black;
            colEliminar.DefaultCellStyle = dataGridViewCellStyle4;
            colEliminar.FlatStyle = FlatStyle.Flat;
            colEliminar.HeaderText = "X";
            colEliminar.Name = "colEliminar";
            colEliminar.Text = "Eliminar";
            colEliminar.UseColumnTextForButtonValue = true;
            colEliminar.Width = 90;
            // 
            // LBuscarF
            // 
            LBuscarF.AutoSize = true;
            LBuscarF.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBuscarF.ForeColor = Color.LightGray;
            LBuscarF.Location = new Point(22, 18);
            LBuscarF.Name = "LBuscarF";
            LBuscarF.Size = new Size(76, 22);
            LBuscarF.TabIndex = 4;
            LBuscarF.Text = "Buscar:";
            // 
            // FListarFacturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            ClientSize = new Size(1334, 659);
            Controls.Add(PListaFacturas);
            Controls.Add(LTitulo);
            Name = "FListarFacturas";
            Text = "Lista de Facturas";
            PListaFacturas.ResumeLayout(false);
            PListaFacturas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaFacturas).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label LTitulo;
        private Panel PListaFacturas;
        private ComboBox CBFiltroF;
        private Label LFiltrar;
        private TextBox TBBuscarF;
        private DataGridView DGListaFacturas;

        private DataGridViewTextBoxColumn colNro;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colDni;
        private DataGridViewTextBoxColumn colVenta;
        private DataGridViewTextBoxColumn colImporte;
        private DataGridViewButtonColumn colVerF;
        private DataGridViewButtonColumn colEliminar;
        private Label LBuscarF;
    }
}
