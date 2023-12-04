using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using BlazorApp1.Server.Models;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoreController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<Proveedore> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Proveedores
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
            Respuesta<List<Proveedore>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Proveedores.ToList();
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
        public IActionResult Add(ProveedoreDTO model)
        {
            Respuesta<ProveedoreDTO> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                Proveedore oProveedore = new();

                oProveedore.Cp = model.Cp;
                oProveedore.Mail = model.Mail;
                oProveedore.NombreContacto = model.NombreContacto;
                oProveedore.NombreEmpresa = model.NombreEmpresa;
                oProveedore.Cuit = model.Cuit;
                oProveedore.Telefono = model.Telefono;
                oProveedore.Observaciones = model.Observaciones;
                oProveedore.Direccion = model.Direccion;
                oProveedore.RazonSocial = model.RazonSocial;
                oProveedore.Categorias= model.Categorias;


                db.Proveedores.Add(oProveedore);
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
        public IActionResult Edit(ProveedoreDTO model)
        {
            Respuesta<ProveedoreDTO> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                Proveedore oProveedore = db.Proveedores.Find(model.Id);

                oProveedore.Cp = model.Cp;
                oProveedore.Mail = model.Mail;
                oProveedore.NombreContacto = model.NombreContacto;
                oProveedore.NombreEmpresa = model.NombreEmpresa;
                oProveedore.Cuit = model.Cuit;
                oProveedore.Telefono = model.Telefono;
                oProveedore.Observaciones = model.Observaciones;
                oProveedore.Direccion = model.Direccion;
                oProveedore.RazonSocial = model.RazonSocial;
                oProveedore.Categorias = model.Categorias;


                db.Entry(oProveedore).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Respuesta<ProveedoreDTO> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                Proveedore oProveedore = db.Proveedores.Find(Id);
                db.Remove(oProveedore);
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
