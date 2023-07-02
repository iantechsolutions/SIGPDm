
namespace BlazorApp1.Server.Models
{
    public partial class Ordencompra
    {
        public int Id { get; set; }
        public string? Estado { get; set; }
        public string? Especificacion { get; set; }
        public string? Archivo { get; set; }
        public int? Insumo { get; set; }
        public int? Cantidad { get; set; }
        public int? Proveedor { get; set; }
        public DateTime? Generada { get; set; }
        public DateTime? Aprobada { get; set; }
        public DateTime? Recepcionada { get; set; }
        public string? CondicionPago { get; set; }
        public string? Precio { get; set; }
        public int? InfoInsumo { get; set; }

        public virtual Insumo? InfoInsumoNavigation { get; set; }
    }
}
