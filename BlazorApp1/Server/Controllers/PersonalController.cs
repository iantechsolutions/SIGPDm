using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Implementacion;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Server.Models;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonalRepositorio _IPersonalRepositorio;
        public PersonalController(IPersonalRepositorio IPersonalRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _IPersonalRepositorio = IPersonalRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<PersonalDTO> oRespuesta = new();

            try
            {
                var listaPersonal = await _IPersonalRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<PersonalDTO>(listaPersonal);
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
            Respuesta<List<PersonalDTO>> oRespuesta = new();

            try
            {
                var a = await _IPersonalRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<PersonalDTO>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{estado:bool}")]
        public async Task<IActionResult> GetByActividad(bool estado)
        {
            Respuesta<List<PersonalDTO>> oRespuesta = new();

            try
            {

                var lst = await _IPersonalRepositorio.Lista();

                oRespuesta.Exito = 1;
                var personal = lst.Where(x => x.Activo == estado || x.Activo == null).ToList();
                oRespuesta.List = _mapper.Map<List<PersonalDTO>>(personal);

              
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpPost]
        public async Task<IActionResult> Add(PersonalDTO model)
        {
            Respuesta<PersonalDTO> oRespuesta = new();

            try
            {


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
                oPersonal.Activo = model.Activo;
                oPersonal.PremioEstablecido = model.PremioEstablecido;

                await _IPersonalRepositorio.Crear(oPersonal);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(PersonalDTO model)
        {
            Respuesta<PersonalDTO> oRespuesta = new();

            try
            {
                var oPersonal = await _IPersonalRepositorio.Obtener(x => x.Id == model.Id); 

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
                oPersonal.Activo = model.Activo;
                oPersonal.PremioEstablecido = model.PremioEstablecido;

                await _IPersonalRepositorio.Editar(oPersonal);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }
      

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            Respuesta<PersonalDTO> oRespuesta = new();
            try
            {
                var oPersonal = await _IPersonalRepositorio.Obtener(x => x.Id == Id);
                await _IPersonalRepositorio.Eliminar(oPersonal);
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
