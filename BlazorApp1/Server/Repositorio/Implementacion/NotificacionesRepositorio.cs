using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{

    public class NotificacionesRepositorio : INotificacionesRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public NotificacionesRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Notificaciones>> Lista()
        {
            try
            {
                return await _dbContext.Notificaciones
                   .OrderByDescending(x=>x.FechaCreacion)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Notificaciones> Obtener(Expression<Func<Notificaciones, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Notificaciones
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        
       
        public async Task<List<Notificaciones>> ObtenerMultiples(Expression<Func<Notificaciones, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Notificaciones
                    .Where(filtro).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Notificaciones entidad)
        {
            try
            {
                _dbContext.Notificaciones.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Notificaciones> Crear(Notificaciones entidad)
        {
            try
            {
                _dbContext.Set<Notificaciones>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Notificaciones entidad)
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
        public async Task<IQueryable<Notificaciones>> Consultar(Expression<Func<Notificaciones, bool>> filtro = null)
        {
            IQueryable<Notificaciones> queryEntidad = filtro == null ? _dbContext.Notificaciones : _dbContext.Notificaciones.Where(filtro);
            return queryEntidad;
        }
    }

}
