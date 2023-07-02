using BlazorApp1.Server.Models;
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{

    public interface IOCRepositorio
    {
        Task<List<Ordencompra>> Lista();
        Task<Ordencompra> Obtener(Expression<Func<Ordencompra, bool>> filtro = null);
        Task<bool> Eliminar(Ordencompra entidad);
        Task<Ordencompra> Crear(Ordencompra entidad);
        Task<bool> Editar(Ordencompra entidad);
        Task<IQueryable<Ordencompra>> Consultar(Expression<Func<Ordencompra, bool>> filtro = null);


    }
}
