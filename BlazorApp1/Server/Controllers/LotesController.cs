using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using System.Text.Json;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotesController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<List<Lotes>> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var insumo = db.Insumos
                    .Where(x => x.Id == id)
                    .First();
                oRespuesta.Exito = 1;
                oRespuesta.List = JsonSerializer.Deserialize<List<Lotes>>(insumo.Lotes);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpGet("esDeLoteUnico{id:int}")]
        public bool esDeLoteUnico(int id)
        {
            try
            {
                using DiMetalloContext db = new();
                var insumo = db.Insumos
                    .Where(x => x.Id == id)
                    .First();
                if (insumo.Lotes == null) return false;
                var lotes = JsonSerializer.Deserialize<List<Lotes>>(insumo.Lotes);
                if (lotes.Count == 0) return false;

                foreach (var lote in lotes)
                {
                    if (lote.Tipo == "Lote unico") return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


            return false;
        }

        [HttpPost("{id:int}")]
        public IActionResult Add(int id, [FromBody] Lotes lote)
        {
            Respuesta<InsumoDTO> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var insumo = db.Insumos
                    .Where(x => x.Id == id)
                    .First();

                if (insumo.Lotes != null && insumo.Lotes != "[]")
                {
                    List<Lotes> lotes = JsonSerializer.Deserialize<List<Lotes>>(insumo.Lotes);
                    lotes.Add(lote);
                    insumo.Lotes = JsonSerializer.Serialize(lotes);

                }
                else
                {
                    List<Lotes> lotes = new() { lote };
                    insumo.Lotes = JsonSerializer.Serialize(lotes);
                }
                if(lote.Tipo != "Lote unico") insumo.StockReal += lote.Cantidad;
                db.Entry(insumo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                oRespuesta.Exito = 1;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, [FromBody] Lotes lote)
        {
            Respuesta<InsumoDTO> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                var insumo = db.Insumos
                    .Where(x => x.Id == id)
                    .First();

                var lotes = JsonSerializer.Deserialize<List<Lotes>>(insumo.Lotes);

                int index = lotes.IndexOf(lotes.Where(x => x.Numero == lote.Numero).First());
                var cantVieja = lotes[index].Cantidad;
                lotes[index] = lote;

                insumo.Lotes = JsonSerializer.Serialize(lotes);
                if (lote.Tipo != "Lote unico") insumo.StockReal = insumo.StockReal - cantVieja + lote.Cantidad;
                db.Entry(insumo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                oRespuesta.Exito = 1;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut("delete{id:int}")]
        public IActionResult Delete(int id, [FromBody] Lotes lote)
        {
            Respuesta<Lotes> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();
                var insumo = db.Insumos
                    .Where(x => x.Id == id)
                    .First();

                var lotes = JsonSerializer.Deserialize<List<Lotes>>(insumo.Lotes);
                lotes.RemoveAll(x => x.Numero == lote.Numero);
                
                insumo.Lotes = JsonSerializer.Serialize(lotes);
                if (lote.Tipo != "Lote unico") insumo.StockReal -= lote.Cantidad;

                db.Entry(insumo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
