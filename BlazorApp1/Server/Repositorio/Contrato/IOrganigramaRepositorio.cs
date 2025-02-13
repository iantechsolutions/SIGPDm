using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IOrganigramaRepositorio
    {
        Task<List<Organigrama>> Lista();
        Task<Organigrama> Obtener(Expression<Func<Organigrama, bool>> filtro = null);
        Task<bool> Eliminar(Organigrama entidad);
        Task<Organigrama> Crear(Organigrama entidad);
        Task<bool> Editar(Organigrama entidad);
        Task<IQueryable<Organigrama>> Consultar(Expression<Func<Organigrama, bool>> filtro = null);

    }
}
