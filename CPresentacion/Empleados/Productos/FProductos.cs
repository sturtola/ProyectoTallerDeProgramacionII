using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AurenPadelStore.CEntidades;
using AurenPadelStore.CLogica;

namespace AurenPadelStore.CPresentacion.Empleados.Productos
{
    public partial class FProductos : Form
    {
        private Panel? _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);

        private readonly ProductoLogica _logica = new ProductoLogica();
        private List<Producto> _cache = new List<Producto>();
        private bool _modoEdicion = false;
        private int? _idProductoEdicion = null;

        private readonly CultureInfo _esAR = new CultureInfo("es-AR");
        private string? _imagenSeleccionadaPathRelativa = null;

        // Búsqueda + filtros
        private System.Windows.Forms.Timer _debounceTimer;
        private string _ordenSel = "A-Z";
        private string _categoriaSel = "Todas";
        private string _marcaSel = "Todas";
        private bool _reconstruyendoFiltros = false;

        // ===== NUEVO: helper de rol =====
        private bool EsVendedor =>
            SesionActual.Rol != null &&
            SesionActual.Rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase);

        public FProductos()
        {
            InitializeComponent();

            _debounceTimer = new System.Windows.Forms.Timer();

            DGListaProd.CellContentClick += DGListaProd_CellContentClick;

            DGListaProd.RowsAdded += (s, e) =>
            {
                for (int i = 0; i < e.RowCount; i++)
                    SetAccionSegunEstado(DGListaProd.Rows[e.RowIndex + i]);
            };

            // ===== NUEVO: cursor bloqueado en colAccion si es Vendedor =====
            DGListaProd.CellMouseMove += DGListaProd_CellMouseMove;
            DGListaProd.CellMouseLeave += (s, e) => DGListaProd.Cursor = Cursors.Default;

            DGListaProd.CellFormatting += DGListaProd_CellFormatting;

            // ===== NUEVO: tooltip en colAccion según permisos =====
            DGListaProd.CellToolTipTextNeeded += DGListaProd_CellToolTipTextNeeded;

            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();

            this.Load += FProductos_Load;
            BAgregarProducto.Click += BAgregarProducto_Click;

            BExaminarImg.Click += BExaminarImg_Click;
            PBImagenP.SizeMode = PictureBoxSizeMode.Zoom;

            if (this.Controls.Find("BCancelarProducto", true).Length > 0)
            {
                var btn = (Button)this.Controls.Find("BCancelarProducto", true)[0];
                btn.Click += (s, e) => CancelarEdicionYLimpiar();
            }

            TBPrecioP.KeyPress += TBPrecio_KeyPress;
            TBStockP.KeyPress += TBStock_KeyPress;

            TBBuscarProd.TextChanged += (_, __) => DebounceAplicar();
            CBFiltrosProd.SelectedIndexChanged += (_, __) => FiltroSeleccionadoCambio();
        }

        private void FProductos_Load(object? sender, EventArgs e)
        {
            // Ya bloqueabas el panel de alta para Vendedor
            if (EsVendedor)
            {
                BloquearInteraccionSinCambiarEstilo(PAgregarProducto, BAgregarProducto,
                    "No tiene permitido realizar esta acción.");
            }

            CargarCategorias();
            CargarDesdeBD();
            ConstruirOpcionesDeFiltros();
            AplicarBusquedaYFiltros();

            if (_scrollHost != null)
                _scrollHost.AutoScrollPosition = Point.Empty;

        }

        // ==== Categorías (combo alta/edición) ====
        private void CargarCategorias()
        {
            try
            {
                var cats = _logica.ListarCategorias();

                CBCategoriaP.DataSource = null;
                CBCategoriaP.DropDownStyle = ComboBoxStyle.DropDown;
                CBCategoriaP.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBCategoriaP.AutoCompleteSource = AutoCompleteSource.ListItems;

                CBCategoriaP.DisplayMember = "Nombre";
                CBCategoriaP.ValueMember = "Id";
                CBCategoriaP.DataSource = cats;

                if (CBCategoriaP.Items.Count > 0) CBCategoriaP.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron obtener las categorías: " + ex.Message,
                                "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBCategoriaP.DataSource = null;
            }
        }

        private void RecargarCategoriasYSeleccionar(string? nombreCategoriaPreferida = null)
        {
            CargarCategorias();

            if (CBCategoriaP.DataSource is System.Collections.IList lista && lista.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(nombreCategoriaPreferida))
                {
                    var items = lista.Cast<object>()
                                     .Select(o => new
                                     {
                                         Obj = o,
                                         Nombre = (o as Categoria)?.Nombre_Categoria
                                     })
                                     .ToList();

                    var match = items.FirstOrDefault(x =>
                        string.Equals(x.Nombre, nombreCategoriaPreferida, StringComparison.OrdinalIgnoreCase));

                    if (match != null)
                    {
                        CBCategoriaP.SelectedItem = match.Obj;
                        return;
                    }
                }

                CBCategoriaP.SelectedIndex = 0;
            }
            else
            {
                CBCategoriaP.Text = "";
            }
        }

        // ==== Scroll ====
        private void PrepararScrollHost()
        {
            _scrollHost = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = this.BackColor
            };

            while (this.Controls.Count > 0)
            {
                Control c = this.Controls[0];
                this.Controls.RemoveAt(0);
                _scrollHost.Controls.Add(c);
            }

            this.Controls.Add(_scrollHost);
            _scrollHost.AutoScrollMinSize = _designContentSize;
            UpdateScrollbars();
        }

        private void UpdateScrollbars()
        {
            if (_scrollHost == null) return;

            if (this.WindowState == FormWindowState.Maximized)
            {
                _scrollHost.AutoScrollMinSize = Size.Empty;
                _scrollHost.AutoScrollPosition = Point.Empty;
            }
            else
            {
                _scrollHost.AutoScrollMinSize = _designContentSize;
            }
        }

        // ==== Cargar productos ====
        private void CargarDesdeBD()
        {
            try
            {
                _cache = _logica.Listar() ?? new List<Producto>();

                if (!DGListaProd.Columns.Contains("colId"))
                {
                    var colId = new DataGridViewTextBoxColumn
                    {
                        Name = "colId",
                        HeaderText = "Id",
                        Visible = false
                    };
                    DGListaProd.Columns.Insert(0, colId);
                }

                RefrescarGrilla(_cache);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==== Formato precio ====
        private void DGListaProd_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGListaProd.Columns[e.ColumnIndex].Name == "colPrecio" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal dec))
                {
                    e.Value = dec.ToString("C", _esAR);
                    e.FormattingApplied = true;
                }
            }
        }

        private void DGListaProd_CellToolTipTextNeeded(object? sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var col = DGListaProd.Columns[e.ColumnIndex];

                if (col.Name == "colDesc")
                {
                    var value = DGListaProd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (value != null) e.ToolTipText = value.ToString();
                }

                // ===== NUEVO: tooltip de permiso en colAccion =====
                if (col.Name == "colAccion" && EsVendedor)
                {
                    e.ToolTipText = "No tiene permitido realizar esta acción.";
                }
            }
        }

        private void SetAccionSegunEstado(DataGridViewRow row)
        {
            var estado = (row.Cells["colEstado"].Value?.ToString() ?? "Activo").Trim();
            var accionCell = row.Cells["colAccion"] as DataGridViewButtonCell;
            if (accionCell == null) return;

            if (string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase))
            {
                accionCell.Value = "Inactivar";
                accionCell.Style.BackColor = Color.LightCoral;
                accionCell.Style.ForeColor = Color.Black;
            }
            else
            {
                accionCell.Value = "Activar";
                accionCell.Style.BackColor = Color.LightSkyBlue;
                accionCell.Style.ForeColor = Color.Black;
            }
        }

        private void DGListaProd_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var colName = DGListaProd.Columns[e.ColumnIndex].Name;
            var row = DGListaProd.Rows[e.RowIndex];

            // ===== NUEVO: bloquear acción al Vendedor =====
            if (colName == "colAccion" && EsVendedor)
            {
                MessageBox.Show("El rol VENDEDOR no puede activar/inactivar productos.",
                                "Acción bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (colName == "colAccion")
            {
                if (!(row.Cells["colId"].Value is int id)) return;

                bool actualmenteActivo = string.Equals(row.Cells["colEstado"].Value?.ToString(), "Activo", StringComparison.OrdinalIgnoreCase);
                string accion = actualmenteActivo ? "Inactivar" : "Activar";

                var dr = MessageBox.Show($"¿Deseás {accion.ToLower()} este producto?",
                                         "Confirmación",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                try
                {
                    _logica.CambiarEstado(id, !actualmenteActivo, SesionActual.Rol);

                    var pCache = _cache.FirstOrDefault(x => x.id_Producto == id);
                    if (pCache != null) pCache.Estado_Producto = !actualmenteActivo;

                    row.Cells["colEstado"].Value = (!actualmenteActivo) ? "Activo" : "Inactivo";
                    SetAccionSegunEstado(row);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cambiar el estado: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            if (colName == "colEditar")
            {
                if (!(row.Cells["colId"].Value is int id)) return;

                var p = _cache.Find(x => x.id_Producto == id);
                if (p == null) return;

                TBNombreP.Text = p.Nombre_Producto;
                TBMarcaP.Text = p.Marca_Producto;
                TBMaterialP.Text = p.Material_Producto;
                TBDescP.Text = p.Descripcion_Producto;
                TBStockP.Text = p.Stock_Producto.ToString();
                TBPrecioP.Text = p.Precio_Unitario_Producto.ToString("N2", _esAR);

                if (p.id_Categoria > 0 && CBCategoriaP.ValueMember == "Id")
                {
                    var before = CBCategoriaP.SelectedIndex;
                    CBCategoriaP.SelectedValue = p.id_Categoria;
                    if (!Equals(CBCategoriaP.SelectedValue, p.id_Categoria))
                    {
                        CBCategoriaP.SelectedIndex = before;
                        CBCategoriaP.Text = p.Categoria_Nombre;
                    }
                }
                else
                {
                    CBCategoriaP.Text = p.Categoria_Nombre;
                }

                _imagenSeleccionadaPathRelativa = p.Imagen_Producto;
                MostrarEnPictureBoxDesdeBD(_imagenSeleccionadaPathRelativa);

                _modoEdicion = true;
                _idProductoEdicion = id;
                BAgregarProducto.Text = "Guardar Edición";
            }
        }

        // ===== NUEVO: cursor bloqueado / mano en colAccion =====
        private void DGListaProd_CellMouseMove(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var isAccion = DGListaProd.Columns[e.ColumnIndex].Name == "colAccion";

            if (isAccion && EsVendedor)
                DGListaProd.Cursor = Cursors.No;
            else if (isAccion)
                DGListaProd.Cursor = Cursors.Hand;
            else
                DGListaProd.Cursor = Cursors.Default;
        }

        // ==== Agregar / Guardar ====
        private void BAgregarProducto_Click(object? sender, EventArgs e)
        {
            if (!ValidarFormulario(out string msgValid, out decimal precio, out int stock))
            {
                MessageBox.Show(msgValid, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string txtAccion = _modoEdicion ? "guardar los cambios de" : "agregar";
            var dr = MessageBox.Show(
                $"¿Deseás {txtAccion} este producto?\n\n" +
                $"- Nombre: {TBNombreP.Text.Trim()}\n" +
                $"- Marca: {TBMarcaP.Text.Trim()}\n" +
                $"- Stock: {stock}\n" +
                $"- Precio: {precio.ToString("C", _esAR)}",
                "Confirmación",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Cancel)
            {
                CancelarEdicionYLimpiar();
                return;
            }
            if (dr == DialogResult.No) return;

            try
            {
                string nombreCategoriaEscrito = (CBCategoriaP.Text ?? "").Trim();

                if (_modoEdicion && _idProductoEdicion.HasValue)
                {
                    var p = _cache.FirstOrDefault(x => x.id_Producto == _idProductoEdicion.Value)
                            ?? new Producto { id_Producto = _idProductoEdicion.Value };

                    p.Nombre_Producto = TBNombreP.Text.Trim();
                    p.Descripcion_Producto = TBDescP.Text.Trim();
                    p.Marca_Producto = TBMarcaP.Text.Trim();
                    p.Material_Producto = TBMaterialP.Text.Trim();
                    p.Stock_Producto = stock;
                    p.Precio_Unitario_Producto = precio;

                    if (!string.IsNullOrWhiteSpace(_imagenSeleccionadaPathRelativa))
                        p.Imagen_Producto = _imagenSeleccionadaPathRelativa;

                    _logica.Actualizar(p, nombreCategoriaEscrito);

                    var row = DGListaProd.Rows
                        .Cast<DataGridViewRow>()
                        .FirstOrDefault(rr => (rr.Cells["colId"].Value is int id) && id == p.id_Producto);

                    if (row != null)
                    {
                        row.Cells["colNombre"].Value = p.Nombre_Producto;
                        row.Cells["colMarca"].Value = p.Marca_Producto;
                        row.Cells["colMaterial"].Value = p.Material_Producto;
                        row.Cells["colDesc"].Value = p.Descripcion_Producto;
                        row.Cells["colStock"].Value = p.Stock_Producto;
                        row.Cells["colPrecio"].Value = p.Precio_Unitario_Producto;

                        if (!string.IsNullOrWhiteSpace(p.Imagen_Producto))
                        {
                            var full = ResolverRutaCompletaDesdeBD(p.Imagen_Producto);
                            row.Cells["colImagen"].Value = File.Exists(full) ? CargarImagenSinLock(full) : null;
                        }
                    }

                    MessageBox.Show("Producto actualizado correctamente.", "OK",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ConstruirOpcionesDeFiltros();
                    RecargarCategoriasYSeleccionar(nombreCategoriaEscrito);
                }
                else
                {
                    var p = new Producto
                    {
                        Nombre_Producto = TBNombreP.Text.Trim(),
                        Descripcion_Producto = TBDescP.Text.Trim(),
                        Marca_Producto = TBMarcaP.Text.Trim(),
                        Material_Producto = TBMaterialP.Text.Trim(),
                        Stock_Producto = stock,
                        Precio_Unitario_Producto = precio,
                        Imagen_Producto = _imagenSeleccionadaPathRelativa ?? string.Empty,
                        Estado_Producto = true
                    };

                    _logica.Registrar(p, nombreCategoriaEscrito);

                    MessageBox.Show("Producto agregado correctamente.", "OK",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDesdeBD();
                    ConstruirOpcionesDeFiltros();
                    RecargarCategoriasYSeleccionar(nombreCategoriaEscrito);
                }

                AplicarBusquedaYFiltros();
                CancelarEdicionYLimpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelarEdicionYLimpiar()
        {
            _modoEdicion = false;
            _idProductoEdicion = null;
            BAgregarProducto.Text = "Agregar Producto";
            LimpiarCampos();
        }

        // ==== Validaciones de tipeo ====
        private void TBPrecio_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void TBStock_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // ==== Validación Form + parser precio ====
        private bool ValidarFormulario(out string mensaje, out decimal precio, out int stock)
        {
            mensaje = "";
            precio = 0m;
            stock = 0;

            string nombre = (TBNombreP.Text ?? "").Trim();
            string marca = (TBMarcaP.Text ?? "").Trim();
            string mat = (TBMaterialP.Text ?? "").Trim();
            string desc = (TBDescP.Text ?? "").Trim();
            string categoria = (CBCategoriaP.Text ?? "").Trim();
            string precioTx = (TBPrecioP.Text ?? "").Trim();
            string stockTx = (TBStockP.Text ?? "").Trim();

            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(marca) ||
                string.IsNullOrWhiteSpace(mat) ||
                string.IsNullOrWhiteSpace(desc) ||
                string.IsNullOrWhiteSpace(categoria) ||
                string.IsNullOrWhiteSpace(precioTx) ||
                string.IsNullOrWhiteSpace(stockTx))
            {
                mensaje = "Debe completar todos los campos";
                return false;
            }

            if (string.IsNullOrWhiteSpace(_imagenSeleccionadaPathRelativa))
            {
                mensaje = "Debe seleccionar una imagen";
                return false;
            }

            if (!ParsePrecioFlexible(precioTx, out precio))
            {
                mensaje = "El precio debe tener formato válido";
                return false;
            }
            if (precio <= 0)
            {
                mensaje = "El precio debe ser mayor a 0";
                return false;
            }

            if (!int.TryParse(stockTx, out stock))
            {
                mensaje = "El stock debe ser un número entero";
                return false;
            }
            if (stock < 0)
            {
                mensaje = "El stock debe ser mayor o igual a 0";
                return false;
            }

            return true;
        }

        private bool ParsePrecioFlexible(string input, out decimal value)
        {
            value = 0m;
            if (string.IsNullOrWhiteSpace(input)) return false;

            string s = input.Trim();
            s = s.Replace(" ", "");
            s = s.Replace("$", "").Replace("ARS", "", StringComparison.OrdinalIgnoreCase);

            int lastDot = s.LastIndexOf('.');
            int lastCom = s.LastIndexOf(',');
            int lastSep = Math.Max(lastDot, lastCom);

            if (lastSep >= 0)
            {
                int digitsRight = s.Length - lastSep - 1;
                bool treatAsDecimal = digitsRight == 2;

                if (treatAsDecimal)
                {
                    string left = s.Substring(0, lastSep).Replace(".", "").Replace(",", "");
                    string right = new string(s.Substring(lastSep + 1).Where(char.IsDigit).ToArray());
                    if (right.Length != 2) return false;

                    string canonical = $"{left}.{right}";
                    return decimal.TryParse(canonical, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
                }
                else
                {
                    string canonical = s.Replace(".", "").Replace(",", "");
                    return decimal.TryParse(canonical, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
                }
            }
            else
            {
                return decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
            }
        }

        private void LimpiarCampos()
        {
            TBNombreP.Clear();
            TBDescP.Clear();
            TBMarcaP.Clear();
            TBMaterialP.Clear();
            TBPrecioP.Clear();
            TBStockP.Clear();

            if (CBCategoriaP.DataSource != null && CBCategoriaP.Items.Count > 0)
                CBCategoriaP.SelectedIndex = 0;
            else
                CBCategoriaP.Text = "";

            _imagenSeleccionadaPathRelativa = null;
            PBImagenP.Image?.Dispose();
            PBImagenP.Image = null;
        }

        // ==== Imágenes ====
        private string GetResourcesPath()
        {
            var baseDir = Application.StartupPath;
            var res = Path.Combine(baseDir, "Resources");
            if (!Directory.Exists(res)) Directory.CreateDirectory(res);
            return res;
        }

        private Image CargarImagenSinLock(string pathCompleto)
        {
            using (var fs = new FileStream(pathCompleto, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var img = Image.FromStream(fs))
                return (Image)img.Clone();
        }

        private string ResolverRutaCompletaDesdeBD(string rutaBD)
        {
            return Path.IsPathRooted(rutaBD)
                ? rutaBD
                : Path.Combine(Application.StartupPath, rutaBD);
        }

        private void MostrarEnPictureBoxDesdeBD(string rutaBD)
        {
            PBImagenP.Image?.Dispose();
            PBImagenP.Image = null;

            if (string.IsNullOrWhiteSpace(rutaBD)) return;

            var full = ResolverRutaCompletaDesdeBD(rutaBD);
            if (File.Exists(full))
                PBImagenP.Image = CargarImagenSinLock(full);
        }

        private void BExaminarImg_Click(object? sender, EventArgs e)
        {
            try
            {
                var resourcesPath = GetResourcesPath();
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Seleccionar imagen del producto";
                    ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    ofd.Multiselect = false;
                    ofd.InitialDirectory = resourcesPath;

                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        var nombre = Path.GetFileName(ofd.FileName);
                        _imagenSeleccionadaPathRelativa = Path.Combine("Resources", nombre);
                        MostrarEnPictureBoxDesdeBD(_imagenSeleccionadaPathRelativa);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen: " + ex.Message,
                                "Imagen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearInteraccionSinCambiarEstilo(Panel panel, Button botonPrincipal, string tooltip = "")
        {
            foreach (Control c in panel.Controls)
            {
                if (c is TextBox tb)
                {
                    var color = tb.BackColor;
                    tb.ReadOnly = true;
                    tb.BackColor = color;
                    tb.TabStop = false;
                    tb.Cursor = Cursors.No;
                    tb.GotFocus += (s, e) => DGListaProd.Focus();
                    tb.ShortcutsEnabled = false;
                }
                else
                {
                    c.TabStop = false;
                }
            }

            if (botonPrincipal != null)
            {
                botonPrincipal.Enabled = false;
                if (!string.IsNullOrWhiteSpace(tooltip))
                {
                    var tt = new ToolTip();
                    tt.SetToolTip(botonPrincipal, tooltip);
                }
            }

            panel.TabStop = false;
            panel.Cursor = Cursors.No;

            if (!string.IsNullOrWhiteSpace(tooltip))
            {
                var tt = new ToolTip();
                tt.SetToolTip(panel, tooltip);
                foreach (Control c in panel.Controls) tt.SetToolTip(c, tooltip);
            }

            panel.MouseDown += (s, e) => DGListaProd.Focus();
        }

        // ==== Buscar + filtrar + ordenar ====
        private void ConstruirOpcionesDeFiltros()
        {
            _reconstruyendoFiltros = true;
            try
            {
                var marcas = _cache
                    ?.Select(p => p.Marca_Producto)
                    .Where(m => !string.IsNullOrWhiteSpace(m))
                    .Select(m => m.Trim())
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(m => m, StringComparer.OrdinalIgnoreCase)
                    .ToList() ?? new List<string>();

                List<string> categorias;
                try
                {
                    categorias = _logica.ListarCategorias()
                                        ?.Select(c => c.Nombre_Categoria)
                                        .Where(n => !string.IsNullOrWhiteSpace(n))
                                        .Distinct(StringComparer.OrdinalIgnoreCase)
                                        .OrderBy(n => n, StringComparer.OrdinalIgnoreCase)
                                        .ToList() ?? new List<string>();
                }
                catch
                {
                    categorias = new List<string>();
                }

                var old = CBFiltrosProd.SelectedItem?.ToString();

                CBFiltrosProd.BeginUpdate();
                CBFiltrosProd.Items.Clear();

                CBFiltrosProd.Items.Add("Orden: A-Z");
                CBFiltrosProd.Items.Add("Orden: Z-A");
                CBFiltrosProd.Items.Add("Orden: Precio ↑");
                CBFiltrosProd.Items.Add("Orden: Precio ↓");
                CBFiltrosProd.Items.Add("Orden: Stock ↑");
                CBFiltrosProd.Items.Add("Orden: Stock ↓");

                CBFiltrosProd.Items.Add("------------------------");

                CBFiltrosProd.Items.Add("Categoría: Todas");
                foreach (var c in categorias)
                    CBFiltrosProd.Items.Add($"Categoría: {c}");

                CBFiltrosProd.Items.Add("------------------------");

                CBFiltrosProd.Items.Add("Marca: Todas");
                foreach (var m in marcas)
                    CBFiltrosProd.Items.Add($"Marca: {m}");

                CBFiltrosProd.EndUpdate();

                if (CBFiltrosProd.Items.Count > 0)
                {
                    if (old != null && CBFiltrosProd.Items.Contains(old))
                        CBFiltrosProd.SelectedItem = old;
                    else
                        CBFiltrosProd.SelectedIndex = 0;
                }
            }
            finally
            {
                _reconstruyendoFiltros = false;
            }
        }

        private void FiltroSeleccionadoCambio()
        {
            if (_reconstruyendoFiltros) return;

            var sel = CBFiltrosProd.SelectedItem?.ToString() ?? "";
            if (sel.StartsWith("Orden:"))
                _ordenSel = sel.Replace("Orden:", "").Trim();
            else if (sel.StartsWith("Categoría:"))
                _categoriaSel = sel.Replace("Categoría:", "").Trim();
            else if (sel.StartsWith("Marca:"))
                _marcaSel = sel.Replace("Marca:", "").Trim();

            AplicarBusquedaYFiltros();
        }

        private void DebounceAplicar(int ms = 160)
        {
            if (_debounceTimer == null)
            {
                _debounceTimer = new System.Windows.Forms.Timer();
                _debounceTimer.Interval = ms;
                _debounceTimer.Tick += (_, __) =>
                {
                    _debounceTimer.Stop();
                    AplicarBusquedaYFiltros();
                };
            }
            _debounceTimer.Stop();
            _debounceTimer.Interval = ms;
            _debounceTimer.Start();
        }

        private void AplicarBusquedaYFiltros()
        {
            if (_cache == null) return;

            string texto = (TBBuscarProd.Text ?? "").Trim();
            IEnumerable<Producto> q = _cache;

            if (!string.IsNullOrEmpty(texto))
            {
                var lower = texto.ToLowerInvariant();

                if (lower.StartsWith("id:"))
                {
                    var raw = texto.Substring(3).Trim();
                    if (int.TryParse(raw, out int idBuscado))
                        q = q.Where(p => p.id_Producto == idBuscado);
                    else
                        q = Enumerable.Empty<Producto>();
                }
                else if (lower.StartsWith("marca:"))
                {
                    var raw = texto.Substring(6).Trim();
                    if (!string.IsNullOrEmpty(raw))
                        q = q.Where(p => !string.IsNullOrEmpty(p.Marca_Producto) &&
                                         p.Marca_Producto.IndexOf(raw, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else if (lower.StartsWith("nombre:"))
                {
                    var raw = texto.Substring(7).Trim();
                    if (!string.IsNullOrEmpty(raw))
                        q = q.Where(p => !string.IsNullOrEmpty(p.Nombre_Producto) &&
                                         p.Nombre_Producto.IndexOf(raw, StringComparison.OrdinalIgnoreCase) >= 0);
                }
                else
                {
                    if (Regex.IsMatch(texto, @"^\d+$"))
                    {
                        if (int.TryParse(texto, out int id))
                            q = q.Where(p => p.id_Producto == id);
                        else
                            q = Enumerable.Empty<Producto>();
                    }
                    else
                    {
                        q = q.Where(p =>
                            (!string.IsNullOrEmpty(p.Nombre_Producto) &&
                             p.Nombre_Producto.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                         || (!string.IsNullOrEmpty(p.Marca_Producto) &&
                             p.Marca_Producto.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0));
                    }
                }
            }

            if (!string.Equals(_categoriaSel, "Todas", StringComparison.OrdinalIgnoreCase))
                q = q.Where(p => string.Equals(p.Categoria_Nombre, _categoriaSel, StringComparison.OrdinalIgnoreCase));

            if (!string.Equals(_marcaSel, "Todas", StringComparison.OrdinalIgnoreCase))
                q = q.Where(p => string.Equals(p.Marca_Producto, _marcaSel, StringComparison.OrdinalIgnoreCase));

            q = _ordenSel switch
            {
                "Z-A" => q.OrderByDescending(p => p.Nombre_Producto),
                "Precio ↓" => q.OrderBy(p => p.Precio_Unitario_Producto),
                "Precio ↑" => q.OrderByDescending(p => p.Precio_Unitario_Producto),
                "Stock ↓" => q.OrderBy(p => p.Stock_Producto),
                "Stock ↑" => q.OrderByDescending(p => p.Stock_Producto),
                _ => q.OrderBy(p => p.Nombre_Producto)
            };

            RefrescarGrilla(q.ToList());
        }

        private void RefrescarGrilla(List<Producto> lista)
        {
            DGListaProd.Rows.Clear();

            foreach (var p in lista)
            {
                int r = DGListaProd.Rows.Add();
                var row = DGListaProd.Rows[r];

                if (!DGListaProd.Columns.Contains("colId"))
                {
                    var colId = new DataGridViewTextBoxColumn
                    {
                        Name = "colId",
                        HeaderText = "Id",
                        Visible = false
                    };
                    DGListaProd.Columns.Insert(0, colId);
                }

                row.Cells["colId"].Value = p.id_Producto;

                var rutaBD = p.Imagen_Producto;
                if (!string.IsNullOrWhiteSpace(rutaBD))
                {
                    var full = ResolverRutaCompletaDesdeBD(rutaBD);
                    row.Cells["colImagen"].Value = File.Exists(full) ? CargarImagenSinLock(full) : null;
                }
                else row.Cells["colImagen"].Value = null;

                row.Cells["colNombre"].Value = p.Nombre_Producto;
                row.Cells["colMarca"].Value = p.Marca_Producto;
                row.Cells["colMaterial"].Value = p.Material_Producto;
                row.Cells["colDesc"].Value = p.Descripcion_Producto;
                row.Cells["colEstado"].Value = p.Estado_Producto ? "Activo" : "Inactivo";
                row.Cells["colStock"].Value = p.Stock_Producto;
                row.Cells["colPrecio"].Value = p.Precio_Unitario_Producto;

                if (DGListaProd.Columns.Contains("colCategoria"))
                    row.Cells["colCategoria"].Value = p.Categoria_Nombre;

                SetAccionSegunEstado(row);
            }
        }
    }
}
