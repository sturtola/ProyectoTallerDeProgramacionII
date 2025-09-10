namespace AurenPadelStore.CPresentacion.Gerente.AgregarUsuario
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
            PAgregarUsuario = new Panel();
            BAgregarUsuario = new Button();
            LRol = new Label();
            CRol = new ComboBox();
            TContraseña = new TextBox();
            TDni = new TextBox();
            TApellido = new TextBox();
            TNombre = new TextBox();
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
            PAgregarUsuario.Controls.Add(BAgregarUsuario);
            PAgregarUsuario.Controls.Add(LRol);
            PAgregarUsuario.Controls.Add(CRol);
            PAgregarUsuario.Controls.Add(TContraseña);
            PAgregarUsuario.Controls.Add(TDni);
            PAgregarUsuario.Controls.Add(TApellido);
            PAgregarUsuario.Controls.Add(TNombre);
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
            // BAgregarUsuario
            // 
            BAgregarUsuario.Anchor = AnchorStyles.None;
            BAgregarUsuario.BackColor = Color.GreenYellow;
            BAgregarUsuario.Cursor = Cursors.Hand;
            BAgregarUsuario.FlatStyle = FlatStyle.Flat;
            BAgregarUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BAgregarUsuario.Location = new Point(211, 282);
            BAgregarUsuario.Name = "BAgregarUsuario";
            BAgregarUsuario.Size = new Size(148, 34);
            BAgregarUsuario.TabIndex = 11;
            BAgregarUsuario.Text = "Agregar Usuario";
            BAgregarUsuario.UseVisualStyleBackColor = false;
            // 
            // LRol
            // 
            LRol.AutoSize = true;
            LRol.Font = new Font("Century Gothic", 15.75F);
            LRol.ForeColor = Color.LightGray;
            LRol.Location = new Point(211, 237);
            LRol.Name = "LRol";
            LRol.Size = new Size(47, 24);
            LRol.TabIndex = 10;
            LRol.Text = "Rol:";
            // 
            // CRol
            // 
            CRol.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CRol.FormattingEnabled = true;
            CRol.Items.AddRange(new object[] { "Vendedor", "Gerente", "Administrador" });
            CRol.Location = new Point(271, 242);
            CRol.Name = "CRol";
            CRol.Size = new Size(121, 24);
            CRol.TabIndex = 9;
            // 
            // TContraseña
            // 
            TContraseña.Location = new Point(271, 207);
            TContraseña.Name = "TContraseña";
            TContraseña.Size = new Size(121, 23);
            TContraseña.TabIndex = 8;
            // 
            // TDni
            // 
            TDni.Location = new Point(271, 170);
            TDni.Name = "TDni";
            TDni.Size = new Size(121, 23);
            TDni.TabIndex = 7;
            // 
            // TApellido
            // 
            TApellido.Location = new Point(271, 133);
            TApellido.Name = "TApellido";
            TApellido.Size = new Size(121, 23);
            TApellido.TabIndex = 6;
            // 
            // TNombre
            // 
            TNombre.Location = new Point(271, 97);
            TNombre.Name = "TNombre";
            TNombre.Size = new Size(121, 23);
            TNombre.TabIndex = 5;
            // 
            // LContraseña
            // 
            LContraseña.AutoSize = true;
            LContraseña.Font = new Font("Century Gothic", 15.75F);
            LContraseña.ForeColor = Color.LightGray;
            LContraseña.Location = new Point(123, 202);
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
            LDni.Location = new Point(192, 168);
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
            LApellido.Location = new Point(156, 131);
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
            LNombre.Location = new Point(158, 97);
            LNombre.Name = "LNombre";
            LNombre.Size = new Size(100, 24);
            LNombre.TabIndex = 1;
            LNombre.Text = "Nombre:";
            // 
            // LAgregarUsuario
            // 
            LAgregarUsuario.AutoSize = true;
            LAgregarUsuario.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LAgregarUsuario.ForeColor = Color.LightGray;
            LAgregarUsuario.Location = new Point(147, 27);
            LAgregarUsuario.Name = "LAgregarUsuario";
            LAgregarUsuario.Size = new Size(265, 38);
            LAgregarUsuario.TabIndex = 0;
            LAgregarUsuario.Text = "Agregar Usuario";
            // 
            // FAgregarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(800, 450);
            Controls.Add(PAgregarUsuario);
            Name = "FAgregarUsuario";
            Text = "Agregar Usuario";
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
        private TextBox TApellido;
        private TextBox TNombre;
        private TextBox TContraseña;
        private TextBox TDni;
        private ComboBox CRol;
        private Label LRol;
        private Button BAgregarUsuario;
    }
}