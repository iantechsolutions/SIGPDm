using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{

    public class RecepcionesHistoricasRepositorio : IRecepcionesHistoricasRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public RecepcionesHistoricasRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<RecepcionesHistoricas>> Lista()
        {
            try
            {
                return await _dbContext.RecepcionesHistoricas
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<RecepcionesHistoricas> Obtener(Expression<Func<RecepcionesHistoricas, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.RecepcionesHistoricas
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
       
        public async Task<bool> Eliminar(RecepcionesHistoricas entidad)
        {
            try
            {
                _dbContext.RecepcionesHistoricas.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RecepcionesHistoricas> Crear(RecepcionesHistoricas entidad)
        {
            try
            {
                _dbContext.Set<RecepcionesHistoricas>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(RecepcionesHistoricas entidad)
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
        public async Task<IQueryable<RecepcionesHistoricas>> Consultar(Expression<Func<RecepcionesHistoricas, bool>> filtro = null)
        {
            IQueryable<RecepcionesHistoricas> queryEntidad = filtro == null ? _dbContext.RecepcionesHistoricas : _dbContext.RecepcionesHistoricas.Where(filtro);
            return queryEntidad;
        }
    }

}
