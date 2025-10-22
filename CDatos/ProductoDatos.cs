using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CDatos
{
    public class ProductoDatos
    {
        private readonly string cs =
            "Server=DESKTOP-1HCDQL3;Database=AurenPadelBD;Encrypt=False;TrustServerCertificate=True;Trusted_Connection=True;";

        // ===== Productos =====

        public List<Producto> ObtenerTodos()
        {
            var lista = new List<Producto>();
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                SELECT  p.id_Producto,
                        p.Nombre_Producto,
                        p.Descripcion_Producto,
                        p.Marca_Producto,
                        p.Material_Producto,
                        p.Stock_Producto,
                        p.Imagen_Producto,
                        p.Precio_Unitario_Producto,
                        p.Estado_Producto,
                        p.id_Categoria,
                        c.Nombre_Categoria
                FROM dbo.Producto p
                INNER JOIN dbo.Categoria c ON c.id_Categoria = p.id_Categoria
                ORDER BY p.Nombre_Producto;", cn);

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Producto
                {
                    id_Producto = dr.GetInt32(0),
                    Nombre_Producto = dr.GetString(1),
                    Descripcion_Producto = dr.GetString(2),
                    Marca_Producto = dr.GetString(3),
                    Material_Producto = dr.GetString(4),
                    Stock_Producto = dr.GetInt32(5),
                    Imagen_Producto = dr.GetString(6),
                    Precio_Unitario_Producto = dr.GetDecimal(7),
                    Estado_Producto = dr.GetBoolean(8),
                    id_Categoria = dr.GetInt32(9),
                    Categoria_Nombre = dr.GetString(10)
                });
            }
            return lista;
        }

        public Producto ObtenerPorId(int id)
        {
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                SELECT  p.id_Producto,
                        p.Nombre_Producto,
                        p.Descripcion_Producto,
                        p.Marca_Producto,
                        p.Material_Producto,
                        p.Stock_Producto,
                        p.Imagen_Producto,
                        p.Precio_Unitario_Producto,
                        p.Estado_Producto,
                        p.id_Categoria,
                        c.Nombre_Categoria
                FROM dbo.Producto p
                INNER JOIN dbo.Categoria c ON c.id_Categoria = p.id_Categoria
                WHERE p.id_Producto=@id;", cn);

            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            cn.Open();
            using var dr = cmd.ExecuteReader();
            if (!dr.Read()) return null;

            return new Producto
            {
                id_Producto = dr.GetInt32(0),
                Nombre_Producto = dr.GetString(1),
                Descripcion_Producto = dr.GetString(2),
                Marca_Producto = dr.GetString(3),
                Material_Producto = dr.GetString(4),
                Stock_Producto = dr.GetInt32(5),
                Imagen_Producto = dr.GetString(6),
                Precio_Unitario_Producto = dr.GetDecimal(7),
                Estado_Producto = dr.GetBoolean(8),
                id_Categoria = dr.GetInt32(9),
                Categoria_Nombre = dr.GetString(10)
            };
        }

        public void Insertar(Producto p)
        {
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                INSERT INTO dbo.Producto
                (Nombre_Producto, Descripcion_Producto, Marca_Producto, Material_Producto,
                 Stock_Producto, Imagen_Producto, Precio_Unitario_Producto, Estado_Producto, id_Categoria)
                VALUES
                (@nom, @desc, @marca, @mat, @stock, @img, @precio, @estado, @idcat);", cn);

            cmd.Parameters.Add("@nom", System.Data.SqlDbType.NVarChar, 150).Value = p.Nombre_Producto;
            cmd.Parameters.Add("@desc", System.Data.SqlDbType.NVarChar, 300).Value = p.Descripcion_Producto;
            cmd.Parameters.Add("@marca", System.Data.SqlDbType.NVarChar, 50).Value = p.Marca_Producto;
            cmd.Parameters.Add("@mat", System.Data.SqlDbType.NVarChar, 100).Value = p.Material_Producto;
            cmd.Parameters.Add("@stock", System.Data.SqlDbType.Int).Value = p.Stock_Producto;
            cmd.Parameters.Add("@img", System.Data.SqlDbType.NVarChar, 300).Value = p.Imagen_Producto ?? "";
            cmd.Parameters.Add("@precio", System.Data.SqlDbType.Decimal).Value = p.Precio_Unitario_Producto;
            cmd.Parameters["@precio"].Precision = 12;
            cmd.Parameters["@precio"].Scale = 2;
            cmd.Parameters.Add("@estado", System.Data.SqlDbType.Bit).Value = p.Estado_Producto;
            cmd.Parameters.Add("@idcat", System.Data.SqlDbType.Int).Value = p.id_Categoria;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Producto p)
        {
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                UPDATE dbo.Producto
                   SET Nombre_Producto=@nom,
                       Descripcion_Producto=@desc,
                       Marca_Producto=@marca,
                       Material_Producto=@mat,
                       Stock_Producto=@stock,
                       Imagen_Producto=@img,
                       Precio_Unitario_Producto=@precio,
                       id_Categoria=@idcat
                 WHERE id_Producto=@id;", cn);

            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = p.id_Producto;
            cmd.Parameters.Add("@nom", System.Data.SqlDbType.NVarChar, 150).Value = p.Nombre_Producto;
            cmd.Parameters.Add("@desc", System.Data.SqlDbType.NVarChar, 300).Value = p.Descripcion_Producto;
            cmd.Parameters.Add("@marca", System.Data.SqlDbType.NVarChar, 50).Value = p.Marca_Producto;
            cmd.Parameters.Add("@mat", System.Data.SqlDbType.NVarChar, 100).Value = p.Material_Producto;
            cmd.Parameters.Add("@stock", System.Data.SqlDbType.Int).Value = p.Stock_Producto;
            cmd.Parameters.Add("@img", System.Data.SqlDbType.NVarChar, 300).Value = p.Imagen_Producto ?? "";
            cmd.Parameters.Add("@precio", System.Data.SqlDbType.Decimal).Value = p.Precio_Unitario_Producto;
            cmd.Parameters["@precio"].Precision = 12;
            cmd.Parameters["@precio"].Scale = 2;
            cmd.Parameters.Add("@idcat", System.Data.SqlDbType.Int).Value = p.id_Categoria;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public void CambiarEstado(int idProducto, bool activar)
        {
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(
                "UPDATE dbo.Producto SET Estado_Producto=@estado WHERE id_Producto=@id;", cn);

            cmd.Parameters.Add("@estado", System.Data.SqlDbType.Bit).Value = activar;
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = idProducto;

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        // ===== Categorías =====

        public List<CategoriaDTO> ListarCategorias()
        {
            var list = new List<CategoriaDTO>();
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                SELECT id_Categoria, Nombre_Categoria
                FROM dbo.Categoria
                ORDER BY Nombre_Categoria;", cn);

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(new CategoriaDTO
                {
                    Id = dr.GetInt32(0),
                    Nombre = dr.GetString(1)
                });
            }
            return list;
        }

        public int ObtenerOCrearCategoria(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("Nombre de categoría inválido.", nameof(nombre));

            int id;
            using var cn = new SqlConnection(cs);
            using var cmdSel = new SqlCommand(@"
                SELECT id_Categoria FROM dbo.Categoria WHERE UPPER(Nombre_Categoria)=UPPER(@n);", cn);
            cmdSel.Parameters.Add("@n", System.Data.SqlDbType.NVarChar, 100).Value = nombre.Trim();

            using var cmdIns = new SqlCommand(@"
                INSERT INTO dbo.Categoria (Nombre_Categoria) VALUES (@n);
                SELECT SCOPE_IDENTITY();", cn);
            cmdIns.Parameters.Add("@n", System.Data.SqlDbType.NVarChar, 100).Value = nombre.Trim();

            cn.Open();
            var r = cmdSel.ExecuteScalar();
            if (r != null && r != DBNull.Value)
            {
                id = Convert.ToInt32(r);
            }
            else
            {
                var rid = cmdIns.ExecuteScalar();
                id = Convert.ToInt32(rid);
            }
            return id;
        }
    }
}
