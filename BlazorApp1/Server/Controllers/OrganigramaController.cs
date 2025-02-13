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
    public class OrganigramaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrganigramaRepositorio _IOrganigramaRepositorio;
        public OrganigramaController(IOrganigramaRepositorio IOrganigramaRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _IOrganigramaRepositorio = IOrganigramaRepositorio;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Respuesta<Organigrama> oRespuesta = new();

            try
            {
                var listaOrganigrama = await _IOrganigramaRepositorio.Obtener(x => x.id == id);


                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<Organigrama>(listaOrganigrama);
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
            Respuesta<List<Organigrama>> oRespuesta = new();

            try
            {
                var a = await _IOrganigramaRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = _mapper.Map<List<Organigrama>>(a);
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        //[HttpGet("esDeOrganigramaUnico{id:int}")]


        [HttpPost]
        public async Task<IActionResult> Add(Organigrama model)
        {

            Respuesta<Organigrama> oRespuesta = new();

            try
            {
                Organigrama oOrganigrama = new();

                oOrganigrama.Imagen = model.Imagen;


                await _IOrganigramaRepositorio.Crear(oOrganigrama);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Organigrama model)
        {
            Respuesta<Organigrama> oRespuesta = new();

            try
            {


                var oOrganigrama = await _IOrganigramaRepositorio.Obtener(x => x.Imagen == model.Imagen);

                oOrganigrama.Imagen = model.Imagen;
                oOrganigrama.id = model.id;




                await _IOrganigramaRepositorio.Editar(oOrganigrama);
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
            Respuesta<Organigrama> oRespuesta = new();
            try
            {
                var oOrganigrama = await _IOrganigramaRepositorio.Obtener(x => x.id == Id);
                await _IOrganigramaRepositorio.Eliminar(oOrganigrama);
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
