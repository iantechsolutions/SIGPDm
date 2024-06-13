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
    public class RecepcionesHistoricasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRecepcionesHistoricasRepositorio _RecepcionesHistoricasRepositorio;
        public RecepcionesHistoricasController(IRecepcionesHistoricasRepositorio RecepcionesHistoricasRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _RecepcionesHistoricasRepositorio = RecepcionesHistoricasRepositorio;
        }


        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            Respuesta<RecepcionesHistoricas> oRespuesta = new();

            try
            {
                var listaRecepcionesHistoricas = await _RecepcionesHistoricasRepositorio.Obtener(x => x.Id == Id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<RecepcionesHistoricas>(listaRecepcionesHistoricas);
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
            Respuesta<List<RecepcionesHistoricas>> oRespuesta = new();

            try
            {
                var a = await _RecepcionesHistoricasRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<RecepcionesHistoricas>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost]
        public async Task<IActionResult> Add(RecepcionesHistoricas model)
        {

            Respuesta<RecepcionesHistoricas> oRespuesta = new();

            try
            {
                RecepcionesHistoricas oRecepcionesHistoricas = new();

                oRecepcionesHistoricas.Cantidad = model.Cantidad;
                oRecepcionesHistoricas.Fecha = model.Fecha;
                oRecepcionesHistoricas.NroRemito = model.NroRemito;
                oRecepcionesHistoricas.CondicionEntrada = model.CondicionEntrada;
                oRecepcionesHistoricas.PrecioCotizado = model.PrecioCotizado;
                oRecepcionesHistoricas.Insumo = model.Insumo;
                oRecepcionesHistoricas.Presupuesto = model.Presupuesto;


                await _RecepcionesHistoricasRepositorio.Crear(oRecepcionesHistoricas);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] RecepcionesHistoricas model)
        {
            Respuesta<RecepcionesHistoricas> oRespuesta = new();

            try
            {


                var oRecepcionesHistoricas = await _RecepcionesHistoricasRepositorio.Obtener(x => x.Id == model.Id);


                oRecepcionesHistoricas.Id = model.Id;
                oRecepcionesHistoricas.Cantidad = model.Cantidad;
                oRecepcionesHistoricas.Fecha = model.Fecha;
                oRecepcionesHistoricas.NroRemito = model.NroRemito;
                oRecepcionesHistoricas.CondicionEntrada = model.CondicionEntrada;
                oRecepcionesHistoricas.PrecioCotizado = model.PrecioCotizado;
                oRecepcionesHistoricas.Insumo = model.Insumo;
                oRecepcionesHistoricas.Presupuesto = model.Presupuesto;


                await _RecepcionesHistoricasRepositorio.Editar(oRecepcionesHistoricas);
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
            Respuesta<RecepcionesHistoricas> oRespuesta = new();
            try
            {
                var oRecepcionesHistoricas = await _RecepcionesHistoricasRepositorio.Obtener(x => x.Id == Id);
                await _RecepcionesHistoricasRepositorio.Eliminar(oRecepcionesHistoricas);
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
