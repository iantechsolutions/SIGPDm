using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Lotes
    {
        public string Tipo { get; set; }
        public int? Numero { get; set; }
        public int? Cantidad { get; set;}
        public DateTime? FechaIngreso { get; set; }
        // Nico: Agrego Alto y Ancho
        public int? Alto { get; set; }
        public int? Ancho { get; set; }
        public int? OC { get; set; }
    }
}
