using BlazorApp1.Shared.Models; //cambiazo
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IMovimientosOTRepositorio
    {
        Task<List<MovimientosOT>> Lista();
        Task<MovimientosOT> Obtener(Expression<Func<MovimientosOT, bool>> filtro = null);
        Task<MovimientosOT> GetByOT(Expression<Func<MovimientosOT, bool>> filtro = null);
        Task<bool> Eliminar(MovimientosOT entidad);
        Task<MovimientosOT> Crear(MovimientosOT entidad);
        Task<bool> Editar(MovimientosOT entidad);
        Task<IQueryable<MovimientosOT>> Consultar(Expression<Func<MovimientosOT, bool>> filtro = null);

    }
}

