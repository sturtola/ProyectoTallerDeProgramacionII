using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CDatos
{
    public class ProductoDatos
    {
        // =========================
        // Helpers de mapeo (Sin Cambios)
        // =========================
        #region Mapeo
        private static Producto MapProducto(SqlDataReader dr)
        {
            var p = new Producto
            {
                id_Producto = dr.GetInt32(dr.GetOrdinal("id_Producto")),
                Nombre_Producto = dr.GetString(dr.GetOrdinal("Nombre_Producto")),
                Descripcion_Producto = dr.GetString(dr.GetOrdinal("Descripcion_Producto")),
                Marca_Producto = dr.GetString(dr.GetOrdinal("Marca_Producto")),
                Material_Producto = dr.GetString(dr.GetOrdinal("Material_Producto")),
                Precio_Unitario_Producto = dr.GetDecimal(dr.GetOrdinal("Precio_Unitario_Producto")),
                Stock_Producto = dr.GetInt32(dr.GetOrdinal("Stock_Producto")),
                Imagen_Producto = dr.GetString(dr.GetOrdinal("Imagen_Producto")),
                Estado_Producto = dr.GetBoolean(dr.GetOrdinal("Estado_Producto")),
                id_Categoria = dr.IsDBNull(dr.GetOrdinal("id_Categoria"))
                                ? 0
                                : dr.GetInt32(dr.GetOrdinal("id_Categoria"))
            };
            return p;
        }

        private static Categoria MapCategoria(SqlDataReader dr)
        {
            return new Categoria
            {
                id_Categoria = dr.GetInt32(dr.GetOrdinal("id_Categoria")),
                Nombre_Categoria = dr.GetString(dr.GetOrdinal("Nombre_Categoria")),
            };
        }
        #endregion

        // =========================
        // STOCK (MODIFICADO)
        // =========================
        public void DescontarStock(int idProducto, int cantidad, SqlConnection cn, SqlTransaction tx)
        {
            using var cmd = new SqlCommand(@"
                UPDATE Producto
                SET Stock_Producto = Stock_Producto - @cant
                WHERE id_Producto = @id AND Stock_Producto >= @cant;", cn, tx);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idProducto;
            cmd.Parameters.Add("@cant", SqlDbType.Int).Value = cantidad;

            var rows = cmd.ExecuteNonQuery();

            // ---------- ¡CAMBIO 4: Mensaje de error mejorado! ----------
            // Si rows == 0, significa que el WHERE falló (Stock_Producto >= @cant fue falso)
            if (rows == 0)
            {
                // Este es el error que el formulario (FGenerarVenta) va a atajar y mostrar.
                throw new InvalidOperationException($"El stock para el producto ID {idProducto} ya no estaba disponible (Stock actual es menor a {cantidad}).");
            }
            // Si el error de tu captura ("dejaría en negativo") sigue saliendo,
            // significa que SÍ tienes un TRIGGER en la base de datos que está
            // causando el descuento doble, y este código C# es correcto.
        }

        // =========================
        // CRUD Producto (Con Try...Catch)
        // =========================

        public int Insertar(Producto p)
        {
            try
            {
                using var cn = Conexion.ObtenerConexion();
                using var cmd = new SqlCommand(@"
                    INSERT INTO Producto
                    (Nombre_Producto, Descripcion_Producto, Marca_Producto, Material_Producto, Precio_Unitario_Producto, Stock_Producto, Imagen_Producto, Estado_Producto, id_Categoria)
                    OUTPUT INSERTED.id_Producto
                    VALUES (@nom, @desc, @mar, @mat, @pre, @stk, @img, @est, @cat);", cn);

                cmd.Parameters.Add("@nom", SqlDbType.NVarChar, 100).Value = p.Nombre_Producto ?? string.Empty;
                cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 300).Value = p.Descripcion_Producto ?? string.Empty;
                cmd.Parameters.Add("@mar", SqlDbType.NVarChar, 100).Value = p.Marca_Producto ?? string.Empty;
                cmd.Parameters.Add("@mat", SqlDbType.NVarChar, 100).Value = (object)p.Material_Producto ?? DBNull.Value;
                var pp = cmd.Parameters.Add("@pre", SqlDbType.Decimal);
                pp.Precision = 12; pp.Scale = 2; pp.Value = p.Precio_Unitario_Producto;
                cmd.Parameters.Add("@stk", SqlDbType.Int).Value = p.Stock_Producto;
                cmd.Parameters.Add("@img", SqlDbType.NVarChar, 300).Value = (object)p.Imagen_Producto ?? DBNull.Value;
                cmd.Parameters.Add("@est", SqlDbType.Bit).Value = p.Estado_Producto;
                if (p.id_Categoria <= 0)
                    cmd.Parameters.Add("@cat", SqlDbType.Int).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@cat", SqlDbType.Int).Value = p.id_Categoria;

                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el producto en la base de datos.", ex);
            }
        }

        public void Actualizar(Producto p)
        {
            try
            {
                using var cn = Conexion.ObtenerConexion();
                using var cmd = new SqlCommand(@"
                    UPDATE Producto
                    SET Nombre_Producto = @nom,
                        Descripcion_Producto = @desc,
                        Marca_Producto = @mar,
                        Material_Producto = @mat,
                        Precio_Unitario_Producto = @pre,
                        Stock_Producto = @stk,
                        Imagen_Producto = @img,
                        Estado_Producto = @est,
                        id_Categoria = @cat
                    WHERE id_Producto = @id;", cn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = p.id_Producto;
                cmd.Parameters.Add("@nom", SqlDbType.NVarChar, 100).Value = p.Nombre_Producto ?? string.Empty;
                cmd.Parameters.Add("@desc", SqlDbType.NVarChar, 300).Value = p.Descripcion_Producto ?? string.Empty;
                cmd.Parameters.Add("@mar", SqlDbType.NVarChar, 100).Value = p.Marca_Producto ?? string.Empty;
                cmd.Parameters.Add("@mat", SqlDbType.NVarChar, 100).Value = (object)p.Material_Producto ?? DBNull.Value;
                var pp = cmd.Parameters.Add("@pre", SqlDbType.Decimal);
                pp.Precision = 12; pp.Scale = 2; pp.Value = p.Precio_Unitario_Producto;
                cmd.Parameters.Add("@stk", SqlDbType.Int).Value = p.Stock_Producto;
                cmd.Parameters.Add("@img", SqlDbType.NVarChar, 300).Value = (object)p.Imagen_Producto ?? DBNull.Value;
                cmd.Parameters.Add("@est", SqlDbType.Bit).Value = p.Estado_Producto;
                if (p.id_Categoria <= 0)
                    cmd.Parameters.Add("@cat", SqlDbType.Int).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@cat", SqlDbType.Int).Value = p.id_Categoria;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el producto.", ex);
            }
        }

        public void CambiarEstado(int idProducto, bool estado)
        {
            try
            {
                using var cn = Conexion.ObtenerConexion();
                using var cmd = new SqlCommand(@"
                    UPDATE Producto
                    SET Estado_Producto = @est
                    WHERE id_Producto = @id;", cn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idProducto;
                cmd.Parameters.Add("@est", SqlDbType.Bit).Value = estado;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado del producto.", ex);
            }
        }

        public Producto? ObtenerPorId(int idProducto)
        {
            try
            {
                using var cn = Conexion.ObtenerConexion();
                using var cmd = new SqlCommand(@"
                    SELECT p.id_Producto, p.Nombre_Producto, p.Descripcion_Producto, p.Marca_Producto, p.Material_Producto,
                           p.Precio_Unitario_Producto, p.Stock_Producto, p.Imagen_Producto, p.Estado_Producto, p.id_Categoria
                    FROM Producto p
                    WHERE p.id_Producto = @id;", cn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idProducto;
                cn.Open();

                using var dr = cmd.ExecuteReader();
                if (!dr.Read()) return null;
                return MapProducto(dr);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto por ID.", ex);
            }
        }

        public List<Producto> ObtenerTodos()
        {
            try
            {
                var lista = new List<Producto>();
                using var cn = Conexion.ObtenerConexion();
                using var cmd = new SqlCommand(@"
                    SELECT p.id_Producto, p.Nombre_Producto, p.Descripcion_Producto, p.Marca_Producto, p.Material_Producto,
                           p.Precio_Unitario_Producto, p.Stock_Producto, p.Imagen_Producto, p.Estado_Producto, p.id_Categoria
                    FROM Producto p
                    ORDER BY p.Nombre_Producto, p.Marca_Producto;", cn);

                cn.Open();
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                    lista.Add(MapProducto(dr));
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los productos.", ex);
            }
        }

        public List<Producto> ObtenerTodosActivos()
        {
            try
            {
                var lista = new List<Producto>();
                using var cn = Conexion.ObtenerConexion();
                using var cmd = new SqlCommand(@"
                    SELECT p.id_Producto, p.Nombre_Producto, p.Descripcion_Producto, p.Marca_Producto, p.Material_Producto,
                           p.Precio_Unitario_Producto, p.Stock_Producto, p.Imagen_Producto, p.Estado_Producto, p.id_Categoria
                    FROM Producto p
                    WHERE p.Estado_Producto = 1
                    ORDER BY p.Nombre_Producto, p.Marca_Producto;", cn);

                cn.Open();
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                    lista.Add(MapProducto(dr));
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos activos.", ex);
            }
        }

        // =========================
        // Categorías (Con Try...Catch)
        // =========================
        public List<Categoria> ListarCategorias()
        {
            try
            {
                var lista = new List<Categoria>();
                using var cn = Conexion.ObtenerConexion();
                using var cmd = new SqlCommand(@"
                    SELECT c.id_Categoria, c.Nombre_Categoria
                    FROM Categoria c
                    ORDER BY c.Nombre_Categoria;", cn);

                cn.Open();
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                    lista.Add(MapCategoria(dr));
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las categorías.", ex);
            }
        }

        public int ObtenerOCrearCategoria(string nombre, SqlConnection? cnExt = null, SqlTransaction? tx = null)
        {
            string nombreTrim = (nombre ?? string.Empty).Trim();

            int EjecutarLogica(SqlConnection cn, SqlTransaction? transaccion)
            {
                using var sel = new SqlCommand(@"
                    SELECT id_Categoria FROM Categoria WHERE LTRIM(RTRIM(Nombre_Categoria)) = @nom;", cn, transaccion);
                sel.Parameters.Add("@nom", SqlDbType.NVarChar, 100).Value = nombreTrim;

                var o = sel.ExecuteScalar();
                if (o != null && o != DBNull.Value)
                    return Convert.ToInt32(o);

                using var ins = new SqlCommand(@"
                    INSERT INTO Categoria (Nombre_Categoria)
                    OUTPUT INSERTED.id_Categoria
                    VALUES (@nom);", cn, transaccion);
                ins.Parameters.Add("@nom", SqlDbType.NVarChar, 100).Value = nombreTrim;

                return Convert.ToInt32(ins.ExecuteScalar());
            }

            try
            {
                if (cnExt is not null)
                {
                    return EjecutarLogica(cnExt, tx);
                }
                else
                {
                    using var cn = Conexion.ObtenerConexion();
                    cn.Open();
                    return EjecutarLogica(cn, null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener o crear la categoría.", ex);
            }
        }
    }
}