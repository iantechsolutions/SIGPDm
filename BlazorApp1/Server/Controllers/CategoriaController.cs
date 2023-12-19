using AutoMapper;
using BlazorApp1.Server.Context;
using BlazorApp1.Server.Models;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _IClienteRepositorio;
        public CategoriaController(ICategoriaRepositorio IClienteRepositorio, IMapper mapper)
        {
            _IClienteRepositorio = IClienteRepositorio;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Respuesta<List<Categoria>> oRespuesta = new();

            try
            {
                var a = await _IClienteRepositorio.Lista();

                oRespuesta.Mensaje = "OK";
                oRespuesta.Exito = 1;
                oRespuesta.List = a.ToList();
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
                using DiMetalloContext db = new();
                db.Categorias.Add(model);
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
