using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Lote
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public int? Numero { get; set; }          
        public int? Cantidad { get; set;}
        public DateTime? FechaIngreso { get; set; }
        public int? Alto { get; set; }
        public int? Ancho { get; set; }
        public string? NroRemito { get; set; }     
        public string? Proveedor { get; set; }
        public int? IdInsumo { get; set; }
        public int? OC { get; set; }
    }
}
