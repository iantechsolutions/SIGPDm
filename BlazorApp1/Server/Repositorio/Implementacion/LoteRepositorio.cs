using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
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
        public async Task<List<Lote>> Lista()
        {
            try
            {
                return await _dbContext.Lotes.Include(x =>x.insumoNavigation).Where(x => x.Estado != "Desaprobado" && x.Estado != "En observacion")
                  .ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Lote> Obtener(Expression<Func<Lote, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Lotes.Include(x => x.insumoNavigation).Where(filtro)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Lote>> ObtenerMultiples(Expression<Func<Lote, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Lotes.Include(x => x.insumoNavigation).Where(filtro).Where(x => x.Estado != "Desaprobado" && x.Estado != "En observacion").ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Lote entidad)
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

        public async Task<Lote> Crear(Lote entidad)
        {
            try
            {
                _dbContext.Set<Lote>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Lote entidad)
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
        public async Task<IQueryable<Lote>> Consultar(Expression<Func<Lote, bool>> filtro = null)
        {
            IQueryable<Lote> queryEntidad = filtro == null ? _dbContext.Lotes : _dbContext.Lotes.Where(filtro);
            return queryEntidad;
        }

        public async Task<List<Lote>> ObtenerFaltantes()
        {
            try
            {
                return await _dbContext.Lotes.Include(x => x.insumoNavigation).Where(x => x.Estado == "Desaprobado" || x.Estado == "En observacion").ToListAsync();
            }
            catch
            {
                throw;
            }
        }

    }
   
}
