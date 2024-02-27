using BlazorApp1.Server.Repositorio.Contrato;
using System.Linq.Expressions;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models; //cambiazo
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class ProveedoreRepositorio : IProveedoreRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public ProveedoreRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Proveedore>> Lista()
        {
            try
            {
                return await _dbContext.Proveedores               
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Proveedore> Obtener(Expression<Func<Proveedore, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Proveedores.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(Proveedore entidad)
        {
            try
            {
                _dbContext.Proveedores.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Proveedore> Crear(Proveedore entidad)
        {
            try
            {
                _dbContext.Set<Proveedore>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Proveedore entidad)
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
        public async Task<IQueryable<Proveedore>> Consultar(Expression<Func<Proveedore, bool>> filtro = null)
        {
            IQueryable<Proveedore> queryEntidad = filtro == null ? _dbContext.Proveedores : _dbContext.Proveedores.Where(filtro);
            return queryEntidad;
        }
    }
}
