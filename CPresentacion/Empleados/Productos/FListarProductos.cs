using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurenPadelStore.CPresentacion.Empleados.Productos
{
    public partial class FListarProductos : Form
    {
        public FListarProductos()
        {
            InitializeComponent();
            CargarProductoDePrueba();

        }


        private void CargarProductoDePrueba()
        {
            // Crear un Bitmap desde un archivo o recurso
            Image img = Image.FromFile(@"C:\Proyecto Taller II\img\bullpadelEliteWoman.png");

            // Agregar fila a DataGridView
            DGListaProd.Rows.Add(
                img,               // colImagen
                "Elite Woman",     // Nombre
                "BullPadel",       // Marca
                "Goma Eva",        // Material
                "Descripción de prueba", // Descripcion
                32,                // Stock
                365000.50,            // Precio
                "Editar",          // Botón editar
                "Eliminar"         // Botón eliminar
            );
        }

        private void BAgregarProducto_Click(object sender, EventArgs e)
        {
            // ---- Validar campos obligatorios ----
            if (string.IsNullOrWhiteSpace(TBNombreP.Text) ||
                string.IsNullOrWhiteSpace(TBDescP.Text) ||
                string.IsNullOrWhiteSpace(TBMarcaP.Text) ||
                string.IsNullOrWhiteSpace(TBMaterialP.Text) ||
                string.IsNullOrWhiteSpace(TBPrecioP.Text) ||
                string.IsNullOrWhiteSpace(TBStockP.Text))
            {
                MessageBox.Show("Por favor, completá todos los campos obligatorios.",
                                "Campos incompletos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // ---- Validar solo letras en nombre ----
            var soloLetras = new Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$");
            if (!soloLetras.IsMatch(TBNombreP.Text))
            {
                MessageBox.Show("El nombre solo puede contener letras.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBNombreP.Focus();
                return;
            }

            // ---- Validar campos que aceptan letras y números (solo evitar caracteres raros) ----
            var letrasNumeros = new Regex(@"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s.,-]*$");
            if (!letrasNumeros.IsMatch(TBDescP.Text))
            {
                MessageBox.Show("La descripción contiene caracteres inválidos.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBDescP.Focus();
                return;
            }
            if (!letrasNumeros.IsMatch(TBMarcaP.Text))
            {
                MessageBox.Show("La marca contiene caracteres inválidos.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBMarcaP.Focus();
                return;
            }
            if (!letrasNumeros.IsMatch(TBMaterialP.Text))
            {
                MessageBox.Show("El material contiene caracteres inválidos.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBMaterialP.Focus();
                return;
            }

            // ---- Precio y Stock: solo números y > 0 ----
            if (!decimal.TryParse(TBPrecioP.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número mayor a 0.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBPrecioP.Focus();
                return;
            }

            if (!int.TryParse(TBStockP.Text, out int stock) || stock <= 0)
            {
                MessageBox.Show("El stock debe ser un número entero mayor a 0.",
                                "Dato inválido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                TBStockP.Focus();
                return;
            }

            // ---- “Guardar” (simulado) ----
            MessageBox.Show("Producto agregado correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            LimpiarCampos();
            TBNombreP.Focus();


        }

        private void TBPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite dígitos, control (borrar) y coma/punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;
        }

        private void TBStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void LimpiarCampos()
        {
            TBNombreP.Clear();
            TBDescP.Clear();
            TBMarcaP.Clear();
            TBMaterialP.Clear();
            TBPrecioP.Clear();
            TBStockP.Clear();
            // Si tenés un PictureBox para la imagen, no se toca.
        }
    }
}

