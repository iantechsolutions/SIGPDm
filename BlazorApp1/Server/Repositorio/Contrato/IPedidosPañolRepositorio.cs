using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IPedidosPañolRepositorio
    {
        Task<List<PedidosPañol>> Lista();
        Task<PedidosPañol> Obtener(Expression<Func<PedidosPañol, bool>> filtro = null);
        Task<bool> Eliminar(PedidosPañol entidad);
        Task<PedidosPañol> Crear(PedidosPañol entidad);
        Task<bool> Editar(PedidosPañol entidad);
        Task<IQueryable<PedidosPañol>> Consultar(Expression<Func<PedidosPañol, bool>> filtro = null);
    }
}
