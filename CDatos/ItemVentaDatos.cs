using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CDatos
{
    public class ItemVentaDatos
    {
        public async Task InsertarAsync(ItemVenta it, SqlConnection cn, SqlTransaction tx)
        {
            using var cmd = new SqlCommand(@"
INSERT INTO Item_Venta (id_Producto, id_Detalle_Venta, Cantidad_Item_Venta, Precio_Unitario_Item_Venta)
VALUES (@p, @d, @c, @pu);", cn, tx);

            cmd.Parameters.Add("@p", SqlDbType.Int).Value = it.id_Producto;
            cmd.Parameters.Add("@d", SqlDbType.Int).Value = it.id_Detalle_Venta;
            cmd.Parameters.Add("@c", SqlDbType.Int).Value = it.Cantidad_Item_Venta;
            var p = cmd.Parameters.Add("@pu", SqlDbType.Decimal);
            p.Precision = 12; p.Scale = 2; p.Value = it.Precio_Unitario_Item_Venta;

            await cmd.ExecuteNonQueryAsync();
        }
    }
}
