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
using BlazorApp1.Server.Services;

namespace BlazorApp1.Server.Controllers
{
    

        [Route("api/[controller]")]
        [ApiController]
        public class PrestamoController : ControllerBase
        {
            private readonly IMapper _mapper;
            private readonly IPrestamoRepositorio _IPrestamoRepositorio;
            public PrestamoController(IPrestamoRepositorio IPrestamoRepositorio, IMapper mapper)
            {
                _mapper = mapper;
                _IPrestamoRepositorio = IPrestamoRepositorio;
            }

            [HttpGet("{id:int}")]
            public async Task<IActionResult> Get(int id)
            {
                Respuesta<Prestamo> oRespuesta = new();

                try
                {
                    var listaPrestamoss = await _IPrestamoRepositorio.Obtener(x => x.Id == id);


                    oRespuesta.Mensaje = "OK";
                    oRespuesta.Exito = 1;
                    oRespuesta.List = _mapper.Map<Prestamo>(listaPrestamoss);
                }
                catch (Exception ex)
                {
                    oRespuesta.Mensaje = ex.Message;
                }
                return Ok(oRespuesta);

            }
            [HttpGet("Insumo/{Insumo:int}")]
            public async Task<IActionResult> GetForInsumo(int IdInsumo)
            {
                Respuesta<List<Prestamo>> oRespuesta = new();

                try
                {
                    var prestamo = await _IPrestamoRepositorio.ObtenerMultiples(x => x.Id == IdInsumo);


                    oRespuesta.Mensaje = "OK";
                    oRespuesta.Exito = 1;
                    oRespuesta.List = _mapper.Map<List<Prestamo>>(prestamo);
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
                Respuesta<List<Prestamo>> oRespuesta = new();

                try
                {
                    var a = await _IPrestamoRepositorio.Lista();

                    oRespuesta.Mensaje = "OK";
                    oRespuesta.Exito = 1;
                    oRespuesta.List = _mapper.Map<List<Prestamo>>(a);
                }
                catch (Exception ex)
                {
                    oRespuesta.Mensaje = ex.Message;
                }
                return Ok(oRespuesta);
            }
            

            [HttpPost]
            public async Task<IActionResult> Add(Prestamo model)
            {

                Respuesta<Prestamo> oRespuesta = new();

                try
                {
                    Prestamo prestamo = new();

                    


                    await _IPrestamoRepositorio.Crear(prestamo);
                    oRespuesta.Exito = 1;
                }
                catch (Exception ex)
                {
                    oRespuesta.Mensaje = ex.Message;

                }
                return Ok(oRespuesta);
            }

            [HttpPut]
            public async Task<IActionResult> Edit(Prestamo model)
            {
                Respuesta<Prestamo> oRespuesta = new();

                try
                {


                    var oPrestamoss = await _IPrestamoRepositorio.Obtener(x => x.Id == model.Id);

                    oPrestamoss.Id = model.Id;
                    oPrestamoss.Operario = model.Operario;
                    oPrestamoss.Insumo = model.Insumo;
                    oPrestamoss.FechaInicio = model.FechaInicio;
                    oPrestamoss.FechaFin = model.FechaFin;
                    oPrestamoss.Cantidad = model.Cantidad;
                    

                    await _IPrestamoRepositorio.Editar(oPrestamoss);
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
                Respuesta<Prestamo> oRespuesta = new();
                try
                {
                    var oPrestamoss = await _IPrestamoRepositorio.Obtener(x => x.Id == Id);
                    await _IPrestamoRepositorio.Eliminar(oPrestamoss);
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

