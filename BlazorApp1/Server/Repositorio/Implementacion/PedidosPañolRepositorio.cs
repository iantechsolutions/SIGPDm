using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class PedidosPañolRepositorio : IPedidosPañolRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public PedidosPañolRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<PedidosPañol>> Lista()
        {
            try
            {
                return await _dbContext.PedidosPañols
                    .Include(x => x.InsumoNavigation)
                    .Include(x => x.PersonalNavigation)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<PedidosPañol> Obtener(Expression<Func<PedidosPañol, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.PedidosPañols
                    .Include(x =>x.InsumoNavigation)
                    .Include(x => x.PersonalNavigation)
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(PedidosPañol entidad)
        {
            try
            {
                _dbContext.PedidosPañols.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PedidosPañol> Crear(PedidosPañol entidad)
        {
            try
            {
                _dbContext.Set<PedidosPañol>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PedidosPañol entidad)
        {
            try
            {
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IQueryable<PedidosPañol>> Consultar(Expression<Func<PedidosPañol, bool>> filtro = null)
        {
            IQueryable<PedidosPañol> queryEntidad = filtro == null ? _dbContext.PedidosPañols : _dbContext.PedidosPañols.Where(filtro);
            return queryEntidad;
        }
    }
}
