using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface ILoteRepositorio
    {
        Task<List<Lote>> Lista();
        Task<Lote> Obtener(Expression<Func<Lote, bool>> filtro = null);
        Task<List<Lote>> ObtenerMultiples(Expression<Func<Lote, bool>> filtro = null);
        Task<bool> Eliminar(Lote entidad);
        Task<Lote> Crear(Lote entidad);
        Task<bool> Editar(Lote entidad);
        Task<IQueryable<Lote>> Consultar(Expression<Func<Lote, bool>> filtro = null);
    }
}
