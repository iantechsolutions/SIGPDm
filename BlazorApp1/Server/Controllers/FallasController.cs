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
    public class FallasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFallasRepositorio _FallasRepositorio;
        public FallasController(IFallasRepositorio FallasRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _FallasRepositorio = FallasRepositorio;
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<Fallas> oRespuesta = new();

            try
            {
                var listaFallas = await _FallasRepositorio.Obtener(x => x.id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Fallas>(listaFallas);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpGet("ot/{id:int}")]
        public async Task<IActionResult> GetByOt(int id)
        {
            Respuesta<Fallas> oRespuesta = new();

            try
            {
                var listaFallas = await _FallasRepositorio.Obtener(x => x.OT == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Fallas>(listaFallas);
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
            Respuesta<List<Fallas>> oRespuesta = new();

            try
            {
                var a = await _FallasRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<Fallas>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost]
        public async Task<IActionResult> Add(Fallas model)
        {

            Respuesta<Fallas> oRespuesta = new();

            try
            {
                Fallas oFallas = new();

                oFallas.id = model.id;
                oFallas.empleado = model.empleado;
                oFallas.fecha = model.fecha;
                oFallas.observacion = model.observacion;
                oFallas.etapa = model.etapa;
                oFallas.OT = model.OT;
                oFallas.codigo = model.codigo;
                oFallas.correccion = model.correccion;



                await _FallasRepositorio.Crear(oFallas);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Fallas model)
        {
            Respuesta<Fallas> oRespuesta = new();

            try
            {


                var oFallas = await _FallasRepositorio.Obtener(x => x.id == model.id);

                oFallas.empleado = model.empleado;
                oFallas.fecha = model.fecha;
                oFallas.observacion = model.observacion;
                oFallas.etapa = model.etapa;
                oFallas.OT = model.OT;
                oFallas.codigo = model.codigo;
                oFallas.correccion = model.correccion;


                await _FallasRepositorio.Editar(oFallas);
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
            Respuesta<Fallas> oRespuesta = new();
            try
            {
                var oFallas = await _FallasRepositorio.Obtener(x => x.id == Id);
                await _FallasRepositorio.Eliminar(oFallas);
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
