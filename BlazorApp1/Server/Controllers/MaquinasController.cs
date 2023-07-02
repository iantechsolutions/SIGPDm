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
    public class MaquinasController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<MaquinasHerramienta> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.MaquinasHerramientas
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
            Respuesta<List<MaquinasHerramienta>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.MaquinasHerramientas.ToList(); 
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
        public IActionResult Add(MaquinasHerramienta model)
        {
            Respuesta<MaquinasHerramienta> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();                

                db.MaquinasHerramientas.Add(model);
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
        public IActionResult Edit(MaquinasHerramienta model)
        {
            Respuesta<MaquinasHerramienta> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Respuesta<MaquinasHerramienta> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                MaquinasHerramienta oMaquinasHerramienta = db.MaquinasHerramientas.Find(Id);
                db.Remove(oMaquinasHerramienta);
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
