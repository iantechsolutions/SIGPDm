using BlazorApp1.Shared.Models; //cambiazo
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface INotificacionesRepositorio
    {
        Task<List<Notificaciones>> Lista();
        Task<Notificaciones> Obtener(Expression<Func<Notificaciones, bool>> filtro = null);
        Task<Notificaciones> ObtenerByMaquina(Expression<Func<Notificaciones, bool>> filtro = null);

        Task<List<Notificaciones>> ObtenerMultiples(Expression<Func<Notificaciones, bool>> filtro = null);
        Task<bool> Eliminar(Notificaciones entidad);
        Task<Notificaciones> Crear(Notificaciones entidad);

        Task<bool> Editar(Notificaciones entidad);
        Task<IQueryable<Notificaciones>> Consultar(Expression<Func<Notificaciones, bool>> filtro = null);

    }
}

