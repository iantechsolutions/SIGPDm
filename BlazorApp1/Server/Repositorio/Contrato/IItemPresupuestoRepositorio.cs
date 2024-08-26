using BlazorApp1.Shared.Models; //cambiazo
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IItemPresupuestoRepositorio
    {
        Task<List<ItemPresupuesto>> Lista();
        Task<ItemPresupuesto> Obtener(Expression<Func<ItemPresupuesto, bool>> filtro = null);

        Task<List<ItemPresupuesto>> ObtenerMultiple(Expression<Func<ItemPresupuesto, bool>> filtro = null);

        Task<bool> Eliminar(ItemPresupuesto entidad);
        Task<ItemPresupuesto> Crear(ItemPresupuesto entidad);
        Task<bool> Editar(ItemPresupuesto entidad);
        Task<IQueryable<ItemPresupuesto>> Consultar(Expression<Func<ItemPresupuesto, bool>> filtro = null);

    }
}

