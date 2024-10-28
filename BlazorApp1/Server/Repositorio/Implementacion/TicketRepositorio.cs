//using BlazorApp1.Server.Context;
//using BlazorApp1.Server.Repositorio.Contrato;
//using BlazorApp1.Shared.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Linq.Dynamic.Core;
//using System.Linq.Expressions;

//namespace BlazorApp1.Server.Repositorio.Implementacion
//{

//    public class TicketsRepositorio : ITicketsRepositorio
//    {
//        private readonly DiMetalloContext _dbContext;

//        public TicketsRepositorio(DiMetalloContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public async Task<List<Tickets>> Lista()
//        {
//            DateTime hoy = DateTime.Now.Date;

//            try
//            {
//                var Tickets = await _dbContext.Tickets
//                    .OrderByDescending(x => x.FechaCreacion)
//                    .ToListAsync();

                

//                return Tickets;
//            }
//            catch
//            {
//                throw;
//            }
//        }
//        public async Task<Tickets> Obtener(Expression<Func<Tickets, bool>> filtro = null)
//        {
//            try
//            {
//                return await _dbContext.Tickets
//                    .Where(filtro)
//                    .FirstOrDefaultAsync();
//            }
//            catch
//            {
//                throw;
//            }
//        }
//        public async Task<Tickets> ObtenerByMaquina(Expression<Func<Tickets, bool>> filtro = null)
//        {
//            try
//            {
//                return await _dbContext.Tickets
//                    .Where(filtro)
//                    .FirstOrDefaultAsync();
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<List<Tickets>> ObtenerMultiples(Expression<Func<Tickets, bool>> filtro = null)
//        {
//            try
//            {
//                return await _dbContext.Tickets
//                    .Where(filtro).ToListAsync();
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<bool> Eliminar(Tickets entidad)
//        {
//            try
//            {
//                _dbContext.Tickets.Remove(entidad);
//                await _dbContext.SaveChangesAsync();
//                return true;
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<Tickets> Crear(Tickets entidad)
//        {
//            try
//            {
//                _dbContext.Set<Tickets>().Add(entidad);
//                await _dbContext.SaveChangesAsync();
//                return entidad;
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        public async Task<bool> Editar(Tickets entidad)
//        {
//            try
//            {
//                _dbContext.Update(entidad);
//                await _dbContext.SaveChangesAsync();
//                return true;
//            }
//            catch
//            {
//                throw;
//            }
//        }
//        public async Task<IQueryable<Tickets>> Consultar(Expression<Func<Tickets, bool>> filtro = null)
//        {
//            IQueryable<Tickets> queryEntidad = filtro == null ? _dbContext.Tickets : _dbContext.Tickets.Where(filtro);
//            return queryEntidad;
//        }
//    }

//}
