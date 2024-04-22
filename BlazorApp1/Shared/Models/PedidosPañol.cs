using System;
using System.Collections.Generic;

namespace BlazorApp1.Shared.Models
{
    public partial class PedidosPañol
    {
        public int Id { get; set; }
        public int? Insumo { get; set; }
        public int? Cantidad { get; set; }
        public int? Operario { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Codigo { get; set; }

        public Insumo? InsumoNavigation { get; set; }
        public Personal? PersonalNavigation { get; set; }

    }
}
