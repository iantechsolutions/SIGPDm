using System;
using System.Collections.Generic;

namespace BlazorApp1.Shared.Models
{
    public partial class Personal
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellido { get; set; }
        public int? Dni { get; set; }
        public string? Mail { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? CondicionContractual { get; set; }
        public int? Legajo { get; set; }
        public string? Puesto { get; set; }
        public string? Categoria { get; set; }
        public string? PremioEstablecido { get; set; }
    }
}
