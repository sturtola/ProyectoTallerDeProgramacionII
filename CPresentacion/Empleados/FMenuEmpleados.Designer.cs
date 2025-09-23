namespace AurenPadelStore.CPresentacion.Empleados
{
    partial class FMenuEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMenuEmpleados));
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            generarVentaToolStripMenuItem = new ToolStripMenuItem();
            listarVentasToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            facturasToolStripMenuItem = new ToolStripMenuItem();
            generarFacturaToolStripMenuItem = new ToolStripMenuItem();
            listaDeFacturasToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, ventasToolStripMenuItem, clientesToolStripMenuItem, productosToolStripMenuItem, facturasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1012, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(48, 20);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(180, 22);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(180, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarVentaToolStripMenuItem, listarVentasToolStripMenuItem });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(53, 20);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // generarVentaToolStripMenuItem
            // 
            generarVentaToolStripMenuItem.Name = "generarVentaToolStripMenuItem";
            generarVentaToolStripMenuItem.Size = new Size(151, 22);
            generarVentaToolStripMenuItem.Text = "Generar Venta";
            // 
            // listarVentasToolStripMenuItem
            // 
            listarVentasToolStripMenuItem.Name = "listarVentasToolStripMenuItem";
            listarVentasToolStripMenuItem.Size = new Size(151, 22);
            listarVentasToolStripMenuItem.Text = "Lista de Ventas";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(61, 20);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(73, 20);
            productosToolStripMenuItem.Text = "Productos";
            productosToolStripMenuItem.Click += productosToolStripMenuItem_Click;
            // 
            // facturasToolStripMenuItem
            // 
            facturasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarFacturaToolStripMenuItem, listaDeFacturasToolStripMenuItem });
            facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
            facturasToolStripMenuItem.Size = new Size(63, 20);
            facturasToolStripMenuItem.Text = "Facturas";
            // 
            // generarFacturaToolStripMenuItem
            // 
            generarFacturaToolStripMenuItem.Name = "generarFacturaToolStripMenuItem";
            generarFacturaToolStripMenuItem.Size = new Size(161, 22);
            generarFacturaToolStripMenuItem.Text = "Generar Factura";
            // 
            // listaDeFacturasToolStripMenuItem
            // 
            listaDeFacturasToolStripMenuItem.Name = "listaDeFacturasToolStripMenuItem";
            listaDeFacturasToolStripMenuItem.Size = new Size(161, 22);
            listaDeFacturasToolStripMenuItem.Text = "Lista de Facturas";
            // 
            // FMenuEmpleados
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1012, 540);
            Controls.Add(menuStrip1);
            Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "FMenuEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empleados";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem generarVentaToolStripMenuItem;
        private ToolStripMenuItem listarVentasToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem facturasToolStripMenuItem;
        private ToolStripMenuItem generarFacturaToolStripMenuItem;
        private ToolStripMenuItem listaDeFacturasToolStripMenuItem;
    }
}