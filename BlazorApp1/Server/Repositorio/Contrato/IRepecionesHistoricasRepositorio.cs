using BlazorApp1.Shared.Models; //cambiazo
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IRecepcionesHistoricasRepositorio
    {
        Task<List<RecepcionesHistoricas>> Lista();
        Task<RecepcionesHistoricas> Obtener(Expression<Func<RecepcionesHistoricas, bool>> filtro = null);
        Task<bool> Eliminar(RecepcionesHistoricas entidad);
        Task<RecepcionesHistoricas> Crear(RecepcionesHistoricas entidad);
        Task<bool> Editar(RecepcionesHistoricas entidad);
        Task<IQueryable<RecepcionesHistoricas>> Consultar(Expression<Func<RecepcionesHistoricas, bool>> filtro = null);

    }
}

