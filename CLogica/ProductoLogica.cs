using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AurenPadelStore.CDatos;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CLogica
{
    public class ProductoLogica
    {
        private readonly ProductoDatos datos = new ProductoDatos();

        private static bool Texto(string s) => !string.IsNullOrWhiteSpace(s);

        public List<Producto> Listar() => datos.ObtenerTodos();

        public void Registrar(Producto p)
        {
            if (!Texto(p.Nombre_Producto) || !Texto(p.Descripcion_Producto) ||
                !Texto(p.Marca_Producto) || !Texto(p.Material_Producto) ||
                !Texto(p.Categoria_Producto))
                throw new Exception("Todos los campos de texto son obligatorios.");

            if (p.Stock_Producto < 0) throw new Exception("El stock no puede ser negativo.");
            if (p.Precio_Unitario_Producto < 0) throw new Exception("El precio no puede ser negativo.");

            // (Opcional) Validar con las mismas regex que el form si querés.
            datos.Insertar(p);
        }

        public void Actualizar(Producto p)
        {
            if (p.id_Producto <= 0) throw new Exception("Producto inválido.");
            Registrar(p); // reutiliza las validaciones
        }

        public void CambiarEstado(int idProducto, bool activar, string rol)
        {
            if (!string.Equals(rol, "Gerente", StringComparison.OrdinalIgnoreCase))
                throw new Exception("Solo un Gerente puede activar/inactivar productos.");
            datos.CambiarEstado(idProducto, activar);
        }

        public List<string> ListarCategorias()
        {
            var list = datos.ObtenerCategorias() ?? new List<string>();
            if (list.Count == 0) // fallback a las admitidas por tu CHECK
                list.AddRange(new[] { "Mujer", "Hombre", "Accesorios" });
            return list;
        }


        public Producto Obtener(int id) => datos.ObtenerPorId(id);
    }
}
