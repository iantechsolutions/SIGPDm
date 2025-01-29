using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazorApp1.Shared.Models
{
    public partial class Ordentrabajo
    {
        public int Id { get; set; }
        public string? Cliente { get; set; }
        public DateTime? Fechaentrega { get; set; }
        public string? Descripcion { get; set; }
        public string? Lugarentrega { get; set; }
        public string? Especificaciones { get; set; }
        public string? Estado { get; set; }
        public string? Planos { get; set; }
        public string? Codigo { get; set; }
        public string? Despiece { get; set; }
        public DateTime? Pedidofabrica { get; set; }
        public string? Cantidad { get; set; }
        public string? Observaciones { get; set; }
        public string? Fechas { get; set; }
        public string? Insumosusados { get; set; }
        public DateTime? Fechaaplazada { get; set; }
        public string? Color { get; set; }
        public string? Titulo { get; set; }
        public string? Obra { get; set; }
        public string? Referencia { get; set; }

        public int? Orden { get; set; }

        public string? ChapaEstructura { get; set; }
        public string? ChapaBandejas { get; set; }
        public string? Zocalo_Trineo { get; set; }
        public string? Portaplanos { get; set; }
        public string? TrabaViento { get; set; }
        public string? Contrafrentes { get; set; }
        public string? TipoCierre { get; set; }
        public string? SentidoPuertas { get; set; }
        public string? Cancamos { get; set; }
        public string? DobleMarcoInterno { get; set; }
        public string? CaballetesTermicas { get; set; }
        public string? CaballetesInterruptores { get; set; }
        public string? TapasPiso { get; set; }
        public string? PerfilesC1yC2 { get; set; }
        public string? PerfilesOmega { get; set; }
        public string? SistemasAisladores { get; set; }
        public string? RejillasVentilacion { get; set; }
        public string? Sobretecho { get; set; }
        public string? ChapaPuertas { get; set; }
        public string? Remitos { get; set; }
        public string? Cotizaciones { get; set; }

        public DateTime? UltimaEtapa { get; set; }


        //[JsonIgnore]
        //public List<Fallas>? Fallas { get; set; }
    }
}
