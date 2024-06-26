﻿using BlazorApp1.Shared.Models; //cambiazo
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{
    public interface IProveedoreRepositorio
    {
        Task<List<Proveedore>> Lista();
        Task<Proveedore> Obtener(Expression<Func<Proveedore, bool>> filtro = null);
        Task<bool> Eliminar(Proveedore entidad);
        Task<Proveedore> Crear(Proveedore entidad);
        Task<bool> Editar(Proveedore entidad);
        Task<IQueryable<Proveedore>> Consultar(Expression<Func<Proveedore, bool>> filtro = null);
    }
}
