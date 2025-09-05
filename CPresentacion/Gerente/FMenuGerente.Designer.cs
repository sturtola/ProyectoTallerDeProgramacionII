namespace AurenPadelStore.CPresentacion.Gerente
{
    partial class FMenuGerente
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
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            listarUsuariosToolStripMenuItem = new ToolStripMenuItem();
            agregarUsuarioToolStripMenuItem1 = new ToolStripMenuItem();
            estadísticasToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, usuariosToolStripMenuItem, estadísticasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesiónToolStripMenuItem, salirToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(48, 20);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(143, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(143, 22);
            salirToolStripMenuItem.Text = "Salir";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listarUsuariosToolStripMenuItem, agregarUsuarioToolStripMenuItem1 });
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(64, 20);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // listarUsuariosToolStripMenuItem
            // 
            listarUsuariosToolStripMenuItem.Name = "listarUsuariosToolStripMenuItem";
            listarUsuariosToolStripMenuItem.Size = new Size(159, 22);
            listarUsuariosToolStripMenuItem.Text = "Listar Usuarios";
            listarUsuariosToolStripMenuItem.Click += listarUsuariosToolStripMenuItem_Click;
            // 
            // agregarUsuarioToolStripMenuItem1
            // 
            agregarUsuarioToolStripMenuItem1.Name = "agregarUsuarioToolStripMenuItem1";
            agregarUsuarioToolStripMenuItem1.Size = new Size(159, 22);
            agregarUsuarioToolStripMenuItem1.Text = "Agregar Usuario";
            agregarUsuarioToolStripMenuItem1.Click += agregarUsuarioToolStripMenuItem1_Click;
            // 
            // estadísticasToolStripMenuItem
            // 
            estadísticasToolStripMenuItem.Name = "estadísticasToolStripMenuItem";
            estadísticasToolStripMenuItem.Size = new Size(79, 20);
            estadísticasToolStripMenuItem.Text = "Estadísticas";
            // 
            // FMenuGerente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FMenuGerente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerente";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem listarUsuariosToolStripMenuItem;
        private ToolStripMenuItem estadísticasToolStripMenuItem;
        private ToolStripMenuItem agregarUsuarioToolStripMenuItem1;
    }
}