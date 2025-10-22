using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurenPadelStore.CEntidades
{
    // DTO para combos/filtros de categorías
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public override string ToString() => Nombre;
    }
}

