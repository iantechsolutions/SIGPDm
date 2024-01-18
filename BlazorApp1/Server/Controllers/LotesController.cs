using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BlazorApp1.Server.Models;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Implementacion;
using BlazorApp1.Server.Repositorio.Contrato;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILoteRepositorio _ILoteRepositorio;
        public LotesController(ILoteRepositorio ILoteRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _ILoteRepositorio = ILoteRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<Lote> oRespuesta = new();

            try
            {
                var listaLotes = await _ILoteRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Lote>(listaLotes);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }
        [HttpGet("IdInsumo/{IdInsumo:int}")]
        public async Task<IActionResult> GetForInsumo(int IdInsumo)
        {
            Respuesta<List<Lote>> oRespuesta = new();

            try
            {
                var listaLotes = await _ILoteRepositorio.ObtenerMultiples(x => x.IdInsumo == IdInsumo);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<Lote>>(listaLotes);
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
            Respuesta<List<Lote>> oRespuesta = new();

            try
            {
                var a = await _ILoteRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<Lote>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpGet("esDeLoteUnico{id:int}")]
        public async Task<bool> esDeLoteUnico(int id)
        {
            try
            {
                var listaLotes = await _ILoteRepositorio.Obtener(x => x.IdInsumo == id);

                if (listaLotes == null)
                {
                    return false;
                }
                else
                {              
                        if (listaLotes.Tipo == "Lote unico")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                   
                }

              
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Add(Lote model)
        {

            Respuesta<Lote> oRespuesta = new();

            try
            {
                Lote oLotes = new();

                oLotes.Tipo = model.Tipo;
                oLotes.Numero = model.Numero;
                oLotes.Cantidad = model.Cantidad;
                oLotes.FechaIngreso = model.FechaIngreso;
                oLotes.Alto = model.Alto;
                oLotes.Ancho = model.Ancho;
                oLotes.NroRemito = model.NroRemito;
                oLotes.Proveedor = model.Proveedor;
                oLotes.IdInsumo = model.IdInsumo;
                oLotes.Id = model.Id;
                oLotes.OC = model.OC;


                await _ILoteRepositorio.Crear(oLotes);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Lote model)
        {
            Respuesta<Lote> oRespuesta = new();

            try
            {


                var oLotes = await _ILoteRepositorio.Obtener(x => x.Id == model.Id);

                oLotes.Tipo = model.Tipo;
                oLotes.Numero = model.Numero;
                oLotes.Cantidad = model.Cantidad;
                oLotes.FechaIngreso = model.FechaIngreso;
                oLotes.Alto = model.Alto;
                oLotes.Ancho = model.Ancho;
                oLotes.NroRemito = model.NroRemito;
                oLotes.Proveedor = model.Proveedor;
                oLotes.IdInsumo = model.IdInsumo;
                oLotes.Id = model.Id;
                oLotes.OC = model.OC;

                await _ILoteRepositorio.Editar(oLotes);
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
            Respuesta<Lote> oRespuesta = new();
            try
            {
                var oLotes = await _ILoteRepositorio.Obtener(x => x.Id == Id);
                await _ILoteRepositorio.Eliminar(oLotes);
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
