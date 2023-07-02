using BlazorApp1.Server.Context;
using BlazorApp1.Server.Models;
using BlazorApp1.Server.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class OCRepositorio : IOCRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public OCRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Ordencompra>> Lista()
        {
            try
            {
                return await _dbContext.Ordencompras.ToListAsync();
            }
            catch
            {
                throw;
            }
        }


        public async Task<Ordencompra> Obtener(Expression<Func<Ordencompra, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Ordencompras.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(Ordencompra entidad)
        {
            try
            {
                _dbContext.Ordencompras.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Ordencompra> Crear(Ordencompra entidad)
        {
            try
            {
                _dbContext.Set<Ordencompra>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Ordencompra entidad)
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
        public async Task<IQueryable<Ordencompra>> Consultar(Expression<Func<Ordencompra, bool>> filtro = null)
        {
            IQueryable<Ordencompra> queryEntidad = filtro == null ? _dbContext.Ordencompras : _dbContext.Ordencompras.Where(filtro);
            return queryEntidad;
        }
    }
}

