using BlazorApp1.Server.Models;
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface ILoteRepositorio
    {
        Task<List<Insumo>> Lista();
        Task<Insumo> Obtener(Expression<Func<Insumo, bool>> filtro = null);
        Task<bool> Eliminar(Insumo entidad);
        Task<Insumo> Crear(Insumo entidad);
        Task<bool> Editar(Insumo entidad);
        Task<IQueryable<Insumo>> Consultar(Expression<Func<Insumo, bool>> filtro = null);
    }
}
