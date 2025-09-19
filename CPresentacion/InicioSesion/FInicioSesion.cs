using AurenPadelStore.CPresentacion.Administrador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.InicioSesion
{
    public partial class FInicioSesion : Form
    {
        public FInicioSesion()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario MDI
            FMenuAdmin menuGerente = new FMenuAdmin();

            // Mostrar el formulario MDI
            menuGerente.Show();

            // Opcional: ocultar o cerrar el formulario de inicio de sesión
            this.Hide();
        }

        
    }
}
    
