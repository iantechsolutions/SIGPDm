using System.Text.Json.Serialization;

namespace BlazorApp1.Shared.Models
{
    public partial class Insumo
    {
        public Insumo()
        {
            ItemsPresupuesto = new HashSet<ItemPresupuesto>();
            OrdencompraInfoInsumoNavigations = new HashSet<Ordencompra>();

            OrdencompraInsumoNavigations = new HashSet<Ordencompra>();
            Prestamos = new HashSet<Prestamo>();
            //PresupuestoInsumoNavigations = new HashSet<Presupuesto>();
        }

        public int Id { get; set; }
        public int? StockMin { get; set; }
        public int? StockMax { get; set; }
        public int? StockReal { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public string? Foto { get; set; }
        public string? Descripcion { get; set; }
        public string? Recepcion { get; set; }
        public string? Lotes { get; set; }
        public string? Proveedor { get; set; }
        public string? Tipo { get; set; }
        public string? UltimoPrecio { get; set; }

        public string? ProveedoresPosibles { get; set; }

        public string? Asignacion { get; set; }
        public int? PeriodicidadMantenimiento { get; set; }
        public string? DescripcionMantenimiento { get; set; }
        public string? Estado { get; set; }
        public string? MotivoEstado { get; set; }
        public string? Disposicion { get; set; }
        public string? MotivoDisposicion { get; set; }
        public DateTime? UltimoMant { get; set; }
        public string? DetalleMantenimiento { get; set; }
        public string? Personal { get; set; }
        public string? DetalleCorrectivo { get; set; }

        public DateTime? MantenimientoPreventivo {  get; set; }

        public string? Categoria { get; set; }

        public string? Marca { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public virtual ICollection<ItemPresupuesto> ItemsPresupuesto { get; set; }
        public virtual ICollection<Ordencompra> OrdencompraInfoInsumoNavigations { get; set; }
        public virtual ICollection<Ordencompra> OrdencompraInsumoNavigations { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }

        [JsonIgnore]
        public List<PedidosPañol>? PedidosNavigation { get; set;}
        //[JsonIgnore]
        public List<Presupuesto>? PresupuestoInsumoNavigations { get; set; }
        //public virtual ICollection<Presupuesto> PresupuestoInsumoNavigations { get; set; }
    }
}
