using System.Windows.Forms;
using System.Drawing;

namespace AurenPadelStore.CPresentacion.InicioSesion
{
    partial class FInicioSesion
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button BIngresar;
        private System.Windows.Forms.Panel PIniciarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBUsuarios;
        private System.Windows.Forms.TextBox TBContraseña;
        private System.Windows.Forms.Label LContraseña;
        private System.Windows.Forms.Label LUsuario;
        private System.Windows.Forms.CheckBox chkMostrarContrasena; // 👈 nuevo

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            chkMostrarContrasena = new CheckBox();
            PIniciarSesion.SuspendLayout();
            SuspendLayout();
            // 
            // BIngresar
            // 
            BIngresar.BackColor = Color.GreenYellow;
            BIngresar.Cursor = Cursors.Hand;
            BIngresar.FlatStyle = FlatStyle.Flat;
            BIngresar.Font = new Font("Century Gothic", 14.25F);
            BIngresar.Location = new Point(73, 289);
            BIngresar.Name = "BIngresar";
            BIngresar.Size = new Size(269, 35);
            BIngresar.TabIndex = 4;
            BIngresar.Text = "Ingresar";
            BIngresar.UseVisualStyleBackColor = false;
            // 
            // PIniciarSesion
            // 
            PIniciarSesion.BackColor = Color.Transparent;
            PIniciarSesion.Controls.Add(CBUsuarios);
            PIniciarSesion.Controls.Add(TBContraseña);
            PIniciarSesion.Controls.Add(LContraseña);
            PIniciarSesion.Controls.Add(LUsuario);
            PIniciarSesion.Controls.Add(label1);
            PIniciarSesion.Controls.Add(chkMostrarContrasena);
            PIniciarSesion.Controls.Add(BIngresar);
            PIniciarSesion.Location = new Point(139, 27);
            PIniciarSesion.Name = "PIniciarSesion";
            PIniciarSesion.Size = new Size(386, 338);
            PIniciarSesion.TabIndex = 1;
            // 
            // CBUsuarios
            // 
            CBUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            CBUsuarios.Font = new Font("Century Gothic", 14.25F);
            CBUsuarios.FormattingEnabled = true;
            CBUsuarios.Location = new Point(102, 125);
            CBUsuarios.Name = "CBUsuarios";
            CBUsuarios.Size = new Size(208, 30);
            CBUsuarios.TabIndex = 1;
            // 
            // TBContraseña
            // 
            TBContraseña.BackColor = Color.Gainsboro;
            TBContraseña.BorderStyle = BorderStyle.FixedSingle;
            TBContraseña.Font = new Font("Century Gothic", 14.25F);
            TBContraseña.Location = new Point(102, 221);
            TBContraseña.Name = "TBContraseña";
            TBContraseña.Size = new Size(208, 31);
            TBContraseña.TabIndex = 2;
            TBContraseña.UseSystemPasswordChar = true;
            // 
            // LContraseña
            // 
            LContraseña.AutoSize = true;
            LContraseña.Font = new Font("Century Gothic", 15.75F);
            LContraseña.ForeColor = Color.LightGray;
            LContraseña.Location = new Point(102, 184);
            LContraseña.Name = "LContraseña";
            LContraseña.Size = new Size(130, 24);
            LContraseña.TabIndex = 3;
            LContraseña.Text = "Contraseña";
            // 
            // LUsuario
            // 
            LUsuario.AutoSize = true;
            LUsuario.Font = new Font("Century Gothic", 15.75F);
            LUsuario.ForeColor = Color.LightGray;
            LUsuario.Location = new Point(102, 86);
            LUsuario.Name = "LUsuario";
            LUsuario.Size = new Size(81, 24);
            LUsuario.TabIndex = 2;
            LUsuario.Text = "Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 24F, FontStyle.Bold);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(91, 20);
            label1.Name = "label1";
            label1.Size = new Size(219, 38);
            label1.TabIndex = 0;
            label1.Text = "Iniciar Sesión";
            // 
            // chkMostrarContrasena
            // 
            chkMostrarContrasena.AutoSize = true;
            chkMostrarContrasena.Font = new Font("Century Gothic", 9.75F);
            chkMostrarContrasena.ForeColor = SystemColors.Control;
            chkMostrarContrasena.Location = new Point(102, 258);
            chkMostrarContrasena.Name = "chkMostrarContrasena";
            chkMostrarContrasena.Size = new Size(151, 21);
            chkMostrarContrasena.TabIndex = 3;
            chkMostrarContrasena.Text = "Mostrar contraseña";
            chkMostrarContrasena.UseVisualStyleBackColor = true;
            // 
            // FInicioSesion
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(671, 377);
            Controls.Add(PIniciarSesion);
            Font = new Font("Century Gothic", 9.75F);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FInicioSesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesión";
            PIniciarSesion.ResumeLayout(false);
            PIniciarSesion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
