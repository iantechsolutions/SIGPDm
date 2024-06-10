using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{

    public class ItemPresupuestoRepositorio : IItemPresupuestoRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public ItemPresupuestoRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ItemPresupuesto>> Lista()
        {
            try
            {
                return await _dbContext.ItemPresupuesto
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<ItemPresupuesto> Obtener(Expression<Func<ItemPresupuesto, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.ItemPresupuesto
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<ItemPresupuesto> GetByOT(Expression<Func<ItemPresupuesto, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.ItemPresupuesto
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<ItemPresupuesto>> ObtenerMultiples(Expression<Func<ItemPresupuesto, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.ItemPresupuesto
                    .Where(filtro).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(ItemPresupuesto entidad)
        {
            try
            {
                _dbContext.ItemPresupuesto.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ItemPresupuesto> Crear(ItemPresupuesto entidad)
        {
            try
            {
                _dbContext.Set<ItemPresupuesto>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ItemPresupuesto entidad)
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
        public async Task<IQueryable<ItemPresupuesto>> Consultar(Expression<Func<ItemPresupuesto, bool>> filtro = null)
        {
            IQueryable<ItemPresupuesto> queryEntidad = filtro == null ? _dbContext.ItemPresupuesto : _dbContext.ItemPresupuesto.Where(filtro);
            return queryEntidad;
        }
    }

}
