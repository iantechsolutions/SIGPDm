using BlazorApp1.Shared.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IPrestamoStockRepositorio
    {
        Task<List<PrestamoStock>> Lista();
        Task<PrestamoStock> Obtener(Expression<Func<PrestamoStock, bool>> filtro = null);
        Task<bool> Eliminar(PrestamoStock entidad);
        Task<PrestamoStock> Crear(PrestamoStock entidad);       
        Task<bool> Editar(PrestamoStock entidad);
        Task<IQueryable<PrestamoStock>> Consultar(Expression<Func<PrestamoStock, bool>> filtro = null);


    }
}