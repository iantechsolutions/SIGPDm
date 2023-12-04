using System;
using System.Collections.Generic;

namespace BlazorApp1.Server.Models2
{
    public partial class EventosProduccion
    {
        public int Id { get; set; }
        public int? Operario { get; set; }
        public string? Etapa { get; set; }
        public int? Ot { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Tipo { get; set; }
    }
}
