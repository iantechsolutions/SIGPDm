using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.Models
{
    public class ItemPresupuesto
    {
        public int? Id { get; set; }
        public int? Cantidad { get; set; }
        public string? Precio { get; set; }
        public string? PrecioUnitario { get; set; }
        public string? Observacion { get; set; }

        public string? Descripcion { get; set; }
        public int? Insumo { get; set; }
        public int? Presupuesto { get; set; }
        public int? OC {  get; set; }
        public int? Proveedor { get; set; }
        public string? Estado { get; set; }

        public string? NroRemito { get; set; }

        public string? CondicionPago { get; set; }
        public string? Comentario { get; set; }
        public string? Detalle { get; set; }

        public string? Codigo { get; set; }

        public string? Moneda { get; set; }

        public DateTime? fechaIngreso { get; set; }

        public DateTime? FechaFinish { get; set; }

        public string? Certificado { get; set; }
        public string? Motivo { get; set; }

        public string? Accion { get; set; }

        public string? imagenes { get; set; }

        public string? Identificacion { get; set; }


        //public Insumo? insumoNavigation { get; set; }

        //public Proveedore? proveedoreNavigation { get; set; }


    }
}
