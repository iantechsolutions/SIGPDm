using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class PrestamoDTO
    {
        public int Id { get; set; }
        public int? Operario { get; set; }
        public int? Lote { get; set; }
        public int? Insumo { get; set; }
        public int? Cantidad { get; set; }
        public int? Maquina { get; set; }
        public string? Estado {  get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin {  get; set; }
        public DateTime? FechaFinReal { get; set; }
        public virtual InsumoDTO? InsumoNavigation { get; set; }
        public virtual PersonalDTO? OperarioNavigation { get; set; }
        public MaquinasHerramienta? MaquinaNavigation { get; set; }

    }
}