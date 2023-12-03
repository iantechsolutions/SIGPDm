using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Server.Models;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OCController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IOCRepositorio _ocRepositorio;
        public OCController(IOCRepositorio ocRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _ocRepositorio = ocRepositorio;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<Ordencompra> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Ordencompras
                    .Where(x => x.Id == id)
                    .First();
                oRespuesta.Exito = 1;
                oRespuesta.List = lst;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("insumo/{id:int}")]
        public IActionResult GetByInsumo(int id)
        {
            Respuesta<Ordencompra> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Ordencompras
                    .Where(x => x.Insumo == id && x.Recepcionada == null)
                    .First();
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
            Respuesta<List<OrdencompraDTO>> _Respuesta = new Respuesta<List<OrdencompraDTO>>();

            try
            {
                List<OrdencompraDTO> listaOrdencompra = new List<OrdencompraDTO>();
                IQueryable<Ordencompra> query = await _ocRepositorio.Consultar();
                query = query
                    .Include(e => e.InfoInsumoNavigation);
                listaOrdencompra = _mapper.Map<List<OrdencompraDTO>>(query.ToList());

                _Respuesta.List = listaOrdencompra;
                _Respuesta.Exito = 1;

                return StatusCode(StatusCodes.Status200OK, _Respuesta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _Respuesta.Mensaje = ex.Message;
                _Respuesta.Exito = 0;

                return StatusCode(StatusCodes.Status500InternalServerError, _Respuesta);
            }
        }

        [HttpPost]
        public IActionResult Add(Ordencompra model)
        {
            Respuesta<Ordencompra> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                Ordencompra oOrdencompra = new();
                model.InfoInsumo = model.Insumo;
                db.Ordencompras.Add(model);
                db.SaveChanges();
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
        public IActionResult Edit(Ordencompra model)
        {
            Respuesta<Ordencompra> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();
                model.InfoInsumo = model.Insumo;
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            Console.WriteLine("HOLA");
            Respuesta<Ordencompra> oRespuesta = new();
            try
            {
                using DiMetalloContext db = new();

                Ordencompra oOrdencompra = db.Ordencompras.Find(Id);
                db.Remove(oOrdencompra);
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
