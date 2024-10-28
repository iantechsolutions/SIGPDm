

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
using System.Net.Http;
using System.Text.Json;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public TicketsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var response = await _httpClient.GetAsync("https://sitp-git-main-hono-proyect.vercel.app/api/hono/tickets");

            if (response.IsSuccessStatusCode)
            {
                var tickets = await response.Content.ReadAsStringAsync();
                return Ok(tickets);
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return StatusCode((int)response.StatusCode, new { message = "Error al obtener los tickets.", details = errorContent });
            }
        }


    }
}
//[HttpGet("{id:int}")]
//public async Task<IActionResult> Get(int id)
//{
//    Respuesta<Tickets> oRespuesta = new();

//    try
//    {
//        var listaTickets = await _httpClient.Obtener(x => x.id == id);


//        oRespuesta.Mensaje = "OK";
//        oRespuesta.Exito = 1;
//        oRespuesta.List = _mapper.Map<Tickets>(listaTickets);
//    }
//    catch (Exception ex)
//    {
//        oRespuesta.Mensaje = ex.Message;
//    }
//    return Ok(oRespuesta);
//}
////[HttpGet("ot/{id:int}")]
////public async Task<IActionResult> GetByOt(int id)
////{
////    Respuesta<Tickets> oRespuesta = new();

////    try
////    {
////        var listaTickets = await _TicketsRepositorio.Obtener(x => x.OT == id);


////        oRespuesta.Mensaje = "OK";
////        oRespuesta.Exito = 1;
////        oRespuesta.List = _mapper.Map<Tickets>(listaTickets);
////    }
////    catch (Exception ex)
////    {
////        oRespuesta.Mensaje = ex.Message;
////    }
////    return Ok(oRespuesta);
////}






//[HttpPost]
//public async Task<IActionResult> Add(Tickets model)
//{

//    Respuesta<Tickets> oRespuesta = new();

//    try
//    {
//        Tickets oTickets = new();

//        oTickets.id = model.id;
//        oTickets.empleado = model.empleado;
//        oTickets.fecha = model.fecha;
//        oTickets.observacion = model.observacion;
//        oTickets.etapa = model.etapa;
//        oTickets.OT = model.OT;
//        oTickets.codigo = model.codigo;
//        oTickets.correccion = model.correccion;
//        oTickets.gravedad = model.gravedad;
//        oTickets.imagenes = model.imagenes;



//        await _TicketsRepositorio.Crear(oTickets);
//        oRespuesta.Exito = 1;
//    }
//    catch (Exception ex)
//    {
//        oRespuesta.Mensaje = ex.Message;

//    }
//    return Ok(oRespuesta);
//}


//[HttpPut]
//public async Task<IActionResult> Edit([FromBody] Tickets model)
//{
//    Respuesta<Tickets> oRespuesta = new();

//    try
//    {


//        var oTickets = await _TicketsRepositorio.Obtener(x => x.id == model.id);

//        oTickets.empleado = model.empleado;
//        oTickets.fecha = model.fecha;
//        oTickets.observacion = model.observacion;
//        oTickets.etapa = model.etapa;
//        oTickets.OT = model.OT;
//        oTickets.codigo = model.codigo;
//        oTickets.correccion = model.correccion;
//        oTickets.gravedad = model.gravedad;
//        oTickets.imagenes = model.imagenes;

//        await _TicketsRepositorio.Editar(oTickets);
//        oRespuesta.Exito = 1;
//    }
//    catch (Exception ex)
//    {
//        oRespuesta.Mensaje = ex.Message;

//    }
//    return Ok(oRespuesta);
//}

//[HttpDelete("{id}")]
//public async Task<IActionResult> Delete(int Id)
//{
//    Respuesta<Tickets> oRespuesta = new();
//    try
//    {
//        var oTickets = await _TicketsRepositorio.Obtener(x => x.id == Id);
//        await _TicketsRepositorio.Eliminar(oTickets);
//        oRespuesta.Exito = 1;
//    }
//    catch (Exception ex)
//    {
//        oRespuesta.Mensaje = ex.Message;

//    }
//    return Ok(oRespuesta);
//}
