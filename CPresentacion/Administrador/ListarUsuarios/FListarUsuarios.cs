using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Administrador.ListarUsuarios
{
    public partial class FListarUsuarios : Form
    {
        public FListarUsuarios()
        {
            InitializeComponent();
            DGVListaUs.CellClick += DGVListaUs_CellClick;
        }

        private void DGVListaUs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (DGVListaUs.Columns[e.ColumnIndex].Name == "CEliminar")
            {
                string nombre = DGVListaUs.Rows[e.RowIndex].Cells["CNombre"].Value.ToString();
                DialogResult result = MessageBox.Show(
                    $"¿Desea eliminar permanentemente al usuario {nombre}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DGVListaUs.Rows.RemoveAt(e.RowIndex);
                }
            }
            else if (DGVListaUs.Columns[e.ColumnIndex].Name == "CEditar")
            {
                MessageBox.Show("Funcionalidad de editar aún no implementada.", "Editar Usuario");
            }
        }

       
    }
}
