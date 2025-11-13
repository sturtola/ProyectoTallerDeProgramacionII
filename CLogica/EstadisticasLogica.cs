using AurenPadelStore.CDatos;
using AurenPadelStore.CEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AurenPadelStore.CLogica
{
    public class EstadisticasLogica
    {
        private readonly EstadisticasDatos _datos = new EstadisticasDatos();

        public (List<VentaPorDiaDto> porDia, List<TopProductoDto> top,
                List<VentaPorMesDto> porMes, ResumenPeriodoDto resumen)
            ObtenerDash(DateTime desde, DateTime hasta, int topN)
        {
            if (hasta < desde) (desde, hasta) = (hasta, desde);
            // cap: hasta fin del día
            var desdeOk = desde.Date;
            var hastaOk = hasta.Date;

            var porDia = _datos.VentasPorDia(desdeOk, hastaOk);
            var top = _datos.TopProductos(desdeOk, hastaOk, topN);

            var totalCant = Math.Max(1, top.Sum(t => t.CantidadVendida));
            foreach (var t in top)
                t.Porcentaje = Math.Round(100m * t.CantidadVendida / totalCant, 2);

            var porMes = _datos.VentasPorMes(hastaOk.Year);
            var resumen = _datos.ResumenPeriodo(desdeOk, hastaOk);

            return (porDia, top, porMes, resumen);
        }
    }
}
