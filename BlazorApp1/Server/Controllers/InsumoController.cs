using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BlazorApp1.Server.Models;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumoController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<Insumo> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Insumos
                    .Where(x => x.Id == id)
                    .First();
                oRespuesta.Exito = 1;
                oRespuesta.List = lst;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<Insumo>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Insumos.ToList();
                oRespuesta.Exito = 1;
                oRespuesta.List = lst;
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
