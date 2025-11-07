using AurenPadelStore.CPresentacion.Empleados.Productos;
using AurenPadelStore.CPresentacion.Empleados.Clientes;
using AurenPadelStore.CPresentacion.Empleados.Ventas.ListarVentas;
using AurenPadelStore.CPresentacion.Empleados.Ventas;
using AurenPadelStore.CPresentacion.Empleados.Facturas.ListarFacturas;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados
{
    public partial class FMenuEmpleados : Form
    {
        // === Rol actual ===
        private readonly string _rolActual;

        // ✔️ Opción A: te pasan el rol por parámetro
        public FMenuEmpleados(string rolActual)
        {
            InitializeComponent();

            _rolActual = rolActual ?? CEntidades.SesionActual.Rol;

            // UI: mantener MDI anclado arriba-izquierda
            this.MdiChildActivate += (s, e) => PinChildActivo();
            this.SizeChanged += (s, e) => PinChildActivo();

            // Para tooltips en items del menu
            MSEmpleados.ShowItemToolTips = true;

            ConfigurarMenuPorRol();
        }

        // ✔️ Opción B: compatibilidad con tu ctor anterior (toma el rol de SesionActual)
        public FMenuEmpleados() : this(CEntidades.SesionActual.Rol) { }

        // Para que se abra un solo formulario a la vez
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

        // ====== Configuración por rol ======
        private void ConfigurarMenuPorRol()
        {
            // Querés: Generar Venta visible pero bloqueado para "Gerente"
            if (_rolActual.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
            {
                // Feedback visual: gris y tooltip
                generarVentaToolStripMenuItem.ForeColor = Color.Gray;
                generarVentaToolStripMenuItem.ToolTipText = "Acceso restringido";

                // Cursor “bloqueado” cuando pasás por arriba del subitem
                generarVentaToolStripMenuItem.MouseEnter += GenerarVenta_MouseEnter_Bloqueado;
                generarVentaToolStripMenuItem.MouseLeave += GenerarVenta_MouseLeave_ResetCursor;

                // Por seguridad, si se cierra el dropdown, reseteo cursor
                ventasToolStripMenuItem.DropDownClosed += Ventas_DropDownClosed_ResetCursor;
            }
            else
            {
                // Rol con permiso: colores por defecto, sin tooltip ni cursor bloqueado
                generarVentaToolStripMenuItem.ForeColor = SystemColors.ControlText;
                generarVentaToolStripMenuItem.ToolTipText = string.Empty;

                generarVentaToolStripMenuItem.MouseEnter -= GenerarVenta_MouseEnter_Bloqueado;
                generarVentaToolStripMenuItem.MouseLeave -= GenerarVenta_MouseLeave_ResetCursor;
                ventasToolStripMenuItem.DropDownClosed -= Ventas_DropDownClosed_ResetCursor;
            }
        }

        private void GenerarVenta_MouseEnter_Bloqueado(object? sender, EventArgs e)
        {
            // No se puede setear el cursor del item directamente: uso el MenuStrip
            MSEmpleados.Cursor = Cursors.No;
        }

        private void GenerarVenta_MouseLeave_ResetCursor(object? sender, EventArgs e)
        {
            MSEmpleados.Cursor = Cursors.Default;
        }

        private void Ventas_DropDownClosed_ResetCursor(object? sender, EventArgs e)
        {
            MSEmpleados.Cursor = Cursors.Default;
        }

        // ===== Menú =====
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FProductos());
        }

        private void listaDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FListarFacturas());
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FClientes());
        }

        

        private void generarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // OpenSingle(() => new FGenerarFactura());
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Oculta el formulario actual
            this.Hide();

            // Limpia cualquier sesión activa si la estás usando
            AurenPadelStore.CEntidades.SesionActual.Id_UsuarioActual = 0;
            AurenPadelStore.CEntidades.SesionActual.Rol = null;

            // Muestra el formulario de inicio de sesión
            var login = new AurenPadelStore.CPresentacion.InicioSesion.FInicioSesion();
            login.FormClosed += (s, args) => this.Show(); // Opcional: si querés volver si cancela
            login.Show();
        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FListarVentas(CEntidades.SesionActual.Rol));
        }

        private void generarVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 🚫 Bloqueo lógico adicional (por si alguien intenta ejecutar)
            if (_rolActual.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "No tenés permisos para Generar una Venta.",
                    "Acceso restringido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            OpenSingle(() => new FGenerarVenta());
        }
    }
}
