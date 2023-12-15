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
    public class MateriaPrimaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMateriaPrimaRepositorio _IMateriaPrimaRepositorio;
        public MateriaPrimaController(IMateriaPrimaRepositorio IMateriaPrimaRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _IMateriaPrimaRepositorio = IMateriaPrimaRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<MateriaPrima> oRespuesta = new();

            try
            {
                var listaInsumo = await _IMateriaPrimaRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<MateriaPrima>(listaInsumo);
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
            Respuesta<List<MateriaPrima>> oRespuesta = new();

            try
            {
                var a = await _IMateriaPrimaRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<MateriaPrima>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MateriaPrima model)
        {
            Respuesta<MateriaPrima> oRespuesta = new();

            try
            {
                MateriaPrima oMateriaPrima = new();

                oMateriaPrima.StockMin = model.StockMin;
                oMateriaPrima.StockMax = model.StockMax;
                oMateriaPrima.StockReal = model.StockReal;
                oMateriaPrima.Nombre = model.Nombre;
                oMateriaPrima.Codigo = model.Codigo;
                oMateriaPrima.Id = model.Id;
               
                


                await _IMateriaPrimaRepositorio.Crear(oMateriaPrima);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(MateriaPrima model)
        {
            Respuesta<MateriaPrima> oRespuesta = new();

            try
            {
                var oMateriaPrima = await _IMateriaPrimaRepositorio.Obtener(x => x.Id == model.Id);              

                oMateriaPrima.StockMin = model.StockMin;
                oMateriaPrima.StockMax = model.StockMax;
                oMateriaPrima.StockReal = model.StockReal;
                oMateriaPrima.Nombre = model.Nombre;
                oMateriaPrima.Codigo = model.Codigo;
                oMateriaPrima.Id = model.Id;

                await _IMateriaPrimaRepositorio.Editar(oMateriaPrima);
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
            Respuesta<MateriaPrima> oRespuesta = new();
            try
            {
                var oMateriaPrima = await _IMateriaPrimaRepositorio.Obtener(x => x.Id == Id);
                await _IMateriaPrimaRepositorio.Eliminar(oMateriaPrima);
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
