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
using BlazorApp1.Server.Models;

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
                Respuesta<PrestamoDTO> oRespuesta = new();

                try
                {
                    var listaPrestamoss = await _IPrestamoRepositorio.Obtener(x => x.Id == id);


                    oRespuesta.Mensaje = "OK";
                    oRespuesta.Exito = 1;
                    oRespuesta.List = _mapper.Map<PrestamoDTO>(listaPrestamoss);
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
                Respuesta<List<PrestamoDTO>> oRespuesta = new();

                try
                {
                    var prestamo = await _IPrestamoRepositorio.ObtenerMultiples(x => x.Id == IdInsumo);


                    oRespuesta.Mensaje = "OK";
                    oRespuesta.Exito = 1;
                    oRespuesta.List = _mapper.Map<List<PrestamoDTO>>(prestamo);
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
                Respuesta<List<PrestamoDTO>> oRespuesta = new();

                try
                {
                    var a = await _IPrestamoRepositorio.Lista();

                    oRespuesta.Mensaje = "OK";
                    oRespuesta.Exito = 1;
                    oRespuesta.List = _mapper.Map<List<PrestamoDTO>>(a);
                }
                catch (Exception ex)
                {
                    oRespuesta.Mensaje = ex.Message;
                }
                return Ok(oRespuesta);
            }
            

            [HttpPost]
            public async Task<IActionResult> Add(PrestamoDTO model)
            {

                Respuesta<PrestamoDTO> oRespuesta = new();

                try
            {
                    Prestamo prestamo = new();

                    prestamo.Id = model.Id;
                    prestamo.Operario = model.Operario;
                    prestamo.Insumo = model.Insumo;
                    prestamo.Cantidad = model.Cantidad;
                    prestamo.Estado = model.Estado;
                    prestamo.Lote = model.Lote;
                    prestamo.FechaInicio = model.FechaInicio;
                    prestamo.FechaFin = model.FechaFin;
                    prestamo.FechaFinReal = model.FechaFinReal;



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
            public async Task<IActionResult> Edit(PrestamoDTO model)
            {
                Respuesta<PrestamoDTO> oRespuesta = new();

                try
                {


                    var prestamo = await _IPrestamoRepositorio.Obtener(x => x.Id == model.Id);

                prestamo.Id = model.Id;
                prestamo.Operario = model.Operario;
                prestamo.Insumo = model.Insumo;
                prestamo.FechaInicio = model.FechaInicio;
                prestamo.FechaFin = model.FechaFin;
                prestamo.Cantidad = model.Cantidad;
                prestamo.Estado = model.Estado;
                prestamo.FechaFinReal = model.FechaFinReal;
                prestamo.Lote = model.Lote;

                    await _IPrestamoRepositorio.Editar(prestamo);
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
                Respuesta<PrestamoDTO> oRespuesta = new();
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

