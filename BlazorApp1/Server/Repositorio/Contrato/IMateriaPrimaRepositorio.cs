using BlazorApp1.Server.Models;
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IMateriaPrimaRepositorio
    {
        Task<List<MateriaPrima>> Lista();
        Task<MateriaPrima> Obtener(Expression<Func<MateriaPrima, bool>> filtro = null);
        Task<bool> Eliminar(MateriaPrima entidad);
        Task<MateriaPrima> Crear(MateriaPrima entidad);
        Task<bool> Editar(MateriaPrima entidad);
        Task<IQueryable<MateriaPrima>> Consultar(Expression<Func<MateriaPrima, bool>> filtro = null);
    }
}
