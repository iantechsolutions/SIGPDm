﻿using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Shared.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Server.Repositorio.Contrato
{

    public interface IInsumoRepositorio
    {
        Task<List<Insumo>> Lista();
        Task<Insumo> Obtener(Expression<Func<Insumo, bool>> filtro = null);
        Task<bool> Eliminar(Insumo entidad);
        Task<Insumo> Crear(Insumo entidad);
        Task<bool> Editar(Insumo entidad);
        Task<IQueryable<Insumo>> Consultar(Expression<Func<Insumo, bool>> filtro = null);


    }
}
