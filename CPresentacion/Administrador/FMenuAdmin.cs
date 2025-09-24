using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AurenPadelStore.CPresentacion.Administrador.Usuarios;

namespace AurenPadelStore.CPresentacion.Administrador
{
    public partial class FMenuAdmin : Form
    {
        public FMenuAdmin()
        {
            InitializeComponent();

            // Mantener child alineado a (0,0) al activar/cambiar tamaño
            this.MdiChildActivate += (s, e) => PinChildActivo();
            this.SizeChanged += (s, e) => PinChildActivo();
        }

        // ====== REGLA: un solo child ======
        // Si ya está abierto el mismo tipo => aviso y foco.
        // Si hay otro abierto => cerrar y abrir el nuevo.
        private void OpenSingle<T>(Func<T> factory) where T : Form
        {
            // ¿Hay algún child abierto?
            var anyChild = this.MdiChildren.FirstOrDefault();

            // ¿Hay un child del mismo tipo ya abierto?
            var same = this.MdiChildren.OfType<T>().FirstOrDefault();

            if (same != null)
            {
                // Ya está abierto este mismo form: avisar y activar
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

            // Hay un child abierto pero es de otro tipo → cerrarlo
            if (anyChild != null)
            {
                foreach (var c in this.MdiChildren)
                    c.Close();
            }

            // Abrir el nuevo child alineado a (0,0)
            var child = factory();
            child.MdiParent = this;
            child.StartPosition = FormStartPosition.Manual;
            child.WindowState = FormWindowState.Normal; // no maximizado
            child.Show();                                // mostrar primero
            child.Location = new Point(0, 0);            // luego fijar (0,0)
        }

        // Mantener el hijo activo clavado en (0,0)
        private void PinChildActivo()
        {
            if (this.ActiveMdiChild != null &&
                this.ActiveMdiChild.WindowState == FormWindowState.Normal)
            {
                this.ActiveMdiChild.Location = new Point(0, 0);
            }
        }

        // ====== Handlers de Menú ======
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FUsuarios());
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // (Opcional) limpiar sesión si la estás usando
            // SesionActual.DNI = null;
            // SesionActual.Nombre = null;
            // SesionActual.Rol = null;

            this.Hide();
            var login = new AurenPadelStore.CPresentacion.InicioSesion.FInicioSesion();
            login.Show();
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
