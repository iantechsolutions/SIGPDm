using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Mantenimiento
    {
        public int? Id { get; set; }

        public int? Maquina { get; set; }
        public int? Cantidad { get; set; }
        public string? Name { get; set; }

        public string? Detalle { get; set; }
        public string? Etapas { get; set; }
        public string? Personal { get; set; }
        public int? Insumo { get; set; }

        public string? Titulo { get; set; }
        public string? Tipo { get; set; }

        public string? Estado { get; set; }
        public DateTime? Fecha { get; set; }


        
    }
}
