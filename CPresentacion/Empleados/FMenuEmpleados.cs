using AurenPadelStore.CPresentacion.Empleados.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados
{
    public partial class FMenuEmpleados : Form
    {
        public FMenuEmpleados()
        {
            InitializeComponent();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Verificar si ya está abierto
            foreach (Form frm in this.MdiChildren)
            {
                if (frm is FListarProductos)
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
            FListarProductos frmHijo = new FListarProductos
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

    }
}
