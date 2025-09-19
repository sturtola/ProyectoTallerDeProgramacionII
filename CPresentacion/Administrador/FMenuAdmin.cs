using AurenPadelStore.CPresentacion.Administrador.AgregarUsuario;
using AurenPadelStore.CPresentacion.Administrador.ListarUsuarios;
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

        private void listarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si ya está abierto
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is FListarUsuarios)
                {
                    MessageBox.Show("La ventana se encuentra abierta", "Atención",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm.Activate();
                    return;
                }
                else
                {
                    frm.Close(); // Cerrar cualquier otro formulario abierto
                }
            }

            // Crear instancia del formulario
            Form listarUsuarios = new FListarUsuarios();
            listarUsuarios.MdiParent = this;

            // Quitar cascada y centrar
            listarUsuarios.StartPosition = FormStartPosition.Manual;
            listarUsuarios.Location = new Point(
                (this.ClientSize.Width - listarUsuarios.Width) / 2,
                (this.ClientSize.Height - listarUsuarios.Height) / 2
            );

            listarUsuarios.Show();
        }

        private void agregarUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Verificar si ya está abierto
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is FAgregarUsuario)
                {
                    MessageBox.Show("La ventana se encuentra abierta", "Atención",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm.Activate();
                    return;
                }
                else
                {
                    frm.Close(); // Cerrar cualquier otro formulario abierto
                }
            }

            // Crear instancia del formulario
            Form agregarUsuario = new FAgregarUsuario();
            agregarUsuario.MdiParent = this;

            // Quitar cascada y centrar
            agregarUsuario.StartPosition = FormStartPosition.Manual;
            agregarUsuario.Location = new Point(
                (this.ClientSize.Width - agregarUsuario.Width) / 2,
                (this.ClientSize.Height - agregarUsuario.Height) / 2
            );

            agregarUsuario.Show();
        }

    }
}

