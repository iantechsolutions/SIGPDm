using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{

    public class MovimientosOTRepositorio : IMovimientosOTRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public MovimientosOTRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MovimientosOT>> Lista()
        {
            try
            {
                return await _dbContext.MovimientosOT
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<MovimientosOT> Obtener(Expression<Func<MovimientosOT, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.MovimientosOT
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<MovimientosOT> GetByOT(Expression<Func<MovimientosOT, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.MovimientosOT
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<MovimientosOT>> ObtenerMultiples(Expression<Func<MovimientosOT, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.MovimientosOT
                    .Where(filtro).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(MovimientosOT entidad)
        {
            try
            {
                _dbContext.MovimientosOT.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<MovimientosOT> Crear(MovimientosOT entidad)
        {
            try
            {
                _dbContext.Set<MovimientosOT>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(MovimientosOT entidad)
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
        public async Task<IQueryable<MovimientosOT>> Consultar(Expression<Func<MovimientosOT, bool>> filtro = null)
        {
            IQueryable<MovimientosOT> queryEntidad = filtro == null ? _dbContext.MovimientosOT : _dbContext.MovimientosOT.Where(filtro);
            return queryEntidad;
        }
    }

}
