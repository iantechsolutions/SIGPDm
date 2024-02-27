using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IMaquinasRepositorio
    {
        Task<List<MaquinasHerramienta>> Lista();
        Task<MaquinasHerramienta> Obtener(Expression<Func<MaquinasHerramienta, bool>> filtro = null);
        Task<bool> Eliminar(MaquinasHerramienta entidad);
        Task<MaquinasHerramienta> Crear(MaquinasHerramienta entidad);
        Task<bool> Editar(MaquinasHerramienta entidad);
        Task<IQueryable<MaquinasHerramienta>> Consultar(Expression<Func<MaquinasHerramienta, bool>> filtro = null);
    }
}
