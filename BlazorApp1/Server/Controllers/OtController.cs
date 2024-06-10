using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using System.Diagnostics;
using System.Text.Json;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Server.Repositorio.Implementacion;


namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOTRepositorio _IOTRepositorio;
        public OtController(IOTRepositorio IOTRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _IOTRepositorio = IOTRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<Ordentrabajo> oRespuesta = new();

            try
            {
                var listaInsumo = await _IOTRepositorio.Obtener(x => x.Id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Ordentrabajo>(listaInsumo);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("Etapa/{etapa}")]
        public async Task<IActionResult> GetPorEtapa(string etapa)
        {
            Respuesta<List<Ordentrabajo>> oRespuesta = new();
            try
            {
                
                var lst = await _IOTRepositorio.GetForEtapa(etapa);
                oRespuesta.Exito = 1;
                oRespuesta.List = lst;

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get(string codigo)
        {

            Console.WriteLine(codigo);
            Respuesta<Ordentrabajo> oRespuesta = new();

            try
            {

               

                var lst = await _IOTRepositorio.Obtener(x => x.Codigo == codigo);
                   
                oRespuesta.Exito = 1;
                oRespuesta.List = lst;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpGet("finalizados")]
        public async Task<IActionResult> GetFinalizados()
        {
            Respuesta<List<Ordentrabajo>> oRespuesta = new();

            try
            {
                var lst = await _IOTRepositorio.Lista();

                oRespuesta.Exito = 1;
                oRespuesta.List = lst.Where(x => x.Estado == "Finalizado" || x.Estado=="Cancelado").ToList();
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpGet("Curso")]
        public async Task<IActionResult> GetEnCurso()
        {
            Respuesta<List<Ordentrabajo>> oRespuesta = new();
            try
            {

                var lst = await _IOTRepositorio.Lista();

                oRespuesta.Exito = 1;
                oRespuesta.List = lst.Where(x => x.Estado != "Finalizado" && x.Estado != "Cancelado").ToList();



            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{inicio:long}/{final:long}")]
        public IActionResult GetRango(long inicio, long final)
        {
            Respuesta<List<Ordentrabajo>> oRespuesta = new();
            try
            {
                DateTime fechaInicio = new DateTime(inicio).Date;
                DateTime fechaFinal = new DateTime(final).Date;
                using DiMetalloContext db = new();
                var lst = db.Ordentrabajos.Where(x => (x.Fechaaplazada.HasValue ? x.Fechaaplazada.Value.Date : x.Fechaentrega.Value.Date) >= fechaInicio && (x.Fechaaplazada.HasValue ? x.Fechaaplazada.Value.Date : x.Fechaentrega.Value.Date) <= fechaFinal).ToList();
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
        public async Task<IActionResult> Get()
        {
            Respuesta<List<Ordentrabajo>> oRespuesta = new();

            try
            {
                var a = await _IOTRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<Ordentrabajo>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }



        [HttpPost]
        public async Task<IActionResult> Add(Ordentrabajo model)
        {
            Respuesta<Ordentrabajo> oRespuesta = new();

            try
            {
                

                Ordentrabajo oOrdentrabajo = new();

                oOrdentrabajo.Id = model.Id;
                oOrdentrabajo.Cliente = model.Cliente;
                oOrdentrabajo.Fechaentrega = model.Fechaentrega;
                oOrdentrabajo.Descripcion = model.Descripcion;
                oOrdentrabajo.Lugarentrega = model.Lugarentrega;
                oOrdentrabajo.Especificaciones = model.Especificaciones;
                oOrdentrabajo.Estado = model.Estado;
                oOrdentrabajo.Planos = model.Planos;
                oOrdentrabajo.Codigo = model.Codigo;
                oOrdentrabajo.Despiece = model.Despiece;
                oOrdentrabajo.Pedidofabrica = model.Pedidofabrica;
                oOrdentrabajo.Cantidad = model.Cantidad;
                oOrdentrabajo.Observaciones = model.Observaciones;
                oOrdentrabajo.Fechas = model.Fechas;
                oOrdentrabajo.Insumosusados = model.Insumosusados;
                oOrdentrabajo.Color = model.Color;
                oOrdentrabajo.Titulo = model.Titulo;
                oOrdentrabajo.Obra = model.Obra;
                oOrdentrabajo.Referencia = model.Referencia;
                oOrdentrabajo.ChapaEstructura = model.ChapaEstructura;
                oOrdentrabajo.ChapaBandejas = model.ChapaBandejas;
                oOrdentrabajo.Zocalo_Trineo = model.Zocalo_Trineo;
                oOrdentrabajo.Portaplanos = model.Portaplanos;
                oOrdentrabajo.TrabaViento = model.TrabaViento;
                oOrdentrabajo.Contrafrentes = model.Contrafrentes;
                oOrdentrabajo.TipoCierre = model.TipoCierre;
                oOrdentrabajo.TapasPiso = model.TapasPiso;
                oOrdentrabajo.SentidoPuertas = model.SentidoPuertas;
                oOrdentrabajo.Cancamos = model.Cancamos;
                oOrdentrabajo.DobleMarcoInterno = model.DobleMarcoInterno;
                oOrdentrabajo.CaballetesTermicas = model.CaballetesTermicas;
                oOrdentrabajo.CaballetesInterruptores = model.CaballetesInterruptores;
                oOrdentrabajo.PerfilesC1yC2 = model.PerfilesC1yC2;
                oOrdentrabajo.PerfilesOmega = model.PerfilesOmega;
                oOrdentrabajo.SistemasAisladores = model.SistemasAisladores;
                oOrdentrabajo.RejillasVentilacion = model.RejillasVentilacion;
                oOrdentrabajo.Sobretecho = model.Sobretecho;
                oOrdentrabajo.ChapaPuertas = model.ChapaPuertas;
                oOrdentrabajo.Cotizaciones = model.Cotizaciones;
                oOrdentrabajo.Remitos = model.Remitos;
                oOrdentrabajo.UltimaEtapa = model.UltimaEtapa;



                await _IOTRepositorio.Crear(oOrdentrabajo);
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
        public async Task<IActionResult> Edit(Ordentrabajo model)
        {
            Respuesta<Ordentrabajo> oRespuesta = new();

            try
            {
                var oOrdentrabajo = await _IOTRepositorio.Obtener(x => x.Id == model.Id);

                oOrdentrabajo.Id = model.Id;
                oOrdentrabajo.Cliente = model.Cliente;
                oOrdentrabajo.Fechaentrega = model.Fechaentrega;
                oOrdentrabajo.Descripcion = model.Descripcion;
                oOrdentrabajo.Lugarentrega = model.Lugarentrega;
                oOrdentrabajo.Especificaciones = model.Especificaciones;
                oOrdentrabajo.Estado = model.Estado;
                oOrdentrabajo.Planos = model.Planos;
                oOrdentrabajo.Codigo = model.Codigo;
                oOrdentrabajo.Despiece = model.Despiece;
                oOrdentrabajo.Pedidofabrica = model.Pedidofabrica;
                oOrdentrabajo.Cantidad = model.Cantidad;
                oOrdentrabajo.Observaciones = model.Observaciones;
                oOrdentrabajo.Fechas = model.Fechas;
                oOrdentrabajo.Insumosusados = model.Insumosusados;
                oOrdentrabajo.Color = model.Color;
                oOrdentrabajo.Titulo = model.Titulo;
                oOrdentrabajo.Obra = model.Obra;
                oOrdentrabajo.Referencia = model.Referencia;
                oOrdentrabajo.ChapaEstructura = model.ChapaEstructura;
                oOrdentrabajo.ChapaBandejas = model.ChapaBandejas;
                oOrdentrabajo.Zocalo_Trineo = model.Zocalo_Trineo;
                oOrdentrabajo.Portaplanos = model.Portaplanos;
                oOrdentrabajo.TrabaViento = model.TrabaViento;
                oOrdentrabajo.Contrafrentes = model.Contrafrentes;
                oOrdentrabajo.TipoCierre = model.TipoCierre;
                oOrdentrabajo.TapasPiso = model.TapasPiso;
                oOrdentrabajo.SentidoPuertas = model.SentidoPuertas;
                oOrdentrabajo.Cancamos = model.Cancamos;
                oOrdentrabajo.DobleMarcoInterno = model.DobleMarcoInterno;
                oOrdentrabajo.CaballetesTermicas = model.CaballetesTermicas;
                oOrdentrabajo.CaballetesInterruptores = model.CaballetesInterruptores;
                oOrdentrabajo.PerfilesC1yC2 = model.PerfilesC1yC2;
                oOrdentrabajo.PerfilesOmega = model.PerfilesOmega;
                oOrdentrabajo.SistemasAisladores = model.SistemasAisladores;
                oOrdentrabajo.RejillasVentilacion = model.RejillasVentilacion;
                oOrdentrabajo.Sobretecho = model.Sobretecho;
                oOrdentrabajo.ChapaPuertas = model.ChapaPuertas;
                oOrdentrabajo.Cotizaciones = model.Cotizaciones;
                oOrdentrabajo.Remitos = model.Remitos;
                oOrdentrabajo.UltimaEtapa = model.UltimaEtapa;


                await _IOTRepositorio.Editar(oOrdentrabajo);
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
            Respuesta<Ordentrabajo> oRespuesta = new();
            try
            {
                var oOrdentrabajo = await _IOTRepositorio.Obtener(x => x.Id == Id);
                await _IOTRepositorio.Eliminar(oOrdentrabajo);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }
        [HttpDelete("codigo/{id}")]
        public async Task<bool> DeleteByCode(string id)
        {
            Console.WriteLine(id);
            Respuesta<Ordentrabajo> oRespuesta = new();
            try
            {


                var oOrdentrabajo = await _IOTRepositorio.Obtener(x => x.Codigo == id);
                await _IOTRepositorio.Eliminar(oOrdentrabajo);
                oRespuesta.Exito = 1;
                return true;
                
                /* using DiMetalloContext db = new();

                Ordentrabajo oOrdentrabajo = db.Ordentrabajos.Where(x => x.Codigo == id).First();
                db.Remove(oOrdentrabajo);
                db.SaveChanges();
                oRespuesta.Exito = 1;
                return true;/*/

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
    }
}
