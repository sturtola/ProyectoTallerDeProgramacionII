using System.Windows.Forms;
using System.Drawing;

namespace AurenPadelStore.CPresentacion.Administrador.Usuarios
{
    partial class FUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUsuarios));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            LListaUsuarios = new Label();
            PAgregarUsuario = new Panel();
            LNombreU = new Label();
            TBNombreU = new TextBox();
            LApellidoU = new Label();
            TBApellidoU = new TextBox();
            LDniU = new Label();
            TBDniU = new TextBox();
            LContrasena = new Label();
            TBContrasena = new TextBox();
            LRepetirContrasena = new Label();
            TBRepetirContrasena = new TextBox();
            LRol = new Label();
            CBRol = new ComboBox();
            BAgregarUsuario = new Button();
            LAgregarUsuario = new Label();
            PListaUsuarios = new Panel();
            labelFiltro = new Label();
            CBFiltroU = new ComboBox();
            BBuscarU = new Button();
            TBBuscarU = new TextBox();
            DGListaUsuarios = new DataGridView();
            colUNombre = new DataGridViewTextBoxColumn();
            colUApellido = new DataGridViewTextBoxColumn();
            colUDni = new DataGridViewTextBoxColumn();
            colURol = new DataGridViewTextBoxColumn();
            colUEstado = new DataGridViewTextBoxColumn();
            colUEditar = new DataGridViewButtonColumn();
            colUAccion = new DataGridViewButtonColumn();
            PAgregarUsuario.SuspendLayout();
            PListaUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaUsuarios).BeginInit();
            SuspendLayout();
            // 
            // LListaUsuarios
            // 
            LListaUsuarios.AutoSize = true;
            LListaUsuarios.BackColor = Color.Transparent;
            LListaUsuarios.Font = new Font("Century Gothic", 20.25F);
            LListaUsuarios.ForeColor = Color.LightGray;
            LListaUsuarios.Location = new Point(720, 40);
            LListaUsuarios.Name = "LListaUsuarios";
            LListaUsuarios.Size = new Size(225, 33);
            LListaUsuarios.TabIndex = 3;
            LListaUsuarios.Text = "Lista de Usuarios";
            // 
            // PAgregarUsuario
            // 
            PAgregarUsuario.BackColor = Color.FromArgb(64, 64, 64);
            PAgregarUsuario.Controls.Add(LNombreU);
            PAgregarUsuario.Controls.Add(TBNombreU);
            PAgregarUsuario.Controls.Add(LApellidoU);
            PAgregarUsuario.Controls.Add(TBApellidoU);
            PAgregarUsuario.Controls.Add(LDniU);
            PAgregarUsuario.Controls.Add(TBDniU);
            PAgregarUsuario.Controls.Add(LContrasena);
            PAgregarUsuario.Controls.Add(TBContrasena);
            PAgregarUsuario.Controls.Add(LRepetirContrasena);
            PAgregarUsuario.Controls.Add(TBRepetirContrasena);
            PAgregarUsuario.Controls.Add(LRol);
            PAgregarUsuario.Controls.Add(CBRol);
            PAgregarUsuario.Controls.Add(BAgregarUsuario);
            PAgregarUsuario.Location = new Point(64, 146);
            PAgregarUsuario.Name = "PAgregarUsuario";
            PAgregarUsuario.Size = new Size(280, 457);
            PAgregarUsuario.TabIndex = 1;
            // 
            // LNombreU
            // 
            LNombreU.Font = new Font("Century Gothic", 14.25F);
            LNombreU.ForeColor = Color.LightGray;
            LNombreU.Location = new Point(15, 22);
            LNombreU.Name = "LNombreU";
            LNombreU.Size = new Size(100, 23);
            LNombreU.TabIndex = 0;
            LNombreU.Text = "Nombre";
            // 
            // TBNombreU
            // 
            TBNombreU.BackColor = Color.Gainsboro;
            TBNombreU.Cursor = Cursors.IBeam;
            TBNombreU.Font = new Font("Century Gothic", 12F);
            TBNombreU.Location = new Point(15, 48);
            TBNombreU.Name = "TBNombreU";
            TBNombreU.Size = new Size(250, 27);
            TBNombreU.TabIndex = 1;
            // 
            // LApellidoU
            // 
            LApellidoU.Font = new Font("Century Gothic", 14.25F);
            LApellidoU.ForeColor = Color.LightGray;
            LApellidoU.Location = new Point(15, 82);
            LApellidoU.Name = "LApellidoU";
            LApellidoU.Size = new Size(100, 23);
            LApellidoU.TabIndex = 2;
            LApellidoU.Text = "Apellido";
            // 
            // TBApellidoU
            // 
            TBApellidoU.BackColor = Color.Gainsboro;
            TBApellidoU.Cursor = Cursors.IBeam;
            TBApellidoU.Font = new Font("Century Gothic", 12F);
            TBApellidoU.Location = new Point(15, 108);
            TBApellidoU.Name = "TBApellidoU";
            TBApellidoU.Size = new Size(250, 27);
            TBApellidoU.TabIndex = 3;
            // 
            // LDniU
            // 
            LDniU.Font = new Font("Century Gothic", 14.25F);
            LDniU.ForeColor = Color.LightGray;
            LDniU.Location = new Point(15, 142);
            LDniU.Name = "LDniU";
            LDniU.Size = new Size(100, 23);
            LDniU.TabIndex = 4;
            LDniU.Text = "DNI";
            // 
            // TBDniU
            // 
            TBDniU.BackColor = Color.Gainsboro;
            TBDniU.Cursor = Cursors.IBeam;
            TBDniU.Font = new Font("Century Gothic", 12F);
            TBDniU.Location = new Point(15, 168);
            TBDniU.Name = "TBDniU";
            TBDniU.Size = new Size(250, 27);
            TBDniU.TabIndex = 5;
            // 
            // LContrasena
            // 
            LContrasena.Font = new Font("Century Gothic", 14.25F);
            LContrasena.ForeColor = Color.LightGray;
            LContrasena.Location = new Point(15, 203);
            LContrasena.Name = "LContrasena";
            LContrasena.Size = new Size(120, 23);
            LContrasena.TabIndex = 6;
            LContrasena.Text = "Contraseña";
            // 
            // TBContrasena
            // 
            TBContrasena.BackColor = Color.Gainsboro;
            TBContrasena.Cursor = Cursors.IBeam;
            TBContrasena.Font = new Font("Century Gothic", 12F);
            TBContrasena.Location = new Point(15, 229);
            TBContrasena.Name = "TBContrasena";
            TBContrasena.PasswordChar = '•';
            TBContrasena.Size = new Size(250, 27);
            TBContrasena.TabIndex = 7;
            // 
            // LRepetirContrasena
            // 
            LRepetirContrasena.Font = new Font("Century Gothic", 14.25F);
            LRepetirContrasena.ForeColor = Color.LightGray;
            LRepetirContrasena.Location = new Point(15, 263);
            LRepetirContrasena.Name = "LRepetirContrasena";
            LRepetirContrasena.Size = new Size(190, 23);
            LRepetirContrasena.TabIndex = 8;
            LRepetirContrasena.Text = "Repetir Contraseña";
            // 
            // TBRepetirContrasena
            // 
            TBRepetirContrasena.BackColor = Color.Gainsboro;
            TBRepetirContrasena.Cursor = Cursors.IBeam;
            TBRepetirContrasena.Font = new Font("Century Gothic", 12F);
            TBRepetirContrasena.Location = new Point(15, 289);
            TBRepetirContrasena.Name = "TBRepetirContrasena";
            TBRepetirContrasena.PasswordChar = '•';
            TBRepetirContrasena.Size = new Size(250, 27);
            TBRepetirContrasena.TabIndex = 9;
            // 
            // LRol
            // 
            LRol.Font = new Font("Century Gothic", 14.25F);
            LRol.ForeColor = Color.LightGray;
            LRol.Location = new Point(15, 323);
            LRol.Name = "LRol";
            LRol.Size = new Size(100, 23);
            LRol.TabIndex = 10;
            LRol.Text = "Rol";
            // 
            // CBRol
            // 
            CBRol.BackColor = Color.LightGray;
            CBRol.Cursor = Cursors.Hand;
            CBRol.DropDownStyle = ComboBoxStyle.DropDownList;
            CBRol.Font = new Font("Century Gothic", 12F);
            CBRol.Location = new Point(15, 349);
            CBRol.Name = "CBRol";
            CBRol.Size = new Size(250, 29);
            CBRol.TabIndex = 11;
            // 
            // BAgregarUsuario
            // 
            BAgregarUsuario.BackColor = Color.YellowGreen;
            BAgregarUsuario.Cursor = Cursors.Hand;
            BAgregarUsuario.FlatStyle = FlatStyle.Popup;
            BAgregarUsuario.Font = new Font("Century Gothic", 14.25F);
            BAgregarUsuario.ForeColor = Color.Black;
            BAgregarUsuario.Location = new Point(15, 410);
            BAgregarUsuario.Name = "BAgregarUsuario";
            BAgregarUsuario.Size = new Size(250, 33);
            BAgregarUsuario.TabIndex = 12;
            BAgregarUsuario.Text = "Agregar Usuario";
            BAgregarUsuario.UseVisualStyleBackColor = false;
            // 
            // LAgregarUsuario
            // 
            LAgregarUsuario.AutoSize = true;
            LAgregarUsuario.BackColor = Color.Transparent;
            LAgregarUsuario.Font = new Font("Century Gothic", 20.25F);
            LAgregarUsuario.ForeColor = Color.LightGray;
            LAgregarUsuario.Location = new Point(98, 89);
            LAgregarUsuario.Name = "LAgregarUsuario";
            LAgregarUsuario.Size = new Size(222, 33);
            LAgregarUsuario.TabIndex = 0;
            LAgregarUsuario.Text = "Agregar Usuario";
            // 
            // PListaUsuarios
            // 
            PListaUsuarios.BackColor = Color.Transparent;
            PListaUsuarios.Controls.Add(labelFiltro);
            PListaUsuarios.Controls.Add(CBFiltroU);
            PListaUsuarios.Controls.Add(BBuscarU);
            PListaUsuarios.Controls.Add(TBBuscarU);
            PListaUsuarios.Controls.Add(DGListaUsuarios);
            PListaUsuarios.Location = new Point(384, 100);
            PListaUsuarios.Name = "PListaUsuarios";
            PListaUsuarios.Size = new Size(888, 503);
            PListaUsuarios.TabIndex = 2;
            // 
            // labelFiltro
            // 
            labelFiltro.AutoSize = true;
            labelFiltro.Font = new Font("Century Gothic", 14.25F);
            labelFiltro.ForeColor = Color.LightGray;
            labelFiltro.Location = new Point(639, 12);
            labelFiltro.Name = "labelFiltro";
            labelFiltro.Size = new Size(62, 22);
            labelFiltro.TabIndex = 6;
            labelFiltro.Text = "Filtrar:";
            // 
            // CBFiltroU
            // 
            CBFiltroU.BackColor = Color.LightGray;
            CBFiltroU.Cursor = Cursors.Hand;
            CBFiltroU.DropDownStyle = ComboBoxStyle.DropDownList;
            CBFiltroU.Font = new Font("Century Gothic", 12F);
            CBFiltroU.FormattingEnabled = true;
            CBFiltroU.Items.AddRange(new object[] { "Nombre A-Z", "Nombre Z-A", "Apellido A-Z", "Apellido Z-A", "Administrador", "Gerente", "Vendedor", "Activos", "Inactivos" });
            CBFiltroU.Location = new Point(717, 9);
            CBFiltroU.Name = "CBFiltroU";
            CBFiltroU.Size = new Size(168, 29);
            CBFiltroU.TabIndex = 5;
            // 
            // BBuscarU
            // 
            BBuscarU.BackColor = Color.LightGray;
            BBuscarU.BackgroundImage = (Image)resources.GetObject("BBuscarU.BackgroundImage");
            BBuscarU.BackgroundImageLayout = ImageLayout.Stretch;
            BBuscarU.Cursor = Cursors.Hand;
            BBuscarU.FlatStyle = FlatStyle.Popup;
            BBuscarU.Location = new Point(233, 11);
            BBuscarU.Name = "BBuscarU";
            BBuscarU.Size = new Size(34, 29);
            BBuscarU.TabIndex = 4;
            BBuscarU.UseVisualStyleBackColor = false;
            // 
            // TBBuscarU
            // 
            TBBuscarU.BackColor = Color.FromArgb(64, 64, 64);
            TBBuscarU.BorderStyle = BorderStyle.FixedSingle;
            TBBuscarU.Cursor = Cursors.IBeam;
            TBBuscarU.Font = new Font("Century Gothic", 12F);
            TBBuscarU.ForeColor = Color.LightGray;
            TBBuscarU.Location = new Point(3, 11);
            TBBuscarU.Name = "TBBuscarU";
            TBBuscarU.PlaceholderText = "  Buscar Usuario...";
            TBBuscarU.Size = new Size(213, 27);
            TBBuscarU.TabIndex = 4;
            // 
            // DGListaUsuarios
            // 
            DGListaUsuarios.AllowUserToAddRows = false;
            DGListaUsuarios.BackgroundColor = Color.FromArgb(64, 64, 64);
            DGListaUsuarios.BorderStyle = BorderStyle.None;
            DGListaUsuarios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F);
            dataGridViewCellStyle1.ForeColor = Color.LightGray;
            DGListaUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGListaUsuarios.ColumnHeadersHeight = 25;
            DGListaUsuarios.Columns.AddRange(new DataGridViewColumn[] { colUNombre, colUApellido, colUDni, colURol, colUEstado, colUEditar, colUAccion });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(100, 100, 100);
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 11F);
            dataGridViewCellStyle4.ForeColor = Color.LightGray;
            dataGridViewCellStyle4.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            DGListaUsuarios.DefaultCellStyle = dataGridViewCellStyle4;
            DGListaUsuarios.EnableHeadersVisualStyles = false;
            DGListaUsuarios.GridColor = Color.Black;
            DGListaUsuarios.Location = new Point(0, 57);
            DGListaUsuarios.Name = "DGListaUsuarios";
            DGListaUsuarios.RowHeadersVisible = false;
            DGListaUsuarios.RowTemplate.Height = 40;
            DGListaUsuarios.Size = new Size(885, 446);
            DGListaUsuarios.TabIndex = 0;
            // 
            // colUNombre
            // 
            colUNombre.HeaderText = "Nombre";
            colUNombre.Name = "colUNombre";
            colUNombre.Width = 148;
            // 
            // colUApellido
            // 
            colUApellido.HeaderText = "Apellido";
            colUApellido.Name = "colUApellido";
            colUApellido.Width = 148;
            // 
            // colUDni
            // 
            colUDni.HeaderText = "DNI";
            colUDni.Name = "colUDni";
            colUDni.Width = 148;
            // 
            // colURol
            // 
            colURol.HeaderText = "Rol";
            colURol.Name = "colURol";
            colURol.Width = 148;
            // 
            // colUEstado
            // 
            colUEstado.HeaderText = "Estado";
            colUEstado.Name = "colUEstado";
            colUEstado.Width = 148;
            // 
            // colUEditar
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.LightGreen;
            dataGridViewCellStyle2.ForeColor = Color.Black;
            colUEditar.DefaultCellStyle = dataGridViewCellStyle2;
            colUEditar.FlatStyle = FlatStyle.Flat;
            colUEditar.HeaderText = "E";
            colUEditar.Name = "colUEditar";
            colUEditar.Text = "Editar";
            colUEditar.UseColumnTextForButtonValue = true;
            colUEditar.Width = 65;
            // 
            // colUAccion
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.LightCoral;
            dataGridViewCellStyle3.ForeColor = Color.Black;
            colUAccion.DefaultCellStyle = dataGridViewCellStyle3;
            colUAccion.FlatStyle = FlatStyle.Flat;
            colUAccion.HeaderText = "A";
            colUAccion.Name = "colUAccion";
            colUAccion.Width = 77;
            // 
            // FUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1334, 659);
            Controls.Add(LAgregarUsuario);
            Controls.Add(PAgregarUsuario);
            Controls.Add(PListaUsuarios);
            Controls.Add(LListaUsuarios);
            Name = "FUsuarios";
            Text = "Lista de Usuarios";
            PAgregarUsuario.ResumeLayout(false);
            PAgregarUsuario.PerformLayout();
            PListaUsuarios.ResumeLayout(false);
            PListaUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGListaUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Label LListaUsuarios;
        private Panel PAgregarUsuario;
        private Label LAgregarUsuario;

        private Label LNombreU, LApellidoU, LDniU, LContrasena, LRepetirContrasena, LRol;
        private TextBox TBNombreU, TBApellidoU, TBDniU, TBContrasena, TBRepetirContrasena;
        private ComboBox CBRol;
        private Button BAgregarUsuario;

        private Panel PListaUsuarios;
        private TextBox TBBuscarU;
        private Button BBuscarU;
        private Label labelFiltro;
        private ComboBox CBFiltroU;
        private DataGridView DGListaUsuarios;

        private DataGridViewTextBoxColumn colUNombre, colUApellido, colUDni, colURol, colUEstado;
        private DataGridViewButtonColumn colUEditar, colUAccion;
    }
}
