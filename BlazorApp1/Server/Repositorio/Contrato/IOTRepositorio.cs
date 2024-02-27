using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IOTRepositorio
    {
        Task<List<Ordentrabajo>> Lista();
        Task<Ordentrabajo> Obtener(Expression<Func<Ordentrabajo, bool>> filtro = null);
        Task<bool> Eliminar(Ordentrabajo entidad);
        Task<Ordentrabajo> Crear(Ordentrabajo entidad);
        Task<List<Ordentrabajo>> GetForEtapa(string etapa);
        Task<bool> Editar(Ordentrabajo entidad);
        Task<IQueryable<Ordentrabajo>> Consultar(Expression<Func<Ordentrabajo, bool>> filtro = null);
    }
}
