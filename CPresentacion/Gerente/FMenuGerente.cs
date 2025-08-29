using AurenPadelStore.CPresentacion.Gerente.AgregarUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Gerente
{
    public partial class FMenuGerente : Form
    {
        public FMenuGerente()
        {
            InitializeComponent();
        }
        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario que querés abrir
            Form agregarUsuario = new FAgregarUsuario(); // Suponiendo que tenés un Form llamado FormUsuarios

            // Indicar que este formulario es hijo del MDI
            agregarUsuario.MdiParent = this;

            // Mostrar el formulario
            agregarUsuario.Show();
        }

    }
}
