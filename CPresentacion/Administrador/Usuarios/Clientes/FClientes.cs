using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AurenPadelStore.CEntidades;
using AurenPadelStore.CLogica;

namespace AurenPadelStore.CPresentacion.Empleados.Clientes
{
    public partial class FClientes : Form
    {
        private readonly ClienteLogica _clienteLogica = new ClienteLogica();
        private List<Cliente> _listaCompletaClientes; // Para guardar la lista original de clientes
        private int? _idClienteEditando = null;
        private Panel _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);
        private bool _bloquearEstadoPorRol = false;

        public FClientes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Shown += (_, __) => this.Location = new Point(0, 0);
            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();
            DGListaClientes.CellContentClick += DGListaClientes_CellContentClick;
            DGListaClientes.CellMouseEnter += DGListaClientes_CellMouseEnter;
            DGListaClientes.CellMouseLeave += DGListaClientes_CellMouseLeave;
            this.Load += FClientes_Load;

            // Se asignan los eventos para buscar y filtrar en tiempo real
            TBBuscarC.TextChanged += (_, __) => AplicarFiltrosYBusqueda();
            CBFiltroC.SelectedIndexChanged += (_, __) => AplicarFiltrosYBusqueda();
        }

        private void FClientes_Load(object sender, EventArgs e)
        {
            // Se cargan las opciones del ComboBox de filtros
            CBFiltroC.Items.AddRange(new object[] {
                "Todos", "Activos", "Inactivos", "Más Recientes", "Más Antiguos"
            });
            CBFiltroC.SelectedIndex = 0; // Se selecciona "Todos" por defecto

            string rolActual = SesionActual.Rol;
            if (rolActual.Equals("Gerente", StringComparison.OrdinalIgnoreCase))
            {
                BloquearInteraccionSinCambiarEstilo(PAgregarCliente, BAgregarCliente, "Solo Vendedor/es pueden agregar clientes.");
            }
            _bloquearEstadoPorRol = !rolActual.Equals("Gerente", StringComparison.OrdinalIgnoreCase);

            _scrollHost.AutoScrollPosition = Point.Empty;
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                _listaCompletaClientes = _clienteLogica.Listar();
                AplicarFiltrosYBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MÉTODO CENTRAL PARA FILTRAR Y BUSCAR
        private void AplicarFiltrosYBusqueda()
        {
            if (_listaCompletaClientes == null) return;

            IEnumerable<Cliente> clientesAMostrar = _listaCompletaClientes;

            // 1. Aplicamos el filtro del ComboBox
            string filtro = CBFiltroC.SelectedItem?.ToString() ?? "Todos";
            switch (filtro)
            {
                case "Activos":
                    clientesAMostrar = clientesAMostrar.Where(c => c.Estado_Cliente);
                    break;
                case "Inactivos":
                    clientesAMostrar = clientesAMostrar.Where(c => !c.Estado_Cliente);
                    break;
                case "Más Recientes":
                    // MODIFICADO: Ordena por ID descendente (el más alto es el más nuevo)
                    clientesAMostrar = clientesAMostrar.OrderByDescending(c => c.id_Cliente);
                    break;
                case "Más Antiguos":
                    // MODIFICADO: Ordena por ID ascendente (el más bajo es el más viejo)
                    clientesAMostrar = clientesAMostrar.OrderBy(c => c.id_Cliente);
                    break;
            }

            // 2. Aplicamos la búsqueda del TextBox
            string busqueda = TBBuscarC.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                clientesAMostrar = clientesAMostrar.Where(c =>
                    c.Nombre_Cliente.ToLower().Contains(busqueda) ||
                    c.Apellido_Cliente.ToLower().Contains(busqueda) ||
                    c.Dni_Cliente.ToString().Contains(busqueda) ||
                    c.Direccion_Cliente.ToLower().Contains(busqueda) ||
                    (c.Correo_Cliente != null && c.Correo_Cliente.ToLower().Contains(busqueda)) ||
                    c.Telefono_Cliente.Contains(busqueda)
                );
            }

            // 3. Finalmente, poblamos la grilla con los resultados
            DGListaClientes.Rows.Clear();
            foreach (var cliente in clientesAMostrar.ToList())
            {
                int idx = DGListaClientes.Rows.Add(
                    cliente.Nombre_Cliente, cliente.Apellido_Cliente, cliente.Dni_Cliente,
                    cliente.Direccion_Cliente, cliente.Correo_Cliente, cliente.Telefono_Cliente,
                    cliente.Estado_Cliente ? "Activo" : "Inactivo", "Editar", ""
                );
                DGListaClientes.Rows[idx].Tag = cliente;
                SetAccionSegunEstado(DGListaClientes.Rows[idx]);
            }
        }

        private void BAgregarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBNombre.Text) || string.IsNullOrWhiteSpace(TBApellido.Text) ||
                string.IsNullOrWhiteSpace(TBDni.Text) || string.IsNullOrWhiteSpace(TBDireccion.Text) ||
                string.IsNullOrWhiteSpace(TBTelefono.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios (excepto correo).", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_idClienteEditando.HasValue)
                {
                    var clienteEditado = new Cliente
                    {
                        id_Cliente = _idClienteEditando.Value,
                        Dni_Cliente = int.Parse(TBDni.Text),
                        Nombre_Cliente = TBNombre.Text.Trim(),
                        Apellido_Cliente = TBApellido.Text.Trim(),
                        Direccion_Cliente = TBDireccion.Text.Trim(),
                        Correo_Cliente = string.IsNullOrWhiteSpace(TBCorreo.Text) ? null : TBCorreo.Text.Trim(),
                        Telefono_Cliente = TBTelefono.Text.Trim()
                    };
                    _clienteLogica.Actualizar(clienteEditado);
                    MessageBox.Show("Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var nuevoCliente = new Cliente
                    {
                        Dni_Cliente = int.Parse(TBDni.Text),
                        Nombre_Cliente = TBNombre.Text.Trim(),
                        Apellido_Cliente = TBApellido.Text.Trim(),
                        Direccion_Cliente = TBDireccion.Text.Trim(),
                        Correo_Cliente = string.IsNullOrWhiteSpace(TBCorreo.Text) ? null : TBCorreo.Text.Trim(),
                        Telefono_Cliente = TBTelefono.Text.Trim()
                    };
                    _clienteLogica.Registrar(nuevoCliente);
                    MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarClientes();
                CambiarModoFormulario(aModoAgregar: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGListaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = DGListaClientes.Columns[e.ColumnIndex].Name;
            var clienteSeleccionado = DGListaClientes.Rows[e.RowIndex].Tag as Cliente;
            if (clienteSeleccionado == null) return;

            if (colName == "colEditar")
            {
                TBNombre.Text = clienteSeleccionado.Nombre_Cliente;
                TBApellido.Text = clienteSeleccionado.Apellido_Cliente;
                TBDni.Text = clienteSeleccionado.Dni_Cliente.ToString();
                TBDireccion.Text = clienteSeleccionado.Direccion_Cliente;
                TBCorreo.Text = clienteSeleccionado.Correo_Cliente;
                TBTelefono.Text = clienteSeleccionado.Telefono_Cliente;
                _idClienteEditando = clienteSeleccionado.id_Cliente;
                CambiarModoFormulario(aModoAgregar: false);
            }
            else if (colName == "colAccion")
            {
                // MODIFICADO: Ahora no hace nada si el rol está bloqueado
                if (_bloquearEstadoPorRol)
                {
                    return; // Simplemente no hace nada, sin mostrar mensaje.
                }

                try
                {
                    bool nuevoEstado = !clienteSeleccionado.Estado_Cliente;
                    _clienteLogica.CambiarEstado(clienteSeleccionado.id_Cliente, nuevoEstado, SesionActual.Rol);
                    CargarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cambiar el estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CambiarModoFormulario(bool aModoAgregar)
        {
            if (aModoAgregar)
            {
                _idClienteEditando = null;
                LAgregarCliente.Text = "Agregar Cliente";
                BAgregarCliente.Text = "Agregar Cliente";
                LimpiarCampos();
                TBNombre.Focus();
            }
            else
            {
                LAgregarCliente.Text = "Editar Cliente";
                BAgregarCliente.Text = "Guardar Edición";
            }
        }

        #region Metodos_UI_Sin_Cambios
        private void SetAccionSegunEstado(DataGridViewRow row)
        {
            var cliente = row.Tag as Cliente;
            bool estadoActivo = cliente?.Estado_Cliente ?? false;
            var accionCell = row.Cells["colAccion"] as DataGridViewButtonCell;
            if (estadoActivo) { accionCell.Value = "Inactivar"; accionCell.Style.BackColor = Color.LightCoral; }
            else { accionCell.Value = "Activar"; accionCell.Style.BackColor = Color.LightSkyBlue; }
            accionCell.Style.ForeColor = Color.Black;
        }

        private void LimpiarCampos()
        {
            TBNombre.Clear(); TBApellido.Clear(); TBDni.Clear();
            TBDireccion.Clear(); TBCorreo.Clear(); TBTelefono.Clear();
        }

        private void TBNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void DGListaClientes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (_bloquearEstadoPorRol && DGListaClientes.Columns[e.ColumnIndex].Name == "colAccion")
                    DGListaClientes.Cursor = Cursors.No;
            }
        }

        private void DGListaClientes_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DGListaClientes.Cursor = Cursors.Default;
        }

        private void PrepararScrollHost()
        {
            _scrollHost = new Panel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = this.BackColor };
            while (this.Controls.Count > 0) { Control c = this.Controls[0]; this.Controls.RemoveAt(0); _scrollHost.Controls.Add(c); }
            this.Controls.Add(_scrollHost);
            _scrollHost.AutoScrollMinSize = _designContentSize;
            UpdateScrollbars();
        }

        private void UpdateScrollbars()
        {
            if (this.WindowState == FormWindowState.Maximized) { _scrollHost.AutoScrollMinSize = Size.Empty; }
            else { _scrollHost.AutoScrollMinSize = _designContentSize; }
            _scrollHost.AutoScrollPosition = Point.Empty;
        }

        private void BloquearInteraccionSinCambiarEstilo(Panel panel, Button botonAgregar, string tooltip = "")
        {
            foreach (Control c in panel.Controls)
            {
                if (c is TextBox tb) { var color = tb.BackColor; tb.ReadOnly = true; tb.BackColor = color; tb.TabStop = false; tb.Cursor = Cursors.No; tb.GotFocus += (s, ev) => DGListaClientes.Focus(); tb.ShortcutsEnabled = false; }
                else if (c is ComboBox cb) { cb.Enabled = false; cb.TabStop = false; }
                else if (c is Button b && !ReferenceEquals(b, botonAgregar)) { b.Enabled = false; b.TabStop = false; }
                else { c.TabStop = false; }
            }
            if (botonAgregar != null) { botonAgregar.Enabled = false; if (!string.IsNullOrWhiteSpace(tooltip)) { var tt = new ToolTip(); tt.SetToolTip(botonAgregar, tooltip); } }
            panel.TabStop = false; panel.Cursor = Cursors.No;
            if (!string.IsNullOrWhiteSpace(tooltip)) { var tt = new ToolTip(); tt.SetToolTip(panel, tooltip); foreach (Control c in panel.Controls) tt.SetToolTip(c, tooltip); }
            panel.MouseDown += (s, ev) => DGListaClientes.Focus();
        }
        #endregion
    }
}
