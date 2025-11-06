namespace AurenPadelStore.CEntidades
{
    public class Producto
    {
        public int id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Descripcion_Producto { get; set; }
        public string Marca_Producto { get; set; }
        public string Material_Producto { get; set; }
        public int Stock_Producto { get; set; }
        public string Imagen_Producto { get; set; }   // ruta/URL (relativa o absoluta)
        public decimal Precio_Unitario_Producto { get; set; }
        public bool Estado_Producto { get; set; } = true;

        // Relación con Categoria
        public int id_Categoria { get; set; }         // FK
        public string Categoria_Nombre { get; set; }  // Para mostrar (JOIN)

        public string NombreMostrar => $"{Nombre_Producto} - {Marca_Producto}";

        public string Mostrar =>
            $"{Nombre_Producto} ({Marca_Producto}) — Stock:{Stock_Producto} — ${Precio_Unitario_Producto:N2}";
    }
}
