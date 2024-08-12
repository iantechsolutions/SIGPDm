using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{

    public class ValorDolarRepositorio : IValorDolarRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public ValorDolarRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ValorDolar>> Lista()
        {
            try
            {
                return await _dbContext.ValorDolar
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<ValorDolar> Obtener(Expression<Func<ValorDolar, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.ValorDolar
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<ValorDolar> ObtenerByInsumo(Expression<Func<ValorDolar, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.ValorDolar
                    .Where(filtro)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<ValorDolar> GetByOT(Expression<Func<ValorDolar, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.ValorDolar
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<ValorDolar>> ObtenerMultiples(Expression<Func<ValorDolar, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.ValorDolar
                    .Where(filtro).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(ValorDolar entidad)
        {
            try
            {
                _dbContext.ValorDolar.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ValorDolar> Crear(ValorDolar entidad)
        {
            try
            {
                _dbContext.Set<ValorDolar>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ValorDolar entidad)
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
        public async Task<IQueryable<ValorDolar>> Consultar(Expression<Func<ValorDolar, bool>> filtro = null)
        {
            IQueryable<ValorDolar> queryEntidad = filtro == null ? _dbContext.ValorDolar : _dbContext.ValorDolar.Where(filtro);
            return queryEntidad;
        }
    }

}
