using System.Windows.Forms;
using System.Drawing;


namespace AurenPadelStore.CPresentacion.Empleados.Productos
{
    partial class FDetalleProducto
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.PPrincipal = new Panel();
            this.PDerecha = new Panel();
            this.LStock = new Label();
            this.LPrecio = new Label();
            this.LMaterial = new Label();
            this.LCategoria = new Label();
            this.LMarca = new Label();
            this.LNombre = new Label();
            this.LDescripcionTitulo = new Label();
            this.TDescripcion = new TextBox();
            this.PIzquierda = new Panel();
            this.PBImagen = new PictureBox();
            this.PPrincipal.SuspendLayout();
            this.PDerecha.SuspendLayout();
            this.PIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // PPrincipal
            // 
            this.PPrincipal.BackColor = Color.FromArgb(30, 30, 30);
            this.PPrincipal.Controls.Add(this.PDerecha);
            this.PPrincipal.Controls.Add(this.PIzquierda);
            this.PPrincipal.Dock = DockStyle.Fill;
            this.PPrincipal.Location = new Point(0, 0);
            this.PPrincipal.Name = "PPrincipal";
            this.PPrincipal.Size = new Size(760, 520);
            this.PPrincipal.TabIndex = 0;
            // 
            // PDerecha
            // 
            this.PDerecha.Dock = DockStyle.Fill;
            this.PDerecha.Padding = new Padding(20);
            this.PDerecha.BackColor = Color.FromArgb(40, 40, 40);
            this.PDerecha.Controls.Add(this.LStock);
            this.PDerecha.Controls.Add(this.LPrecio);
            this.PDerecha.Controls.Add(this.LMaterial);
            this.PDerecha.Controls.Add(this.LCategoria);
            this.PDerecha.Controls.Add(this.LMarca);
            this.PDerecha.Controls.Add(this.LNombre);
            this.PDerecha.Controls.Add(this.LDescripcionTitulo);
            this.PDerecha.Controls.Add(this.TDescripcion);
            this.PDerecha.Location = new Point(300, 0);
            this.PDerecha.Name = "PDerecha";
            this.PDerecha.Size = new Size(460, 520);
            this.PDerecha.TabIndex = 1;
            // 
            // LStock
            // 
            this.LStock.AutoSize = true;
            this.LStock.Font = new Font("Century Gothic", 11F);
            this.LStock.ForeColor = Color.Gainsboro;
            this.LStock.Location = new Point(20, 210);
            this.LStock.Name = "LStock";
            this.LStock.Size = new Size(68, 20);
            this.LStock.TabIndex = 7;
            this.LStock.Text = "Stock: -";
            // 
            // LPrecio
            // 
            this.LPrecio.AutoSize = true;
            this.LPrecio.Font = new Font("Century Gothic", 11F);
            this.LPrecio.ForeColor = Color.Gainsboro;
            this.LPrecio.Location = new Point(20, 180);
            this.LPrecio.Name = "LPrecio";
            this.LPrecio.Size = new Size(70, 20);
            this.LPrecio.TabIndex = 6;
            this.LPrecio.Text = "Precio: -";
            // 
            // LMaterial
            // 
            this.LMaterial.AutoSize = true;
            this.LMaterial.Font = new Font("Century Gothic", 11F);
            this.LMaterial.ForeColor = Color.Gainsboro;
            this.LMaterial.Location = new Point(20, 150);
            this.LMaterial.Name = "LMaterial";
            this.LMaterial.Size = new Size(84, 20);
            this.LMaterial.TabIndex = 5;
            this.LMaterial.Text = "Material: -";
            // 
            // LCategoria
            // 
            this.LCategoria.AutoSize = true;
            this.LCategoria.Font = new Font("Century Gothic", 11F);
            this.LCategoria.ForeColor = Color.Gainsboro;
            this.LCategoria.Location = new Point(20, 120);
            this.LCategoria.Name = "LCategoria";
            this.LCategoria.Size = new Size(93, 20);
            this.LCategoria.TabIndex = 4;
            this.LCategoria.Text = "Categoría: -";
            // 
            // LMarca
            // 
            this.LMarca.AutoSize = true;
            this.LMarca.Font = new Font("Century Gothic", 11F);
            this.LMarca.ForeColor = Color.Gainsboro;
            this.LMarca.Location = new Point(20, 90);
            this.LMarca.Name = "LMarca";
            this.LMarca.Size = new Size(71, 20);
            this.LMarca.TabIndex = 3;
            this.LMarca.Text = "Marca: -";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new Font("Century Gothic", 16F, FontStyle.Bold);
            this.LNombre.ForeColor = Color.White;
            this.LNombre.Location = new Point(20, 40);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new Size(118, 26);
            this.LNombre.TabIndex = 2;
            this.LNombre.Text = "Producto";
            // 
            // LDescripcionTitulo
            // 
            this.LDescripcionTitulo.AutoSize = true;
            this.LDescripcionTitulo.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            this.LDescripcionTitulo.ForeColor = Color.WhiteSmoke;
            this.LDescripcionTitulo.Location = new Point(20, 260);
            this.LDescripcionTitulo.Name = "LDescripcionTitulo";
            this.LDescripcionTitulo.Size = new Size(104, 19);
            this.LDescripcionTitulo.TabIndex = 1;
            this.LDescripcionTitulo.Text = "Descripción";
            // 
            // TDescripcion
            // 
            this.TDescripcion.BackColor = Color.FromArgb(45, 45, 45);
            this.TDescripcion.BorderStyle = BorderStyle.FixedSingle;
            this.TDescripcion.Font = new Font("Century Gothic", 10.5F);
            this.TDescripcion.ForeColor = Color.Gainsboro;
            this.TDescripcion.Location = new Point(20, 285);
            this.TDescripcion.Multiline = true;
            this.TDescripcion.Name = "TDescripcion";
            this.TDescripcion.ReadOnly = true;
            this.TDescripcion.ScrollBars = ScrollBars.Vertical;
            this.TDescripcion.Size = new Size(420, 200);
            this.TDescripcion.TabIndex = 0;
            // 
            // PIzquierda
            // 
            this.PIzquierda.Dock = DockStyle.Left;
            this.PIzquierda.BackColor = Color.FromArgb(20, 20, 20);
            this.PIzquierda.Padding = new Padding(15);
            this.PIzquierda.Controls.Add(this.PBImagen);
            this.PIzquierda.Location = new Point(0, 0);
            this.PIzquierda.Name = "PIzquierda";
            this.PIzquierda.Size = new Size(300, 520);
            this.PIzquierda.TabIndex = 0;
            // 
            // PBImagen
            // 
            this.PBImagen.Dock = DockStyle.Fill;
            this.PBImagen.SizeMode = PictureBoxSizeMode.Zoom;
            this.PBImagen.BackColor = Color.Black;
            this.PBImagen.Location = new Point(15, 15);
            this.PBImagen.Name = "PBImagen";
            this.PBImagen.Size = new Size(270, 490);
            this.PBImagen.TabIndex = 0;
            this.PBImagen.TabStop = false;
            // 
            // FDetalleProducto
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.Black;
            this.ClientSize = new Size(760, 520);
            this.Controls.Add(this.PPrincipal);
            this.Font = new Font("Century Gothic", 9F);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FDetalleProducto";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Detalle del Producto";
            this.PPrincipal.ResumeLayout(false);
            this.PDerecha.ResumeLayout(false);
            this.PDerecha.PerformLayout();
            this.PIzquierda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBImagen)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private Panel PPrincipal;
        private Panel PDerecha;
        private Panel PIzquierda;
        private PictureBox PBImagen;
        private Label LNombre;
        private Label LMarca;
        private Label LCategoria;
        private Label LMaterial;
        private Label LPrecio;
        private Label LStock;
        private Label LDescripcionTitulo;
        private TextBox TDescripcion;
    }
}
