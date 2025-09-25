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
            MSEmpleados.BackColor = Color.Black;
            MSEmpleados.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MSEmpleados.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, ventasToolStripMenuItem, clientesToolStripMenuItem, productosToolStripMenuItem, facturasToolStripMenuItem });
            MSEmpleados.Location = new Point(0, 0);
            MSEmpleados.Name = "MSEmpleados";
            MSEmpleados.Size = new Size(1012, 27);
            MSEmpleados.TabIndex = 0;
            MSEmpleados.Text = "Empleados";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { salirToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            inicioToolStripMenuItem.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            inicioToolStripMenuItem.ForeColor = Color.LightGray;
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(63, 23);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.BackColor = Color.Black;
            salirToolStripMenuItem.ForeColor = Color.LightGray;
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(180, 24);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.BackColor = Color.Black;
            cerrarSesiónToolStripMenuItem.ForeColor = Color.LightGray;
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(180, 24);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.BackColor = Color.Black;
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarVentaToolStripMenuItem, listarVentasToolStripMenuItem });
            ventasToolStripMenuItem.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            ventasToolStripMenuItem.ForeColor = Color.LightGray;
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(73, 23);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // generarVentaToolStripMenuItem
            // 
            generarVentaToolStripMenuItem.BackColor = Color.Black;
            generarVentaToolStripMenuItem.ForeColor = Color.LightGray;
            generarVentaToolStripMenuItem.Name = "generarVentaToolStripMenuItem";
            generarVentaToolStripMenuItem.Size = new Size(192, 24);
            generarVentaToolStripMenuItem.Text = "Generar Venta";
            generarVentaToolStripMenuItem.Click += generarVentaToolStripMenuItem_Click;
            // 
            // listarVentasToolStripMenuItem
            // 
            listarVentasToolStripMenuItem.BackColor = Color.Black;
            listarVentasToolStripMenuItem.ForeColor = Color.LightGray;
            listarVentasToolStripMenuItem.Name = "listarVentasToolStripMenuItem";
            listarVentasToolStripMenuItem.Size = new Size(192, 24);
            listarVentasToolStripMenuItem.Text = "Lista de Ventas";
            listarVentasToolStripMenuItem.Click += listarVentasToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            clientesToolStripMenuItem.ForeColor = Color.LightGray;
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(81, 23);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            productosToolStripMenuItem.ForeColor = Color.LightGray;
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(96, 23);
            productosToolStripMenuItem.Text = "Productos";
            productosToolStripMenuItem.Click += productosToolStripMenuItem_Click;
            // 
            // facturasToolStripMenuItem
            // 
            facturasToolStripMenuItem.BackColor = Color.Black;
            facturasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarFacturaToolStripMenuItem, listaDeFacturasToolStripMenuItem });
            facturasToolStripMenuItem.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            facturasToolStripMenuItem.ForeColor = Color.LightGray;
            facturasToolStripMenuItem.Name = "facturasToolStripMenuItem";
            facturasToolStripMenuItem.Size = new Size(86, 23);
            facturasToolStripMenuItem.Text = "Facturas";
            // 
            // generarFacturaToolStripMenuItem
            // 
            generarFacturaToolStripMenuItem.BackColor = Color.Black;
            generarFacturaToolStripMenuItem.ForeColor = Color.LightGray;
            generarFacturaToolStripMenuItem.Name = "generarFacturaToolStripMenuItem";
            generarFacturaToolStripMenuItem.Size = new Size(205, 24);
            generarFacturaToolStripMenuItem.Text = "Generar Factura";
            // 
            // listaDeFacturasToolStripMenuItem
            // 
            listaDeFacturasToolStripMenuItem.BackColor = Color.Black;
            listaDeFacturasToolStripMenuItem.ForeColor = Color.LightGray;
            listaDeFacturasToolStripMenuItem.Name = "listaDeFacturasToolStripMenuItem";
            listaDeFacturasToolStripMenuItem.Size = new Size(205, 24);
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