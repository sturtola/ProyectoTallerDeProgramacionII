using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenPadelStore.CEntidades
{
    public class ItemVenta
    {
        public int id_Item_Venta { get; set; }
        public int id_Producto { get; set; }
        public int id_Detalle_Venta { get; set; }
        public int Cantidad_Item_Venta { get; set; }
        public decimal Precio_Unitario_Item_Venta { get; set; }
        public decimal Subtotal_Item_Venta => Cantidad_Item_Venta * Precio_Unitario_Item_Venta;
    }
}


