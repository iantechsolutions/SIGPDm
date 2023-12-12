using BlazorApp1.Server.Context;
using BlazorApp1.Server.Models;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class AspNetRoleRepositorio : IAspNetRoleRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public AspNetRoleRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<AspNetRole>> Lista()
        {
            try
            {
                return await _dbContext.AspNetRoles
                    .Include(x=>x.AspNetRoleClaims)
                    .Include(x=>x.AspNetUserRoles)                    
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<AspNetRole> Obtener(Expression<Func<AspNetRole, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.AspNetRoles.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(AspNetRole entidad)
        {
            try
            {
                _dbContext.AspNetRoles.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AspNetRole> Crear(AspNetRole entidad)
        {
            try
            {
                _dbContext.Set<AspNetRole>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(AspNetRole entidad)
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
        public async Task<IQueryable<AspNetRole>> Consultar(Expression<Func<AspNetRole, bool>> filtro = null)
        {
            IQueryable<AspNetRole> queryEntidad = filtro == null ? _dbContext.AspNetRoles : _dbContext.AspNetRoles.Where(filtro);
            return queryEntidad;
        }
    }
}
