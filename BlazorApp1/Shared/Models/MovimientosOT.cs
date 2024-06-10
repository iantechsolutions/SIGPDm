using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class MovimientosOT
    {
        public int? Id { get; set; }
        public int? OT { get; set; }
        public string? EtapaOrigen { get; set; }
        public string? EtapaDestino { get; set; }
        public DateTime? Fecha { get; set; }
        
    }
}
