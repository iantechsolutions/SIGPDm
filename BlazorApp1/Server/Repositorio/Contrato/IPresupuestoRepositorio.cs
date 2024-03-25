using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{

    public interface IPresupuestoRepositorio
    {
        Task<List<Presupuesto>> Lista();
        Task<Presupuesto> Obtener(Expression<Func<Presupuesto, bool>> filtro = null);
        Task<bool> Eliminar(Presupuesto entidad);
        Task<Presupuesto> Crear(Presupuesto entidad);
        Task<bool> Editar(Presupuesto entidad);
        Task<IQueryable<Presupuesto>> Consultar(Expression<Func<Presupuesto, bool>> filtro = null);


    }
}
