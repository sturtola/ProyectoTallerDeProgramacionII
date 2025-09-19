namespace AurenPadelStore.CPresentacion.Administrador.AgregarUsuario
{
    partial class FAgregarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAgregarUsuario));
            PAgregarUsuario = new Panel();
            TBRepContra = new TextBox();
            BAgregarUsuario = new Button();
            LRol = new Label();
            CBRol = new ComboBox();
            TBContraseña = new TextBox();
            TBDni = new TextBox();
            TBApellido = new TextBox();
            TBNombre = new TextBox();
            LContraseña = new Label();
            LDni = new Label();
            LApellido = new Label();
            LNombre = new Label();
            LAgregarUsuario = new Label();
            PAgregarUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // PAgregarUsuario
            // 
            PAgregarUsuario.BackColor = Color.Transparent;
            PAgregarUsuario.Controls.Add(TBRepContra);
            PAgregarUsuario.Controls.Add(BAgregarUsuario);
            PAgregarUsuario.Controls.Add(LRol);
            PAgregarUsuario.Controls.Add(CBRol);
            PAgregarUsuario.Controls.Add(TBContraseña);
            PAgregarUsuario.Controls.Add(TBDni);
            PAgregarUsuario.Controls.Add(TBApellido);
            PAgregarUsuario.Controls.Add(TBNombre);
            PAgregarUsuario.Controls.Add(LContraseña);
            PAgregarUsuario.Controls.Add(LDni);
            PAgregarUsuario.Controls.Add(LApellido);
            PAgregarUsuario.Controls.Add(LNombre);
            PAgregarUsuario.Controls.Add(LAgregarUsuario);
            PAgregarUsuario.Location = new Point(113, 12);
            PAgregarUsuario.Name = "PAgregarUsuario";
            PAgregarUsuario.Size = new Size(548, 415);
            PAgregarUsuario.TabIndex = 0;
            // 
            // TBRepContra
            // 
            TBRepContra.BackColor = Color.Gainsboro;
            TBRepContra.Font = new Font("Century Gothic", 11.25F);
            TBRepContra.Location = new Point(248, 248);
            TBRepContra.Name = "TBRepContra";
            TBRepContra.PlaceholderText = "Repetir contraseña...";
            TBRepContra.Size = new Size(162, 26);
            TBRepContra.TabIndex = 12;
            TBRepContra.UseSystemPasswordChar = true;
            // 
            // BAgregarUsuario
            // 
            BAgregarUsuario.Anchor = AnchorStyles.None;
            BAgregarUsuario.BackColor = Color.GreenYellow;
            BAgregarUsuario.Cursor = Cursors.Hand;
            BAgregarUsuario.FlatStyle = FlatStyle.Flat;
            BAgregarUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BAgregarUsuario.Location = new Point(133, 345);
            BAgregarUsuario.Name = "BAgregarUsuario";
            BAgregarUsuario.Size = new Size(278, 34);
            BAgregarUsuario.TabIndex = 11;
            BAgregarUsuario.Text = "Agregar Usuario";
            BAgregarUsuario.UseVisualStyleBackColor = false;
            // 
            // LRol
            // 
            LRol.AutoSize = true;
            LRol.Font = new Font("Century Gothic", 15.75F);
            LRol.ForeColor = Color.LightGray;
            LRol.Location = new Point(188, 287);
            LRol.Name = "LRol";
            LRol.Size = new Size(47, 24);
            LRol.TabIndex = 10;
            LRol.Text = "Rol:";
            // 
            // CBRol
            // 
            CBRol.DropDownStyle = ComboBoxStyle.DropDownList;
            CBRol.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBRol.FormattingEnabled = true;
            CBRol.Items.AddRange(new object[] { "Vendedor", "Gerente", "Administrador" });
            CBRol.Location = new Point(248, 287);
            CBRol.Name = "CBRol";
            CBRol.Size = new Size(162, 29);
            CBRol.TabIndex = 9;
            // 
            // TBContraseña
            // 
            TBContraseña.BackColor = Color.Gainsboro;
            TBContraseña.Font = new Font("Century Gothic", 11.25F);
            TBContraseña.Location = new Point(248, 207);
            TBContraseña.Name = "TBContraseña";
            TBContraseña.PlaceholderText = "Contraseña...";
            TBContraseña.Size = new Size(162, 26);
            TBContraseña.TabIndex = 8;
            // 
            // TBDni
            // 
            TBDni.BackColor = Color.Gainsboro;
            TBDni.Font = new Font("Century Gothic", 11.25F);
            TBDni.Location = new Point(248, 170);
            TBDni.Name = "TBDni";
            TBDni.PlaceholderText = "12345678";
            TBDni.Size = new Size(162, 26);
            TBDni.TabIndex = 7;
            // 
            // TBApellido
            // 
            TBApellido.BackColor = Color.Gainsboro;
            TBApellido.Font = new Font("Century Gothic", 11.25F);
            TBApellido.Location = new Point(248, 133);
            TBApellido.Name = "TBApellido";
            TBApellido.PlaceholderText = "Perez";
            TBApellido.Size = new Size(162, 26);
            TBApellido.TabIndex = 6;
            // 
            // TBNombre
            // 
            TBNombre.BackColor = Color.Gainsboro;
            TBNombre.Font = new Font("Century Gothic", 11.25F);
            TBNombre.Location = new Point(248, 97);
            TBNombre.Name = "TBNombre";
            TBNombre.PlaceholderText = "Juan";
            TBNombre.Size = new Size(162, 26);
            TBNombre.TabIndex = 5;
            // 
            // LContraseña
            // 
            LContraseña.AutoSize = true;
            LContraseña.Font = new Font("Century Gothic", 15.75F);
            LContraseña.ForeColor = Color.LightGray;
            LContraseña.Location = new Point(100, 206);
            LContraseña.Name = "LContraseña";
            LContraseña.Size = new Size(135, 24);
            LContraseña.TabIndex = 4;
            LContraseña.Text = "Contraseña:";
            // 
            // LDni
            // 
            LDni.AutoSize = true;
            LDni.Font = new Font("Century Gothic", 15.75F);
            LDni.ForeColor = Color.LightGray;
            LDni.Location = new Point(170, 170);
            LDni.Name = "LDni";
            LDni.Size = new Size(62, 24);
            LDni.TabIndex = 3;
            LDni.Text = "D.N.I:";
            // 
            // LApellido
            // 
            LApellido.AutoSize = true;
            LApellido.Font = new Font("Century Gothic", 15.75F);
            LApellido.ForeColor = Color.LightGray;
            LApellido.Location = new Point(133, 131);
            LApellido.Name = "LApellido";
            LApellido.Size = new Size(99, 24);
            LApellido.TabIndex = 2;
            LApellido.Text = "Apellido:";
            // 
            // LNombre
            // 
            LNombre.AutoSize = true;
            LNombre.Font = new Font("Century Gothic", 15.75F);
            LNombre.ForeColor = Color.LightGray;
            LNombre.Location = new Point(135, 97);
            LNombre.Name = "LNombre";
            LNombre.Size = new Size(100, 24);
            LNombre.TabIndex = 1;
            LNombre.Text = "Nombre:";
            // 
            // LAgregarUsuario
            // 
            LAgregarUsuario.AutoSize = true;
            LAgregarUsuario.Font = new Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LAgregarUsuario.ForeColor = Color.LightGray;
            LAgregarUsuario.Location = new Point(158, 28);
            LAgregarUsuario.Name = "LAgregarUsuario";
            LAgregarUsuario.Size = new Size(241, 36);
            LAgregarUsuario.TabIndex = 0;
            LAgregarUsuario.Text = "Agregar Usuario";
            // 
            // FAgregarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(PAgregarUsuario);
            Name = "FAgregarUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Usuario";
            WindowState = FormWindowState.Maximized;
            Load += FAgregarUsuario_Load;
            PAgregarUsuario.ResumeLayout(false);
            PAgregarUsuario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PAgregarUsuario;
        private Label LAgregarUsuario;
        private Label LApellido;
        private Label LNombre;
        private Label LContraseña;
        private Label LDni;
        private TextBox TBApellido;
        private TextBox TBNombre;
        private TextBox TBContraseña;
        private TextBox TBDni;
        private ComboBox CBRol;
        private Label LRol;
        private Button BAgregarUsuario;
        private TextBox TBRepContra;
    }
}