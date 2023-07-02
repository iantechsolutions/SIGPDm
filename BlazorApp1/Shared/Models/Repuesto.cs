using System;
using System.Collections.Generic;

namespace BlazorApp1.Shared.Models
{
    public partial class Repuesto
    {
        public int Id { get; set; }
        public int? StockMin { get; set; }
        public int? StockMax { get; set; }
        public int? StockReal { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public string? Foto { get; set; }
        public string? Descripcion { get; set; }
    }
}
