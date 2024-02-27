using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IRepuestoRepositorio
    {
        Task<List<Repuesto>> Lista();
        Task<Repuesto> Obtener(Expression<Func<Repuesto, bool>> filtro = null);
        Task<bool> Eliminar(Repuesto entidad);
        Task<Repuesto> Crear(Repuesto entidad);
        Task<bool> Editar(Repuesto entidad);
        Task<IQueryable<Repuesto>> Consultar(Expression<Func<Repuesto, bool>> filtro = null);
    }
}
