using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
  
    public class LoteRepositorio : ILoteRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public LoteRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Lotes>> Lista()
        {
            try
            {
                return await _dbContext.Lotes
                   .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Lotes> Obtener(Expression<Func<Lotes, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Insumos.Where(filtro)
                     .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(Lotes entidad)
        {
            try
            {
                _dbContext.Lotes.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Lotes> Crear(Lotes entidad)
        {
            try
            {
                _dbContext.Set<Lotes>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Lotes entidad)
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
        public async Task<IQueryable<Lotes>> Consultar(Expression<Func<Lotes, bool>> filtro = null)
        {
            IQueryable<Lotes> queryEntidad = filtro == null ? _dbContext.Lotes : _dbContext.Lotes.Where(filtro);
            return queryEntidad;
        }
    }
   
}
