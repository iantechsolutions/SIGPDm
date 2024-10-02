using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Server.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using System.Linq.Dynamic.Core;
using Polly;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class PedidosPañolRepositorio : IPedidosPañolRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public PedidosPañolRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PedidosPañol>> Lista(int skip, int take)
        {
            try
            {
                // Use Skip and Take for paging, and include Socio
                return await _dbContext.PedidosPañols.Include(x=>x.insumoNavigation).Include(x=>x.operarioNavigation)
                                                 .OrderByDescending(t => t.Fecha)
                                                 .Skip(skip)
                                                 .Take(take)
                                                 .ToListAsync();

            }
            catch
            {
                throw;
            }
        }
        public async Task<List<PedidosPañol>> LimitadosFiltrados(int skip, int take, string? expression)
        {
            var query = _dbContext.PedidosPañols
                .OrderByDescending(x => x.Fecha)
                .Include(p => p.operarioNavigation)
                .Include(p => p.insumoNavigation)
                .AsQueryable();

            if (!string.IsNullOrEmpty(expression))
            {
                Console.WriteLine(expression);
                query = query.Where(expression); 
            }

            //query = query

            // Aplicar paginación
            return await query.Skip(skip).Take(take).ToListAsync();
        }
        public async Task<int> CantidadTotal()
        {
            try
            {
                return _dbContext.PedidosPañols.Count();
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
                return await _dbContext.PedidosPañols.Where(filtro).OrderByDescending(x => x.Fecha)
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
