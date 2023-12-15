using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
   /* public class LoteRepositorio : ILoteRepositorio
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
                Lotes lote = await _dbContext.Insumos.Include(x=>x.Lotes).ToListAsync();               
                return lote;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Cliente> Obtener(Expression<Func<Cliente, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Clientes.Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(Cliente entidad)
        {
            try
            {
                _dbContext.Clientes.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Cliente> Crear(Cliente entidad)
        {
            try
            {
                _dbContext.Set<Cliente>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Cliente entidad)
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
        public async Task<IQueryable<Cliente>> Consultar(Expression<Func<Cliente, bool>> filtro = null)
        {
            IQueryable<Cliente> queryEntidad = filtro == null ? _dbContext.Clientes : _dbContext.Clientes.Where(filtro);
            return queryEntidad;
        }
    }
   */
}
