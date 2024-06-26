﻿using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IPrestamoRepositorio
    {
        Task<List<Prestamo>> Lista();
        Task<Prestamo> Obtener(Expression<Func<Prestamo, bool>> filtro = null);
        Task<bool> Eliminar(Prestamo entidad);
        Task<Prestamo> Crear(Prestamo entidad);    
        Task<List<Prestamo>>ObtenerMultiples(Expression<Func<Prestamo, bool>> filtro = null);
        Task<bool> Editar(Prestamo entidad);
        Task<IQueryable<Prestamo>> Consultar(Expression<Func<Prestamo, bool>> filtro = null);


    }
}
