using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class Prestamo
    {
        public int Id { get; set; }

        public string? Operario { get; set; }

        public string? Insumo { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin {  get; set; }

        public int? Cantidad { get; set; }




    }
}


//La tabla tiene operario (relacional), insumo (tabla relacional), fechainicio, fechafin, cantidad.