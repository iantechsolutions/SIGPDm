using BlazorApp1.Shared.Models; //cambiazo
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface ICondicionPagoRepositorio
    {
        Task<List<CondicionPago>> Lista();
        Task<CondicionPago> Obtener(Expression<Func<CondicionPago, bool>> filtro = null);
        Task<bool> Eliminar(CondicionPago entidad);
        Task<CondicionPago> Crear(CondicionPago entidad);
        Task<bool> Editar(CondicionPago entidad);
        Task<IQueryable<CondicionPago>> Consultar(Expression<Func<CondicionPago, bool>> filtro = null);
    }
}
