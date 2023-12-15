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
    public class CotizacionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICotizacionesRepositorio _ICotizacionesRepositorio;
        public CotizacionController(ICotizacionesRepositorio ICotizacionesRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _ICotizacionesRepositorio = ICotizacionesRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<Cotizacione> oRespuesta = new();

            try
            {
                var listaInsumo = await _ICotizacionesRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Cotizacione>(listaInsumo);
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
            Respuesta<List<Cotizacione>> oRespuesta = new();

            try
            {
                var lst = await _ICotizacionesRepositorio.Lista();


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
        public async Task<IActionResult> Add(Cotizacione model)
        {
            Respuesta<Cotizacione> oRespuesta = new();

            try
            {
                

                Cotizacione oCotizacione = new();

                oCotizacione.Id = model.Id;
                oCotizacione.Cliente = model.Cliente;
                oCotizacione.Titulo = model.Titulo;
                oCotizacione.Descripcion = model.Descripcion;
                oCotizacione.Alcance = model.Alcance;
                oCotizacione.Tratamientosuperficial = model.Tratamientosuperficial;
                oCotizacione.Color = model.Color;
                oCotizacione.Valorpeso = model.Valorpeso;
                oCotizacione.Valordolar = model.Valordolar;
                oCotizacione.Estado = model.Estado;
                oCotizacione.Planos = model.Planos;
                oCotizacione.Codigo = model.Codigo;
                oCotizacione.Cantidad = model.Cantidad;
                oCotizacione.Observaciones = model.Observaciones;
                oCotizacione.Fechaentrega = model.Fechaentrega;
                oCotizacione.Obra = model.Obra;
                oCotizacione.Referencia = model.Referencia;



                await _ICotizacionesRepositorio.Crear(oCotizacione);
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
        public async Task<IActionResult> Edit(Cotizacione model)
        {
            Respuesta<Cotizacione> oRespuesta = new();

            try
            {
                var oCotizacione = await _ICotizacionesRepositorio.Obtener(x => x.Id == model.Id);

                oCotizacione.Id = model.Id;
                oCotizacione.Cliente = model.Cliente;
                oCotizacione.Titulo = model.Titulo;
                oCotizacione.Descripcion = model.Descripcion;
                oCotizacione.Alcance = model.Alcance;
                oCotizacione.Tratamientosuperficial = model.Tratamientosuperficial;
                oCotizacione.Color = model.Color;
                oCotizacione.Valorpeso = model.Valorpeso;
                oCotizacione.Valordolar = model.Valordolar;
                oCotizacione.Estado = model.Estado;
                oCotizacione.Planos = model.Planos;
                oCotizacione.Codigo = model.Codigo;
                oCotizacione.Cantidad = model.Cantidad;
                oCotizacione.Observaciones = model.Observaciones;
                oCotizacione.Fechaentrega = model.Fechaentrega;
                oCotizacione.Obra = model.Obra;
                oCotizacione.Referencia = model.Referencia;

                await _ICotizacionesRepositorio.Editar(oCotizacione);
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
            Respuesta<Cotizacione> oRespuesta = new();
            try
            {
                var oCotizacione = await _ICotizacionesRepositorio.Obtener(x => x.Id == Id);
                await _ICotizacionesRepositorio.Eliminar(oCotizacione);
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
