using AurenPadelStore.CEntidades;
using AurenPadelStore.CLogica;
using AurenPadelStore.CPresentacion.Empleados.Productos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados.Ventas
{
    public partial class FGenerarVenta : Form
    {
        private readonly CultureInfo _esAR = new CultureInfo("es-AR");

        private readonly ClienteLogica _clienteLogica = new ClienteLogica();
        private readonly ProductoLogica _productoLogica = new ProductoLogica();
        private readonly VentaLogica _ventaLogica = new VentaLogica();

        private List<Cliente> _clientes = new();
        private List<Producto> _productos = new();

        private List<ComboCliente> _comboClientesMaestro = new();
        private List<ComboProducto> _comboProductosMaestro = new();

        private bool _ignorandoTextChangedCliente = false;
        private bool _ignorandoTextChangedProducto = false;

        // Índices Grilla
        private int idxVer => DGItemsVenta.Columns["colVer"].Index;
        private int idxProducto => DGItemsVenta.Columns["colProducto"].Index;
        private int idxPrecioUnitario => DGItemsVenta.Columns["colPrecioUnitario"].Index;
        private int idxMenos => DGItemsVenta.Columns["colMenos"].Index;
        private int idxCantidad => DGItemsVenta.Columns["colCantidad"].Index;
        private int idxMas => DGItemsVenta.Columns["colMas"].Index;
        private int idxSubtotal => DGItemsVenta.Columns["colPrecioTotal"].Index;
        private int idxStockOculto => DGItemsVenta.Columns["colStockOculto"].Index;

        public FGenerarVenta()
        {
            InitializeComponent();
            ConfigurarControlesIniciales();
            WireEvents();
        }

        private void FGenerarVenta_Load(object sender, EventArgs e)
        {
            CargarDatos();
            ActualizarTotal();
        }

        private void ConfigurarControlesIniciales()
        {
            LTotalValor.Text = 0m.ToString("C2", _esAR);
            DTPFecha.MaxDate = DateTime.Today;
            DTPFecha.Value = DateTime.Today;

            CBCliente.DropDownStyle = ComboBoxStyle.DropDown;
            CBCliente.AutoCompleteMode = AutoCompleteMode.None;
        }

        private void WireEvents()
        {
            this.Load += FGenerarVenta_Load;
            BAgregarProducto.Click += BAgregarProducto_Click;
            BRealizarVenta.Click += BRealizarVenta_Click;

            DGItemsVenta.CellContentClick += DGItemsVenta_CellContentClick;
            DGItemsVenta.CellValueChanged += DGItemsVenta_CellValueChanged;
            DGItemsVenta.EditingControlShowing += DGItemsVenta_EditingControlShowing;
            DGItemsVenta.CurrentCellDirtyStateChanged += DGItemsVenta_CurrentCellDirtyStateChanged;
            DGItemsVenta.DataError += DGItemsVenta_DataError;

            CBEnvio.CheckedChanged += (s, e) => { if (CBEnvio.Checked) CBRetiro.Checked = false; ActualizarTotal(); };
            CBRetiro.CheckedChanged += (s, e) => { if (CBRetiro.Checked) CBEnvio.Checked = false; ActualizarTotal(); };

            CBEfectivo.CheckedChanged += ExclusivoPago_CheckedChanged;
            CBTransf.CheckedChanged += ExclusivoPago_CheckedChanged;
            CBTarjeta.CheckedChanged += ExclusivoPago_CheckedChanged;

            CBCliente.TextChanged += CBCliente_TextChanged;
            CBCliente.DropDown += CBCliente_DropDown;
            CBCliente.Leave += CBCliente_Leave;
        }

        private void CargarDatos()
        {
            _clientes = _clienteLogica.ObtenerTodosActivos() ?? new List<Cliente>();
            _comboClientesMaestro = new List<ComboCliente> { new ComboCliente { Id = -1, Texto = "Ningún cliente seleccionado" } };
            _comboClientesMaestro.AddRange(_clientes.Select(c => new ComboCliente { Id = c.id_Cliente, Texto = $"{c.Nombre_Cliente} {c.Apellido_Cliente} | DNI: {c.Dni_Cliente} | ID: {c.id_Cliente}" }));

            _ignorandoTextChangedCliente = true;
            CBCliente.DisplayMember = nameof(ComboCliente.Texto);
            CBCliente.ValueMember = nameof(ComboCliente.Id);
            CBCliente.DataSource = new List<ComboCliente>(_comboClientesMaestro);
            CBCliente.SelectedValue = -1;
            _ignorandoTextChangedCliente = false;

            _productos = _productoLogica.ObtenerTodosActivos() ?? new List<Producto>();
            _comboProductosMaestro = new List<ComboProducto> { new ComboProducto { Id = -1, Texto = "Seleccione un producto...", Precio = 0, Stock = 0 } };
            _comboProductosMaestro.AddRange(_productos.Select(p => new ComboProducto { Id = p.id_Producto, Texto = $"{p.Nombre_Producto} | {p.Marca_Producto} | ID: {p.id_Producto}", Precio = p.Precio_Unitario_Producto, Stock = p.Stock_Producto }));

            var colCombo = (DataGridViewComboBoxColumn)DGItemsVenta.Columns[idxProducto];
            colCombo.DisplayMember = nameof(ComboProducto.Texto);
            colCombo.ValueMember = nameof(ComboProducto.Id);
            colCombo.DataSource = _comboProductosMaestro;
        }

        // ==========================================================
        // COMBO CLIENTE
        // ==========================================================
        private void CBCliente_TextChanged(object? sender, EventArgs e)
        {
            if (_ignorandoTextChangedCliente || !CBCliente.Focused) return;
            string texto = CBCliente.Text;
            if (CBCliente.SelectedItem is ComboCliente sel && sel.Texto == texto) return;

            _ignorandoTextChangedCliente = true;
            int start = CBCliente.SelectionStart;
            var filtrados = _comboClientesMaestro.Where(c => c.Id == -1 || c.Texto.ToLower().Contains(texto.ToLower())).ToList();
            if (filtrados.Count == 0) filtrados.Add(_comboClientesMaestro.First(c => c.Id == -1));

            CBCliente.DataSource = filtrados;
            CBCliente.Text = texto;
            CBCliente.SelectionStart = Math.Min(start, CBCliente.Text.Length);
            if (!CBCliente.DroppedDown && CBCliente.Focused) CBCliente.DroppedDown = true;
            Cursor.Current = Cursors.Default;
            _ignorandoTextChangedCliente = false;
        }

        private void CBCliente_DropDown(object? sender, EventArgs e)
        {
            _ignorandoTextChangedCliente = true;
            var sel = CBCliente.SelectedItem as ComboCliente;
            CBCliente.DataSource = new List<ComboCliente>(_comboClientesMaestro);
            if (sel != null) CBCliente.SelectedValue = sel.Id;
            _ignorandoTextChangedCliente = false;
        }

        private void CBCliente_Leave(object? sender, EventArgs e)
        {
            var item = CBCliente.SelectedItem as ComboCliente;
            if (item == null || (item.Id == -1 && !string.IsNullOrEmpty(CBCliente.Text) && CBCliente.Text != item.Texto))
            {
                var match = _comboClientesMaestro.FirstOrDefault(c => c.Texto.Equals(CBCliente.Text, StringComparison.OrdinalIgnoreCase));
                _ignorandoTextChangedCliente = true;
                CBCliente.DataSource = new List<ComboCliente>(_comboClientesMaestro);
                CBCliente.SelectedValue = match?.Id ?? -1;
                _ignorandoTextChangedCliente = false;
            }
        }

        // ==========================================================
        // GRILLA PRODUCTOS
        // ==========================================================
        private void BAgregarProducto_Click(object? sender, EventArgs e)
        {
            int n = DGItemsVenta.Rows.Add();
            DGItemsVenta.Rows[n].Cells[idxProducto].Value = -1;
            DGItemsVenta.Rows[n].Cells[idxPrecioUnitario].Value = 0m.ToString("C2", _esAR);
            DGItemsVenta.Rows[n].Cells[idxCantidad].Value = "1";
            DGItemsVenta.Rows[n].Cells[idxSubtotal].Value = 0m.ToString("C2", _esAR);
            DGItemsVenta.Rows[n].Cells[idxStockOculto].Value = 0;
        }

        private void DGItemsVenta_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DGItemsVenta.CurrentCell.ColumnIndex == idxProducto && e.Control is ComboBox cb)
            {
                cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.AutoCompleteMode = AutoCompleteMode.None;

                var usados = new HashSet<int>();
                foreach (DataGridViewRow row in DGItemsVenta.Rows)
                {
                    if (row.Index == DGItemsVenta.CurrentCell.RowIndex) continue;
                    var id = GetIdProducto(row);
                    if (id.HasValue && id.Value != -1) usados.Add(id.Value);
                }
                var disponibles = _comboProductosMaestro.Where(p => p.Id == -1 || !usados.Contains(p.Id)).ToList();

                _ignorandoTextChangedProducto = true;
                cb.DataSource = disponibles;
                cb.DisplayMember = nameof(ComboProducto.Texto);
                cb.ValueMember = nameof(ComboProducto.Id);
                _ignorandoTextChangedProducto = false;

                cb.TextChanged -= ProductoGrid_TextChanged;
                cb.TextChanged += ProductoGrid_TextChanged;
                cb.Leave -= ProductoGrid_Leave;
                cb.Leave += ProductoGrid_Leave;
            }
            if (DGItemsVenta.CurrentCell.ColumnIndex == idxCantidad && e.Control is TextBox tb)
            {
                tb.KeyPress -= Cantidad_KeyPressSoloNumeros;
                tb.KeyPress += Cantidad_KeyPressSoloNumeros;
            }
        }

        private void ProductoGrid_TextChanged(object? sender, EventArgs e)
        {
            if (_ignorandoTextChangedProducto || sender is not ComboBox cb || !cb.Focused) return;

            string texto = cb.Text;
            if (cb.SelectedItem is ComboProducto sel && sel.Texto == texto) return;

            _ignorandoTextChangedProducto = true;
            int start = cb.SelectionStart;

            var usados = new HashSet<int>();
            foreach (DataGridViewRow row in DGItemsVenta.Rows)
            {
                if (row.Index == DGItemsVenta.CurrentRow.Index) continue;
                var id = GetIdProducto(row);
                if (id.HasValue && id.Value != -1) usados.Add(id.Value);
            }

            var filtrados = _comboProductosMaestro
                .Where(p => (p.Id == -1 || !usados.Contains(p.Id)) &&
                            (p.Id == -1 || p.Texto.ToLower().Contains(texto.ToLower())))
                .ToList();

            if (filtrados.Count == 0) filtrados.Add(_comboProductosMaestro.First(p => p.Id == -1));

            cb.DataSource = filtrados;
            cb.DisplayMember = nameof(ComboProducto.Texto);
            cb.ValueMember = nameof(ComboProducto.Id);
            cb.Text = texto;
            cb.SelectionStart = Math.Min(start, cb.Text.Length);

            if (!cb.DroppedDown && cb.Focused) cb.DroppedDown = true;
            Cursor.Current = Cursors.Default;
            _ignorandoTextChangedProducto = false;
        }

        private void ProductoGrid_Leave(object? sender, EventArgs e)
        {
            if (sender is ComboBox cb)
            {
                var item = cb.SelectedItem as ComboProducto;
                if (item == null || (item.Id == -1 && !string.IsNullOrEmpty(cb.Text) && cb.Text != item.Texto))
                {
                    _ignorandoTextChangedProducto = true;
                    cb.SelectedValue = -1;
                    _ignorandoTextChangedProducto = false;
                }
            }
        }

        private void DGItemsVenta_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = DGItemsVenta.Rows[e.RowIndex];

            if (e.ColumnIndex == idxProducto)
            {
                var idVal = GetIdProducto(row);
                if (idVal.HasValue && idVal.Value != -1)
                {
                    var p = _productos.FirstOrDefault(x => x.id_Producto == idVal.Value);
                    if (p != null)
                    {
                        row.Cells[idxPrecioUnitario].Value = p.Precio_Unitario_Producto.ToString("C2", _esAR);
                        row.Cells[idxStockOculto].Value = p.Stock_Producto;
                        row.Cells[idxCantidad].Value = "1";
                    }
                }
                else
                {
                    row.Cells[idxPrecioUnitario].Value = 0m.ToString("C2", _esAR);
                    row.Cells[idxStockOculto].Value = 0;
                    row.Cells[idxSubtotal].Value = 0m.ToString("C2", _esAR);
                }
                RecalcularFila(row);
                ActualizarTotal();
            }
            else if (e.ColumnIndex == idxCantidad)
            {
                ValidarStock(row);
                RecalcularFila(row);
                ActualizarTotal();
            }
        }

        private void ValidarStock(DataGridViewRow row)
        {
            int stock = Convert.ToInt32(row.Cells[idxStockOculto].Value ?? 0);
            int cant = GetCantidad(row);

            if (GetIdProducto(row).GetValueOrDefault(-1) != -1)
            {
                if (cant > stock)
                {
                    MessageBox.Show($"No hay suficiente stock. Máximo disponible: {stock}", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells[idxCantidad].Value = stock.ToString();
                }
                else if (cant < 1)
                {
                    row.Cells[idxCantidad].Value = "1";
                }
            }
        }

        private void DGItemsVenta_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = DGItemsVenta.Rows[e.RowIndex];

            if (e.ColumnIndex == idxVer)
            {
                var idVal = GetIdProducto(row);
                if (!idVal.HasValue || idVal.Value <= 0)
                {
                    MessageBox.Show("Seleccione un producto válido primero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    // Corrección: Usar el método que trae el producto completo
                    Producto productoCompleto = _productoLogica.Obtener(idVal.Value);

                    if (productoCompleto != null)
                    {
                        using (var fDetalle = new FDetalleProducto(productoCompleto))
                        {
                            fDetalle.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo recuperar la información completa del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar detalle: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.ColumnIndex == idxMas)
            {
                int cant = GetCantidad(row);
                int stock = Convert.ToInt32(row.Cells[idxStockOculto].Value ?? 0);
                if (cant < stock)
                {
                    row.Cells[idxCantidad].Value = (cant + 1).ToString();
                }
                else
                {
                    MessageBox.Show("No hay más stock disponible.", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (e.ColumnIndex == idxMenos)
            {
                int cant = GetCantidad(row);
                if (cant > 1) row.Cells[idxCantidad].Value = (cant - 1).ToString();
                else DGItemsVenta.Rows.RemoveAt(e.RowIndex);
                ActualizarTotal();
            }
        }

        // ==========================================================
        // REALIZAR VENTA
        // ==========================================================
        private void BRealizarVenta_Click(object? sender, EventArgs e)
        {
            // 1. Validar Sesión de Usuario
            if (SesionActual.Id_UsuarioActual <= 0)
            {
                MessageBox.Show("Error de sesión. No se puede registrar la venta. Por favor, reinicie la aplicación e inicie sesión.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Validar Cliente
            if (CBCliente.SelectedValue is not int idCliente || idCliente <= 0)
            {
                MessageBox.Show("Seleccione un cliente válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBCliente.Focus();
                return;
            }

            // 3. Validar Método de Pago
            string? metodo = MetodoPagoSeleccionado();
            if (string.IsNullOrEmpty(metodo))
            {
                MessageBox.Show("Seleccione un método de pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Validar Envío/Retiro
            if (!CBEnvio.Checked && !CBRetiro.Checked)
            {
                MessageBox.Show("Seleccione un método de entrega (Envío o Retiro).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Validar Items y Stock
            var items = new List<ItemVenta>();
            decimal totalCalculado = 0m;

            if (DGItemsVenta.Rows.Count == 0 || DGItemsVenta.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow r in DGItemsVenta.Rows)
            {
                if (r.IsNewRow) continue;

                var idProd = GetIdProducto(r);
                if (idProd == null || idProd.Value <= 0)
                {
                    MessageBox.Show("Hay filas de producto sin un ítem seleccionado. Por favor, revíselas o elimínelas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int cant = GetCantidad(r);
                if (cant <= 0)
                {
                    MessageBox.Show($"La cantidad para el producto ID {idProd.Value} debe ser al menos 1.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int stock = Convert.ToInt32(r.Cells[idxStockOculto].Value ?? 0);
                if (cant > stock)
                {
                    MessageBox.Show($"Stock insuficiente para el producto ID {idProd.Value}. Máximo: {stock}", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal precio = GetPrecio(r);
                items.Add(new ItemVenta
                {
                    id_Producto = idProd.Value,
                    Cantidad_Item_Venta = cant,
                    Precio_Unitario_Item_Venta = precio
                });
                totalCalculado += precio * cant;
            }

            if (!items.Any())
            {
                MessageBox.Show("No se ha agregado ningún producto válido a la venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CBEnvio.Checked) totalCalculado += 5000m; // Asumo costo fijo de 5000

            // --- ARMADO DE OBJETO VENTA ---
            var venta = new Venta
            {
                id_Cliente = idCliente,
                id_Usuario = SesionActual.Id_UsuarioActual, // <-- CORRECCIÓN APLICADA
                Metodo_Pago = metodo,
                Envio = CBEnvio.Checked,
                Total = totalCalculado,
                Fecha = DTPFecha.Value
            };

            // --- EJECUCIÓN ---
            try
            {
                // Asumo que tu VentaLogica tiene este método que maneja la transacción
                _ventaLogica.InsertarVentaConItems(venta, items);

                MessageBox.Show($"Venta registrada con éxito. \nVendedor: {SesionActual.NombreCompleto}", "Venta Exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ==========================================================
        // HELPERS
        // ==========================================================
        private void RecalcularFila(DataGridViewRow row)
        {
            decimal precio = GetPrecio(row);
            int cant = GetCantidad(row);
            row.Cells[idxSubtotal].Value = (precio * cant).ToString("C2", _esAR);
        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow r in DGItemsVenta.Rows)
            {
                string subStr = r.Cells[idxSubtotal].Value?.ToString()?.Replace("$", "").Trim() ?? "0";
                if (decimal.TryParse(subStr, NumberStyles.Any, _esAR, out decimal sub)) total += sub;
            }
            if (CBEnvio.Checked) total += 5000;
            LTotalValor.Text = total.ToString("C2", _esAR);
        }

        private int? GetIdProducto(DataGridViewRow row)
        {
            if (row.Cells[idxProducto].Value is int id) return id;
            if (row.Cells[idxProducto].Value is ComboProducto cp) return cp.Id;
            return null;
        }

        private int GetCantidad(DataGridViewRow row)
        {
            return int.TryParse(row.Cells[idxCantidad].Value?.ToString(), out int c) ? c : 0;
        }

        private decimal GetPrecio(DataGridViewRow row)
        {
            string precioStr = row.Cells[idxPrecioUnitario].Value?.ToString()?.Replace("$", "").Trim() ?? "0";
            decimal.TryParse(precioStr, NumberStyles.Any, _esAR, out decimal precio);
            return precio;
        }

        private string? MetodoPagoSeleccionado()
        {
            if (CBEfectivo.Checked) return "Efectivo";
            if (CBTransf.Checked) return "Transferencia";
            if (CBTarjeta.Checked) return "Tarjeta";
            return null;
        }

        private void LimpiarFormulario()
        {
            _ignorandoTextChangedCliente = true;
            CBCliente.SelectedValue = -1;
            _ignorandoTextChangedCliente = false;

            DGItemsVenta.Rows.Clear();
            CBEfectivo.Checked = false;
            CBTransf.Checked = false;
            CBTarjeta.Checked = false;
            CBEnvio.Checked = false;
            CBRetiro.Checked = false;
            DTPFecha.Value = DateTime.Today;
            ActualizarTotal();
        }

        private void Cantidad_KeyPressSoloNumeros(object? sender, KeyPressEventArgs e) { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; }
        private void DGItemsVenta_DataError(object? sender, DataGridViewDataErrorEventArgs e) { e.Cancel = true; }
        private void DGItemsVenta_CurrentCellDirtyStateChanged(object? sender, EventArgs e) { if (DGItemsVenta.IsCurrentCellDirty) DGItemsVenta.CommitEdit(DataGridViewDataErrorContexts.Commit); }
        private void ExclusivoPago_CheckedChanged(object? sender, EventArgs e) { if (sender is CheckBox c && c.Checked) { if (c != CBEfectivo) CBEfectivo.Checked = false; if (c != CBTransf) CBTransf.Checked = false; if (c != CBTarjeta) CBTarjeta.Checked = false; } }

        internal class ComboCliente { public int Id { get; set; } public string Texto { get; set; } = ""; public override string ToString() => Texto; }
        internal class ComboProducto { public int Id { get; set; } public string Texto { get; set; } = ""; public decimal Precio { get; set; } public int Stock { get; set; } public override string ToString() => Texto; }

        // --- CLASE INTERNA DE SESIÓN ELIMINADA ---
        // (Ahora usa la global AurenPadelStore.CEntidades.SesionActual)
    }
}