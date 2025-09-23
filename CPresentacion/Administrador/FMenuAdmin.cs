using AurenPadelStore.CPresentacion.Administrador.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Administrador
{
    public partial class FMenuAdmin : Form
    {
        public FMenuAdmin()
        {
            InitializeComponent();
        }


        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si ya está abierto
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is FUsuarios)
                {
                    MessageBox.Show("La ventana se encuentra abierta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm.Activate();
                    return;
                }
            }

            // Cerrar todos los demás formularios abiertos
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            // Crear el formulario hijo
            FUsuarios frmHijo = new FUsuarios()
            {
                MdiParent = this,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(0, 0),
                Dock = DockStyle.Fill // ocupa todo el MDI y se ajusta automáticamente al cambiar tamaño
            };

            frmHijo.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Oculto el menú actual
            this.Hide();

            // Abro el form de inicio de sesión
            var login = new AurenPadelStore.CPresentacion.InicioSesion.FInicioSesion();
            login.Show();

            // Cuando se cierre el login, cierro este menú también
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

