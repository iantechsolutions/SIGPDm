using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace BlazorApp1.Shared.Models
{
    public partial class ProveedoreDTO
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
        public string? Localidad { get; set; }
        public string? NumeroContacto { get; set; }
        public string? NombreFantasia { get; set; }

        public string? TipoCuenta { get; set;}

        public virtual ICollection<Presupuesto>? Presupuestos { get; set; }
    }
}