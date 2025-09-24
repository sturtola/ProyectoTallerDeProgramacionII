using AurenPadelStore.CPresentacion.Empleados.Productos;
using AurenPadelStore.CPresentacion.Empleados.Clientes;
using AurenPadelStore.CPresentacion.Empleados.Facturas.ListarFacturas;
using AurenPadelStore.CPresentacion.Empleados.Ventas.ListarVentas;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados
{
    public partial class FMenuEmpleados : Form
    {
        public FMenuEmpleados()
        {
            InitializeComponent();

            this.MdiChildActivate += (s, e) => PinChildActivo();
            this.SizeChanged += (s, e) => PinChildActivo();
        }

        // Para que se abra un solo formulario a al vez
        private void OpenSingle<T>(Func<T> factory) where T : Form
        {
            var anyChild = this.MdiChildren.FirstOrDefault();
            var same = this.MdiChildren.OfType<T>().FirstOrDefault();

            if (same != null)
            {
                MessageBox.Show("La ventana ya está abierta.",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                if (same.WindowState == FormWindowState.Minimized)
                    same.WindowState = FormWindowState.Normal;

                same.Activate();
                same.BringToFront();
                same.Location = new Point(0, 0);
                return;
            }

            if (anyChild != null)
                foreach (var c in this.MdiChildren) c.Close();

            var child = factory();
            child.MdiParent = this;
            child.StartPosition = FormStartPosition.Manual;
            child.WindowState = FormWindowState.Normal;
            child.Show();
            child.Location = new Point(0, 0);
        }

        private void PinChildActivo()
        {
            if (this.ActiveMdiChild != null &&
                this.ActiveMdiChild.WindowState == FormWindowState.Normal)
            {
                this.ActiveMdiChild.Location = new Point(0, 0);
            }
        }

        // ===== Menú =====
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FProductos());
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FClientes());
        }

        // 👉 LISTA DE FACTURAS (ahora pasa el rol)
        private void listaDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FListarFacturas(AurenPadelStore.SesionActual.Rol));
        }

        // Si también tenés "Generar factura", dejalo igual o crea el form correspondiente
        private void generarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // OpenSingle(() => new FGenerarFactura());
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new AurenPadelStore.CPresentacion.InicioSesion.FInicioSesion();
            login.Show();
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FListarVentas(AurenPadelStore.SesionActual.Rol));
        }
    }
}

