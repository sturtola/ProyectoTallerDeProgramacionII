using AurenPadelStore.CEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace AurenPadelStore.CDatos
{
    public class VentaDatos
    {
        private readonly ProductoDatos _prodDatos = new ProductoDatos();
        
        public void InsertarVentaConItems(Venta venta, List<ItemVenta> items)
        {
            using var cn = Conexion.ObtenerConexion();
            cn.Open();
            using var tx = cn.BeginTransaction();

            try
            {
                // 1) Insert Venta (cabecera)
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

                // 2) Insert Detalle_Venta (uno por cabecera)
                int idDetalle;
                using (var cmd = new SqlCommand(@"
INSERT INTO Detalle_Venta (id_Venta)
OUTPUT INSERTED.id_Detalle_Venta
VALUES (@idv);", cn, tx))
                {
                    cmd.Parameters.Add("@idv", SqlDbType.Int).Value = idVenta;
                    idDetalle = (int)cmd.ExecuteScalar();
                }

                // 3) Items + Descuento de stock (todo dentro de la misma transacción)
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
