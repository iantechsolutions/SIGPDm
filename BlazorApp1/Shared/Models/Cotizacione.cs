using System;
using System.Collections.Generic;

namespace BlazorApp1.Shared.Models
{
    public partial class Cotizacione
    {
        public int Id { get; set; }
        public string? Cliente { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Alcance { get; set; }
        public string? Tratamientosuperficial { get; set; }
        public string? Color { get; set; }
        public string? Valorpeso { get; set; }
        public string? Valordolar { get; set; }
        public string? Estado { get; set; }
        public string? Codigo { get; set; }
        public string? Cantidad { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? Fechaentrega { get; set; }
        public string? Obra { get; set; }
        public string? Referencia { get; set; }
        public string? Planos { get; set; }
        public string? Cotizaciones { get; set; }
        public string? Remito { get; set; }

    }
}
