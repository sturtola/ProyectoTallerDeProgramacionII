namespace AurenPadelStore.CPresentacion.Gerente.ListarUsuarios
{
    partial class FListarUsuarios
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel PListaUsuarios;
        private System.Windows.Forms.DataGridView DGVListaUs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FListarUsuarios));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            PListaUsuarios = new Panel();
            LFiltroUs = new Label();
            CBFiltroUs = new ComboBox();
            button1 = new Button();
            TBBuscar = new TextBox();
            DGVListaUs = new DataGridView();
            CDocumento = new DataGridViewTextBoxColumn();
            CNombre = new DataGridViewTextBoxColumn();
            CApellido = new DataGridViewTextBoxColumn();
            CRol = new DataGridViewTextBoxColumn();
            CEditar = new DataGridViewButtonColumn();
            CEliminar = new DataGridViewButtonColumn();
            LListadeUsuarios = new Label();
            PListaUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVListaUs).BeginInit();
            SuspendLayout();
            // 
            // PListaUsuarios
            // 
            PListaUsuarios.BackColor = Color.Transparent;
            PListaUsuarios.Controls.Add(LFiltroUs);
            PListaUsuarios.Controls.Add(CBFiltroUs);
            PListaUsuarios.Controls.Add(button1);
            PListaUsuarios.Controls.Add(TBBuscar);
            PListaUsuarios.Controls.Add(DGVListaUs);
            PListaUsuarios.Location = new Point(58, 100);
            PListaUsuarios.Margin = new Padding(3, 2, 3, 2);
            PListaUsuarios.Name = "PListaUsuarios";
            PListaUsuarios.Size = new Size(687, 300);
            PListaUsuarios.TabIndex = 0;
            // 
            // LFiltroUs
            // 
            LFiltroUs.AutoSize = true;
            LFiltroUs.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LFiltroUs.ForeColor = Color.LightGray;
            LFiltroUs.Location = new Point(479, 22);
            LFiltroUs.Name = "LFiltroUs";
            LFiltroUs.Size = new Size(62, 22);
            LFiltroUs.TabIndex = 3;
            LFiltroUs.Text = "Filtrar:";
            // 
            // CBFiltroUs
            // 
            CBFiltroUs.BackColor = Color.FromArgb(224, 224, 224);
            CBFiltroUs.FlatStyle = FlatStyle.Popup;
            CBFiltroUs.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBFiltroUs.ForeColor = Color.FromArgb(64, 64, 64);
            CBFiltroUs.FormattingEnabled = true;
            CBFiltroUs.Items.AddRange(new object[] { "Vendedor", "Gerente", "Administrador" });
            CBFiltroUs.Location = new Point(547, 17);
            CBFiltroUs.Name = "CBFiltroUs";
            CBFiltroUs.Size = new Size(137, 28);
            CBFiltroUs.TabIndex = 2;
            CBFiltroUs.Tag = "";
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(153, 17);
            button1.Name = "button1";
            button1.Size = new Size(32, 27);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = true;
            // 
            // TBBuscar
            // 
            TBBuscar.Anchor = AnchorStyles.Right;
            TBBuscar.BackColor = Color.FromArgb(64, 64, 64);
            TBBuscar.BorderStyle = BorderStyle.FixedSingle;
            TBBuscar.Cursor = Cursors.IBeam;
            TBBuscar.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBBuscar.ForeColor = Color.LightGray;
            TBBuscar.Location = new Point(3, 17);
            TBBuscar.Name = "TBBuscar";
            TBBuscar.PlaceholderText = "  Buscar...";
            TBBuscar.Size = new Size(132, 27);
            TBBuscar.TabIndex = 1;
            // 
            // DGVListaUs
            // 
            DGVListaUs.AllowUserToAddRows = false;
            DGVListaUs.AllowUserToDeleteRows = false;
            DGVListaUs.Anchor = AnchorStyles.None;
            DGVListaUs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVListaUs.BackgroundColor = Color.FromArgb(64, 64, 64);
            DGVListaUs.BorderStyle = BorderStyle.None;
            DGVListaUs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F);
            dataGridViewCellStyle1.ForeColor = Color.LightGray;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGVListaUs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGVListaUs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVListaUs.Columns.AddRange(new DataGridViewColumn[] { CDocumento, CNombre, CApellido, CRol, CEditar, CEliminar });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 10F);
            dataGridViewCellStyle2.ForeColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionBackColor = Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGVListaUs.DefaultCellStyle = dataGridViewCellStyle2;
            DGVListaUs.EnableHeadersVisualStyles = false;
            DGVListaUs.GridColor = Color.Black;
            DGVListaUs.Location = new Point(0, 63);
            DGVListaUs.Margin = new Padding(3, 2, 3, 2);
            DGVListaUs.MultiSelect = false;
            DGVListaUs.Name = "DGVListaUs";
            DGVListaUs.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DGVListaUs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DGVListaUs.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(80, 80, 80);
            dataGridViewCellStyle4.ForeColor = Color.LightGray;
            DGVListaUs.RowsDefaultCellStyle = dataGridViewCellStyle4;
            DGVListaUs.RowTemplate.Height = 28;
            DGVListaUs.Size = new Size(687, 237);
            DGVListaUs.TabIndex = 0;
            // 
            // CDocumento
            // 
            CDocumento.FillWeight = 137.055847F;
            CDocumento.HeaderText = "Documento";
            CDocumento.Name = "CDocumento";
            CDocumento.ReadOnly = true;
            // 
            // CNombre
            // 
            CNombre.FillWeight = 110.419518F;
            CNombre.HeaderText = "Nombre";
            CNombre.Name = "CNombre";
            CNombre.ReadOnly = true;
            // 
            // CApellido
            // 
            CApellido.FillWeight = 121.480148F;
            CApellido.HeaderText = "Apellido";
            CApellido.Name = "CApellido";
            CApellido.ReadOnly = true;
            // 
            // CRol
            // 
            CRol.FillWeight = 115.939911F;
            CRol.HeaderText = "Rol";
            CRol.Name = "CRol";
            CRol.ReadOnly = true;
            // 
            // CEditar
            // 
            CEditar.FillWeight = 58.1089859F;
            CEditar.HeaderText = "E";
            CEditar.Name = "CEditar";
            CEditar.ReadOnly = true;
            CEditar.Text = "Editar";
            CEditar.UseColumnTextForButtonValue = true;
            // 
            // CEliminar
            // 
            CEliminar.FillWeight = 56.9955635F;
            CEliminar.HeaderText = "X";
            CEliminar.Name = "CEliminar";
            CEliminar.ReadOnly = true;
            CEliminar.Text = "Eliminar";
            CEliminar.UseColumnTextForButtonValue = true;
            // 
            // LListadeUsuarios
            // 
            LListadeUsuarios.Anchor = AnchorStyles.None;
            LListadeUsuarios.AutoSize = true;
            LListadeUsuarios.BackColor = Color.Transparent;
            LListadeUsuarios.Font = new Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LListadeUsuarios.ForeColor = Color.LightGray;
            LListadeUsuarios.Location = new Point(290, 44);
            LListadeUsuarios.Name = "LListadeUsuarios";
            LListadeUsuarios.Size = new Size(246, 36);
            LListadeUsuarios.TabIndex = 1;
            LListadeUsuarios.Text = "Lista de Usuarios";
            // 
            // FListarUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(LListadeUsuarios);
            Controls.Add(PListaUsuarios);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FListarUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Listar Usuarios";
            WindowState = FormWindowState.Maximized;
            PListaUsuarios.ResumeLayout(false);
            PListaUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVListaUs).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        private DataGridViewTextBoxColumn CDocumento;
        private DataGridViewTextBoxColumn CNombre;
        private DataGridViewTextBoxColumn CApellido;
        private DataGridViewTextBoxColumn CRol;
        private DataGridViewButtonColumn CEditar;
        private DataGridViewButtonColumn CEliminar;
        private Label LListadeUsuarios;
        private TextBox TBBuscar;
        private Button button1;
        private ComboBox CBFiltroUs;
        private Label LFiltroUs;
    }
}
