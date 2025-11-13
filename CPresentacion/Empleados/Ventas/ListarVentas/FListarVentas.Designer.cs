using System.Windows.Forms;
using System.Drawing;

namespace AurenPadelStore.CPresentacion.Empleados.Ventas.ListarVentas
{
    partial class FListarVentas
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
            PListaVentas = new Panel();
            CBFiltroV = new ComboBox();
            LFiltrar = new Label();
            TBBuscarV = new TextBox();
            DGListaVentas = new DataGridView();
            colNroVenta = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colDni = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colImporte = new DataGridViewTextBoxColumn();
            colVerV = new DataGridViewButtonColumn();
            colEliminar = new DataGridViewButtonColumn();
            PListaVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaVentas).BeginInit();
            SuspendLayout();
            // 
            // LTitulo
            // 
            LTitulo.AutoSize = true;
            LTitulo.BackColor = Color.Transparent;
            LTitulo.Font = new Font("Century Gothic", 20.25F);
            LTitulo.ForeColor = Color.LightGray;
            LTitulo.Location = new Point(560, 60);
            LTitulo.Name = "LTitulo";
            LTitulo.Size = new Size(213, 33);
            LTitulo.TabIndex = 0;
            LTitulo.Text = "Lista de Ventas";
            // 
            // PListaVentas
            // 
            PListaVentas.BackColor = Color.Transparent;
            PListaVentas.Controls.Add(CBFiltroV);
            PListaVentas.Controls.Add(LFiltrar);
            PListaVentas.Controls.Add(TBBuscarV);
            PListaVentas.Controls.Add(DGListaVentas);
            PListaVentas.Location = new Point(183, 111);
            PListaVentas.Name = "PListaVentas";
            PListaVentas.Size = new Size(983, 503);
            PListaVentas.TabIndex = 1;
            // 
            // CBFiltroV
            // 
            CBFiltroV.BackColor = Color.LightGray;
            CBFiltroV.Cursor = Cursors.Hand;
            CBFiltroV.DropDownStyle = ComboBoxStyle.DropDownList;
            CBFiltroV.Font = new Font("Century Gothic", 12F);
            CBFiltroV.FormattingEnabled = true;
            CBFiltroV.Items.AddRange(new object[] { "Sin filtro", "Fecha (más reciente)", "Fecha (más antigua)", "Cliente A-Z", "Cliente Z-A" });
            CBFiltroV.Location = new Point(781, 11);
            CBFiltroV.Name = "CBFiltroV";
            CBFiltroV.Size = new Size(199, 29);
            CBFiltroV.TabIndex = 2;
            // 
            // LFiltrar
            // 
            LFiltrar.AutoSize = true;
            LFiltrar.Font = new Font("Century Gothic", 14.25F);
            LFiltrar.ForeColor = Color.LightGray;
            LFiltrar.Location = new Point(713, 13);
            LFiltrar.Name = "LFiltrar";
            LFiltrar.Size = new Size(62, 22);
            LFiltrar.TabIndex = 3;
            LFiltrar.Text = "Filtrar:";
            // 
            // TBBuscarV
            // 
            TBBuscarV.BackColor = Color.FromArgb(64, 64, 64);
            TBBuscarV.BorderStyle = BorderStyle.FixedSingle;
            TBBuscarV.Cursor = Cursors.IBeam;
            TBBuscarV.Font = new Font("Century Gothic", 12F);
            TBBuscarV.ForeColor = Color.LightGray;
            TBBuscarV.Location = new Point(5, 11);
            TBBuscarV.Name = "TBBuscarV";
            TBBuscarV.PlaceholderText = "  Buscar venta...";
            TBBuscarV.Size = new Size(218, 27);
            TBBuscarV.TabIndex = 1;
            // 
            // DGListaVentas
            // 
            DGListaVentas.AllowUserToAddRows = false;
            DGListaVentas.BackgroundColor = Color.FromArgb(64, 64, 64);
            DGListaVentas.BorderStyle = BorderStyle.None;
            DGListaVentas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F);
            dataGridViewCellStyle1.ForeColor = Color.LightGray;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            DGListaVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGListaVentas.ColumnHeadersHeight = 32;
            DGListaVentas.Columns.AddRange(new DataGridViewColumn[] { colNroVenta, colFecha, colCliente, colDni, colCantidad, colImporte, colVerV, colEliminar });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 100, 100);
            dataGridViewCellStyle5.Font = new Font("Century Gothic", 11F);
            dataGridViewCellStyle5.ForeColor = Color.LightGray;
            dataGridViewCellStyle5.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            DGListaVentas.DefaultCellStyle = dataGridViewCellStyle5;
            DGListaVentas.EnableHeadersVisualStyles = false;
            DGListaVentas.GridColor = Color.Black;
            DGListaVentas.Location = new Point(0, 57);
            DGListaVentas.MultiSelect = false;
            DGListaVentas.Name = "DGListaVentas";
            DGListaVentas.RowHeadersVisible = false;
            DGListaVentas.RowTemplate.Height = 40;
            DGListaVentas.Size = new Size(980, 446);
            DGListaVentas.TabIndex = 0;
            // 
            // colNroVenta
            // 
            colNroVenta.HeaderText = "Nro Venta";
            colNroVenta.Name = "colNroVenta";
            colNroVenta.Width = 150;
            // 
            // colFecha
            // 
            colFecha.HeaderText = "Fecha";
            colFecha.Name = "colFecha";
            colFecha.Width = 120;
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
            // colCantidad
            // 
            colCantidad.HeaderText = "Cant. Prod.";
            colCantidad.Name = "colCantidad";
            colCantidad.Width = 110;
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
            // colVerV
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.LightSkyBlue;
            dataGridViewCellStyle3.ForeColor = Color.Black;
            colVerV.DefaultCellStyle = dataGridViewCellStyle3;
            colVerV.FlatStyle = FlatStyle.Flat;
            colVerV.HeaderText = "A";
            colVerV.Name = "colVerV";
            colVerV.Text = "Ver";
            colVerV.UseColumnTextForButtonValue = true;
            colVerV.Width = 59;
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
            colEliminar.Text = "Anular";
            colEliminar.UseColumnTextForButtonValue = true;
            colEliminar.Width = 90;
            // 
            // FListarVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            ClientSize = new Size(1334, 659);
            Controls.Add(PListaVentas);
            Controls.Add(LTitulo);
            Name = "FListarVentas";
            Text = "Lista de Ventas";
            PListaVentas.ResumeLayout(false);
            PListaVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label LTitulo;
        private Panel PListaVentas;
        private ComboBox CBFiltroV;
        private Label LFiltrar;
        private TextBox TBBuscarV;
        private DataGridView DGListaVentas;

        private DataGridViewTextBoxColumn colNroVenta;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colDni;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colImporte;
        private DataGridViewButtonColumn colVerV;
        private DataGridViewButtonColumn colEliminar;
    }
}
