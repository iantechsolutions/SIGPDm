using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IClienteRepositorio
    {
        Task<List<Cliente>> Lista();
        Task<Cliente> Obtener(Expression<Func<Cliente, bool>> filtro = null);
        Task<bool> Eliminar(Cliente entidad);
        Task<Cliente> Crear(Cliente entidad);
        Task<bool> Editar(Cliente entidad);
        Task<IQueryable<Cliente>> Consultar(Expression<Func<Cliente, bool>> filtro = null);
    }
}
