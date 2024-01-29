namespace BlazorApp1.Shared.Models
{
    public partial class InsumoDTO
    {
        public InsumoDTO()
        {
            OrdencompraInfoInsumoNavigations = new HashSet<OrdencompraDTO>();
            OrdencompraInsumoNavigations = new HashSet<OrdencompraDTO>();
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
        public string? ProveedoresPosibles { get; set; }
        public virtual ICollection<OrdencompraDTO> OrdencompraInfoInsumoNavigations { get; set; }
        public virtual ICollection<OrdencompraDTO> OrdencompraInsumoNavigations { get; set; }
    }
}
