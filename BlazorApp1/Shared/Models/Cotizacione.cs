using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared.Models
{
    public partial class Cotizacione
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El cliente es obligatorio.")]
        public string? Cliente { get; set; }
        [Required(ErrorMessage = "El titulo es obligatorio.")]
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string? Alcance { get; set; }
        public string? Tratamientosuperficial { get; set; }
        public string? Color { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio.")]
        public string? Valorpeso { get; set; }
        public string? Valordolar { get; set; }
        public string? Estado { get; set; }
        public string? Planos { get; set; }
        [Required(ErrorMessage = "El N° de cotización es obligatorio.")]
        public string? Codigo { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        public string? Cantidad { get; set; }
        public string? Referencia { get; set; }
        [Required(ErrorMessage = "La fecha de entrega es obligatoria.")]
        public DateTime? Fechaentrega { get; set; }
        public string? Obra { get; set; }
    }
}
