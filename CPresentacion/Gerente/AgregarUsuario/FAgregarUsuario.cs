using System;
using System.Drawing;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Gerente.AgregarUsuario
{
    public partial class FAgregarUsuario : Form
    {
        public FAgregarUsuario()
        {
            InitializeComponent();

            // ---- Enganche de eventos (a prueba de balas) ----
            this.Load += FAgregarUsuario_Load;
            this.Shown += FAgregarUsuario_Shown;        // para centrar cuando ya conoce el MdiParent
            this.Resize += (_, __) => CentrarContenido();
            BAgregarUsuario.Click += BAgregarUsuario_Click;
            TDni.KeyPress += TDni_KeyPress;
            // -------------------------------------------------

            // UX: Enter = Agregar
            this.AcceptButton = BAgregarUsuario;

            // Evitar barras de scroll del form (están cortando la UI)
            this.AutoScroll = false;

            // Menos parpadeo con fondo
            this.DoubleBuffered = true;
        }

        private void FAgregarUsuario_Load(object sender, EventArgs e)
        {
            // Transparencia del panel sobre el fondo del Form
            if (PAgregarUsuario != null)
                PAgregarUsuario.BackColor = Color.Transparent;

            // Password oculto
            if (TContraseña != null)
                TContraseña.UseSystemPasswordChar = true;

            // Rol
            CRol.Items.Clear();
            CRol.Items.Add("Vendedor");
            CRol.Items.Add("Gerente");
            CRol.Items.Add("Administrador");
            CRol.SelectedIndex = 0;

            // Máximo largo DNI (opcional)
            TDni.MaxLength = 8;

            // Asegurar que el botón no quede debajo de nada
            BAgregarUsuario.BringToFront();

            // Centrar contenido
            CentrarContenido();

            TNombre.Focus();
        }

        // En MDI, StartPosition no se respeta: centramos cuando ya está mostrado
        private void FAgregarUsuario_Shown(object sender, EventArgs e)
        {
            CentrarContenido();
        }

        // Centra el Panel con los campos dentro del área visible del Form
        private void CentrarContenido()
        {
            if (PAgregarUsuario == null) return;

            // Si querés centrar TODO el form dentro del MDI:
            if (this.MdiParent != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                var w = this.MdiParent.ClientSize.Width;
                var h = this.MdiParent.ClientSize.Height;
                this.Location = new Point(
                    Math.Max(0, (w - this.Width) / 2),
                    Math.Max(0, (h - this.Height) / 2)
                );
            }

            // Centrar el panel dentro del form
            var area = this.ClientSize;
            PAgregarUsuario.Left = Math.Max(0, (area.Width - PAgregarUsuario.Width) / 2);
            PAgregarUsuario.Top = Math.Max(0, (area.Height - PAgregarUsuario.Height) / 2);
            // Importante para que no “se mueva” con el resize
            PAgregarUsuario.Anchor = AnchorStyles.None;
        }

        private void BAgregarUsuario_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(TNombre.Text) ||
                string.IsNullOrWhiteSpace(TApellido.Text) ||
                string.IsNullOrWhiteSpace(TDni.Text) ||
                string.IsNullOrWhiteSpace(TContraseña.Text) ||
                CRol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completá todos los campos.",
                                "Campos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Sólo números en DNI (por si pegaste texto)
            if (!long.TryParse(TDni.Text, out _))
            {
                MessageBox.Show("El DNI debe contener solo números.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TDni.Focus();
                TDni.SelectAll();
                return;
            }

            // Confirmación (mock front, sin BD)
            var result = MessageBox.Show(
                "Usuario agregado correctamente.\n\n¿Querés agregar otro usuario?",
                "Éxito",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                LimpiarCampos();
                TNombre.Focus();
            }
            else
            {
                this.Close();
            }
        }

        // Bloquea ingreso de letras en DNI mientras escribe
        private void TDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite control (Backspace, Delete, Tab, Enter) y dígitos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void LimpiarCampos()
        {
            TNombre.Clear();
            TApellido.Clear();
            TDni.Clear();
            TContraseña.Clear();
            CRol.SelectedIndex = 0;
        }
    }
}
