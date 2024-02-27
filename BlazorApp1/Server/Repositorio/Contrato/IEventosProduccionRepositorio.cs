using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IEventosProduccionRepositorio
    {
        Task<List<EventosProduccion>> Lista();
        Task<EventosProduccion> Obtener(Expression<Func<EventosProduccion, bool>> filtro = null);
        Task<bool> Eliminar(EventosProduccion entidad);
        Task<EventosProduccion> Crear(EventosProduccion entidad);
        Task<bool> Editar(EventosProduccion entidad);
        Task<IQueryable<EventosProduccion>> Consultar(Expression<Func<EventosProduccion, bool>> filtro = null);
    }
}
