﻿using Microsoft.AspNetCore.Authentication;
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

                using DiMetalloContext db = new();

                var lst = db.EventosProduccions
                    .Where(x => x.Ot == ot && x.Etapa == etapa)
                    .OrderByDescending(p => p.Fecha).ToList();

                if (lst.Count == 0)
                {
                    var lst2 = db.EventosProduccions
                    .Where(x => x.Ot == ot)
                    .OrderByDescending(p => p.Fecha).ToList();
                    return lst2.Last().Fecha;
                }

                var a = lst.Last().Fecha;

                return a;
            }
            catch (Exception ex)
            {

            }
            return DateTime.Now;
        }

        [HttpGet("GetByOrder")]
        public IActionResult GetByOrder(int ot, string etapa)
        {
            Respuesta<List<EventosProduccion>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.EventosProduccions
                    .Where(x => x.Ot == ot && x.Etapa == etapa)
                    .ToList();
                
                oRespuesta.List = lst;
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpGet("GetByOtId")]
        public IActionResult GetByOtId(int ot)
        {
            Respuesta<List<EventosProduccion>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.EventosProduccions
                    .Where(x => x.Ot == ot)
                    .ToList();

                oRespuesta.List = lst;
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpGet("GetTiempoEtapa")]
        public int GetTiempoEtapa(int ot, string etapa)
        {

            try
            {
                using DiMetalloContext db = new();

                var lst = db.EventosProduccions
                    .Where(x => x.Ot == ot && x.Etapa == etapa)
                    .OrderBy(e => e.Fecha)
                    .ToList();
                TimeSpan tiempoTotalProduccion = TimeSpan.Zero;
                DateTime? fechaInicio = null;
                foreach (EventosProduccion evento in lst)
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
        public IActionResult Get()
        {
            Respuesta<List<EventosProduccion>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.EventosProduccions.ToList();
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
        public IActionResult Add(EventosProduccion model)
        {
            Respuesta<EventosProduccion> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                db.EventosProduccions.Add(model);
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
        public IActionResult Edit(EventosProduccion model)
        {
            Respuesta<EventosProduccion> oRespuesta = new();

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

        [HttpPut("{idOperario}/{etapa}/{ot}")]
        public IActionResult EditFinalizado(int idOperario, string etapa, int ot,EventosProduccion model)
        {
            Respuesta<EventosProduccion> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                EventosProduccion oEventoProduccion = db.EventosProduccions.Where(x => x.Ot == ot && x.Operario == idOperario && x.Etapa == etapa && x.Tipo=="Finalizado").First();


                db.Entry(oEventoProduccion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            Respuesta<EventosProduccion> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                EventosProduccion oEventosProduccion = db.EventosProduccions.Find(Id);
                db.Remove(oEventosProduccion);
                db.SaveChanges();
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
