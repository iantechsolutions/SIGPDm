using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Server.Repositorio.Implementacion;


namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosPañolController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPedidosPañolRepositorio _IPedidosPañolRepositorio;
        public PedidosPañolController(IPedidosPañolRepositorio IPedidosPañolRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _IPedidosPañolRepositorio = IPedidosPañolRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<PedidosPañol> oRespuesta = new();

            try
            {
                var listaInsumo = await _IPedidosPañolRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<PedidosPañol>(listaInsumo);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [Route("Lista")]
        public async Task<IActionResult> Lista(int skip, int take)
        {

            Respuesta<List<PedidosPañol>> _ResponseDTO = new Respuesta<List<PedidosPañol>>();

            try
            {
                List<PedidosPañol> listaPedido = new List<PedidosPañol>();
                var a = await _IPedidosPañolRepositorio.Lista(skip, take);


                listaPedido = _mapper.Map<List<PedidosPañol>>(a);

                _ResponseDTO = new Respuesta<List<PedidosPañol>>() { Exito = 1, Mensaje = "Exito", List = listaPedido };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);


            }
            catch (Exception ex)
            {
                _ResponseDTO = new Respuesta<List<PedidosPañol>>() { Exito = 1, Mensaje = ex.Message, List = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        [HttpGet]
        [Route("Cantidad")]
        public async Task<IActionResult> CantidadTotal()
        {

            Respuesta<int> _ResponseDTO = new Respuesta<int>();

            try
            {
                var a = await _IPedidosPañolRepositorio.CantidadTotal();

                _ResponseDTO = new Respuesta<int>() { Exito = 1, Mensaje = "Exito", List = a };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);


            }
            catch (Exception ex)
            {
                _ResponseDTO = new Respuesta<int>() { Exito = 1, Mensaje = ex.Message, List = 0 };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
        [HttpGet]
        [Route("LimitadosFiltrados")]
        public async Task<IActionResult> LimitadosFiltrados(int skip, int take, string? expression = null)
        {

            Respuesta<List<PedidosPañol>> _ResponseDTO = new Respuesta<List<PedidosPañol>>();

            try
            {
                var a = await _IPedidosPañolRepositorio.LimitadosFiltrados(skip, take, expression);

                var listaFiltrada = _mapper.Map<List<PedidosPañol>>(a);

                _ResponseDTO = new Respuesta<List<PedidosPañol>>() { Exito = 1, Mensaje = "Exito", List = listaFiltrada };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);


            }
            catch (Exception ex)
            {
                _ResponseDTO = new Respuesta<List<PedidosPañol>>() { Exito = 1, Mensaje = ex.Message, List = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(PedidosPañol model)
        {
            Respuesta<PedidosPañol> oRespuesta = new();

            try
            {
                

                PedidosPañol oPedidosPañol = new();

                oPedidosPañol.Id = model.Id;
                oPedidosPañol.Insumo = model.Insumo;
                oPedidosPañol.Cantidad = model.Cantidad;
                oPedidosPañol.Operario = model.Operario;
                oPedidosPañol.Fecha = model.Fecha;
                oPedidosPañol.Codigo = model.Codigo;



                await _IPedidosPañolRepositorio.Crear(oPedidosPañol);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(PedidosPañol model)
        {
            Respuesta<PedidosPañol> oRespuesta = new();

            try
            {
                

                var oPedidosPañol = await _IPedidosPañolRepositorio.Obtener(x => x.Id == model.Id);

                oPedidosPañol.Id = model.Id;
                oPedidosPañol.Insumo = model.Insumo;
                oPedidosPañol.Cantidad = model.Cantidad;
                oPedidosPañol.Operario = model.Operario;
                oPedidosPañol.Fecha = model.Fecha;
                oPedidosPañol.Codigo = model.Codigo;

                await _IPedidosPañolRepositorio.Editar(oPedidosPañol);
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
            Respuesta<PedidosPañol> oRespuesta = new();
            try
            {
                var oPedidosPañol = await _IPedidosPañolRepositorio.Obtener(x => x.Id == Id);
                await _IPedidosPañolRepositorio.Eliminar(oPedidosPañol);
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
