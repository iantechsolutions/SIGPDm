using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BlazorApp1.Shared.Models; //cambiazo
using AutoMapper;
using BlazorApp1.Server.Repositorio.Implementacion;
using BlazorApp1.Server.Repositorio.Contrato;


namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMantenimientoRepositorio _MantenimientoRepositorio;
        public MantenimientoController(IMantenimientoRepositorio MantenimientoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _MantenimientoRepositorio = MantenimientoRepositorio;
        }


        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            Respuesta<Mantenimiento> oRespuesta = new();

            try
            {
                var listaMantenimiento = await _MantenimientoRepositorio.Obtener(x => x.Id == Id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Mantenimiento>(listaMantenimiento);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("maquina/{Id:int}")]
        public async Task<IActionResult> GetByInsumo(int id)
        {
            Respuesta<List<Mantenimiento>> oRespuesta = new();

            try
            {
                var listaMantenimiento = await _MantenimientoRepositorio.ObtenerMultiple(x => x.Maquina == id);

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<Mantenimiento>>(listaMantenimiento);
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
            Respuesta<List<Mantenimiento>> oRespuesta = new();

            try
            {
                var a = await _MantenimientoRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<Mantenimiento>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost]
        public async Task<IActionResult> Add(Mantenimiento model)
        {

            Respuesta<Mantenimiento> oRespuesta = new();

            try
            {
                Mantenimiento oMantenimiento = new();
                oMantenimiento.Id = model.Id;

                oMantenimiento.Cantidad = model.Cantidad;
                oMantenimiento.Maquina = model.Maquina;
                oMantenimiento.Name = model.Name;
                oMantenimiento.Fecha = model.Fecha;
                oMantenimiento.Etapas = model.Etapas;
                oMantenimiento.Detalle = model.Detalle;
                oMantenimiento.Personal = model.Personal;
                oMantenimiento.Insumo = model.Insumo;








                await _MantenimientoRepositorio.Crear(oMantenimiento);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Mantenimiento model)
        {
            Respuesta<Mantenimiento> oRespuesta = new();

            try
            {


                var oMantenimiento = await _MantenimientoRepositorio.Obtener(x => x.Id == model.Id);

                oMantenimiento.Id = model.Id;
                oMantenimiento.Cantidad = model.Cantidad;
                oMantenimiento.Maquina = model.Maquina;
                oMantenimiento.Name = model.Name;
                oMantenimiento.Fecha = model.Fecha;
                oMantenimiento.Etapas = model.Etapas;
                oMantenimiento.Detalle = model.Detalle;
                oMantenimiento.Insumo = model.Insumo;



                await _MantenimientoRepositorio.Editar(oMantenimiento);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            Respuesta<Mantenimiento> oRespuesta = new();
            try
            {
                var oMantenimiento = await _MantenimientoRepositorio.Obtener(x => x.Id == Id);
                await _MantenimientoRepositorio.Eliminar(oMantenimiento);
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
