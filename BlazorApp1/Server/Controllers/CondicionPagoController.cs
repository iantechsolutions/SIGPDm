using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Implementacion;
using BlazorApp1.Server.Repositorio.Contrato;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionPagoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICondicionPagoRepositorio _ICondicionPagoRepositorio;
        public CondicionPagoController(ICondicionPagoRepositorio ICondicionPagoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _ICondicionPagoRepositorio = ICondicionPagoRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<CondicionPago> oRespuesta = new();

            try
            {
                var lst = await _ICondicionPagoRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<CondicionPago>(lst);
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
            Respuesta<List<CondicionPago>> oRespuesta = new();

            try
            {
                var lst = await _ICondicionPagoRepositorio.Lista();


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = lst.ToList();
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CondicionPago model)
        {
            Respuesta<CondicionPago> oRespuesta = new();

            try
            {


                CondicionPago oCondicionPago = new();

                oCondicionPago.Id = model.Id;
                oCondicionPago.Nombre = model.Nombre;






                await _ICondicionPagoRepositorio.Crear(oCondicionPago);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(CondicionPago model)
        {
            Respuesta<CondicionPago> oRespuesta = new();

            try
            {
                var oCondicionPago = await _ICondicionPagoRepositorio.Obtener(x => x.Id == model.Id);
                
                oCondicionPago.Id = model.Id;
                oCondicionPago.Nombre = model.Nombre;

                await _ICondicionPagoRepositorio.Editar(oCondicionPago);
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
            Respuesta<CondicionPago> oRespuesta = new();
            try
            {
                var oCondicionPago = await _ICondicionPagoRepositorio.Obtener(x => x.Id == Id);
                await _ICondicionPagoRepositorio.Eliminar(oCondicionPago);
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
