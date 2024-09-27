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
    public class InsumoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInsumoRepositorio _InsumoRepositorio;
        public InsumoController(IInsumoRepositorio InsumoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _InsumoRepositorio = InsumoRepositorio;
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<InsumoDTO> oRespuesta = new();

            try
            {

                var listaInsumo = await _InsumoRepositorio.Obtener(x=>x.Id==id);

              
                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<InsumoDTO>(listaInsumo);
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
            Respuesta<List<InsumoDTO>> oRespuesta = new();

            try
            {
                var a = await _InsumoRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<InsumoDTO>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost]
        public async Task<IActionResult> Add(Insumo model)
        {
           
            Respuesta<Insumo> oRespuesta = new();

            try
            {
                

                Insumo oInsumo = new();

                oInsumo.StockMin = model.StockMin;
                oInsumo.StockMax = model.StockMax;
                oInsumo.StockReal = model.StockReal;
                oInsumo.Nombre = model.Nombre;
                oInsumo.Codigo = model.Codigo;
                oInsumo.Foto = model.Foto;
                oInsumo.Descripcion = model.Descripcion;
                oInsumo.Recepcion = model.Recepcion;
                oInsumo.Lotes = model.Lotes;
                oInsumo.Tipo = model.Tipo;
                oInsumo.ProveedoresPosibles = model.ProveedoresPosibles;
                oInsumo.UltimoPrecio = model.UltimoPrecio;
               
                oInsumo.Asignacion = model.Asignacion;
                oInsumo.PeriodicidadMantenimiento = model.PeriodicidadMantenimiento;
                oInsumo.Estado = model.Estado;
                oInsumo.MotivoEstado = model.MotivoEstado;
                oInsumo.Disposicion = model.Disposicion;
                oInsumo.MotivoDisposicion = model.MotivoDisposicion;
                oInsumo.UltimoMant = model.UltimoMant;
                oInsumo.DetalleMantenimiento = model.DetalleMantenimiento;
                oInsumo.Personal = model.Personal;
                oInsumo.DetalleCorrectivo = model.DetalleCorrectivo;
                oInsumo.MantenimientoPreventivo = model.MantenimientoPreventivo;
                oInsumo.Categoria = model.Categoria;
                oInsumo.Marca = model.Marca;
                oInsumo.FechaIngreso = model.FechaIngreso;
                oInsumo.DescripcionMantenimiento = model.DescripcionMantenimiento;

                

                //oInsumo.Proveedor = model.Proveedor;



                await _InsumoRepositorio.Crear(oInsumo);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Insumo model)
        {
            Respuesta<Insumo> oRespuesta = new();

            try
            {


                var oInsumo = await _InsumoRepositorio.Obtener(x => x.Id == model.Id);

                oInsumo.StockMin = model.StockMin;
                oInsumo.StockMax = model.StockMax;
                oInsumo.StockReal = model.StockReal;
                oInsumo.Nombre = model.Nombre;
                oInsumo.Codigo = model.Codigo;
                oInsumo.Foto = model.Foto;
                oInsumo.Descripcion = model.Descripcion;
                oInsumo.Recepcion = model.Recepcion;
                oInsumo.Lotes = model.Lotes;
                oInsumo.Tipo = model.Tipo;
                oInsumo.UltimoPrecio = model.UltimoPrecio;
                oInsumo.Asignacion = model.Asignacion;

                oInsumo.PeriodicidadMantenimiento = model.PeriodicidadMantenimiento;
                oInsumo.Estado = model.Estado;
                oInsumo.MotivoEstado = model.MotivoEstado;
                oInsumo.Disposicion = model.Disposicion;
                oInsumo.MotivoDisposicion = model.MotivoDisposicion;
                oInsumo.UltimoMant = model.UltimoMant;
                oInsumo.DetalleMantenimiento = model.DetalleMantenimiento;
                oInsumo.Personal = model.Personal;
                oInsumo.DetalleCorrectivo = model.DetalleCorrectivo;
                oInsumo.MantenimientoPreventivo = model.MantenimientoPreventivo;
                oInsumo.Categoria = model.Categoria;
                oInsumo.Marca = model.Marca;
                oInsumo.FechaIngreso = model.FechaIngreso;
                oInsumo.DescripcionMantenimiento = model.DescripcionMantenimiento;


                oInsumo.ProveedoresPosibles = model.ProveedoresPosibles;
                await _InsumoRepositorio.Editar(oInsumo);
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
            Respuesta<Insumo> oRespuesta = new();
            try
            {
                var oInsumo = await _InsumoRepositorio.Obtener(x => x.Id == Id);
                await _InsumoRepositorio.Eliminar(oInsumo);
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
