using BlazorApp1.Server.Models;
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Lista();
        Task<Categoria> Obtener(Expression<Func<Categoria, bool>> filtro = null);
        Task<bool> Eliminar(Categoria entidad);
        Task<Categoria> Crear(Categoria entidad);
        Task<bool> Editar(Categoria entidad);
        Task<IQueryable<Categoria>> Consultar(Expression<Func<Categoria, bool>> filtro = null);
    }
}
