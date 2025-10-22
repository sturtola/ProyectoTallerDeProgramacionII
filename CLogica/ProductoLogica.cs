using System;
using System.Collections.Generic;
using AurenPadelStore.CDatos;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CLogica
{
    public class ProductoLogica
    {
        private readonly ProductoDatos datos = new ProductoDatos();

        private static bool Texto(string s) => !string.IsNullOrWhiteSpace(s);

        public List<Producto> Listar() => datos.ObtenerTodos();
        public Producto Obtener(int id) => datos.ObtenerPorId(id);

        // Para combo/filtros
        public List<CategoriaDTO> ListarCategorias() => datos.ListarCategorias();

        private int ResolverIdCategoriaObligatoria(string nombreCategoria)
        {
            if (!Texto(nombreCategoria))
                throw new Exception("La categoría es obligatoria.");
            return datos.ObtenerOCrearCategoria(nombreCategoria.Trim());
        }

        // OJO: NO duplicamos validaciones de UI aquí para evitar mensajes dobles.
        public void Registrar(Producto p, string nombreCategoriaEscrito)
        {
            p.id_Categoria = ResolverIdCategoriaObligatoria(nombreCategoriaEscrito);
            datos.Insertar(p);
        }

        public void Actualizar(Producto p, string nombreCategoriaEscrito)
        {
            if (p.id_Producto <= 0) throw new Exception("Producto inválido.");

            p.id_Categoria = ResolverIdCategoriaObligatoria(nombreCategoriaEscrito);
            datos.Actualizar(p);
        }

        public void CambiarEstado(int idProducto, bool activar, string rol)
        {
            if (!string.Equals(rol, "Gerente", StringComparison.OrdinalIgnoreCase))
                throw new Exception("Solo un Gerente puede activar/inactivar productos.");
            datos.CambiarEstado(idProducto, activar);
        }
    }
}
