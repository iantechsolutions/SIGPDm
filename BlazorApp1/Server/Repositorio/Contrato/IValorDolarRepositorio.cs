using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IValorDolarRepositorio
    {
        Task<List<ValorDolar>> Lista();
        Task<ValorDolar> Obtener(Expression<Func<ValorDolar, bool>> filtro = null);
        Task<bool> Eliminar(ValorDolar entidad);
        Task<ValorDolar> Crear(ValorDolar entidad);
        Task<bool> Editar(ValorDolar entidad);
        Task<IQueryable<ValorDolar>> Consultar(Expression<Func<ValorDolar, bool>> filtro = null);

    }
}
