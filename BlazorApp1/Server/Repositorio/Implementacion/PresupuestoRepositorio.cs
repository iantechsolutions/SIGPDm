using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Server.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class PresupuestoRepositorio : IPresupuestoRepositorio
    {
        private readonly DiMetalloContext _dbContext;

        public PresupuestoRepositorio(DiMetalloContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Presupuesto>> Lista()
        {
            try
            {
                var coso = _dbContext.Presupuestos.ToList();
                Console.WriteLine(coso);
                return await _dbContext.Presupuestos
                    //.Include(e => e.InfoInsumoNavigation)
                    .Include(e => e.InsumoNavigation)
                    .Include(e => e.ProveedorNavigation)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }


        public async Task<Presupuesto> Obtener(Expression<Func<Presupuesto, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Presupuestos.Where(filtro)
                    //.include(e => e.infoinsumonavigation)
                    .Include(e => e.InsumoNavigation)
                    .Include(e => e.ProveedorNavigation)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Eliminar(Presupuesto entidad)
        {
            try
            {
                _dbContext.Presupuestos.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Presupuesto> Crear(Presupuesto entidad)
        {
            try
            {
                _dbContext.Set<Presupuesto>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Presupuesto entidad)
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
        public async Task<IQueryable<Presupuesto>> Consultar(Expression<Func<Presupuesto, bool>> filtro = null)
        {
            IQueryable<Presupuesto> queryEntidad = filtro == null ? _dbContext.Presupuestos : _dbContext.Presupuestos.Where(filtro);
            return queryEntidad;
        }
    }
}


