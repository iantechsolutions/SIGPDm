using System;
using System.Collections.Generic;

namespace BlazorApp1.Server.ModelsTemp
{
    public partial class Proveedore
    {
        public int Id { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? Cuit { get; set; }
        public string? Direccion { get; set; }
        public string? Mail { get; set; }
        public string? Telefono { get; set; }
        public string? Cp { get; set; }
        public string? NombreContacto { get; set; }
        public string? Observaciones { get; set; }
        public string? RazonSocial { get; set; }
        public string? Categorias { get; set; }
    }
}
