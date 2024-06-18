using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorApp1.Shared.Models
{
    public partial class MaquinasHerramienta
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La marca es obligatoria.")]
        public string? Marca { get; set; }
        //[Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La fecha de ingreso es obligatoria.")]
        public DateTime? FechaIngreso { get; set; }
        [Required(ErrorMessage = "El código es obligatorio.")]
        public string? Codigo { get; set; }
        [Required(ErrorMessage = "La asignación es obligatoria.")]
        public string? Asignacion { get; set; }
        [Required(ErrorMessage = "La periodicidad de mantenimiento es obligatoria.")]
        public int? PeriodicidadMantenimiento { get; set; }
        [Required(ErrorMessage = "La descripción del mantenimiento es obligatoria.")]
        public string? DescripcionMantenimiento { get; set; }
        [Required(ErrorMessage = "El estado de la maquina es obligatorio.")]
        public string? Estado { get; set; }
        public string? MotivoEstado { get; set; }
        public string? Disposicion { get; set; }
        public string? MotivoDisposicion { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string? Descripcion { get; set; }
        public List<Prestamo>? Prestamos { get; set; }
        [Required(ErrorMessage = "La fecha del ultimo mantenimiento es obligatoria")]
        public DateTime? UltimoMant { get; set; }
        public DateTime? MantenimientoPreventivo { get; set; }

        public string? DetalleCorrectivo { get; set; }

        public string? DetalleMantenimiento { get; set; }
    }
}
