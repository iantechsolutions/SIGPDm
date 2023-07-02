using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepuestoController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<Repuesto> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Repuestos
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
            Respuesta<List<Repuesto>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Repuestos.ToList();
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
        public IActionResult Add(Repuesto model)
        {
            Respuesta<Repuesto> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                Repuesto oRepuesto = new();

                oRepuesto.StockMin = model.StockMin;
                oRepuesto.StockMax = model.StockMax;
                oRepuesto.StockReal = model.StockReal;
                oRepuesto.Nombre = model.Nombre;
                oRepuesto.Codigo = model.Codigo;
                oRepuesto.Foto = model.Foto;
                oRepuesto.Descripcion = model.Descripcion;

                db.Repuestos.Add(oRepuesto);
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
        public IActionResult Edit(Repuesto model)
        {
            Respuesta<Repuesto> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                Repuesto oRepuesto = db.Repuestos.Find(model.Id);

                oRepuesto.StockMin = model.StockMin;
                oRepuesto.StockMax = model.StockMax;
                oRepuesto.StockReal = model.StockReal;
                oRepuesto.Nombre = model.Nombre;
                oRepuesto.Codigo = model.Codigo;
                oRepuesto.Foto = model.Foto;
                oRepuesto.Descripcion = model.Descripcion;

                db.Entry(oRepuesto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Respuesta<Repuesto> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                Repuesto oRepuesto = db.Repuestos.Find(Id);
                db.Remove(oRepuesto);
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
