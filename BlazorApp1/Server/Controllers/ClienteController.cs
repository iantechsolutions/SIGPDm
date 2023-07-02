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
    public class ClienteController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<Cliente> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Clientes
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
            Respuesta<List<Cliente>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Clientes.ToList();
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
        public IActionResult Add(Cliente model)
        {
            Respuesta<Cliente> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                Cliente oCliente = new();
                
                oCliente.Direccion = model.Direccion;
                oCliente.Cp = model.Cp;
                oCliente.Mail = model.Mail;
                oCliente.NombreContacto = model.NombreContacto;
                oCliente.NombreEmpresa = model.NombreEmpresa;
                oCliente.Cuit = model.Cuit;
                oCliente.Telefono = model.Telefono;
                oCliente.Observaciones = model.Observaciones;
                oCliente.RazonSocial = model.RazonSocial;
                oCliente.Corredor = model.Corredor;
                oCliente.Expreso= model.Expreso;
                oCliente.DomicilioEntrega = model.DomicilioEntrega;

                db.Clientes.Add(oCliente);
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
        public IActionResult Edit(Cliente model)
        {
            Respuesta<Cliente> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                Cliente oCliente = db.Clientes.Find(model.Id);

                oCliente.Direccion = model.Direccion;
                oCliente.Cp = model.Cp;
                oCliente.Mail = model.Mail;
                oCliente.NombreContacto = model.NombreContacto;
                oCliente.NombreEmpresa = model.NombreEmpresa;
                oCliente.Cuit = model.Cuit;
                oCliente.Telefono = model.Telefono;
                oCliente.Observaciones = model.Observaciones;
                oCliente.RazonSocial = model.RazonSocial;
                oCliente.Corredor = model.Corredor;
                oCliente.Expreso = model.Expreso;
                oCliente.DomicilioEntrega = model.DomicilioEntrega;

                db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Respuesta<Cliente> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                Cliente oCliente = db.Clientes.Find(Id);
                db.Remove(oCliente);
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
