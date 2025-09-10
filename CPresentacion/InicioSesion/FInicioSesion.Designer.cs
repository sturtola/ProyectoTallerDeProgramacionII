namespace AurenPadelStore.CPresentacion.InicioSesion
{
    partial class FInicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInicioSesion));
            BIngresar = new Button();
            PIniciarSesion = new Panel();
            CBUsuarios = new ComboBox();
            TBContraseña = new TextBox();
            LContraseña = new Label();
            LUsuario = new Label();
            label1 = new Label();
            PIniciarSesion.SuspendLayout();
            SuspendLayout();
            // 
            // BIngresar
            // 
            BIngresar.BackColor = Color.YellowGreen;
            BIngresar.Cursor = Cursors.Hand;
            BIngresar.FlatStyle = FlatStyle.Flat;
            BIngresar.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BIngresar.Location = new Point(125, 265);
            BIngresar.Name = "BIngresar";
            BIngresar.Size = new Size(114, 35);
            BIngresar.TabIndex = 0;
            BIngresar.Text = "Ingresar";
            BIngresar.UseVisualStyleBackColor = false;
            BIngresar.Click += button1_Click;
            // 
            // PIniciarSesion
            // 
            PIniciarSesion.BackColor = Color.Transparent;
            PIniciarSesion.Controls.Add(CBUsuarios);
            PIniciarSesion.Controls.Add(TBContraseña);
            PIniciarSesion.Controls.Add(LContraseña);
            PIniciarSesion.Controls.Add(LUsuario);
            PIniciarSesion.Controls.Add(label1);
            PIniciarSesion.Controls.Add(BIngresar);
            PIniciarSesion.Location = new Point(187, 23);
            PIniciarSesion.Name = "PIniciarSesion";
            PIniciarSesion.Size = new Size(386, 338);
            PIniciarSesion.TabIndex = 1;
            // 
            // CBUsuarios
            // 
            CBUsuarios.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBUsuarios.FormattingEnabled = true;
            CBUsuarios.Location = new Point(166, 100);
            CBUsuarios.Name = "CBUsuarios";
            CBUsuarios.Size = new Size(126, 30);
            CBUsuarios.TabIndex = 4;
            // 
            // TBContraseña
            // 
            TBContraseña.BackColor = Color.White;
            TBContraseña.BorderStyle = BorderStyle.FixedSingle;
            TBContraseña.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBContraseña.Location = new Point(166, 184);
            TBContraseña.Name = "TBContraseña";
            TBContraseña.Size = new Size(126, 31);
            TBContraseña.TabIndex = 2;
            TBContraseña.UseSystemPasswordChar = true;
            // 
            // LContraseña
            // 
            LContraseña.AutoSize = true;
            LContraseña.Font = new Font("Century Gothic", 15.75F);
            LContraseña.ForeColor = Color.LightGray;
            LContraseña.Location = new Point(20, 184);
            LContraseña.Name = "LContraseña";
            LContraseña.Size = new Size(135, 24);
            LContraseña.TabIndex = 3;
            LContraseña.Text = "Contraseña:";
            // 
            // LUsuario
            // 
            LUsuario.AutoSize = true;
            LUsuario.Font = new Font("Century Gothic", 15.75F);
            LUsuario.ForeColor = Color.LightGray;
            LUsuario.Location = new Point(69, 101);
            LUsuario.Name = "LUsuario";
            LUsuario.Size = new Size(86, 24);
            LUsuario.TabIndex = 2;
            LUsuario.Text = "Usuario:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(91, 20);
            label1.Name = "label1";
            label1.Size = new Size(219, 38);
            label1.TabIndex = 1;
            label1.Text = "Iniciar Sesión";
            // 
            // FInicioSesion
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(745, 389);
            Controls.Add(PIniciarSesion);
            Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FInicioSesion";
            Text = "Iniciar Sesión";
            PIniciarSesion.ResumeLayout(false);
            PIniciarSesion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BIngresar;
        private Panel PIniciarSesion;
        private Label label1;
        private ComboBox CBUsuarios;
        private TextBox TBContraseña;
        private Label LContraseña;
        private Label LUsuario;
    }
}