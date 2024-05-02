using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{

    public class FallasRepositorio : IFallasRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public FallasRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Fallas>> Lista()
        {
            try
            {
                return await _dbContext.Fallas.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Fallas> Obtener(Expression<Func<Fallas, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Fallas.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Fallas> GetByOT(Expression<Func<Fallas, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Fallas.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Fallas>> ObtenerMultiples(Expression<Func<Fallas, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Fallas.Where(filtro).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Fallas entidad)
        {
            try
            {
                _dbContext.Fallas.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Fallas> Crear(Fallas entidad)
        {
            try
            {
                _dbContext.Set<Fallas>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Fallas entidad)
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
        public async Task<IQueryable<Fallas>> Consultar(Expression<Func<Fallas, bool>> filtro = null)
        {
            IQueryable<Fallas> queryEntidad = filtro == null ? _dbContext.Fallas : _dbContext.Fallas.Where(filtro);
            return queryEntidad;
        }
    }

}
