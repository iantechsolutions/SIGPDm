using BlazorApp1.Server.Context;
using BlazorApp1.Server.Models;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Server.Services;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{  
        public class PrestamoRepositorio : IPrestamoRepositorio
    {
            private readonly DiMetalloContext _dbContext;
               
            public PrestamoRepositorio(DiMetalloContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<List<Prestamo>> Lista()
            {
                try
                {
                    return await _dbContext.Prestamos
                      .ToListAsync();
                }
                catch
                {
                    throw;
                }
            }
            public async Task<Prestamo> Obtener(Expression<Func<Prestamo, bool>> filtro = null)
            {
                try
                {
                    return await _dbContext.Prestamos.Where(filtro)
                        .FirstOrDefaultAsync();
                }
                catch
                {
                    throw;
                }
            }
            

            public async Task<bool> Eliminar(Prestamo entidad)
            {
                try
                {
                    _dbContext.Prestamos.Remove(entidad);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    throw;
                }
            }
        public async Task<List<Prestamo>> ObtenerMultiples(Expression<Func<Prestamo, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Prestamos.Where(filtro).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Prestamo> Crear(Prestamo entidad)
            {
                try
                {
                    _dbContext.Set<Prestamo>().Add(entidad);
                    await _dbContext.SaveChangesAsync();
                    return entidad;
                }
                catch
                {
                    throw;
                }
            }

            public async Task<bool> Editar(Prestamo entidad)
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
            public async Task<IQueryable<Prestamo>> Consultar(Expression<Func<Prestamo, bool>> filtro = null)
            {
                IQueryable<Prestamo> queryEntidad = filtro == null ? _dbContext.Prestamos : _dbContext.Prestamos.Where(filtro);
                return queryEntidad;
            }
        }
}

