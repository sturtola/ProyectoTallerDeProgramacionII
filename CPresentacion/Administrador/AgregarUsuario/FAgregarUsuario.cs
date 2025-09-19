using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CPresentacion.Administrador.AgregarUsuario
{
    public partial class FAgregarUsuario : Form
    {
        // Simulación de DNIs ya existentes (luego se reemplaza por consulta a BD)
        private readonly HashSet<string> dnisRegistrados = new HashSet<string>
        {
            "12345678", "87654321"
        };

        public FAgregarUsuario()
        {
            InitializeComponent();
            this.Load += FAgregarUsuario_Load;
            this.Shown += FAgregarUsuario_Shown;
            this.Resize += (_, __) => CentrarContenido();
            BAgregarUsuario.Click += BAgregarUsuario_Click;
            TBDni.KeyPress += TDni_KeyPress;

            this.AcceptButton = BAgregarUsuario;
            this.AutoScroll = false;
            this.DoubleBuffered = true;
        }

        private void FAgregarUsuario_Load(object sender, EventArgs e)
        {
            if (PAgregarUsuario != null)
                PAgregarUsuario.BackColor = Color.Transparent;

            if (TBContraseña != null)
                TBContraseña.UseSystemPasswordChar = true;
            if (TBRepContra != null)
                TBRepContra.UseSystemPasswordChar = true;

            CBRol.Items.Clear();
            CBRol.Items.AddRange(new[] { "Vendedor", "Gerente", "Administrador" });
            CBRol.SelectedIndex = 0;

            TBDni.MaxLength = 8;
            BAgregarUsuario.BringToFront();
            CentrarContenido();
            TBNombre.Focus();
        }

        private void FAgregarUsuario_Shown(object sender, EventArgs e) => CentrarContenido();

        private void CentrarContenido()
        {
            if (PAgregarUsuario == null) return;

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

            var area = this.ClientSize;
            PAgregarUsuario.Left = Math.Max(0, (area.Width - PAgregarUsuario.Width) / 2);
            PAgregarUsuario.Top = Math.Max(0, (area.Height - PAgregarUsuario.Height) / 2);
            PAgregarUsuario.Anchor = AnchorStyles.None;
        }

        private void BAgregarUsuario_Click(object sender, EventArgs e)
        {
            // ---- Validaciones ----
            if (string.IsNullOrWhiteSpace(TBNombre.Text) ||
                string.IsNullOrWhiteSpace(TBApellido.Text) ||
                string.IsNullOrWhiteSpace(TBDni.Text) ||
                string.IsNullOrWhiteSpace(TBContraseña.Text) ||
                string.IsNullOrWhiteSpace(TBRepContra.Text))
            {
                MessageBox.Show("Por favor, completá todos los campos.",
                                "Campos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Solo letras en nombre/apellido (con acentos y ñ)
            var soloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
            if (!soloLetras.IsMatch(TBNombre.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBNombre.Focus();
                return;
            }
            if (!soloLetras.IsMatch(TBApellido.Text))
            {
                MessageBox.Show("El apellido solo puede contener letras.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBApellido.Focus();
                return;
            }

            // DNI numérico de 8 dígitos
            if (TBDni.Text.Length != 8 || !long.TryParse(TBDni.Text, out _))
            {
                MessageBox.Show("El DNI debe tener 8 dígitos numéricos.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBDni.Focus();
                return;
            }

            // Contraseñas
            if (TBContraseña.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.",
                                "Contraseña débil",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBContraseña.Focus();
                return;
            }
            if (TBContraseña.Text != TBRepContra.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.",
                                "Error de confirmación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBRepContra.Focus();
                return;
            }

            // DNI repetido (simulado)
            if (dnisRegistrados.Contains(TBDni.Text))
            {
                MessageBox.Show("El DNI ya está registrado.",
                                "Duplicado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                TBDni.Focus();
                return;
            }

            // ---- Inserción en BD ----
            try
            {
                var u = new AurenPadelStore.CEntidades.Usuario
                {
                    Nombre = TBNombre.Text.Trim(),
                    Apellido = TBApellido.Text.Trim(),
                    DNI = TBDni.Text.Trim(),
                    Contrasena = TBContraseña.Text,   // considera hashear en el futuro
                    Rol = CBRol.SelectedItem.ToString()
                };

                var logica = new AurenPadelStore.CLogica.UsuarioLogica();
                logica.RegistrarUsuario(u);

                // Mensaje de éxito
                var result = MessageBox.Show(
                    "Usuario agregado correctamente.\n\n¿Querés agregar otro usuario?",
                    "Éxito",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (result == DialogResult.Yes)
                {
                    LimpiarCampos();
                    TBNombre.Focus();
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void TDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void LimpiarCampos()
        {
            TBNombre.Clear();
            TBApellido.Clear();
            TBDni.Clear();
            TBContraseña.Clear();
            TBRepContra.Clear();
            CBRol.SelectedIndex = 0;
        }
    }
}
