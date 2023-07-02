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
    public class PersonalController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<Personal> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Personals
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
            Respuesta<List<Personal>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Personals.ToList();
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
        public IActionResult Add(Personal model)
        {
            Respuesta<Personal> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                Personal oPersonal = new();

                oPersonal.Nombres = model.Nombres;
                oPersonal.Apellido = model.Apellido;
                oPersonal.Dni = model.Dni;
                oPersonal.Mail = model.Mail;
                oPersonal.Telefono = model.Telefono;
                oPersonal.Direccion = model.Direccion;
                oPersonal.CondicionContractual = model.CondicionContractual;
                oPersonal.Legajo = model.Legajo;
                oPersonal.Puesto = model.Puesto;
                oPersonal.Categoria = model.Categoria;
                oPersonal.PremioEstablecido = model.PremioEstablecido;

                db.Personals.Add(oPersonal);
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
        public IActionResult Edit(Personal model)
        {
            Respuesta<Personal> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                Personal oPersonal = db.Personals.Find(model.Id);

                oPersonal.Nombres = model.Nombres;
                oPersonal.Apellido = model.Apellido;
                oPersonal.Dni = model.Dni;
                oPersonal.Mail = model.Mail;
                oPersonal.Telefono = model.Telefono;
                oPersonal.Direccion = model.Direccion;
                oPersonal.CondicionContractual = model.CondicionContractual;
                oPersonal.Legajo = model.Legajo;
                oPersonal.Puesto = model.Puesto;
                oPersonal.Categoria = model.Categoria;
                oPersonal.PremioEstablecido = model.PremioEstablecido;

                db.Entry(oPersonal).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Respuesta<Personal> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                Personal oPersonal = db.Personals.Find(Id);
                db.Remove(oPersonal);
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
