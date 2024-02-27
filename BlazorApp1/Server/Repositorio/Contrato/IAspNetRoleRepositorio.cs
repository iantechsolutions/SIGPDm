using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IAspNetRoleRepositorio
    {
        Task<List<AspNetRole>> Lista();
        Task<AspNetRole> Obtener(Expression<Func<AspNetRole, bool>> filtro = null);
        Task<bool> Eliminar(AspNetRole entidad);
        Task<AspNetRole> Crear(AspNetRole entidad);
        Task<bool> Editar(AspNetRole entidad);
        Task<IQueryable<AspNetRole>> Consultar(Expression<Func<AspNetRole, bool>> filtro = null);
    }
}
