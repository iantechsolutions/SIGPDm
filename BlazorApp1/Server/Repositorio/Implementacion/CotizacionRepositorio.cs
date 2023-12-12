using BlazorApp1.Server.Context;
using BlazorApp1.Server.Models;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class CotizacionesRepositorio : ICotizacionesRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public CotizacionesRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Cotizacione>> Lista()
        {
            try
            {
                return await _dbContext.Cotizaciones
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Cotizacione> Obtener(Expression<Func<Cotizacione, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Cotizaciones.Where(filtro)                   
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(Cotizacione entidad)
        {
            try
            {
                _dbContext.Cotizaciones.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Cotizacione> Crear(Cotizacione entidad)
        {
            try
            {
                _dbContext.Set<Cotizacione>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Cotizacione entidad)
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
        public async Task<IQueryable<Cotizacione>> Consultar(Expression<Func<Cotizacione, bool>> filtro = null)
        {
            IQueryable<Cotizacione> queryEntidad = filtro == null ? _dbContext.Cotizaciones : _dbContext.Cotizaciones.Where(filtro);
            return queryEntidad;
        }
    }
}
