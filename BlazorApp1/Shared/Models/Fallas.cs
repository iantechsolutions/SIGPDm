using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Fallas
    {
        public int id { get; set; }
        public int? empleado { get; set; }
        public string? observacion { get; set; }
        public string? correccion { get; set; }
        public string? etapa { get; set; }
        public DateTime? fecha { get; set; }
        public int? OT { get; set; }

        public string? codigo { get; set; }
        public Personal? personalNavigation { get; set; }
        //public Ordentrabajo? ordenNavigation { get; set; }

    }
}
