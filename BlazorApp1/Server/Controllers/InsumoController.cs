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
    public class InsumoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInsumoRepositorio _InsumoRepositorio;
        public InsumoController(IInsumoRepositorio InsumoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _InsumoRepositorio = InsumoRepositorio;
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

       
        [HttpGet("presupuesto")]
        public async Task<IActionResult> GetInsumoPresupuesto()
        {
            Respuesta<List<InsumoDTO>> oRespuesta = new();

            try
            {

                var listaInsumo = await _InsumoRepositorio.Lista();

                var listaInsumosPresupuesto = listaInsumo
                    .Where(e => e.OrdencompraInsumoNavigations.Any(x => x.Estado == "Presupuesto"))
                    .ToList();
                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<InsumoDTO>>(listaInsumosPresupuesto);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost]
        public IActionResult Add(Insumo model)
        {
           
            Respuesta<Insumo> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

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
                //oInsumo.Proveedor = model.Proveedor;

                db.Insumos.Add(oInsumo);
                db.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpPut]
        public IActionResult Edit([FromBody]Insumo model)
        {
            Respuesta<Insumo> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                Insumo oInsumo = db.Insumos.Find(model.Id);

                oInsumo.StockMin = model.StockMin;
                oInsumo.StockMax = model.StockMax;
                oInsumo.StockReal = model.StockReal;
                oInsumo.Nombre = model.Nombre;
                oInsumo.Codigo = model.Codigo;
                oInsumo.Foto = model.Foto;
                oInsumo.Descripcion = model.Descripcion;
                oInsumo.Recepcion = model.Recepcion;
                oInsumo.Lotes = model.Lotes;

                db.Entry(oInsumo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta<Insumo> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                Insumo oInsumo = db.Insumos.Find(Id);
                db.Remove(oInsumo);
                db.SaveChanges();
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
