using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Server.Repositorio.Implementacion;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IPresupuestoRepositorio _PresupuestoRepositorio;
        public PresupuestoController(IPresupuestoRepositorio presupuestoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _PresupuestoRepositorio = presupuestoRepositorio;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Respuesta<Presupuesto> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lst = db.Presupuestos
                    .Where(x => x.Id == id).Include(x => x.InsumoNavigation).Include(x=>x.ProveedorNavigation)
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
        public async Task<IActionResult> GetByInsumo(int id)
        {


            Respuesta<Presupuesto> _Respuesta = new Respuesta<Presupuesto>();

            try
            {
                Presupuesto listaPresupuesto = new Presupuesto();

                // Include related entities
                Presupuesto query = await _PresupuestoRepositorio.Obtener(x => x.Recepcionada == null && x.Estado == "Aprobada");



                // Map entities to DTOs
                listaPresupuesto = _mapper.Map<Presupuesto>(query);

                _Respuesta.List = listaPresupuesto;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            Respuesta<List<Presupuesto>> _Respuesta = new Respuesta<List<Presupuesto>>();

            try
            {
                List<Presupuesto> listaPresupuesto = new List<Presupuesto>();

                // Include related entities
                listaPresupuesto = await _PresupuestoRepositorio.Lista();
                //query = query
                //    .Include(e => e.InfoInsumoNavigation)
                //.Include(e => e.InsumoNavigation)
                //.Include(e => e.ProveedorNavigation);

                // Map entities to DTOs
                Console.WriteLine("aca");
                Console.WriteLine(listaPresupuesto);

                _Respuesta.List = listaPresupuesto;
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

        [HttpGet("Recepciones")]
        public async Task<IActionResult> GetRecepciones()
        {

            Respuesta<List<Presupuesto>> _Respuesta = new Respuesta<List<Presupuesto>>();

            try
            {
                List<Presupuesto> listaPresupuesto = new List<Presupuesto>();

                // Include related entities
                IQueryable<Presupuesto> query = await _PresupuestoRepositorio.Consultar(x => x.Estado == "Aprobada" && x.Recepcionada == null);
                //query = query
                //    .Include(e => e.InfoInsumoNavigation)
                    //.Include(e => e.InsumoNavigation)
                    //.Include(e => e.ProveedorNavigation);

                // Map entities to DTOs
                listaPresupuesto = _mapper.Map<List<Presupuesto>>(query.ToList());

                _Respuesta.List = listaPresupuesto;
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
        public async Task<IActionResult> Add(Presupuesto model)
        {

            Respuesta<Presupuesto> oRespuesta = new();

            try
            {


                Presupuesto _ocUpdate = new();

                _ocUpdate.Estado = model.Estado;
                _ocUpdate.Especificacion = model.Especificacion;
                _ocUpdate.Recepcionada = model.Recepcionada;
                _ocUpdate.Archivo = model.Archivo;
                _ocUpdate.Aprobada = model.Aprobada;
                _ocUpdate.Cantidad = model.Cantidad;
                _ocUpdate.Insumo = model.Insumo;
                _ocUpdate.CondicionPago = model.CondicionPago;
                _ocUpdate.Generada = model.Generada;
                _ocUpdate.Precio = model.Precio;
                _ocUpdate.PrecioUnitario = model.PrecioUnitario;
                _ocUpdate.Iva = model.Iva;
                _ocUpdate.Proveedor = model.Proveedor;
                _ocUpdate.InfoInsumo = model.InfoInsumo;
                _ocUpdate.Comentario = model.Comentario;
                _ocUpdate.NroRemito = model.NroRemito;
                _ocUpdate.OC = model.OC;
                _ocUpdate.PlazoDePago = model.PlazoDePago;
                _ocUpdate.TipoCuenta = model.TipoCuenta;
                _ocUpdate.Moneda = model.Moneda;



                await _PresupuestoRepositorio.Crear(_ocUpdate);
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Presupuesto model)
        {
            Respuesta<Presupuesto> oRespuesta = new();

            try
            {
                Presupuesto _ocNueva = _mapper.Map<Presupuesto>(model);

                Presupuesto _ocUpdate = await _PresupuestoRepositorio.Obtener(x => x.Id == model.Id);


                if (_ocUpdate != null)
                {
                    //Como Presupuesto = Presupuesto no hace falta nada
                    _ocUpdate.Estado = model.Estado;
                    _ocUpdate.Especificacion = model.Especificacion;
                    _ocUpdate.Recepcionada = model.Recepcionada;
                    _ocUpdate.Comentario = model.Comentario;
                    _ocUpdate.Archivo = model.Archivo;
                    _ocUpdate.Aprobada = model.Aprobada;
                    _ocUpdate.Cantidad = model.Cantidad;
                    _ocUpdate.Insumo = model.Insumo;
                    _ocUpdate.CondicionPago = model.CondicionPago;
                    _ocUpdate.Generada = model.Generada;
                    _ocUpdate.Precio = model.Precio;
                    _ocUpdate.PrecioUnitario = model.PrecioUnitario;
                    _ocUpdate.Iva = model.Iva;
                    _ocUpdate.Proveedor = model.Proveedor;
                    _ocUpdate.InfoInsumo = model.InfoInsumo;
                    _ocUpdate.Comentario = model.Comentario;
                    _ocUpdate.NroRemito = model.NroRemito;
                    _ocUpdate.OC = model.OC;
                    _ocUpdate.PlazoDePago = model.PlazoDePago;
                    _ocUpdate.TipoCuenta = model.TipoCuenta;
                    _ocUpdate.Moneda = model.Moneda;

                }


                await _PresupuestoRepositorio.Editar(_ocUpdate);


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
            Respuesta<Presupuesto> oRespuesta = new();
            try
            {
                var oInsumo = await _PresupuestoRepositorio.Obtener(x => x.Id == Id);
                await _PresupuestoRepositorio.Eliminar(oInsumo);
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
