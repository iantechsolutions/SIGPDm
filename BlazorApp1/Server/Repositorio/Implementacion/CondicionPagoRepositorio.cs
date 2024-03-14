using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{

    public class CondicionPagoRepositorio : ICondicionPagoRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public CondicionPagoRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CondicionPago>> Lista()
        {
            try
            {
                return await _dbContext.CondicionPago
                  .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<CondicionPago> Obtener(Expression<Func<CondicionPago, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.CondicionPago.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<CondicionPago>> ObtenerMultiples(Expression<Func<CondicionPago, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.CondicionPago.Where(filtro).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(CondicionPago entidad)
        {
            try
            {
                _dbContext.CondicionPago.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CondicionPago> Crear(CondicionPago entidad)
        {
            try
            {
                _dbContext.Set<CondicionPago>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CondicionPago entidad)
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
        public async Task<IQueryable<CondicionPago>> Consultar(Expression<Func<CondicionPago, bool>> filtro = null)
        {
            IQueryable<CondicionPago> queryEntidad = filtro == null ? _dbContext.CondicionPago : _dbContext.CondicionPago.Where(filtro);
            return queryEntidad;
        }
    }

}
