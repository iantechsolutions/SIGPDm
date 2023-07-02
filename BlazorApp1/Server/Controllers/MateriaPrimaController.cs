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
    public class MateriaPrimaController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<MateriaPrima> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.MateriaPrimas
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
            Respuesta<List<MateriaPrima>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.MateriaPrimas.ToList();
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
        public IActionResult Add(MateriaPrima model)
        {
            Respuesta<MateriaPrima> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                MateriaPrima oMateriaPrima = new();

                oMateriaPrima.StockMin = model.StockMin;
                oMateriaPrima.StockMax = model.StockMax;
                oMateriaPrima.StockReal = model.StockReal;
                oMateriaPrima.Nombre = model.Nombre;
                oMateriaPrima.Codigo = model.Codigo;

                db.MateriaPrimas.Add(oMateriaPrima);
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
        public IActionResult Edit(MateriaPrima model)
        {
            Respuesta<MateriaPrima> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                MateriaPrima oMateriaPrima = db.MateriaPrimas.Find(model.Id);

                oMateriaPrima.StockMin = model.StockMin;
                oMateriaPrima.StockMax = model.StockMax;
                oMateriaPrima.StockReal = model.StockReal;
                oMateriaPrima.Nombre = model.Nombre;
                oMateriaPrima.Codigo = model.Codigo;

                db.Entry(oMateriaPrima).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Respuesta<MateriaPrima> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                MateriaPrima oMateriaPrima = db.MateriaPrimas.Find(Id);
                db.Remove(oMateriaPrima);
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
