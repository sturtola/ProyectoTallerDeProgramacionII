using AurenPadelStore.CEntidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace AurenPadelStore.CDatos
{
    public class EstadisticasDatos
    {
        public List<VentaPorDiaDto> VentasPorDia(DateTime desde, DateTime hasta)
        {
            var lista = new List<VentaPorDiaDto>();
            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(@"
SELECT CAST(v.Fecha_Venta AS date) AS Fecha,
       SUM(v.Monto_Total_Venta)     AS ImporteTotal
FROM dbo.Venta v WITH (READCOMMITTED)
WHERE v.Fecha_Venta >= @desde AND v.Fecha_Venta < DATEADD(day, 1, @hasta)
GROUP BY CAST(v.Fecha_Venta AS date)
ORDER BY Fecha;", cn);

            cmd.Parameters.Add("@desde", SqlDbType.DateTime2, 3).Value = desde.Date;
            cmd.Parameters.Add("@hasta", SqlDbType.DateTime2, 3).Value = hasta.Date;

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new VentaPorDiaDto
                {
                    Fecha = dr.GetDateTime(0),
                    ImporteTotal = dr.GetDecimal(1)
                });
            }
            return lista;
        }

        public List<TopProductoDto> TopProductos(DateTime desde, DateTime hasta, int topN)
        {
            var lista = new List<TopProductoDto>();
            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(@"
SELECT TOP(@topN)
    p.id_Producto,
    p.Nombre_Producto,
    SUM(iv.Cantidad_Item_Venta) AS Cantidad
FROM dbo.Venta v
JOIN dbo.Detalle_Venta dv ON dv.id_Venta = v.id_Venta
JOIN dbo.Item_Venta    iv ON iv.id_Detalle_Venta = dv.id_Detalle_Venta
JOIN dbo.Producto       p ON p.id_Producto = iv.id_Producto
WHERE v.Fecha_Venta >= @desde AND v.Fecha_Venta < DATEADD(day, 1, @hasta)
GROUP BY p.id_Producto, p.Nombre_Producto
ORDER BY Cantidad DESC, p.Nombre_Producto;", cn);

            cmd.Parameters.Add("@desde", SqlDbType.DateTime2, 3).Value = desde.Date;
            cmd.Parameters.Add("@hasta", SqlDbType.DateTime2, 3).Value = hasta.Date;
            cmd.Parameters.Add("@topN", SqlDbType.Int).Value = topN;

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new TopProductoDto
                {
                    id_Producto = dr.GetInt32(0),
                    Nombre = dr.GetString(1),
                    CantidadVendida = dr.IsDBNull(2) ? 0 : dr.GetInt32(2)
                });
            }
            return lista;
        }

        public List<VentaPorMesDto> VentasPorMes(int anio)
        {
            var lista = new List<VentaPorMesDto>();
            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(@"
SELECT YEAR(v.Fecha_Venta) AS Anio,
       MONTH(v.Fecha_Venta) AS Mes,
       SUM(v.Monto_Total_Venta) AS ImporteTotal
FROM dbo.Venta v WITH(READCOMMITTED)
WHERE YEAR(v.Fecha_Venta) = @anio
GROUP BY YEAR(v.Fecha_Venta), MONTH(v.Fecha_Venta)
ORDER BY Mes;", cn);

            cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new VentaPorMesDto
                {
                    Anio = dr.GetInt32(0),
                    Mes = dr.GetInt32(1),
                    ImporteTotal = dr.GetDecimal(2)
                });
            }
            return lista;
        }

        public ResumenPeriodoDto ResumenPeriodo(DateTime desde, DateTime hasta)
        {
            using var cn = Conexion.ObtenerConexion();
            using var cmd = new SqlCommand(@"
;WITH ventas AS (
    SELECT v.id_Venta, v.Monto_Total_Venta
    FROM dbo.Venta v
    WHERE v.Fecha_Venta >= @desde AND v.Fecha_Venta < DATEADD(day, 1, @hasta)
),
items AS (
    SELECT iv.id_Item_Venta, iv.Cantidad_Item_Venta
    FROM dbo.Detalle_Venta dv
    JOIN dbo.Item_Venta iv ON iv.id_Detalle_Venta = dv.id_Detalle_Venta
    JOIN ventas         vs ON vs.id_Venta = dv.id_Venta
)
SELECT 
    (SELECT COUNT(*) FROM ventas)                                                AS CantVentas,
    (SELECT ISNULL(SUM(i.Cantidad_Item_Venta),0) FROM items i)                   AS CantProductos,
    (SELECT ISNULL(SUM(v.Monto_Total_Venta),0) FROM ventas v)                    AS ImporteTotal;", cn);

            cmd.Parameters.Add("@desde", SqlDbType.DateTime2, 3).Value = desde.Date;
            cmd.Parameters.Add("@hasta", SqlDbType.DateTime2, 3).Value = hasta.Date;

            cn.Open();
            using var dr = cmd.ExecuteReader();
            dr.Read();

            var cantVentas = dr.GetInt32(0);
            var cantProd = dr.GetInt32(1);
            var total = dr.GetDecimal(2);

            return new ResumenPeriodoDto
            {
                CantidadVentas = cantVentas,
                CantidadProductos = cantProd,
                ImporteTotal = total,
                TicketPromedio = cantVentas > 0 ? Math.Round(total / cantVentas, 2) : 0m
            };
        }
    }
}
