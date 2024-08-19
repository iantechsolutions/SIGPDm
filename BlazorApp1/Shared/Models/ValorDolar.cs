using BlazorApp1.Shared.Models;
using System;
using System.Collections.Generic;

namespace BlazorApp1.Shared.Models
{
    public partial class ValorDolar
    {
        public int Id { get; set; }
        public string? Valor {  get; set; }
        public DateTime? Fecha { get; set; }
    }
}
