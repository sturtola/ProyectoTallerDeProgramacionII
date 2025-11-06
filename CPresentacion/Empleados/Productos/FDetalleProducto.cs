using AurenPadelStore.CDatos;
using AurenPadelStore.CEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados.Productos
{
    public partial class FDetalleProducto : Form
    {
        private readonly CultureInfo _esAR = new CultureInfo("es-AR");

        // Constructor sin parámetros requerido por el diseñador de VS
        public FDetalleProducto()
        {
            InitializeComponent();
        }

        // Constructor principal que recibe el producto
        public FDetalleProducto(Producto p) : this()
        {
            if (p == null)
            {
                MessageBox.Show("No se pudo cargar la información del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Cierra si no hay producto válido
                return;
            }

            CargarDatosProducto(p);
        }

        private void CargarDatosProducto(Producto p)
        {
            try
            {
                // --- Textos ---
                // Usamos el operador null-coalescing (??) para valores por defecto seguros
                LNombre.Text = p.Nombre_Producto ?? "Sin Nombre";
                LMarca.Text = $"Marca: {p.Marca_Producto ?? "No especificada"}";
                LMaterial.Text = $"Material: {p.Material_Producto ?? "No especificado"}";
                LPrecio.Text = $"Precio: {p.Precio_Unitario_Producto.ToString("C2", _esAR)}";
                LStock.Text = $"Stock: {p.Stock_Producto}";
                TDescripcion.Text = p.Descripcion_Producto ?? "Sin descripción disponible.";

                // --- Categoría ---
                string categoriaNombre = ObtenerNombreCategoria(p.id_Categoria);
                LCategoria.Text = $"Categoría: {categoriaNombre}";

                // --- Imagen ---
                CargarImagenSegura(p.Imagen_Producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerNombreCategoria(int idCategoria)
        {
            // Si el ID es inválido, retornamos rápido
            if (idCategoria <= 0) return "(Sin categoría asignada)";

            try
            {
                using (var cn = Conexion.ObtenerConexion())
                {
                    cn.Open();
                    // Consulta parametrizada simple y eficiente
                    using (var cmd = new SqlCommand("SELECT Nombre_Categoria FROM Categoria WHERE id_Categoria = @id", cn))
                    {
                        cmd.Parameters.AddWithValue("@id", idCategoria);
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null && resultado != DBNull.Value)
                        {
                            return resultado.ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                // En producción podrías loguear el error real aquí
                return "(Error al cargar categoría)";
            }

            return "(Categoría no encontrada)";
        }

        private void CargarImagenSegura(string rutaImagen)
        {
            // Limpiar imagen previa si existe
            if (PBImagen.Image != null)
            {
                PBImagen.Image.Dispose();
                PBImagen.Image = null;
            }

            try
            {
                // 1. Intentar cargar desde archivo si la ruta es válida
                if (!string.IsNullOrWhiteSpace(rutaImagen) && File.Exists(rutaImagen))
                {
                    // Usar FileStream + MemoryStream evita bloquear el archivo en disco
                    using (var fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read))
                    {
                        var ms = new MemoryStream();
                        fs.CopyTo(ms);
                        ms.Position = 0; // Resetear posición para leer desde el inicio
                        PBImagen.Image = Image.FromStream(ms);
                    }
                    PBImagen.SizeMode = PictureBoxSizeMode.Zoom; // Ajuste recomendado
                    return;
                }
            }
            catch (Exception) { /* Fallo silencioso al cargar archivo, pasamos al fallback */ }

            // 2. Intentar cargar imagen por defecto desde Resources
            try
            {
                // Asegúrate que 'imagen_no_disponible' existe en tus recursos (Properties.Resources)
                // Si no existe, esta línea lanzará excepción y pasaremos al paso 3.
                var imgFallback = Properties.Resources.imagen_no_disponible;
                if (imgFallback != null)
                {
                    PBImagen.Image = imgFallback;
                    PBImagen.SizeMode = PictureBoxSizeMode.Zoom;
                    return;
                }
            }
            catch (Exception) { /* Fallo al acceder a Resources, pasamos al último recurso */ }

            // 3. Último recurso: mostrar un placeholder visual simple
            PBImagen.Image = null;
            PBImagen.BackColor = Color.LightGray; // Indicador visual de que no hay imagen
        }

        // Evento opcional para cerrar con Escape (buena práctica en diálogos de detalle)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}