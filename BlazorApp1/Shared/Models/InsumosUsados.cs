using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class InsumosUsados
    {
        public string? Descripcion { get; set; }
        public InsumoDTO? insumo { get; set; }

        public int? cantidad { get; set; }

        public int? lote { get; set; }

    }
}
