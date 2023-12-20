using System;
using System.Collections.Generic;

namespace BlazorApp1.Server.ModelsTemp
{
    public partial class Lote
    {
        public string? Tipo { get; set; }
        public int? Numero { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Alto { get; set; }
        public int? Ancho { get; set; }
        public string? NroRemito { get; set; }
        public string? Proveedor { get; set; }
        public int? IdInsumo { get; set; }
        public int Id { get; set; }
    }
}
