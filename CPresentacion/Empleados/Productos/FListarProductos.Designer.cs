using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados.Productos
{
    partial class FListarProductos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FListarProductos));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            LListaProductos = new Label();
            PAgregarProducto = new Panel();
            TBImagenProd = new TextBox();
            TBPrecioP = new TextBox();
            TBStockP = new TextBox();
            TBNombreP = new TextBox();
            TBMaterialP = new TextBox();
            TBDescP = new TextBox();
            TBMarcaP = new TextBox();
            BAgregarProducto = new Button();
            LPrecioProd = new Label();
            LImagenProd = new Label();
            LStockProd = new Label();
            LNombreProd = new Label();
            LDescProd = new Label();
            LMarcaProd = new Label();
            LMaterialProd = new Label();
            LAgregarProducto = new Label();
            PListaProductos = new Panel();
            BBuscarProd = new Button();
            CBFiltrosProd = new ComboBox();
            LFiltrar = new Label();
            TBBuscarProd = new TextBox();
            DGListaProd = new DataGridView();
            colImagen = new DataGridViewImageColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            PAgregarProducto.SuspendLayout();
            PListaProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaProd).BeginInit();
            SuspendLayout();
            // 
            // LListaProductos
            // 
            LListaProductos.AutoSize = true;
            LListaProductos.BackColor = Color.Transparent;
            LListaProductos.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LListaProductos.ForeColor = Color.LightGray;
            LListaProductos.Location = new Point(722, 42);
            LListaProductos.Name = "LListaProductos";
            LListaProductos.Size = new Size(254, 33);
            LListaProductos.TabIndex = 0;
            LListaProductos.Text = "Lista de Productos";
            // 
            // PAgregarProducto
            // 
            PAgregarProducto.BackColor = Color.FromArgb(64, 64, 64);
            PAgregarProducto.Controls.Add(TBImagenProd);
            PAgregarProducto.Controls.Add(TBPrecioP);
            PAgregarProducto.Controls.Add(TBStockP);
            PAgregarProducto.Controls.Add(TBNombreP);
            PAgregarProducto.Controls.Add(TBMaterialP);
            PAgregarProducto.Controls.Add(TBDescP);
            PAgregarProducto.Controls.Add(TBMarcaP);
            PAgregarProducto.Controls.Add(BAgregarProducto);
            PAgregarProducto.Controls.Add(LPrecioProd);
            PAgregarProducto.Controls.Add(LImagenProd);
            PAgregarProducto.Controls.Add(LStockProd);
            PAgregarProducto.Controls.Add(LNombreProd);
            PAgregarProducto.Controls.Add(LDescProd);
            PAgregarProducto.Controls.Add(LMarcaProd);
            PAgregarProducto.Controls.Add(LMaterialProd);
            PAgregarProducto.ForeColor = Color.LightGray;
            PAgregarProducto.Location = new Point(73, 147);
            PAgregarProducto.Name = "PAgregarProducto";
            PAgregarProducto.Size = new Size(274, 465);
            PAgregarProducto.TabIndex = 1;
            // 
            // TBImagenProd
            // 
            TBImagenProd.BackColor = Color.LightGray;
            TBImagenProd.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBImagenProd.Location = new Point(104, 347);
            TBImagenProd.Name = "TBImagenProd";
            TBImagenProd.Size = new Size(155, 27);
            TBImagenProd.TabIndex = 14;
            // 
            // TBPrecioP
            // 
            TBPrecioP.BackColor = Color.Gainsboro;
            TBPrecioP.Font = new Font("Century Gothic", 12F);
            TBPrecioP.Location = new Point(161, 301);
            TBPrecioP.Name = "TBPrecioP";
            TBPrecioP.Size = new Size(98, 27);
            TBPrecioP.TabIndex = 6;
            // 
            // TBStockP
            // 
            TBStockP.BackColor = Color.Gainsboro;
            TBStockP.Font = new Font("Century Gothic", 12F);
            TBStockP.Location = new Point(13, 301);
            TBStockP.Name = "TBStockP";
            TBStockP.Size = new Size(99, 27);
            TBStockP.TabIndex = 3;
            // 
            // TBNombreP
            // 
            TBNombreP.BackColor = Color.Gainsboro;
            TBNombreP.Font = new Font("Century Gothic", 12F);
            TBNombreP.Location = new Point(13, 39);
            TBNombreP.Name = "TBNombreP";
            TBNombreP.Size = new Size(246, 27);
            TBNombreP.TabIndex = 4;
            // 
            // TBMaterialP
            // 
            TBMaterialP.BackColor = Color.Gainsboro;
            TBMaterialP.Font = new Font("Century Gothic", 12F);
            TBMaterialP.Location = new Point(13, 236);
            TBMaterialP.Name = "TBMaterialP";
            TBMaterialP.Size = new Size(246, 27);
            TBMaterialP.TabIndex = 1;
            // 
            // TBDescP
            // 
            TBDescP.BackColor = Color.Gainsboro;
            TBDescP.Font = new Font("Century Gothic", 12F);
            TBDescP.Location = new Point(13, 105);
            TBDescP.Name = "TBDescP";
            TBDescP.Size = new Size(246, 27);
            TBDescP.TabIndex = 2;
            // 
            // TBMarcaP
            // 
            TBMarcaP.BackColor = Color.Gainsboro;
            TBMarcaP.Font = new Font("Century Gothic", 12F);
            TBMarcaP.Location = new Point(13, 169);
            TBMarcaP.Name = "TBMarcaP";
            TBMarcaP.Size = new Size(246, 27);
            TBMarcaP.TabIndex = 0;
            // 
            // BAgregarProducto
            // 
            BAgregarProducto.BackColor = Color.YellowGreen;
            BAgregarProducto.FlatStyle = FlatStyle.Popup;
            BAgregarProducto.Font = new Font("Century Gothic", 14.25F);
            BAgregarProducto.ForeColor = Color.Black;
            BAgregarProducto.Location = new Point(13, 403);
            BAgregarProducto.Name = "BAgregarProducto";
            BAgregarProducto.Size = new Size(246, 33);
            BAgregarProducto.TabIndex = 5;
            BAgregarProducto.Text = "Agregar Producto";
            BAgregarProducto.UseVisualStyleBackColor = false;
            BAgregarProducto.Click += BAgregarProducto_Click;
            // 
            // LPrecioProd
            // 
            LPrecioProd.AutoSize = true;
            LPrecioProd.Font = new Font("Century Gothic", 14.25F);
            LPrecioProd.Location = new Point(176, 276);
            LPrecioProd.Name = "LPrecioProd";
            LPrecioProd.Size = new Size(66, 22);
            LPrecioProd.TabIndex = 7;
            LPrecioProd.Text = "Precio";
            // 
            // LImagenProd
            // 
            LImagenProd.AutoSize = true;
            LImagenProd.Font = new Font("Century Gothic", 14.25F);
            LImagenProd.Location = new Point(18, 347);
            LImagenProd.Name = "LImagenProd";
            LImagenProd.Size = new Size(82, 22);
            LImagenProd.TabIndex = 8;
            LImagenProd.Text = "Imagen";
            // 
            // LStockProd
            // 
            LStockProd.AutoSize = true;
            LStockProd.Font = new Font("Century Gothic", 14.25F);
            LStockProd.Location = new Point(37, 276);
            LStockProd.Name = "LStockProd";
            LStockProd.Size = new Size(60, 22);
            LStockProd.TabIndex = 9;
            LStockProd.Text = "Stock";
            // 
            // LNombreProd
            // 
            LNombreProd.AutoSize = true;
            LNombreProd.Font = new Font("Century Gothic", 14.25F);
            LNombreProd.Location = new Point(16, 14);
            LNombreProd.Name = "LNombreProd";
            LNombreProd.Size = new Size(84, 22);
            LNombreProd.TabIndex = 10;
            LNombreProd.Text = "Nombre";
            // 
            // LDescProd
            // 
            LDescProd.AutoSize = true;
            LDescProd.Font = new Font("Century Gothic", 14.25F);
            LDescProd.Location = new Point(13, 80);
            LDescProd.Name = "LDescProd";
            LDescProd.Size = new Size(116, 22);
            LDescProd.TabIndex = 11;
            LDescProd.Text = "Descripción";
            // 
            // LMarcaProd
            // 
            LMarcaProd.AutoSize = true;
            LMarcaProd.Font = new Font("Century Gothic", 14.25F);
            LMarcaProd.Location = new Point(13, 144);
            LMarcaProd.Name = "LMarcaProd";
            LMarcaProd.Size = new Size(71, 22);
            LMarcaProd.TabIndex = 12;
            LMarcaProd.Text = "Marca";
            // 
            // LMaterialProd
            // 
            LMaterialProd.AutoSize = true;
            LMaterialProd.Font = new Font("Century Gothic", 14.25F);
            LMaterialProd.Location = new Point(13, 211);
            LMaterialProd.Name = "LMaterialProd";
            LMaterialProd.Size = new Size(84, 22);
            LMaterialProd.TabIndex = 13;
            LMaterialProd.Text = "Material";
            // 
            // LAgregarProducto
            // 
            LAgregarProducto.AutoSize = true;
            LAgregarProducto.BackColor = Color.Transparent;
            LAgregarProducto.Font = new Font("Century Gothic", 20.25F);
            LAgregarProducto.ForeColor = Color.LightGray;
            LAgregarProducto.Location = new Point(86, 91);
            LAgregarProducto.Name = "LAgregarProducto";
            LAgregarProducto.Size = new Size(251, 33);
            LAgregarProducto.TabIndex = 0;
            LAgregarProducto.Text = "Agregar Producto";
            // 
            // PListaProductos
            // 
            PListaProductos.BackColor = Color.Transparent;
            PListaProductos.Controls.Add(BBuscarProd);
            PListaProductos.Controls.Add(CBFiltrosProd);
            PListaProductos.Controls.Add(LFiltrar);
            PListaProductos.Controls.Add(TBBuscarProd);
            PListaProductos.Controls.Add(DGListaProd);
            PListaProductos.ForeColor = Color.LightGray;
            PListaProductos.Location = new Point(385, 102);
            PListaProductos.Name = "PListaProductos";
            PListaProductos.Size = new Size(882, 510);
            PListaProductos.TabIndex = 2;
            // 
            // BBuscarProd
            // 
            BBuscarProd.BackColor = Color.LightGray;
            BBuscarProd.BackgroundImage = (Image)resources.GetObject("BBuscarProd.BackgroundImage");
            BBuscarProd.BackgroundImageLayout = ImageLayout.Stretch;
            BBuscarProd.FlatStyle = FlatStyle.Popup;
            BBuscarProd.Location = new Point(236, 13);
            BBuscarProd.Name = "BBuscarProd";
            BBuscarProd.Size = new Size(31, 27);
            BBuscarProd.TabIndex = 6;
            BBuscarProd.UseVisualStyleBackColor = false;
            // 
            // CBFiltrosProd
            // 
            CBFiltrosProd.BackColor = Color.LightGray;
            CBFiltrosProd.DropDownStyle = ComboBoxStyle.DropDownList;
            CBFiltrosProd.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBFiltrosProd.FormattingEnabled = true;
            CBFiltrosProd.Location = new Point(713, 11);
            CBFiltrosProd.Name = "CBFiltrosProd";
            CBFiltrosProd.Size = new Size(162, 29);
            CBFiltrosProd.TabIndex = 5;
            // 
            // LFiltrar
            // 
            LFiltrar.AutoSize = true;
            LFiltrar.BackColor = Color.Transparent;
            LFiltrar.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LFiltrar.ForeColor = Color.LightGray;
            LFiltrar.Location = new Point(645, 13);
            LFiltrar.Name = "LFiltrar";
            LFiltrar.Size = new Size(62, 22);
            LFiltrar.TabIndex = 3;
            LFiltrar.Text = "Filtrar:";
            // 
            // TBBuscarProd
            // 
            TBBuscarProd.Anchor = AnchorStyles.None;
            TBBuscarProd.BackColor = Color.FromArgb(64, 64, 64);
            TBBuscarProd.BorderStyle = BorderStyle.FixedSingle;
            TBBuscarProd.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBBuscarProd.ForeColor = Color.LightGray;
            TBBuscarProd.Location = new Point(5, 15);
            TBBuscarProd.Name = "TBBuscarProd";
            TBBuscarProd.PlaceholderText = "  Buscar Producto...";
            TBBuscarProd.Size = new Size(218, 27);
            TBBuscarProd.TabIndex = 4;
            // 
            // DGListaProd
            // 
            DGListaProd.AllowUserToOrderColumns = true;
            DGListaProd.Anchor = AnchorStyles.None;
            DGListaProd.BackgroundColor = Color.FromArgb(64, 64, 64);
            DGListaProd.BorderStyle = BorderStyle.None;
            DGListaProd.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F);
            dataGridViewCellStyle1.ForeColor = Color.LightGray;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGListaProd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGListaProd.ColumnHeadersHeight = 25;
            DGListaProd.Columns.AddRange(new DataGridViewColumn[] { colImagen, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewButtonColumn1, dataGridViewButtonColumn2 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(100, 100, 100);
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 11F);
            dataGridViewCellStyle3.ForeColor = Color.LightGray;
            dataGridViewCellStyle3.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DGListaProd.DefaultCellStyle = dataGridViewCellStyle3;
            DGListaProd.EnableHeadersVisualStyles = false;
            DGListaProd.GridColor = Color.Black;
            DGListaProd.Location = new Point(0, 59);
            DGListaProd.MultiSelect = false;
            DGListaProd.Name = "DGListaProd";
            DGListaProd.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            DGListaProd.RowHeadersVisible = false;
            DGListaProd.RowTemplate.Height = 40;
            DGListaProd.Size = new Size(882, 451);
            DGListaProd.TabIndex = 0;
            // 
            // colImagen
            // 
            colImagen.HeaderText = "Img";
            colImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            colImagen.Name = "colImagen";
            colImagen.Resizable = DataGridViewTriState.False;
            colImagen.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 126;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Marca";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 126;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Material";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 126;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewTextBoxColumn4.HeaderText = "Descripción";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 180;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Stock";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Precio";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 93;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewButtonColumn1.HeaderText = "E";
            dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            dataGridViewButtonColumn1.Text = "Editar";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            dataGridViewButtonColumn1.Width = 65;
            // 
            // dataGridViewButtonColumn2
            // 
            dataGridViewButtonColumn2.HeaderText = "X";
            dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            dataGridViewButtonColumn2.Text = "Eliminar";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
            dataGridViewButtonColumn2.Width = 65;
            // 
            // FListarProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1334, 659);
            Controls.Add(LAgregarProducto);
            Controls.Add(PListaProductos);
            Controls.Add(PAgregarProducto);
            Controls.Add(LListaProductos);
            Name = "FListarProductos";
            Text = "Lista de Productos";
            PAgregarProducto.ResumeLayout(false);
            PAgregarProducto.PerformLayout();
            PListaProductos.ResumeLayout(false);
            PListaProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaProd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LListaProductos;
        private Panel PAgregarProducto;
        private Label LAgregarProducto;
        private Panel PListaProductos;
        private Label LNombreProd;
        private Label LImagenProd;
        private Label LMaterialProd;
        private Label LMarcaProd;
        private Label LDescProd;
        private Button BAgregarProducto;
        private Label LPrecioProd;
        private Label LStockProd;
        private TextBox TBPrecioP;
        private TextBox TBStockP;
        private TextBox TBNombreP;
        private TextBox TBMaterialP;
        private TextBox TBDescP;
        private TextBox TBMarcaP;
        private DataGridView DGListaProd;
        private DataGridViewImageColumn colImagen;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private DataGridViewButtonColumn dataGridViewButtonColumn2;
        private Label LFiltrar;
        private TextBox TBBuscarProd;
        private ComboBox CBFiltrosProd;
        private Button BBuscarProd;
        private TextBox TBImagenProd;
    }
}
