using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechasEventoController : ControllerBase
    {
        //[HttpGet("{date:DateTime}")]
        //public IActionResult Get(DateTime date)
        //{
        //    Respuesta<List<FechasEvento>> oRespuesta = new();
        //    try
        //    {
        //        using DiMetalloContext db = new();
        //        var lst = db.FechasEventos
        //            .Where(x => x.Fecha == date).ToList();
        //        oRespuesta.Exito = 1;
        //        oRespuesta.List = lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        oRespuesta.Mensaje = ex.Message;
        //    }
        //    return Ok(oRespuesta);
        //}

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<List<FechasEvento>> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();
                var lst = db.FechasEventos
                    .Where(x => x.Id==id).ToList();
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
            Respuesta<List<FechasEvento>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.FechasEventos.ToList();
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
        public IActionResult Add(FechasEvento model)
        {
            Respuesta<FechasEvento> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                db.FechasEventos.Add(model);
                db.SaveChanges();
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(FechasEvento model)
        {
            Respuesta<FechasEvento> oRespuesta = new();

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
            Respuesta<FechasEvento> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                FechasEvento oFechasEvento = db.FechasEventos.Find(Id);
                db.Remove(oFechasEvento);
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
