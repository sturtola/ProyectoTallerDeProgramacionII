using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AurenPadelStore.CPresentacion.Administrador.Usuarios;
using AurenPadelStore.CPresentacion.Administrador.Backup;

namespace AurenPadelStore.CPresentacion.Administrador
{
    public partial class FMenuAdmin : Form
    {
        public FMenuAdmin()
        {
            InitializeComponent();

            this.MdiChildActivate += (s, e) => PinChildActivo();
            this.SizeChanged += (s, e) => PinChildActivo();
        }


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
            {
                foreach (var c in this.MdiChildren)
                    c.Close();
            }


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

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FUsuarios());
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

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSingle(() => new FBackup());
        }
    }
}
