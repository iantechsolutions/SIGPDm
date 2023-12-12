using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using BlazorApp1.Server.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class OTRepositorio : IOTRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public OTRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Ordentrabajo>> Lista()
        {
            try
            {
                return await _dbContext.Ordentrabajos
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Ordentrabajo> Obtener(Expression<Func<Ordentrabajo, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Ordentrabajos.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(Ordentrabajo entidad)
        {
            try
            {
                _dbContext.Ordentrabajos.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Ordentrabajo>> GetForEtapa(string etapa)
        {
           return await _dbContext.Ordentrabajos.Where(x => x.Estado == etapa)
                .ToListAsync();


        } 

        public async Task<Ordentrabajo> Crear(Ordentrabajo entidad)
        {
            try
            {
                _dbContext.Set<Ordentrabajo>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Ordentrabajo entidad)
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
        public async Task<IQueryable<Ordentrabajo>> Consultar(Expression<Func<Ordentrabajo, bool>> filtro = null)
        {
            IQueryable<Ordentrabajo> queryEntidad = filtro == null ? _dbContext.Ordentrabajos : _dbContext.Ordentrabajos.Where(filtro);
            return queryEntidad;
        }
    }
}
