using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class PrestamoStockRepositorio : IPrestamoStockRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public PrestamoStockRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<PrestamoStock>> Lista()
        {
            try
            {
                return await _dbContext.PrestamoStock
                  .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<PrestamoStock> Obtener(Expression<Func<PrestamoStock, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.PrestamoStock.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> Eliminar(PrestamoStock entidad)
        {
            try
            {
                _dbContext.PrestamoStock.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<PrestamoStock>> ObtenerMultiples(Expression<Func<PrestamoStock, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.PrestamoStock.Where(filtro).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<PrestamoStock> Crear(PrestamoStock entidad)
        {
            try
            {
                _dbContext.Set<PrestamoStock>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PrestamoStock entidad)
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
        public async Task<IQueryable<PrestamoStock>> Consultar(Expression<Func<PrestamoStock, bool>> filtro = null)
        {
            IQueryable<PrestamoStock> queryEntidad = filtro == null ? _dbContext.PrestamoStock : _dbContext.PrestamoStock.Where(filtro);
            return queryEntidad;
        }
    }
}

