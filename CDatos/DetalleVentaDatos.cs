using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using AurenPadelStore.CEntidades;

namespace AurenPadelStore.CDatos
{
    public class DetalleVentaDatos
    {
        public async Task<int> InsertarAsync(DetalleVenta d, SqlConnection cn, SqlTransaction tx)
        {
            using var cmd = new SqlCommand(@"
INSERT INTO Detalle_Venta (id_Venta)
OUTPUT INSERTED.id_Detalle_Venta
VALUES (@v);", cn, tx);

            cmd.Parameters.Add("@v", SqlDbType.Int).Value = d.id_Venta;
            var result = await cmd.ExecuteScalarAsync();
            if (result is null)
                throw new InvalidOperationException("No se pudo insertar el detalle de venta.");
            var idDet = (int)result;
            return idDet;
        }
    }
}
