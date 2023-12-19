using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BlazorApp1.Server.Models;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Implementacion;
using BlazorApp1.Server.Repositorio.Contrato;

namespace BlazorApp1.Server.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class CategoriaController : ControllerBase
        {
            private readonly IMapper _mapper;
            private readonly ICategoriaRepositorio _ICategoriaRepositorio;
            public CategoriaController(ICategoriaRepositorio ICategoriaRepositorio, IMapper mapper)
            {
                _mapper = mapper;
            _ICategoriaRepositorio = ICategoriaRepositorio;
            }


            [HttpGet("{id:int}")]
            public async Task<IActionResult> Get(int id)
            {
                Respuesta<Categoria> oRespuesta = new();

                try
                {

                    var listaInsumo = await _ICategoriaRepositorio.Obtener(x => x.Id == id);


                    oRespuesta.Mensaje = "OK";
                    oRespuesta.Exito = 1;
                    oRespuesta.List = _mapper.Map<Categoria>(listaInsumo);
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
                Respuesta<List<Categoria>> oRespuesta = new();

                try
                {
                    var a = await _ICategoriaRepositorio.Lista();

                    oRespuesta.Mensaje = "OK";
                    oRespuesta.Exito = 1;
                    oRespuesta.List = _mapper.Map<List<Categoria>>(a);
                }
                catch (Exception ex)
                {
                    oRespuesta.Mensaje = ex.Message;
                }
                return Ok(oRespuesta);
            }



            [HttpPost]
            public async Task<IActionResult> Add(Categoria model)
            {

                Respuesta<Categoria> oRespuesta = new();

                try
                {


                Categoria oCategoria = new();

                oCategoria.Id = model.Id;
                oCategoria.Name = model.Name;
                /*oCategoria.StockReal = model.StockReal;
                oCategoria.Nombre = model.Nombre;
                oCategoria.Codigo = model.Codigo;
                oCategoria.Foto = model.Foto;
                oCategoria.Descripcion = model.Descripcion;
                oCategoria.Recepcion = model.Recepcion;
                oCategoria.Lotes = model.Lotes;
                */
                    


                    await _ICategoriaRepositorio.Crear(oCategoria);
                    oRespuesta.Exito = 1;
                }
                catch (Exception ex)
                {
                    oRespuesta.Mensaje = ex.Message;

                }
                return Ok(oRespuesta);
            }


            [HttpPut]
            public async Task<IActionResult> Edit([FromBody] Categoria model)
            {
                Respuesta<Categoria> oRespuesta = new();

                try
                {


                    var oCategoria = await _ICategoriaRepositorio.Obtener(x => x.Id == model.Id);

                oCategoria.Id = model.Id;
                oCategoria.Name = model.Name;
                /*oCategoria.StockReal = model.StockReal;
                oCategoria.Nombre = model.Nombre;
                oCategoria.Codigo = model.Codigo;
                oCategoria.Foto = model.Foto;
                oCategoria.Descripcion = model.Descripcion;
                oCategoria.Recepcion = model.Recepcion;
                oCategoria.Lotes = model.Lotes;
                */

                await _ICategoriaRepositorio.Editar(oCategoria);
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
                Respuesta<Insumo> oRespuesta = new();
                try
                {
                    var oCategoria = await _ICategoriaRepositorio.Obtener(x => x.Id == Id);
                    await _ICategoriaRepositorio.Eliminar(oCategoria);
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
