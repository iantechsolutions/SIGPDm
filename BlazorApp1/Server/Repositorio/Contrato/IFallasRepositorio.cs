using BlazorApp1.Shared.Models; //cambiazo
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IFallasRepositorio
    {
        Task<List<Fallas>> Lista();
        Task<Fallas> Obtener(Expression<Func<Fallas, bool>> filtro = null);
        Task<Fallas> GetByOT(Expression<Func<Fallas, bool>> filtro = null);
        Task<List<Fallas>> ObtenerMultiples(Expression<Func<Fallas, bool>> filtro = null);
        Task<bool> Eliminar(Fallas entidad);
        Task<Fallas> Crear(Fallas entidad);
        Task<bool> Editar(Fallas entidad);
        Task<IQueryable<Fallas>> Consultar(Expression<Func<Fallas, bool>> filtro = null);

    }
}

