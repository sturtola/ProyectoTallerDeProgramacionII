using AurenPadelStore.CEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace AurenPadelStore.CDatos
{
    // ===== DTOs de factura =====
    public class FacturaItemDto
    {
        public string NombreProducto { get; set; } = "";
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Math.Round(PrecioUnitario * Cantidad, 2);
    }

    public class FacturaDto
    {
        // Cabecera
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string MetodoPago { get; set; } = "";
        public bool Envio { get; set; }
        public decimal Total { get; set; }
        public decimal Subtotal { get; set; }
        public decimal CostoEnvio { get; set; }

        // Cliente
        public string ClienteNombre { get; set; } = "";
        public string ClienteApellido { get; set; } = "";
        public int ClienteDni { get; set; }
        public string ClienteDireccion { get; set; } = "";
        public string ClienteTelefono { get; set; } = "";

        // Usuario (vendedor)
        public string UsuarioNombre { get; set; } = "";
        public string UsuarioApellido { get; set; } = "";

        // Ítems
        public List<FacturaItemDto> Items { get; set; } = new();
    }

    public class VentaListado
    {
        public int id_Venta { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public string Nombre_Cliente { get; set; } = "";
        public string Apellido_Cliente { get; set; } = "";
        public int Dni_Cliente { get; set; }
        public int CantidadProductos { get; set; }
        public decimal ImporteTotal { get; set; }
    }

    // ===== VentaDatos =====
    public class VentaDatos
    {
        private readonly ProductoDatos _prodDatos = new ProductoDatos();

        // Constante de envío fijo
        private const decimal COSTO_ENVIO_FIJO = 5000m;

        // --- Factura (cabecera + items) ---
        public FacturaDto ObtenerFacturaPorId(int idVenta)
        {
            var factura = new FacturaDto();

            using var cn = Conexion.ObtenerConexion();
            cn.Open();

            // Cabecera (y también traigo el subtotal de ítems por si querés auditar)
            using (var cmd = new SqlCommand(@"
SELECT 
    v.id_Venta,
    v.Fecha_Venta,
    v.Metodo_Pago_Venta,
    v.Envio_Paquete_Venta,
    v.Monto_Total_Venta,
    c.Nombre_Cliente, c.Apellido_Cliente, c.Dni_Cliente, c.Direccion_Cliente, c.Telefono_Cliente,
    u.Nombre_Usuario, u.Apellido_Usuario,
    ISNULL(SUM(iv.Cantidad_Item_Venta * iv.Precio_Unitario_Item_Venta), 0) AS SubtotalItems
FROM dbo.Venta v
JOIN dbo.Cliente c             ON c.id_Cliente          = v.id_Cliente
JOIN dbo.Usuario u             ON u.id_Usuario          = v.id_Usuario
LEFT JOIN dbo.Detalle_Venta dv ON dv.id_Venta           = v.id_Venta
LEFT JOIN dbo.Item_Venta iv    ON iv.id_Detalle_Venta   = dv.id_Detalle_Venta
WHERE v.id_Venta = @id
GROUP BY 
    v.id_Venta, v.Fecha_Venta, v.Metodo_Pago_Venta, v.Envio_Paquete_Venta, v.Monto_Total_Venta,
    c.Nombre_Cliente, c.Apellido_Cliente, c.Dni_Cliente, c.Direccion_Cliente, c.Telefono_Cliente,
    u.Nombre_Usuario, u.Apellido_Usuario;", cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idVenta;
                using var dr = cmd.ExecuteReader();
                if (!dr.Read())
                    throw new InvalidOperationException($"No existe la venta {idVenta}.");

                factura.IdVenta = dr.GetInt32(0);
                factura.Fecha = dr.GetDateTime(1);
                factura.MetodoPago = dr.GetString(2);
                factura.Envio = dr.GetBoolean(3);
                factura.Total = dr.GetDecimal(4);
                factura.ClienteNombre = dr.GetString(5);
                factura.ClienteApellido = dr.GetString(6);
                factura.ClienteDni = dr.GetInt32(7);
                factura.ClienteDireccion = dr.IsDBNull(8) ? "" : dr.GetString(8);
                factura.ClienteTelefono = dr.IsDBNull(9) ? "" : dr.GetString(9);
                factura.UsuarioNombre = dr.GetString(10);
                factura.UsuarioApellido = dr.GetString(11);

                var subtotalItems = dr.GetDecimal(12);

                // Regla: Total YA incluye envío si Envio = 1
                if (factura.Envio)
                {
                    factura.CostoEnvio = COSTO_ENVIO_FIJO;
                    factura.Subtotal = Math.Max(0, factura.Total - COSTO_ENVIO_FIJO);
                }
                else
                {
                    factura.CostoEnvio = 0m;
                    factura.Subtotal = factura.Total;
                }

                // (opcional) comparar con subtotalItems si querés auditar diferencias
                _ = subtotalItems;
            }

            // Ítems
            using (var cmd = new SqlCommand(@"
SELECT 
    p.Nombre_Producto,
    iv.Precio_Unitario_Item_Venta,
    iv.Cantidad_Item_Venta
FROM dbo.Detalle_Venta dv
JOIN dbo.Item_Venta iv ON iv.id_Detalle_Venta = dv.id_Detalle_Venta
JOIN dbo.Producto p    ON p.id_Producto       = iv.id_Producto
WHERE dv.id_Venta = @id
ORDER BY p.Nombre_Producto;", cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idVenta;
                using var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    factura.Items.Add(new FacturaItemDto
                    {
                        NombreProducto = dr.GetString(0),
                        PrecioUnitario = dr.GetDecimal(1),
                        Cantidad = dr.GetInt32(2)
                    });
                }
            }

            return factura;
        }

        // --- Listado por usuario (resumen) ---
        public List<VentaListado> ObtenerListadoPorUsuario(int idUsuario)
        {
            var lista = new List<VentaListado>();

            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(@"
SELECT 
    v.id_Venta,
    v.Fecha_Venta,
    c.Nombre_Cliente,
    c.Apellido_Cliente,
    c.Dni_Cliente,
    ISNULL(SUM(iv.Cantidad_Item_Venta), 0) AS CantidadProductos,
    v.Monto_Total_Venta AS ImporteTotal
FROM dbo.Venta v
JOIN dbo.Cliente c             ON c.id_Cliente          = v.id_Cliente
LEFT JOIN dbo.Detalle_Venta dv ON dv.id_Venta           = v.id_Venta
LEFT JOIN dbo.Item_Venta iv    ON iv.id_Detalle_Venta   = dv.id_Detalle_Venta
WHERE v.id_Usuario = @idUsuario
GROUP BY 
    v.id_Venta, v.Fecha_Venta, 
    c.Nombre_Cliente, c.Apellido_Cliente, c.Dni_Cliente,
    v.Monto_Total_Venta
ORDER BY v.Fecha_Venta DESC;", cn);

            cmd.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int) { Value = idUsuario });

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new VentaListado
                {
                    id_Venta = dr.GetInt32(0),
                    Fecha_Venta = dr.GetDateTime(1),
                    Nombre_Cliente = dr.GetString(2),
                    Apellido_Cliente = dr.GetString(3),
                    Dni_Cliente = dr.GetInt32(4),
                    CantidadProductos = dr.IsDBNull(5) ? 0 : dr.GetInt32(5),
                    ImporteTotal = dr.GetDecimal(6)
                });
            }

            return lista;
        }

        // --- Insert venta + detalle + ítems (con descuento de stock) ---
        public void InsertarVentaConItems(Venta venta, List<ItemVenta> items)
        {
            using var cn = Conexion.ObtenerConexion();
            cn.Open();
            using var tx = cn.BeginTransaction();

            try
            {
                // 1) Cabecera
                int idVenta;
                using (var cmd = new SqlCommand(@"
INSERT INTO Venta (id_Cliente, id_Usuario, Metodo_Pago_Venta, Envio_Paquete_Venta, Monto_Total_Venta, Fecha_Venta)
OUTPUT INSERTED.id_Venta
VALUES (@idc, @idu, @mp, @env, @tot, @fec);", cn, tx))
                {
                    cmd.Parameters.Add("@idc", SqlDbType.Int).Value = venta.id_Cliente;
                    cmd.Parameters.Add("@idu", SqlDbType.Int).Value = venta.id_Usuario;
                    cmd.Parameters.Add("@mp", SqlDbType.NVarChar, 50).Value = venta.Metodo_Pago;
                    cmd.Parameters.Add("@env", SqlDbType.Bit).Value = venta.Envio;

                    var pTot = cmd.Parameters.Add("@tot", SqlDbType.Decimal);
                    pTot.Precision = 12; pTot.Scale = 2; pTot.Value = venta.Total;

                    cmd.Parameters.Add("@fec", SqlDbType.DateTime2, 3).Value = venta.Fecha;

                    idVenta = (int)cmd.ExecuteScalar();
                }

                // 2) Detalle
                int idDetalle;
                using (var cmd = new SqlCommand(@"
INSERT INTO Detalle_Venta (id_Venta)
OUTPUT INSERTED.id_Detalle_Venta
VALUES (@idv);", cn, tx))
                {
                    cmd.Parameters.Add("@idv", SqlDbType.Int).Value = idVenta;
                    idDetalle = (int)cmd.ExecuteScalar();
                }

                // 3) Ítems + stock
                foreach (var it in items)
                {
                    _prodDatos.DescontarStock(it.id_Producto, it.Cantidad_Item_Venta, cn, tx);

                    using var cmd = new SqlCommand(@"
INSERT INTO Item_Venta (id_Producto, id_Detalle_Venta, Cantidad_Item_Venta, Precio_Unitario_Item_Venta)
VALUES (@idp, @idd, @cant, @precio);", cn, tx);
                    cmd.Parameters.Add("@idp", SqlDbType.Int).Value = it.id_Producto;
                    cmd.Parameters.Add("@idd", SqlDbType.Int).Value = idDetalle;
                    cmd.Parameters.Add("@cant", SqlDbType.Int).Value = it.Cantidad_Item_Venta;

                    var pPrecio = cmd.Parameters.Add("@precio", SqlDbType.Decimal);
                    pPrecio.Precision = 12; pPrecio.Scale = 2; pPrecio.Value = it.Precio_Unitario_Item_Venta;

                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }
    }
}
