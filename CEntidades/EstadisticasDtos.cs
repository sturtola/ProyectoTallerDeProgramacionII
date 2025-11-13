using System;

namespace AurenPadelStore.CEntidades
{
    public class VentaPorDiaDto
    {
        public DateTime Fecha { get; set; }
        public decimal ImporteTotal { get; set; }
    }

    public class VentaPorMesDto
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal ImporteTotal { get; set; }
    }

    public class TopProductoDto
    {
        public int id_Producto { get; set; }
        public string Nombre { get; set; } = "";
        public int CantidadVendida { get; set; }
        public decimal Porcentaje { get; set; } // calculado en lógica
    }

    public class ResumenPeriodoDto
    {
        public int CantidadVentas { get; set; }
        public int CantidadProductos { get; set; }
        public decimal ImporteTotal { get; set; }
        public decimal TicketPromedio { get; set; }
    }
}
