using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Server.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class InsumoRepositorio : IInsumoRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public InsumoRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Insumo>> Lista()
        {
            try
            {
                return await _dbContext.Insumos
                    .Include(e => e.OrdencompraInsumoNavigations)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Insumo> Obtener(Expression<Func<Insumo, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Insumos.Where(filtro)
                    .Include(e => e.OrdencompraInsumoNavigations)
                    .ThenInclude(x => x.ProveedorNavigation)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(Insumo entidad)
        {
            try
            {
                _dbContext.Insumos.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Insumo> Crear(Insumo entidad)
        {
            try
            {
                _dbContext.Set<Insumo>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Insumo entidad)
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
        public async Task<IQueryable<Insumo>> Consultar(Expression<Func<Insumo, bool>> filtro = null)
        {
            IQueryable<Insumo> queryEntidad = filtro == null ? _dbContext.Insumos : _dbContext.Insumos.Where(filtro);
            return queryEntidad;
        }
    }

}


