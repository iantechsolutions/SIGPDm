using BlazorApp1.Server.Context;
using BlazorApp1.Server.Models;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class PersonalRepositorio : IPersonalRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public PersonalRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Personal>> Lista()
        {
            try
            {
                return await _dbContext.Personals
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Personal> Obtener(Expression<Func<Personal, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Personals.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(Personal entidad)
        {
            try
            {
                _dbContext.Personals.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Personal> Crear(Personal entidad)
        {
            try
            {
                _dbContext.Set<Personal>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Personal entidad)
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
        public async Task<bool> Estado(Personal entidad)
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
        public async Task<IQueryable<Personal>> Consultar(Expression<Func<Personal, bool>> filtro = null)
        {
            IQueryable<Personal> queryEntidad = filtro == null ? _dbContext.Personals : _dbContext.Personals.Where(filtro);
            return queryEntidad;
        }
    }
}
