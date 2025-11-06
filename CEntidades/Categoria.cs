using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenPadelStore.CEntidades
{
    // DTO para combos/filtros de categorías
    public class Categoria
    {
        public int id_Categoria { get; set; }
        public required string Nombre_Categoria { get; set; }
        public override string ToString() => Nombre_Categoria;
    }
}

