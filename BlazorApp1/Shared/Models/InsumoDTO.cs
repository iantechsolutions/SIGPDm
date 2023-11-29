using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BlazorApp1.Shared.Models
{
    public partial class InsumoDTO
    {
        public int Id { get; set; }
        [DisplayName("Stock Minimo")]
        public int? StockMin { get; set; }
        [DisplayName("Stock Maximo")]
        public int? StockMax { get; set; }
        [DisplayName("Stock Actual")]
        public int? StockReal { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public string? Foto { get; set; }
        public string? Descripcion { get; set; }
        public string? Lotes { get; set; }
        public string? Recepcion { get; set; }



    }
}
