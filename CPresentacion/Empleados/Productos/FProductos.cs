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
        private Panel _scrollHost;
        private readonly Size _designContentSize = new Size(1334, 659);

        private readonly ProductoLogica _logica = new ProductoLogica();
        private List<Producto> _cache = new List<Producto>();
        private bool _modoEdicion = false;
        private int? _idProductoEdicion = null;

        private readonly CultureInfo _esAR = new CultureInfo("es-AR");

        // Ruta relativa guardada en BD (p.ej. "Resources\\foto.png")
        private string _imagenSeleccionadaPathRelativa = null;

        public FProductos()
        {
            InitializeComponent();

            // Eventos de grilla
            DGListaProd.CellContentClick += DGListaProd_CellContentClick;
            DGListaProd.RowsAdded += (s, e) =>
            {
                for (int i = 0; i < e.RowCount; i++)
                    SetAccionSegunEstado(DGListaProd.Rows[e.RowIndex + i]);
            };
            DGListaProd.CellMouseMove += DGListaProd_CellMouseMove;
            DGListaProd.CellMouseLeave += (s, e) => DGListaProd.Cursor = Cursors.Default;
            DGListaProd.CellFormatting += DGListaProd_CellFormatting;
            DGListaProd.CellToolTipTextNeeded += DGListaProd_CellToolTipTextNeeded;

            // Scroll
            PrepararScrollHost();
            this.Resize += (_, __) => UpdateScrollbars();

            // Carga
            this.Load += FProductos_Load;
            BAgregarProducto.Click += BAgregarProducto_Click;

            // Imagen
            BExaminarImg.Click += BExaminarImg_Click;
            PBImagenP.SizeMode = PictureBoxSizeMode.Zoom;

            // Botón cancelar (si existe en el diseño)
            if (this.Controls.Find("BCancelarProducto", true).Length > 0)
            {
                var btn = (Button)this.Controls.Find("BCancelarProducto", true)[0];
                btn.Click += (s, e) => CancelarEdicionYLimpiar();
            }

            // Validaciones
            TBPrecioP.KeyPress += TBPrecio_KeyPress;
            TBStockP.KeyPress += TBStock_KeyPress;
        }

        // ===== Carga inicial =====
        private void FProductos_Load(object sender, EventArgs e)
        {
            if (SesionActual.Rol != null &&
                SesionActual.Rol.Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                BloquearInteraccionSinCambiarEstilo(PAgregarProducto, BAgregarProducto,
                    "No tiene permitido realizar esta acción.");
            }

            CargarCategorias();
            CargarDesdeBD();
            _scrollHost.AutoScrollPosition = Point.Empty;
        }

        // ===== Categorías =====
        private void CargarCategorias()
        {
            try
            {
                var cats = _logica.ListarCategorias();
                CBCategoriaP.DataSource = null;
                CBCategoriaP.DataSource = cats;
                if (CBCategoriaP.Items.Count > 0) CBCategoriaP.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron obtener las categorías: " + ex.Message,
                                "Categorías", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBCategoriaP.DataSource = new[] { "Mujer", "Hombre", "Accesorios" };
            }
        }

        // ===== Scroll =====
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

        // ===== Cargar productos =====
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

                DGListaProd.Rows.Clear();

                foreach (var p in _cache)
                {
                    int r = DGListaProd.Rows.Add();
                    var row = DGListaProd.Rows[r];

                    // Id oculto
                    row.Cells["colId"].Value = p.id_Producto;

                    // Imagen
                    var rutaBD = p.Imagen_Producto;
                    if (!string.IsNullOrWhiteSpace(rutaBD))
                    {
                        var full = ResolverRutaCompletaDesdeBD(rutaBD);
                        row.Cells["colImagen"].Value = File.Exists(full) ? CargarImagenSinLock(full) : null;
                    }
                    else row.Cells["colImagen"].Value = null;

                    // Campos visibles
                    row.Cells["colNombre"].Value = p.Nombre_Producto;
                    row.Cells["colMarca"].Value = p.Marca_Producto;
                    row.Cells["colMaterial"].Value = p.Material_Producto;
                    row.Cells["colDesc"].Value = p.Descripcion_Producto;
                    row.Cells["colEstado"].Value = p.Estado_Producto ? "Activo" : "Inactivo";
                    row.Cells["colStock"].Value = p.Stock_Producto;
                    row.Cells["colPrecio"].Value = p.Precio_Unitario_Producto;

                    SetAccionSegunEstado(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== Formato de precio =====
        private void DGListaProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        // ===== Tooltip de descripción =====
        private void DGListaProd_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var col = DGListaProd.Columns[e.ColumnIndex];
                if (col.Name == "colDesc")
                {
                    var value = DGListaProd.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (value != null)
                        e.ToolTipText = value.ToString();
                }
            }
        }

        // ===== Estado / Acción =====
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

        // ===== Click en grilla =====
        private void DGListaProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var colName = DGListaProd.Columns[e.ColumnIndex].Name;
            var row = DGListaProd.Rows[e.RowIndex];

            // --- Activar/Inactivar ---
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
                    // Cambia en BD
                    _logica.CambiarEstado(id, !actualmenteActivo, SesionActual.Rol);

                    // Actualiza cache
                    var pCache = _cache.FirstOrDefault(x => x.id_Producto == id);
                    if (pCache != null) pCache.Estado_Producto = !actualmenteActivo;

                    // Actualiza grilla
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

            // --- Editar ---
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
                if (!string.IsNullOrWhiteSpace(p.Categoria_Producto))
                    CBCategoriaP.SelectedItem = p.Categoria_Producto;

                _imagenSeleccionadaPathRelativa = p.Imagen_Producto;
                MostrarEnPictureBoxDesdeBD(_imagenSeleccionadaPathRelativa);

                _modoEdicion = true;
                _idProductoEdicion = id;
                BAgregarProducto.Text = "Guardar Edición";
            }
        }

        // ===== Agregar / Guardar =====
        private void BAgregarProducto_Click(object sender, EventArgs e)
        {
            // Validaciones mínimas
            if (string.IsNullOrWhiteSpace(TBNombreP.Text) ||
                string.IsNullOrWhiteSpace(TBDescP.Text) ||
                string.IsNullOrWhiteSpace(TBMarcaP.Text) ||
                string.IsNullOrWhiteSpace(TBMaterialP.Text) ||
                string.IsNullOrWhiteSpace(TBPrecioP.Text) ||
                string.IsNullOrWhiteSpace(TBStockP.Text))
            {
                MessageBox.Show("Por favor, completá todos los campos.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryParsePrecio(TBPrecioP.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio debe tener formato válido.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(TBStockP.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Texto de confirmación
            // --- Confirmación (Yes / No / Cancel) ---
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

            // Cancelar: limpiar y salir
            if (dr == DialogResult.Cancel)
            {
                CancelarEdicionYLimpiar();
                return;
            }

            // No: simplemente salir sin hacer nada
            if (dr == DialogResult.No)
            {
                return;
            }

            // Sí: continúa con el flujo de guardar (lo que ya tenés debajo)

            try
            {
                if (_modoEdicion && _idProductoEdicion.HasValue)
                {
                    // Tomo el existente (evita crear uno nuevo y preserva campos no editables)
                    var p = _cache.FirstOrDefault(x => x.id_Producto == _idProductoEdicion.Value);
                    if (p == null) p = new Producto { id_Producto = _idProductoEdicion.Value };

                    p.Nombre_Producto = TBNombreP.Text.Trim();
                    p.Descripcion_Producto = TBDescP.Text.Trim();
                    p.Marca_Producto = TBMarcaP.Text.Trim();
                    p.Material_Producto = TBMaterialP.Text.Trim();
                    p.Stock_Producto = stock;
                    p.Precio_Unitario_Producto = precio;
                    p.Categoria_Producto = CBCategoriaP.SelectedItem?.ToString() ?? p.Categoria_Producto;

                    // Si no cambiaste la imagen, queda la que tenía
                    if (!string.IsNullOrWhiteSpace(_imagenSeleccionadaPathRelativa))
                        p.Imagen_Producto = _imagenSeleccionadaPathRelativa;

                    // Estado queda como está en BD
                    // p.Estado_Producto (no lo tocamos acá)

                    _logica.Actualizar(p);

                    // Actualizo la fila visible sin recargar todo si querés
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
                }
                else
                {
                    // Alta
                    var p = new Producto
                    {
                        Nombre_Producto = TBNombreP.Text.Trim(),
                        Descripcion_Producto = TBDescP.Text.Trim(),
                        Marca_Producto = TBMarcaP.Text.Trim(),
                        Material_Producto = TBMaterialP.Text.Trim(),
                        Stock_Producto = stock,
                        Precio_Unitario_Producto = precio,
                        Categoria_Producto = CBCategoriaP.SelectedItem?.ToString() ?? "Accesorios",
                        Imagen_Producto = _imagenSeleccionadaPathRelativa,
                        Estado_Producto = true // por defecto activo
                    };

                    _logica.Registrar(p);
                    MessageBox.Show("Producto agregado correctamente.", "OK",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargo para verlo (o podrías añadir la fila manualmente)
                    CargarDesdeBD();
                }

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

        // ===== Validaciones =====
        private void TBPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void TBStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private bool TryParsePrecio(string input, out decimal value)
        {
            input = (input ?? "").Trim();
            var normalized = input.Replace(".", "").Replace(',', '.');
            return decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
        }

        private void LimpiarCampos()
        {
            TBNombreP.Clear();
            TBDescP.Clear();
            TBMarcaP.Clear();
            TBMaterialP.Clear();
            TBPrecioP.Clear();
            TBStockP.Clear();
            if (CBCategoriaP.Items.Count > 0) CBCategoriaP.SelectedIndex = 0;

            _imagenSeleccionadaPathRelativa = null;
            PBImagenP.Image?.Dispose();
            PBImagenP.Image = null;
        }

        // ===== IMÁGENES =====
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

        private void BExaminarImg_Click(object sender, EventArgs e)
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

        // === Bloquear panel si el rol no puede editar ===
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

        // === Cursor mano sobre botón de acción ===
        private void DGListaProd_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (DGListaProd.Columns[e.ColumnIndex].Name == "colAccion")
                DGListaProd.Cursor = Cursors.Hand;
            else
                DGListaProd.Cursor = Cursors.Default;
        }
    }
}
