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
    public class ItemPresupuestoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItemPresupuestoRepositorio _ItemPresupuestoRepositorio;
        public ItemPresupuestoController(IItemPresupuestoRepositorio ItemPresupuestoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _ItemPresupuestoRepositorio = ItemPresupuestoRepositorio;
        }


        [HttpGet("{Id:int}")]
        public async Task<IActionResult> Get(int Id)
        {
            Respuesta<ItemPresupuesto> oRespuesta = new();

            try
            {
                var listaItemPresupuesto = await _ItemPresupuestoRepositorio.Obtener(x => x.Id == Id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<ItemPresupuesto>(listaItemPresupuesto);
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
            Respuesta<List<ItemPresupuesto>> oRespuesta = new();

            try
            {
                var a = await _ItemPresupuestoRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<ItemPresupuesto>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost]
        public async Task<IActionResult> Add(ItemPresupuesto model)
        {

            Respuesta<ItemPresupuesto> oRespuesta = new();

            try
            {
                ItemPresupuesto oItemPresupuesto = new();

                oItemPresupuesto.Id = model.Id;
                oItemPresupuesto.Cantidad = model.Cantidad;
                oItemPresupuesto.Precio = model.Precio;
                oItemPresupuesto.PrecioUnitario = model.PrecioUnitario;
                oItemPresupuesto.Observacion = model.Observacion;
                oItemPresupuesto.Insumo = model.Insumo;
                oItemPresupuesto.Presupuesto = model.Presupuesto;
                oItemPresupuesto.Descripcion = model.Descripcion;
                oItemPresupuesto.OC = model.OC;







                await _ItemPresupuestoRepositorio.Crear(oItemPresupuesto);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] ItemPresupuesto model)
        {
            Respuesta<ItemPresupuesto> oRespuesta = new();

            try
            {


                var oItemPresupuesto = await _ItemPresupuestoRepositorio.Obtener(x => x.Id == model.Id);

                oItemPresupuesto.Id = model.Id;
                oItemPresupuesto.Cantidad = model.Cantidad;
                oItemPresupuesto.Precio = model.Precio;
                oItemPresupuesto.PrecioUnitario = model.PrecioUnitario;
                oItemPresupuesto.Observacion = model.Observacion;
                oItemPresupuesto.Insumo = model.Insumo;
                oItemPresupuesto.Presupuesto = model.Presupuesto;
                oItemPresupuesto.Descripcion = model.Descripcion;
                oItemPresupuesto.OC = model.OC;


                await _ItemPresupuestoRepositorio.Editar(oItemPresupuesto);
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
            Respuesta<ItemPresupuesto> oRespuesta = new();
            try
            {
                var oItemPresupuesto = await _ItemPresupuestoRepositorio.Obtener(x => x.Id == Id);
                await _ItemPresupuestoRepositorio.Eliminar(oItemPresupuesto);
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
