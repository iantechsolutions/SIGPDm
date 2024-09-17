using BlazorApp1.Shared.Models; //cambiazo
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IMantenimientoRepositorio
    {
        Task<List<Mantenimiento>> Lista();
        Task<Mantenimiento> Obtener(Expression<Func<Mantenimiento, bool>> filtro = null);

        Task<List<Mantenimiento>> ObtenerMultiple(Expression<Func<Mantenimiento, bool>> filtro = null);

        Task<bool> Eliminar(Mantenimiento entidad);
        Task<Mantenimiento> Crear(Mantenimiento entidad);
        Task<bool> Editar(Mantenimiento entidad);
        Task<IQueryable<Mantenimiento>> Consultar(Expression<Func<Mantenimiento, bool>> filtro = null);

    }
}

