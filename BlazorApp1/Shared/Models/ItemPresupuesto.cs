using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class ItemPresupuesto
    {
        public int? Id { get; set; }
        public int? Cantidad { get; set; }
        public string? Precio { get; set; }
        public string? PrecioUnitario { get; set; }
        public string? Observacion { get; set; }

        public string? Descripcion { get; set; }
        public int? Insumo { get; set; }
        public int? Presupuesto { get; set; }
    }
}
