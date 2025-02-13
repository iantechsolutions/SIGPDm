using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{

    public class OrganigramaRepositorio : IOrganigramaRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public OrganigramaRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Organigrama>> Lista()
        {
            try
            {
                return await _dbContext.Organigrama
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Organigrama> Obtener(Expression<Func<Organigrama, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Organigrama
                    .Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
      
       
        public async Task<List<Organigrama>> ObtenerMultiples(Expression<Func<Organigrama, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Organigrama
                    .Where(filtro).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Organigrama entidad)
        {
            try
            {
                _dbContext.Organigrama.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Organigrama> Crear(Organigrama entidad)
        {
            try
            {
                _dbContext.Set<Organigrama>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Organigrama entidad)
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
        public async Task<IQueryable<Organigrama>> Consultar(Expression<Func<Organigrama, bool>> filtro = null)
        {
            IQueryable<Organigrama> queryEntidad = filtro == null ? _dbContext.Organigrama : _dbContext.Organigrama.Where(filtro);
            return queryEntidad;
        }
    }

}
