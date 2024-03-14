using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Server.Repositorio.Implementacion;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMaquinasRepositorio _IMaquinasRepositorio;
        public MaquinasController(IMaquinasRepositorio IMaquinasRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _IMaquinasRepositorio = IMaquinasRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<MaquinasHerramienta> oRespuesta = new();

            try
            {
                var listaInsumo = await _IMaquinasRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<MaquinasHerramienta>(listaInsumo);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Respuesta<List<MaquinasHerramienta>> oRespuesta = new();

            try
            {
                var a = await _IMaquinasRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<MaquinasHerramienta>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MaquinasHerramienta model)
        {
            Respuesta<MaquinasHerramienta> oRespuesta = new();

            try
            {
                MaquinasHerramienta oMaquinasHerramienta = new();

                oMaquinasHerramienta.Id = model.Id;
                oMaquinasHerramienta.Marca = model.Marca;
                oMaquinasHerramienta.Nombre = model.Nombre;
                oMaquinasHerramienta.FechaIngreso = model.FechaIngreso;
                oMaquinasHerramienta.Codigo = model.Codigo;
                oMaquinasHerramienta.Asignacion = model.Asignacion;
                oMaquinasHerramienta.PeriodicidadMantenimiento = model.PeriodicidadMantenimiento;
                oMaquinasHerramienta.DescripcionMantenimiento = model.DescripcionMantenimiento;
                oMaquinasHerramienta.Estado = model.Estado;
                oMaquinasHerramienta.MotivoEstado = model.MotivoEstado;
                oMaquinasHerramienta.Disposicion = model.Disposicion;
                oMaquinasHerramienta.MotivoDisposicion = model.MotivoDisposicion;
                oMaquinasHerramienta.Descripcion = model.Descripcion;
                oMaquinasHerramienta.UltimoMant = model.UltimoMant;


                await _IMaquinasRepositorio.Crear(oMaquinasHerramienta);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(MaquinasHerramienta model)
        {
            Respuesta<MaquinasHerramienta> oRespuesta = new();

            try
            {
                var oMaquinasHerramienta = await _IMaquinasRepositorio.Obtener(x => x.Id == model.Id);

                oMaquinasHerramienta.Id = model.Id;
                oMaquinasHerramienta.Marca = model.Marca;
                oMaquinasHerramienta.Nombre = model.Nombre;
                oMaquinasHerramienta.FechaIngreso = model.FechaIngreso;
                oMaquinasHerramienta.Codigo = model.Codigo;
                oMaquinasHerramienta.Asignacion = model.Asignacion;
                oMaquinasHerramienta.PeriodicidadMantenimiento = model.PeriodicidadMantenimiento;
                oMaquinasHerramienta.DescripcionMantenimiento = model.DescripcionMantenimiento;
                oMaquinasHerramienta.Estado = model.Estado;
                oMaquinasHerramienta.MotivoEstado = model.MotivoEstado;
                oMaquinasHerramienta.Disposicion = model.Disposicion;
                oMaquinasHerramienta.MotivoDisposicion = model.MotivoDisposicion;
                oMaquinasHerramienta.Descripcion = model.Descripcion;
                oMaquinasHerramienta.UltimoMant = model.UltimoMant;
                await _IMaquinasRepositorio.Editar(oMaquinasHerramienta);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            Respuesta<MaquinasHerramienta> oRespuesta = new();
            try
            {
                var oMaquinasHerramienta = await _IMaquinasRepositorio.Obtener(x => x.Id == Id);
                await _IMaquinasRepositorio.Eliminar(oMaquinasHerramienta);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }
    }
}
