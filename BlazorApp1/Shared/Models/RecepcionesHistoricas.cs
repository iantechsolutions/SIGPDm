using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class RecepcionesHistoricas
    {
        public int? Id {  get; set; }

        public int? Cantidad { get; set; }

        public DateTime? Fecha { get; set; }

        public string? NroRemito { get; set; }

        public string? PrecioCotizado { get; set; }

        public string? CondicionEntrada { get; set; }

        public int? Insumo { get; set; }
        public int? Presupuesto { get; set; }



    }
}
