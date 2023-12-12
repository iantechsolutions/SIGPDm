using BlazorApp1.Server.Context;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Implementacion
{
    public class RepuestoRepositorio : IRepuestoRepositorio
    { 

         private readonly DiMetalloContext _dbContext;

    public RepuestoRepositorio(DiMetalloContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Repuesto>> Lista()
    {
        try
        {
            return await _dbContext.Repuestos                
                .ToListAsync();
        }
        catch
        {
            throw;
        }
    }
    public async Task<Repuesto> Obtener(Expression<Func<Repuesto, bool>> filtro = null)
    {
        try
        {
            return await _dbContext.Repuestos.Where(filtro)
                .FirstOrDefaultAsync();
        }
        catch
        {
            throw;
        }
    }
    public async Task<bool> Eliminar(Repuesto entidad)
    {
        try
        {
            _dbContext.Repuestos.Remove(entidad);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Repuesto> Crear(Repuesto entidad)
    {
        try
        {
            _dbContext.Set<Repuesto>().Add(entidad);
            await _dbContext.SaveChangesAsync();
            return entidad;
        }
        catch
        {
            throw;
        }
    }

    public async Task<bool> Editar(Repuesto entidad)
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
    public async Task<IQueryable<Repuesto>> Consultar(Expression<Func<Repuesto, bool>> filtro = null)
    {
        IQueryable<Repuesto> queryEntidad = filtro == null ? _dbContext.Repuestos : _dbContext.Repuestos.Where(filtro);
        return queryEntidad;
    }
}
}
