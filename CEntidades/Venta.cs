using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenPadelStore.CEntidades
{
    public class Venta
    {
        public int id_Venta { get; set; }
        public int id_Cliente { get; set; }
        public int id_Usuario { get; set; }
        public string Metodo_Pago { get; set; } = "";
        public bool Envio { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}


