using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Server.Repositorio.Implementacion;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
            private readonly IMapper _mapper;
            private readonly IClienteRepositorio _IClienteRepositorio;
            public ClienteController(IClienteRepositorio IClienteRepositorio, IMapper mapper)
            {
                _mapper = mapper;
            _IClienteRepositorio = IClienteRepositorio;
            }


            [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<Cliente> oRespuesta = new();

            try
            {
                var listaInsumo = await _IClienteRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Cliente>(listaInsumo);
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
            Respuesta<List<Cliente>> oRespuesta = new();

            try
            {
                var lst = await _IClienteRepositorio.Lista();


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = lst.ToList();
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
                oCliente.Localidad = model.Localidad;

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
                oCliente.Localidad = model.Localidad;

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
