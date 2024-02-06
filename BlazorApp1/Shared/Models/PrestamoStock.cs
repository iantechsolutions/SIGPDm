using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class PrestamoStock
    {
        public int Id { get; set; }

        public int? Insumo { get; set; }

        public int? Prestamo { get; set; }

        public int? Cantidad { get; set; }

        public int? Lote { get; set;}

        public string? LoteTipo { get; set; }

        public string? InsumoTipo { get; set; }

        public DateTime? FechaFinal { get; set; }

    }
}
