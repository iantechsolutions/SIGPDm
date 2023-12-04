using System;
using System.Collections.Generic;

namespace BlazorApp1.Server.Models2
{
    public partial class MaquinasHerramienta
    {
        public int Id { get; set; }
        public string? Marca { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string? Codigo { get; set; }
        public string? Asignacion { get; set; }
        public string? PeriodicidadMantenimiento { get; set; }
        public string? DescripcionMantenimiento { get; set; }
        public string? Estado { get; set; }
        public string? MotivoEstado { get; set; }
        public string? Disposicion { get; set; }
        public string? MotivoDisposicion { get; set; }
        public string? Descripcion { get; set; }
    }
}
