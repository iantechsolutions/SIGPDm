using BlazorApp1.Server.Models;
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface ICotizacionesRepositorio
    {
        Task<List<Cotizacione>> Lista();
        Task<Cotizacione> Obtener(Expression<Func<Cotizacione, bool>> filtro = null);
        Task<bool> Eliminar(Cotizacione entidad);
        Task<Cotizacione> Crear(Cotizacione entidad);
        Task<bool> Editar(Cotizacione entidad);
        Task<IQueryable<Cotizacione>> Consultar(Expression<Func<Cotizacione, bool>> filtro = null);
    }
}
