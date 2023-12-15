using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using BlazorApp1.Server.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class MaquinasRepositorio : IMaquinasRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public MaquinasRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<MaquinasHerramienta>> Lista()
        {
            try
            {
                return await _dbContext.MaquinasHerramientas                    
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<MaquinasHerramienta> Obtener(Expression<Func<MaquinasHerramienta, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.MaquinasHerramientas.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(MaquinasHerramienta entidad)
        {
            try
            {
                _dbContext.MaquinasHerramientas.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<MaquinasHerramienta> Crear(MaquinasHerramienta entidad)
        {
            try
            {
                _dbContext.Set<MaquinasHerramienta>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(MaquinasHerramienta entidad)
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
        public async Task<IQueryable<MaquinasHerramienta>> Consultar(Expression<Func<MaquinasHerramienta, bool>> filtro = null)
        {
            IQueryable<MaquinasHerramienta> queryEntidad = filtro == null ? _dbContext.MaquinasHerramientas : _dbContext.MaquinasHerramientas.Where(filtro);
            return queryEntidad;
        }
    }
}
