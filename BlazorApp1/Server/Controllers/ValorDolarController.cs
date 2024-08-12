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
    public class ValorDolarController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IValorDolarRepositorio _IValorDolarRepositorio;
        public ValorDolarController(IValorDolarRepositorio IValorDolarRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _IValorDolarRepositorio = IValorDolarRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<ValorDolar> oRespuesta = new();

            try
            {
                var listaValorDolar = await _IValorDolarRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<ValorDolar>(listaValorDolar);
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
            Respuesta<List<ValorDolar>> oRespuesta = new();

            try
            {
                var a = await _IValorDolarRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<ValorDolar>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpGet("esDeValorDolarUnico{id:int}")]
        

        [HttpPost]
        public async Task<IActionResult> Add(ValorDolar model)
        {

            Respuesta<ValorDolar> oRespuesta = new();

            try
            {
                ValorDolar oValorDolar = new();

                oValorDolar.Fecha = model.Fecha;
                oValorDolar.Valor = model.Valor;



                await _IValorDolarRepositorio.Crear(oValorDolar);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(ValorDolar model)
        {
            Respuesta<ValorDolar> oRespuesta = new();

            try
            {


                var oValorDolar = await _IValorDolarRepositorio.Obtener(x => x.Id == model.Id);

                oValorDolar.Fecha = model.Fecha;
                oValorDolar.Valor = model.Valor;



                await _IValorDolarRepositorio.Editar(oValorDolar);
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
            Respuesta<ValorDolar> oRespuesta = new();
            try
            {
                var oValorDolar = await _IValorDolarRepositorio.Obtener(x => x.Id == Id);
                await _IValorDolarRepositorio.Eliminar(oValorDolar);
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
