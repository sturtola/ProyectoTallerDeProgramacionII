using System;

using System.Collections.Generic;

using System.Linq;

using AurenPadelStore.CDatos;

using AurenPadelStore.CEntidades;



namespace AurenPadelStore.CLogica

{

    public class VentaLogica

    {
        private readonly VentaDatos _ventaDatos = new VentaDatos();

        public List<VentaListado> ListadoPorUsuario(int idUsuario)
        {
            return _ventaDatos.ObtenerListadoPorUsuario(idUsuario);
        }


        private readonly VentaDatos _datos = new VentaDatos();



        public void InsertarVentaConItems(Venta venta, List<ItemVenta> items)

        {

            if (venta is null) throw new ArgumentNullException(nameof(venta));

            if (items is null) throw new ArgumentNullException(nameof(items));



            if (venta.id_Cliente <= 0) throw new ArgumentException("Cliente inválido.");

            if (venta.id_Usuario <= 0) throw new ArgumentException("Usuario inválido.");

            if (string.IsNullOrWhiteSpace(venta.Metodo_Pago)) throw new ArgumentException("Debe seleccionar un método de pago.");

            if (items.Count == 0) throw new ArgumentException("Debe agregar al menos un ítem de venta.");



            foreach (var it in items)

            {

                if (it.id_Producto <= 0) throw new ArgumentException("Ítem con producto inválido.");

                if (it.Cantidad_Item_Venta <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.");

                if (it.Precio_Unitario_Item_Venta < 0) throw new ArgumentException("El precio unitario no puede ser negativo.");

            }



            if (venta.Total <= 0m)

                venta.Total = CalcularTotal(items, venta.Envio);



            if (venta.Fecha > DateTime.Now)

                venta.Fecha = DateTime.Now;



            _datos.InsertarVentaConItems(venta, items);

        }



        public decimal CalcularTotal(IEnumerable<ItemVenta> items, bool envio)

        {

            var total = items.Sum(i => i.Precio_Unitario_Item_Venta * i.Cantidad_Item_Venta);

            if (envio) total += 5000m; // envío fijo

            return decimal.Round(total, 2, MidpointRounding.AwayFromZero);

        }


    }

}