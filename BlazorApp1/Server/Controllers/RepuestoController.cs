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
    public class RepuestoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IRepuestoRepositorio _IRepuestoRepositorio;
        public RepuestoController(IRepuestoRepositorio IRepuestoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _IRepuestoRepositorio = IRepuestoRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<Repuesto> oRespuesta = new();

            try
            {
                var listaInsumo = await _IRepuestoRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Repuesto>(listaInsumo);
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
            Respuesta<List<Repuesto>> oRespuesta = new();

            try
            {
                var a = await _IRepuestoRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<Repuesto>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Repuesto model)
        {
            Respuesta<Repuesto> oRespuesta = new();

            try
            {                             

                Repuesto oRepuesto = new();

                oRepuesto.Id = model.Id;
                oRepuesto.StockMin = model.StockMin;
                oRepuesto.StockMax = model.StockMax;
                oRepuesto.StockReal = model.StockReal;
                oRepuesto.Nombre = model.Nombre;
                oRepuesto.Codigo = model.Codigo;
                oRepuesto.Foto = model.Foto;
                oRepuesto.Descripcion = model.Descripcion;

                await _IRepuestoRepositorio.Crear(oRepuesto);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Repuesto model)
        {
            Respuesta<Repuesto> oRespuesta = new();

            try
            {
                var oRepuesto = await _IRepuestoRepositorio.Obtener(x => x.Id == model.Id);

                oRepuesto.Id = model.Id;
                oRepuesto.StockMin = model.StockMin;
                oRepuesto.StockMax = model.StockMax;
                oRepuesto.StockReal = model.StockReal;
                oRepuesto.Nombre = model.Nombre;
                oRepuesto.Codigo = model.Codigo;
                oRepuesto.Foto = model.Foto;
                oRepuesto.Descripcion = model.Descripcion;

                await _IRepuestoRepositorio.Editar(oRepuesto);
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
            Respuesta<Repuesto> oRespuesta = new();
            try
            {
                var oRepuesto = await _IRepuestoRepositorio.Obtener(x => x.Id == Id);
                await _IRepuestoRepositorio.Eliminar(oRepuesto);
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
