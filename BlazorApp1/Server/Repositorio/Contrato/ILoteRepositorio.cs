using BlazorApp1.Server.Models;
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface ILoteRepositorio
    {
        Task<List<Lotes>> Lista();
        Task<Lotes> Obtener(Expression<Func<Lotes, bool>> filtro = null);
        Task<bool> Eliminar(Lotes entidad);
        Task<Lotes> Crear(Lotes entidad);
        Task<bool> Editar(Lotes entidad);
        Task<IQueryable<Lotes>> Consultar(Expression<Func<Lotes, bool>> filtro = null);
    }
}
