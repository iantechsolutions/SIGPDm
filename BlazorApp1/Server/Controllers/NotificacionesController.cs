using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BlazorApp1.Shared.Models; //cambiazo
using AutoMapper;
using BlazorApp1.Server.Repositorio.Implementacion;
using BlazorApp1.Server.Repositorio.Contrato;


namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INotificacionesRepositorio _NotificacionesRepositorio;
        public NotificacionesController(INotificacionesRepositorio NotificacionesRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _NotificacionesRepositorio = NotificacionesRepositorio;
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<Notificaciones> oRespuesta = new();

            try
            {
                var listaNotificaciones = await _NotificacionesRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Notificaciones>(listaNotificaciones);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("maquina/{idMaquina:int}")]
        public async Task<IActionResult> GetByMaquina(int idMaquina)
        {
            Respuesta<Notificaciones> oRespuesta = new();

            try
            {
                var listaNotificaciones = await _NotificacionesRepositorio.ObtenerByMaquina(x => x.Maquina == idMaquina);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Notificaciones>(listaNotificaciones);
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
            Respuesta<List<Notificaciones>> oRespuesta = new();

            try
            {
                var a = await _NotificacionesRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<Notificaciones>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost]
        public async Task<IActionResult> Add(Notificaciones model)
        {

            Respuesta<Notificaciones> oRespuesta = new();

            try
            {
               Notificaciones oNotificaciones = new();

                oNotificaciones.Id = model.Id;
                oNotificaciones.RolesAfectados = model.RolesAfectados;
                oNotificaciones.UsuariosQueAfecta = model.UsuariosQueAfecta;
                oNotificaciones.UsuariosVisto = model.UsuariosVisto;
                oNotificaciones.Titulo = model.Titulo;
                oNotificaciones.Descripcion = model.Descripcion;
                oNotificaciones.Categoria = model.Categoria;
                oNotificaciones.UrlRedireccion = model.UrlRedireccion;
                oNotificaciones.FechaCreacion = model.FechaCreacion;
                oNotificaciones.Maquina = model.Maquina;
                oNotificaciones.FechaEntrega = model.FechaEntrega;
                oNotificaciones.Dias = model.Dias;


                await _NotificacionesRepositorio.Crear(oNotificaciones);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Notificaciones model)
        {
            Respuesta<Notificaciones> oRespuesta = new();

            try
            {


                var oNotificaciones = await _NotificacionesRepositorio.Obtener(x => x.Id == model.Id);

                oNotificaciones.Id = model.Id;
                oNotificaciones.RolesAfectados = model.RolesAfectados;
                oNotificaciones.UsuariosQueAfecta = model.UsuariosQueAfecta;
                oNotificaciones.UsuariosVisto = model.UsuariosVisto;
                oNotificaciones.Titulo = model.Titulo;
                oNotificaciones.Descripcion = model.Descripcion;
                oNotificaciones.Categoria = model.Categoria;
                oNotificaciones.UrlRedireccion = model.UrlRedireccion;
                oNotificaciones.FechaCreacion = model.FechaCreacion;
                oNotificaciones.Maquina = model.Maquina;
                oNotificaciones.FechaEntrega = model.FechaEntrega;
                oNotificaciones.Dias = model.Dias;

                await _NotificacionesRepositorio.Editar(oNotificaciones);
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
            Respuesta<Notificaciones> oRespuesta = new();
            try
            {
                var oNotificaciones = await _NotificacionesRepositorio.Obtener(x => x.Id == Id);
                await _NotificacionesRepositorio.Eliminar(oNotificaciones);
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
