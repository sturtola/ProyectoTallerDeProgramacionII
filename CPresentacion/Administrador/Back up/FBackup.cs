using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using AurenPadelStore.CLogica;

namespace AurenPadelStore.CPresentacion.Administrador.Backup
{
    public partial class FBackup : Form
    {
        private readonly BackupLogica _logica = new BackupLogica();

        public FBackup()
        {
            InitializeComponent();
            CargarDefaults();
        }

        private void CargarDefaults()
        {
            // Sugerimos escritorio con nombre de archivo por fecha y hora
            var escritorio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var sugerido = Path.Combine(escritorio, $"AurenPadelBD_{DateTime.Now:yyyyMMdd_HHmm}.bak");
            txtRuta.Text = sugerido;
            lblEstado.Text = "Elegí una ubicación y tocá 'Crear backup'.";
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using var dlg = new SaveFileDialog
            {
                Title = "Guardar backup de AurenPadelBD",
                Filter = "Backup SQL Server (*.bak)|*.bak",
                FileName = txtRuta.Text,
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = "bak"
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                txtRuta.Text = dlg.FileName;
                lblEstado.Text = "Ruta seleccionada. Listo para crear backup.";
            }
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            var ruta = txtRuta.Text.Trim();
            if (string.IsNullOrWhiteSpace(ruta))
            {
                MessageBox.Show("Seleccioná una ruta para guardar el backup.", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                btnCrear.Enabled = false;
                btnExaminar.Enabled = false;
                lblEstado.Text = "Creando backup... (no cierres la aplicación)";
                UseWaitCursor = true;

                // Ejecutar en hilo de fondo para no colgar UI
                await Task.Run(() => _logica.EjecutarBackup(ruta));

                lblEstado.Text = "Backup creado con éxito ✅";
                MessageBox.Show($"Backup generado:\n{ruta}", "Backup OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al crear el backup.";
                MessageBox.Show($"No se pudo crear el backup.\n\nDetalle:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UseWaitCursor = false;
                btnCrear.Enabled = true;
                btnExaminar.Enabled = true;
            }
        }
    }
}
