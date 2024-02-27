using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;

namespace BlazorApp1.Server.Models
{
    public partial class Prestamo
    {
        public int Id { get; set; }
        public int? Operario { get; set; }
        public int? Lote { get; set; }
        public int? Insumo { get; set; }
        public int? Cantidad { get; set; }
        public int? Maquina { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaFinReal { get; set; }

        public virtual Insumo? InsumoNavigation { get; set; }
        public virtual Personal? OperarioNavigation { get; set; }
        public MaquinasHerramienta MaquinaNavigation { get; set; }
    }
}
