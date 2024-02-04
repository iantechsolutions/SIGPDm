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
using BlazorApp1.Client.Pages.d_Deposito.Prestamos;

namespace BlazorApp1.Server.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoStockController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPrestamoStockRepositorio _IPrestamoStockRepositorio;
        public PrestamoStockController(IPrestamoStockRepositorio IPrestamoStockRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _IPrestamoStockRepositorio = IPrestamoStockRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<PrestamoStock> oRespuesta = new();

            try
            {
                var listaPrestamoss = await _IPrestamoStockRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<PrestamoStock>(listaPrestamoss);
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
            Respuesta<List<PrestamoStock>> oRespuesta = new();

            try
            {
                var a = await _IPrestamoStockRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = a;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpPost]
        public async Task<IActionResult> Add(PrestamoStock model)
        {

            Respuesta<PrestamoStock> oRespuesta = new();

            try
            {
                PrestamoStock prestamo = new();

                prestamo.Id = model.Id;
                prestamo.Prestamo = model.Prestamo;
                prestamo.Insumo = model.Insumo;
                prestamo.Cantidad = model.Cantidad;
                prestamo.Lote = model.Lote;
                prestamo.LoteTipo = model.LoteTipo;
                prestamo.InsumoTipo = model.InsumoTipo;
                prestamo.FechaFinal = model.FechaFinal;



                await _IPrestamoStockRepositorio.Crear(prestamo);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(PrestamoStock model)
        {
            Respuesta<PrestamoStock> oRespuesta = new();

            try
            {


                var prestamo = await _IPrestamoStockRepositorio.Obtener(x => x.Id == model.Id);

                prestamo.Id = model.Id;
                prestamo.Prestamo = model.Prestamo;
                prestamo.Insumo = model.Insumo;
                prestamo.Cantidad = model.Cantidad;
                prestamo.Lote = model.Lote;
                prestamo.LoteTipo = model.LoteTipo;
                prestamo.InsumoTipo = model.InsumoTipo;
                prestamo.FechaFinal = model.FechaFinal;

                await _IPrestamoStockRepositorio.Editar(prestamo);
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
            Respuesta<PrestamoStock> oRespuesta = new();
            try
            {
                var oPrestamoss = await _IPrestamoStockRepositorio.Obtener(x => x.Id == Id);
                await _IPrestamoStockRepositorio.Eliminar(oPrestamoss);
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

