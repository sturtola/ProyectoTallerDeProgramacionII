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
        public string Imagen_Producto { get; set; }     // ruta/URL
        public string Categoria_Producto { get; set; }  // "Mujer","Hombre","Accesorios"
        public decimal Precio_Unitario_Producto { get; set; }
        public bool Estado_Producto { get; set; } = true;

        public string NombreMostrar => $"{Nombre_Producto} - {Marca_Producto}";
    }
}
