using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{

    public class MantenimientoRepositorio : IMantenimientoRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public MantenimientoRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Mantenimiento>> Lista()
        {
            try
            {
                return await _dbContext.Mantenimiento
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Mantenimiento> Obtener(Expression<Func<Mantenimiento, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Mantenimiento
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        
       
        public async Task<List<Mantenimiento>> ObtenerMultiple(Expression<Func<Mantenimiento, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Mantenimiento
                    .Where(filtro).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Mantenimiento entidad)
        {
            try
            {
                _dbContext.Mantenimiento.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Mantenimiento> Crear(Mantenimiento entidad)
        {
            try
            {
                _dbContext.Set<Mantenimiento>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Mantenimiento entidad)
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
        public async Task<IQueryable<Mantenimiento>> Consultar(Expression<Func<Mantenimiento, bool>> filtro = null)
        {
            IQueryable<Mantenimiento> queryEntidad = filtro == null ? _dbContext.Mantenimiento : _dbContext.Mantenimiento.Where(filtro);
            return queryEntidad;
        }
    }

}
