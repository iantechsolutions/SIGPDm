using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using BlazorApp1.Server.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class EventosProduccionRepositorio : IEventosProduccionRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public EventosProduccionRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<EventosProduccion>> Lista()
        {
            try
            {
                return await _dbContext.EventosProduccions
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        

        public async Task<EventosProduccion> Obtener(Expression<Func<EventosProduccion, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.EventosProduccions.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(EventosProduccion entidad)
        {
            try
            {
                _dbContext.EventosProduccions.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<EventosProduccion> Crear(EventosProduccion entidad)
        {
            try
            {
                _dbContext.Set<EventosProduccion>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(EventosProduccion entidad)
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
        public async Task<IQueryable<EventosProduccion>> Consultar(Expression<Func<EventosProduccion, bool>> filtro = null)
        {
            IQueryable<EventosProduccion> queryEntidad = filtro == null ? _dbContext.EventosProduccions : _dbContext.EventosProduccions.Where(filtro);
            return queryEntidad;
        }
    }
}
