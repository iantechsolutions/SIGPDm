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
    public class MovimientosOTController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovimientosOTRepositorio _MovimientosOTRepositorio;
        public MovimientosOTController(IMovimientosOTRepositorio MovimientosOTRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _MovimientosOTRepositorio = MovimientosOTRepositorio;
        }


        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            Respuesta<MovimientosOT> oRespuesta = new();

            try
            {
                var listaMovimientosOT = await _MovimientosOTRepositorio.Obtener(x => x.Id == Id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<MovimientosOT>(listaMovimientosOT);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpGet("ot/{Id:int}")]
        public async Task<IActionResult> GetByOt(int Id)
        {
            Respuesta<MovimientosOT> oRespuesta = new();

            try
            {
                var listaMovimientosOT = await _MovimientosOTRepositorio.Obtener(x => x.OT == Id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<MovimientosOT>(listaMovimientosOT);
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
            Respuesta<List<MovimientosOT>> oRespuesta = new();

            try
            {
                var a = await _MovimientosOTRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<MovimientosOT>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost]
        public async Task<IActionResult> Add(MovimientosOT model)
        {

            Respuesta<MovimientosOT> oRespuesta = new();

            try
            {
                MovimientosOT oMovimientosOT = new();

                oMovimientosOT.Id = model.Id;
                oMovimientosOT.OT = model.OT;
                oMovimientosOT.EtapaOrigen = model.EtapaOrigen;
                oMovimientosOT.EtapaDestino = model.EtapaDestino;
                oMovimientosOT.Fecha = model.Fecha;



                await _MovimientosOTRepositorio.Crear(oMovimientosOT);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] MovimientosOT model)
        {
            Respuesta<MovimientosOT> oRespuesta = new();

            try
            {


                var oMovimientosOT = await _MovimientosOTRepositorio.Obtener(x => x.Id == model.Id);


                oMovimientosOT.Id = model.Id;
                oMovimientosOT.EtapaOrigen = model.EtapaOrigen;
                oMovimientosOT.EtapaDestino = model.EtapaDestino;
                oMovimientosOT.Fecha = model.Fecha;
                oMovimientosOT.OT = model.OT;


                await _MovimientosOTRepositorio.Editar(oMovimientosOT);
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
            Respuesta<MovimientosOT> oRespuesta = new();
            try
            {
                var oMovimientosOT = await _MovimientosOTRepositorio.Obtener(x => x.Id == Id);
                await _MovimientosOTRepositorio.Eliminar(oMovimientosOT);
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
