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

        public List<Producto> ObtenerTodos()
        {
            var lista = new List<Producto>();
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                SELECT id_Producto, Nombre_Producto, Descripcion_Producto, Marca_Producto, Material_Producto,
                       Stock_Producto, Imagen_Producto, Categoria_Producto, Precio_Unitario_Producto, Estado_Producto
                FROM dbo.Producto
                ORDER BY Nombre_Producto;", cn);
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
                    Categoria_Producto = dr.GetString(7),
                    Precio_Unitario_Producto = dr.GetDecimal(8),
                    Estado_Producto = dr.GetBoolean(9)
                });
            }
            return lista;
        }

        // using System.Collections.Generic; using Microsoft.Data.SqlClient;
        public List<string> ObtenerCategorias()
        {
            var cats = new List<string>();
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(
                "SELECT DISTINCT Categoria_Producto FROM dbo.Producto WHERE Categoria_Producto IS NOT NULL ORDER BY 1;", cn);
            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read()) cats.Add(dr.GetString(0));
            return cats;
        }


        public void Insertar(Producto p)
        {
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                INSERT INTO dbo.Producto
                (Nombre_Producto, Descripcion_Producto, Marca_Producto, Material_Producto,
                 Stock_Producto, Imagen_Producto, Categoria_Producto, Precio_Unitario_Producto, Estado_Producto)
                VALUES (@nom,@desc,@marca,@mat,@stock,@img,@cat,@precio,@estado);", cn);

            cmd.Parameters.Add("@nom", System.Data.SqlDbType.NVarChar, 150).Value = p.Nombre_Producto;
            cmd.Parameters.Add("@desc", System.Data.SqlDbType.NVarChar, 300).Value = p.Descripcion_Producto;
            cmd.Parameters.Add("@marca", System.Data.SqlDbType.NVarChar, 50).Value = p.Marca_Producto;
            cmd.Parameters.Add("@mat", System.Data.SqlDbType.NVarChar, 100).Value = p.Material_Producto;
            cmd.Parameters.Add("@stock", System.Data.SqlDbType.Int).Value = p.Stock_Producto;
            cmd.Parameters.Add("@img", System.Data.SqlDbType.NVarChar, 300).Value = p.Imagen_Producto ?? "";
            cmd.Parameters.Add("@cat", System.Data.SqlDbType.NVarChar, 200).Value = p.Categoria_Producto;
            cmd.Parameters.Add("@precio", System.Data.SqlDbType.Decimal).Value = p.Precio_Unitario_Producto;
            cmd.Parameters["@precio"].Precision = 12; cmd.Parameters["@precio"].Scale = 2;
            cmd.Parameters.Add("@estado", System.Data.SqlDbType.Bit).Value = p.Estado_Producto;

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
                       Categoria_Producto=@cat,
                       Precio_Unitario_Producto=@precio
                 WHERE id_Producto=@id;", cn);

            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = p.id_Producto;
            cmd.Parameters.Add("@nom", System.Data.SqlDbType.NVarChar, 150).Value = p.Nombre_Producto;
            cmd.Parameters.Add("@desc", System.Data.SqlDbType.NVarChar, 300).Value = p.Descripcion_Producto;
            cmd.Parameters.Add("@marca", System.Data.SqlDbType.NVarChar, 50).Value = p.Marca_Producto;
            cmd.Parameters.Add("@mat", System.Data.SqlDbType.NVarChar, 100).Value = p.Material_Producto;
            cmd.Parameters.Add("@stock", System.Data.SqlDbType.Int).Value = p.Stock_Producto;
            cmd.Parameters.Add("@img", System.Data.SqlDbType.NVarChar, 300).Value = p.Imagen_Producto ?? "";
            cmd.Parameters.Add("@cat", System.Data.SqlDbType.NVarChar, 200).Value = p.Categoria_Producto;
            cmd.Parameters.Add("@precio", System.Data.SqlDbType.Decimal).Value = p.Precio_Unitario_Producto;
            cmd.Parameters["@precio"].Precision = 12; cmd.Parameters["@precio"].Scale = 2;

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

        public Producto ObtenerPorId(int id)
        {
            using var cn = new SqlConnection(cs);
            using var cmd = new SqlCommand(@"
                SELECT id_Producto, Nombre_Producto, Descripcion_Producto, Marca_Producto, Material_Producto,
                       Stock_Producto, Imagen_Producto, Categoria_Producto, Precio_Unitario_Producto, Estado_Producto
                FROM dbo.Producto WHERE id_Producto=@id;", cn);
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
                Categoria_Producto = dr.GetString(7),
                Precio_Unitario_Producto = dr.GetDecimal(8),
                Estado_Producto = dr.GetBoolean(9)
            };
        }
    }
}
