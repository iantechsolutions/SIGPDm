using System;
using System.Collections.Generic;

namespace BlazorApp1.Server.Models
{
    public partial class Prestamo
    {
        public int Id { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? Cantidad { get; set; }
        public int? Insumo { get; set; }
        public int? Operario { get; set; }
        public string? Estado { get; set; }

        public virtual Insumo? InsumoNavigation { get; set; }
        public virtual Personal? OperarioNavigation { get; set; }
    }
}
