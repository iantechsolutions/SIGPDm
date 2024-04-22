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
    public class EventosProduccionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventosProduccionRepositorio _IEventosProduccionRepositorio;
        public EventosProduccionController(IEventosProduccionRepositorio IEventosProduccionRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _IEventosProduccionRepositorio = IEventosProduccionRepositorio;
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<EventosProduccion> oRespuesta = new();

            try
            {
                var listaInsumo = await _IEventosProduccionRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<EventosProduccion>(listaInsumo);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpGet("GetPrimerInicio")]
        public async Task<DateTime?> GetPrimerInicio(int ot, string etapa)
        {
            Respuesta<List<EventosProduccion>> oRespuesta = new();

            try
            {
                var list = await _IEventosProduccionRepositorio.Lista();
                var eventos = list.Where(x => x.Ot == ot && x.Etapa == etapa).OrderByDescending(p => p.Fecha).ToList();



                if (eventos.Count == 0)
                {
                    var lst2 = list
                    .Where(x => x.Ot == ot)
                    .OrderByDescending(p => p.Fecha).ToList();
                    return lst2.Last().Fecha;
                }

                var a = eventos.Last().Fecha;

                return a;
                //using DiMetalloContext db = new();

                //var lst = db.EventosProduccions
                //    .Where(x => x.Ot == ot && x.Etapa == etapa)
                //    .OrderByDescending(p => p.Fecha).ToList();

                //if (lst.Count == 0)
                //{
                //    var lst2 = db.EventosProduccions
                //    .Where(x => x.Ot == ot)
                //    .OrderByDescending(p => p.Fecha).ToList();
                //    return lst2.Last().Fecha;
                //}

                //var a = lst.Last().Fecha;

                //return a;
            }
            catch (Exception ex)
            {

            }
            return DateTime.Now;
        }

        [HttpGet("GetByOrder")]
        public async Task<IActionResult> GetByOrder(int ot, string etapa)
        {
            Respuesta<List<EventosProduccion>> oRespuesta = new();

            try
            {
                var lst = await _IEventosProduccionRepositorio.Lista();

                var eventos = lst.Where(x => x.Ot == ot && x.Etapa == etapa).ToList();


                //using DiMetalloContext db = new();

                //var lst = db.EventosProduccions
                //    .Where(x => x.Ot == ot && x.Etapa == etapa)
                //    .ToList();
                
                oRespuesta.List = eventos;
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpGet("GetByOtId")]
        public async Task<IActionResult> GetByOtId(int ot)
        {
            Respuesta<List<EventosProduccion>> oRespuesta = new();

            try
            {

                var lst = await _IEventosProduccionRepositorio.Lista();
                var evento = lst.Where(x => x.Ot == ot).ToList();
                //using DiMetalloContext db = new();

                //var lst = db.EventosProduccions
                //    .Where(x => x.Ot == ot)
                //    .ToList();

                oRespuesta.List = evento;
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpGet("GetTiempoEtapa")]
        public async Task<int> GetTiempoEtapa(int ot, string etapa)
        {

            try
            {
                var lst = await _IEventosProduccionRepositorio.Lista();

                var eventosProduccion = lst
                    .Where(x => x.Ot == ot && x.Etapa == etapa)
                    .OrderBy(e => e.Fecha)
                    .ToList();
                TimeSpan tiempoTotalProduccion = TimeSpan.Zero;
                DateTime? fechaInicio = null;
                foreach (EventosProduccion evento in eventosProduccion)
                {
                    if (evento.Tipo == "Comenzar")
                    {
                        fechaInicio = evento.Fecha;
                    }
                    else if (evento.Tipo == "Finalizado")
                    {
                        if (fechaInicio.HasValue)
                        {
                            tiempoTotalProduccion += evento.Fecha.Value - fechaInicio.Value;
                            fechaInicio = null;
                        }
                    }
                }

                return (int)tiempoTotalProduccion.TotalSeconds;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Respuesta<List<EventosProduccion>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = await _IEventosProduccionRepositorio.Lista();
                oRespuesta.Exito = 1;
                oRespuesta.List = lst;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("estaFinalizado")]
        public bool estaFinalizado(int idOT, int idOperario, string etapa)
        {
            try
            {
                using DiMetalloContext db = new();
                var lst = db.EventosProduccions.Where(x => x.Ot == idOT && x.Operario == idOperario && x.Etapa == etapa).ToList();
                foreach (var item in lst)
                {
                    if (item.Tipo == "Finalizado") return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


            return false;
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventosProduccion model)
        {
            Respuesta<EventosProduccion> oRespuesta = new();

            try
            {
                EventosProduccion eventosProduccion = new();

                eventosProduccion.Etapa = model.Etapa;
                eventosProduccion.Fecha = model.Fecha;
                eventosProduccion.Operario = model.Operario;
                eventosProduccion.Ot = model.Ot;
                eventosProduccion.Tipo = model.Tipo;
                
                await _IEventosProduccionRepositorio.Crear(eventosProduccion);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EventosProduccion model)
        {
            Respuesta<EventosProduccion> oRespuesta = new();

            try
            {
                EventosProduccion eventosProduccion = await _IEventosProduccionRepositorio.Obtener(x => x.Id == model.Id);

                eventosProduccion.Etapa = model.Etapa;
                eventosProduccion.Fecha = model.Fecha;
                eventosProduccion.Operario = model.Operario;
                eventosProduccion.Ot = model.Ot;
                eventosProduccion.Tipo = model.Tipo;

                await _IEventosProduccionRepositorio.Editar(eventosProduccion);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut("{idOperario}/{etapa}/{ot}")]
        public async Task<IActionResult> EditFinalizado(int idOperario, string etapa, int ot,EventosProduccion model)
        {
            Respuesta<EventosProduccion> oRespuesta = new();

            try
            {
                var lst = await _IEventosProduccionRepositorio.Lista();
                var oEventoProcudccion = lst.Where(x => x.Ot == ot && x.Operario == idOperario && x.Etapa == etapa && x.Tipo == "Finalizado").First();


                oEventoProcudccion.Etapa = model.Etapa;
                oEventoProcudccion.Fecha = model.Fecha;
                oEventoProcudccion.Operario = model.Operario;
                oEventoProcudccion.Ot = model.Ot;
                oEventoProcudccion.Tipo = model.Tipo;

                await _IEventosProduccionRepositorio.Editar(oEventoProcudccion);
                //db.Entry(oEventoProduccion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //db.SaveChanges();
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
            Respuesta<EventosProduccion> oRespuesta = new();
            try
            {
                var oEventoRepositorio = await _IEventosProduccionRepositorio.Obtener(x => x.Id == Id);
                await _IEventosProduccionRepositorio.Eliminar(oEventoRepositorio);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }
        [HttpDelete("{idOperario}/{etapa}/{ot}/{fecha}")]
        public IActionResult DeleteByOperario(int idOperario, string etapa, int ot,DateTime fecha)
        {
            Respuesta<EventosProduccion> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                List<EventosProduccion> oEventosProduccion = db.EventosProduccions.Where(x => x.Ot == ot && x.Operario == idOperario && x.Etapa == etapa && x.Fecha == fecha).ToList();
                foreach (var evento in oEventosProduccion)
                {
                    db.Remove(evento);
                    db.SaveChanges();
                }
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
