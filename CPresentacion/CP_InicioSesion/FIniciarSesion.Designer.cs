namespace AurenPadelStore.CPresentacion
{
    partial class FIniciarSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIniciarSesion));
            panel1 = new Panel();
            BIngresar = new Button();
            TBContrasenia = new TextBox();
            CBUsuarios = new ComboBox();
            label1 = new Label();
            LContrasenia = new Label();
            LIniciarSesion = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(BIngresar);
            panel1.Controls.Add(TBContrasenia);
            panel1.Controls.Add(CBUsuarios);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(LContrasenia);
            panel1.Controls.Add(LIniciarSesion);
            panel1.Location = new Point(435, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(271, 370);
            panel1.TabIndex = 0;
            // 
            // BIngresar
            // 
            BIngresar.BackColor = Color.YellowGreen;
            BIngresar.BackgroundImageLayout = ImageLayout.None;
            BIngresar.Cursor = Cursors.Hand;
            BIngresar.FlatStyle = FlatStyle.Popup;
            BIngresar.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BIngresar.Location = new Point(66, 300);
            BIngresar.Name = "BIngresar";
            BIngresar.Size = new Size(134, 36);
            BIngresar.TabIndex = 5;
            BIngresar.Text = "INGRESAR";
            BIngresar.UseVisualStyleBackColor = false;
            // 
            // TBContrasenia
            // 
            TBContrasenia.BackColor = Color.LightGray;
            TBContrasenia.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TBContrasenia.ForeColor = SystemColors.WindowFrame;
            TBContrasenia.Location = new Point(56, 242);
            TBContrasenia.Name = "TBContrasenia";
            TBContrasenia.Size = new Size(159, 27);
            TBContrasenia.TabIndex = 4;
            // 
            // CBUsuarios
            // 
            CBUsuarios.BackColor = Color.LightGray;
            CBUsuarios.Cursor = Cursors.Hand;
            CBUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            CBUsuarios.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CBUsuarios.ForeColor = Color.Black;
            CBUsuarios.FormattingEnabled = true;
            CBUsuarios.Items.AddRange(new object[] { "Usuario1", "Usuario2", "Usuario3" });
            CBUsuarios.Location = new Point(56, 139);
            CBUsuarios.Name = "CBUsuarios";
            CBUsuarios.Size = new Size(159, 29);
            CBUsuarios.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(46, 25);
            label1.Name = "label1";
            label1.Size = new Size(184, 32);
            label1.TabIndex = 2;
            label1.Text = "Iniciar Sesión";
            // 
            // LContrasenia
            // 
            LContrasenia.AutoSize = true;
            LContrasenia.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LContrasenia.ForeColor = Color.LightGray;
            LContrasenia.Location = new Point(56, 192);
            LContrasenia.Name = "LContrasenia";
            LContrasenia.Size = new Size(159, 30);
            LContrasenia.TabIndex = 1;
            LContrasenia.Text = "Contraseña:";
            // 
            // LIniciarSesion
            // 
            LIniciarSesion.AutoSize = true;
            LIniciarSesion.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LIniciarSesion.ForeColor = Color.LightGray;
            LIniciarSesion.Location = new Point(56, 88);
            LIniciarSesion.Name = "LIniciarSesion";
            LIniciarSesion.Size = new Size(106, 30);
            LIniciarSesion.TabIndex = 0;
            LIniciarSesion.Text = "Usuario:";
            // 
            // FIniciarSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "FIniciarSesion";
            Text = "Iniciar Sesión";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label LContrasenia;
        private Label LIniciarSesion;
        private Label label1;
        private TextBox TBContrasenia;
        private Button BIngresar;
        private ComboBox CBUsuarios;
    }
}