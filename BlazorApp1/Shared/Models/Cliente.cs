using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        
        public string? NombreEmpresa { get; set; }
        [Required(ErrorMessage = "El cuit es obligatorio.")]
        public string? Cuit { get; set; }
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "El mail es obligatorio.")]
        public string? Mail { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El código postal es obligatorio.")]
        public string? Cp { get; set; }
        [Required(ErrorMessage = "El nombre de contacto es obligatorio.")]
        public string? NombreContacto { get; set; }

        public string? Observaciones { get; set; }
        [Required(ErrorMessage = "La razon social es obligatoria.")]
        public string? RazonSocial { get; set; }
        
        public string? Corredor { get; set; }
        public string? Expreso { get; set; }
        [Required(ErrorMessage = "El domicilio es obligatorio.")]
        public string? DomicilioEntrega { get; set; }
    }
}
