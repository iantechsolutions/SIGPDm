using System;
using System.Collections.Generic;

namespace BlazorApp1.Shared.Models
{
    public partial class SalidasDePañol
    {
        public int Id { get; set; }
        public int? Cantidad { get; set; }
        public string? TablaEnQueBuscar { get; set; }
        public string? Usuario { get; set; }
        public int? IdDelMaterial { get; set; }
        public string? Codigo { get; set; }
    }
}
