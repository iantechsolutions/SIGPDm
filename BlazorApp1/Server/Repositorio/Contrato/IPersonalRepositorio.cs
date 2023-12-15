using BlazorApp1.Server.Models;
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IPersonalRepositorio
    {
        Task<List<Personal>> Lista();
        Task<Personal> Obtener(Expression<Func<Personal, bool>> filtro = null);
        Task<bool> Eliminar(Personal entidad);
        Task<Personal> Crear(Personal entidad);
        Task<bool> Editar(Personal entidad);
        Task<IQueryable<Personal>> Consultar(Expression<Func<Personal, bool>> filtro = null);
    }
}
