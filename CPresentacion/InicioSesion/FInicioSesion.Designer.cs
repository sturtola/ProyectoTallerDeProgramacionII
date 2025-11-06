using System.Windows.Forms;
using System.Drawing;

namespace AurenPadelStore.CPresentacion.InicioSesion
{
    partial class FInicioSesion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInicioSesion));
            this.BIngresar = new System.Windows.Forms.Button();
            this.PIniciarSesion = new System.Windows.Forms.Panel();
            this.CBUsuarios = new System.Windows.Forms.ComboBox();
            this.TBContraseña = new System.Windows.Forms.TextBox();
            this.LContraseña = new System.Windows.Forms.Label();
            this.LUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PIniciarSesion.SuspendLayout();
            this.SuspendLayout();
            // 
            // BIngresar
            // 
            this.BIngresar.BackColor = System.Drawing.Color.GreenYellow;
            this.BIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BIngresar.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.BIngresar.Location = new System.Drawing.Point(73, 289);
            this.BIngresar.Name = "BIngresar";
            this.BIngresar.Size = new System.Drawing.Size(269, 35);
            this.BIngresar.TabIndex = 0;
            this.BIngresar.Text = "Ingresar";
            this.BIngresar.UseVisualStyleBackColor = false;
            // (evento Click se engancha en el .cs para evitar duplicados)
            // 
            // PIniciarSesion
            // 
            this.PIniciarSesion.BackColor = System.Drawing.Color.Transparent;
            this.PIniciarSesion.Controls.Add(this.CBUsuarios);
            this.PIniciarSesion.Controls.Add(this.TBContraseña);
            this.PIniciarSesion.Controls.Add(this.LContraseña);
            this.PIniciarSesion.Controls.Add(this.LUsuario);
            this.PIniciarSesion.Controls.Add(this.label1);
            this.PIniciarSesion.Controls.Add(this.BIngresar);
            this.PIniciarSesion.Location = new System.Drawing.Point(139, 27);
            this.PIniciarSesion.Name = "PIniciarSesion";
            this.PIniciarSesion.Size = new System.Drawing.Size(386, 338);
            this.PIniciarSesion.TabIndex = 1;
            // 
            // CBUsuarios
            // 
            this.CBUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBUsuarios.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.CBUsuarios.FormattingEnabled = true;
            this.CBUsuarios.Location = new System.Drawing.Point(102, 125);
            this.CBUsuarios.Name = "CBUsuarios";
            this.CBUsuarios.Size = new System.Drawing.Size(208, 30);
            this.CBUsuarios.TabIndex = 1;
            // IMPORTANTE: no seteamos SelectedIndex aquí.
            // 
            // TBContraseña
            // 
            this.TBContraseña.BackColor = System.Drawing.Color.Gainsboro;
            this.TBContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBContraseña.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.TBContraseña.Location = new System.Drawing.Point(102, 221);
            this.TBContraseña.Name = "TBContraseña";
            this.TBContraseña.Size = new System.Drawing.Size(208, 31);
            this.TBContraseña.TabIndex = 2;
            this.TBContraseña.UseSystemPasswordChar = true;
            // 
            // LContraseña
            // 
            this.LContraseña.AutoSize = true;
            this.LContraseña.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.LContraseña.ForeColor = System.Drawing.Color.LightGray;
            this.LContraseña.Location = new System.Drawing.Point(102, 184);
            this.LContraseña.Name = "LContraseña";
            this.LContraseña.Size = new System.Drawing.Size(130, 24);
            this.LContraseña.TabIndex = 3;
            this.LContraseña.Text = "Contraseña";
            // 
            // LUsuario
            // 
            this.LUsuario.AutoSize = true;
            this.LUsuario.Font = new System.Drawing.Font("Century Gothic", 15.75F);
            this.LUsuario.ForeColor = System.Drawing.Color.LightGray;
            this.LUsuario.Location = new System.Drawing.Point(102, 86);
            this.LUsuario.Name = "LUsuario";
            this.LUsuario.Size = new System.Drawing.Size(81, 24);
            this.LUsuario.TabIndex = 2;
            this.LUsuario.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(91, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Iniciar Sesión";
            // 
            // FInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(671, 377);
            this.Controls.Add(this.PIniciarSesion);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FInicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.PIniciarSesion.ResumeLayout(false);
            this.PIniciarSesion.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button BIngresar;
        private System.Windows.Forms.Panel PIniciarSesion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBUsuarios;
        private System.Windows.Forms.TextBox TBContraseña;
        private System.Windows.Forms.Label LContraseña;
        private System.Windows.Forms.Label LUsuario;
    }
}
