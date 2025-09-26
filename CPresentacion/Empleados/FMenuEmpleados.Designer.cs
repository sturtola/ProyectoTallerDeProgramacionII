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
            MSEmpleados = new MenuStrip();
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
            MSEmpleados.SuspendLayout();
            SuspendLayout();
            // 
            // MSEmpleados
            // 
            MSEmpleados.BackColor = Color.LightGray;
            MSEmpleados.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MSEmpleados.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, ventasToolStripMenuItem, clientesToolStripMenuItem, productosToolStripMenuItem, facturasToolStripMenuItem });
            MSEmpleados.Location = new Point(0, 0);
            MSEmpleados.Name = "MSEmpleados";
            MSEmpleados.Size = new Size(1012, 29);
            MSEmpleados.TabIndex = 0;
            MSEmpleados.Text = "Empleados";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.BackColor = Color.LightGray;
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            inicioToolStripMenuItem.Font = new Font("Century Gothic", 12F);
            inicioToolStripMenuItem.ForeColor = Color.Black;
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(63, 25);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.BackColor = Color.LightGray;
            salirToolStripMenuItem.Font = new Font("Century Gothic", 12F);
            salirToolStripMenuItem.ForeColor = Color.Black;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(180, 26);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.BackColor = Color.LightGray;
            cerrarSesiónToolStripMenuItem.Font = new Font("Century Gothic", 12F);
            cerrarSesiónToolStripMenuItem.ForeColor = Color.Black;
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(180, 26);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.BackColor = Color.LightGray;
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarVentaToolStripMenuItem, listarVentasToolStripMenuItem });
            ventasToolStripMenuItem.Font = new Font("Century Gothic", 12F);
            ventasToolStripMenuItem.ForeColor = Color.Black;
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(77, 25);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // generarVentaToolStripMenuItem
            // 
            generarVentaToolStripMenuItem.BackColor = Color.LightGray;
            generarVentaToolStripMenuItem.ForeColor = Color.Black;
            generarVentaToolStripMenuItem.Name = "generarVentaToolStripMenuItem";
            generarVentaToolStripMenuItem.Size = new Size(198, 26);
            generarVentaToolStripMenuItem.Text = "Generar Venta";
            generarVentaToolStripMenuItem.Click += generarVentaToolStripMenuItem_Click;
            // 
            // listarVentasToolStripMenuItem
            // 
            listarVentasToolStripMenuItem.BackColor = Color.LightGray;
            listarVentasToolStripMenuItem.ForeColor = Color.Black;
            listarVentasToolStripMenuItem.Name = "listarVentasToolStripMenuItem";
            listarVentasToolStripMenuItem.Size = new Size(198, 26);
            listarVentasToolStripMenuItem.Text = "Lista de Ventas";
            listarVentasToolStripMenuItem.Click += listarVentasToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.BackColor = Color.LightGray;
            clientesToolStripMenuItem.Font = new Font("Century Gothic", 12F);
            clientesToolStripMenuItem.ForeColor = Color.Black;
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(84, 25);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.BackColor = Color.LightGray;
            productosToolStripMenuItem.Font = new Font("Century Gothic", 12F);
            productosToolStripMenuItem.ForeColor = Color.Black;
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(100, 25);
            productosToolStripMenuItem.Text = "Productos";
            productosToolStripMenuItem.Click += productosToolStripMenuItem_Click;
            // 
            // facturasToolStripMenuItem
            // 
            facturasToolStripMenuItem.BackColor = Color.LightGray;
            facturasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarFacturaToolStripMenuItem, listaDeFacturasToolStripMenuItem });
            facturasToolStripMenuItem.Font = new Font("Century Gothic", 12F);
            facturasToolStripMenuItem.ForeColor = Color.Black;
            facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
            facturasToolStripMenuItem.Size = new Size(90, 25);
            facturasToolStripMenuItem.Text = "Facturas";
            // 
            // generarFacturaToolStripMenuItem
            // 
            generarFacturaToolStripMenuItem.BackColor = Color.LightGray;
            generarFacturaToolStripMenuItem.ForeColor = Color.Black;
            generarFacturaToolStripMenuItem.Name = "generarFacturaToolStripMenuItem";
            generarFacturaToolStripMenuItem.Size = new Size(211, 26);
            generarFacturaToolStripMenuItem.Text = "Generar Factura";
            // 
            // listaDeFacturasToolStripMenuItem
            // 
            listaDeFacturasToolStripMenuItem.BackColor = Color.LightGray;
            listaDeFacturasToolStripMenuItem.ForeColor = Color.Black;
            listaDeFacturasToolStripMenuItem.Name = "listaDeFacturasToolStripMenuItem";
            listaDeFacturasToolStripMenuItem.Size = new Size(211, 26);
            listaDeFacturasToolStripMenuItem.Text = "Lista de Facturas";
            listaDeFacturasToolStripMenuItem.Click += listaDeFacturasToolStripMenuItem_Click;
            // 
            // FMenuEmpleados
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1012, 540);
            Controls.Add(MSEmpleados);
            Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            IsMdiContainer = true;
            MainMenuStrip = MSEmpleados;
            Margin = new Padding(4);
            Name = "FMenuEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empleados";
            MSEmpleados.ResumeLayout(false);
            MSEmpleados.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MSEmpleados;
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