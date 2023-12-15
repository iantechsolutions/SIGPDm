using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class MateriaPrimaRepositorio : IMateriaPrimaRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public MateriaPrimaRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MateriaPrima>> Lista()
        {
            try
            {
                return await _dbContext.MateriaPrimas
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<MateriaPrima> Obtener(Expression<Func<MateriaPrima, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.MateriaPrimas.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(MateriaPrima entidad)
        {
            try
            {
                _dbContext.MateriaPrimas.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<MateriaPrima> Crear(MateriaPrima entidad)
        {
            try
            {
                _dbContext.Set<MateriaPrima>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(MateriaPrima entidad)
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
        public async Task<IQueryable<MateriaPrima>> Consultar(Expression<Func<MateriaPrima, bool>> filtro = null)
        {
            IQueryable<MateriaPrima> queryEntidad = filtro == null ? _dbContext.MateriaPrimas : _dbContext.MateriaPrimas.Where(filtro);
            return queryEntidad;
        }
    }
}
