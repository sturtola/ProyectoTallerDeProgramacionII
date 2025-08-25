namespace AurenPadelStore
{
    partial class FIniciarSesion
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIniciarSesion));
            PIniciarSesion = new Panel();
            BIngresar = new Button();
            TBContrasenia = new TextBox();
            LContrasenia = new Label();
            comboBox1 = new ComboBox();
            LUsuario = new Label();
            TBIniciarSesion = new TextBox();
            PIniciarSesion.SuspendLayout();
            SuspendLayout();
            // 
            // PIniciarSesion
            // 
            PIniciarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            PIniciarSesion.BackColor = Color.Transparent;
            PIniciarSesion.Controls.Add(BIngresar);
            PIniciarSesion.Controls.Add(TBContrasenia);
            PIniciarSesion.Controls.Add(LContrasenia);
            PIniciarSesion.Controls.Add(comboBox1);
            PIniciarSesion.Controls.Add(LUsuario);
            PIniciarSesion.Controls.Add(TBIniciarSesion);
            PIniciarSesion.Location = new Point(516, 31);
            PIniciarSesion.Name = "PIniciarSesion";
            PIniciarSesion.Size = new Size(339, 455);
            PIniciarSesion.TabIndex = 0;
            // 
            // BIngresar
            // 
            BIngresar.BackColor = Color.YellowGreen;
            BIngresar.Cursor = Cursors.Hand;
            BIngresar.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BIngresar.ForeColor = Color.Black;
            BIngresar.Location = new Point(78, 413);
            BIngresar.Name = "BIngresar";
            BIngresar.Size = new Size(168, 51);
            BIngresar.TabIndex = 5;
            BIngresar.Text = "INGRESAR";
            BIngresar.UseVisualStyleBackColor = false;
            // 
            // TBContrasenia
            // 
            TBContrasenia.BackColor = Color.LightGray;
            TBContrasenia.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBContrasenia.ForeColor = Color.Black;
            TBContrasenia.Location = new Point(87, 313);
            TBContrasenia.Name = "TBContrasenia";
            TBContrasenia.Size = new Size(171, 27);
            TBContrasenia.TabIndex = 4;
            TBContrasenia.UseSystemPasswordChar = true;
            // 
            // LContrasenia
            // 
            LContrasenia.AutoSize = true;
            LContrasenia.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LContrasenia.ForeColor = Color.LightGray;
            LContrasenia.Location = new Point(87, 247);
            LContrasenia.Name = "LContrasenia";
            LContrasenia.Size = new Size(159, 30);
            LContrasenia.TabIndex = 3;
            LContrasenia.Text = "Contraseña:";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(224, 224, 224);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Usuario1", "Usuario2", "Usuario3" });
            comboBox1.Location = new Point(87, 184);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(171, 29);
            comboBox1.TabIndex = 2;
            // 
            // LUsuario
            // 
            LUsuario.AutoSize = true;
            LUsuario.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LUsuario.ForeColor = Color.Silver;
            LUsuario.Location = new Point(87, 120);
            LUsuario.Name = "LUsuario";
            LUsuario.Size = new Size(106, 30);
            LUsuario.TabIndex = 1;
            LUsuario.Text = "Usuario:";
            LUsuario.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TBIniciarSesion
            // 
            TBIniciarSesion.BackColor = SystemColors.ActiveCaptionText;
            TBIniciarSesion.BorderStyle = BorderStyle.None;
            TBIniciarSesion.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TBIniciarSesion.ForeColor = SystemColors.ScrollBar;
            TBIniciarSesion.Location = new Point(87, 38);
            TBIniciarSesion.Name = "TBIniciarSesion";
            TBIniciarSesion.Size = new Size(171, 34);
            TBIniciarSesion.TabIndex = 0;
            TBIniciarSesion.Text = "Iniciar Sesión";
            TBIniciarSesion.TextAlign = HorizontalAlignment.Center;
            // 
            // FIniciarSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(938, 534);
            Controls.Add(PIniciarSesion);
            Name = "FIniciarSesion";
            Text = "Iniciar Sesión";
            PIniciarSesion.ResumeLayout(false);
            PIniciarSesion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PIniciarSesion;
        private TextBox TBIniciarSesion;
        private ComboBox comboBox1;
        private Label LUsuario;
        private Label LContrasenia;
        private TextBox TBContrasenia;
        private Button BIngresar;
    }
}
