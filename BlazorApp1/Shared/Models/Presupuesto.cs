namespace BlazorApp1.Shared.Models
{
    public partial class Presupuesto
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
        public string? PrecioUnitario { get; set; }
        public string? Iva { get; set; }
        public int? InfoInsumo { get; set; }
        public string? Comentario { get; set; }
        public string? NroRemito { get; set; }

        public int? PlazoDePago { get; set; }

        public int? OC {  get; set; }

        public string? TipoCuenta { get; set; }

        public virtual Insumo? InsumoNavigation { get; set; }
        public virtual Proveedore? ProveedorNavigation { get; set; }

    }
}
