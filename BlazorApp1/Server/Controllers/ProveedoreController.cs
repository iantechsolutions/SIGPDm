﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using BlazorApp1.Server.Models;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Server.Repositorio.Implementacion;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProveedoreRepositorio _ProveedoreRepositorio;
        public ProveedoreController(IProveedoreRepositorio ProveedoreRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _ProveedoreRepositorio = ProveedoreRepositorio;
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<ProveedoreDTO> oRespuesta = new();

            try
            {
                var listaProveedore = await _ProveedoreRepositorio.Obtener(x => x.Id == id);

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<ProveedoreDTO>(listaProveedore);
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
            Respuesta<List<ProveedoreDTO>> oRespuesta = new();

            try
            {
                var a = await _ProveedoreRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<ProveedoreDTO>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(Proveedore model)
        {
            Respuesta<Proveedore> oRespuesta = new();

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
