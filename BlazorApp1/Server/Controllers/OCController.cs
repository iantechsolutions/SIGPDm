using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using AutoMapper;
using BlazorApp1.Server.Repositorio.Contrato;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Shared.Models; //cambiazo
using BlazorApp1.Server.Repositorio.Implementacion;

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
        public async Task<IActionResult> GetByInsumo(int id)
        {


            Respuesta<OrdencompraDTO> _Respuesta = new Respuesta<OrdencompraDTO>();

            try
            {
                OrdencompraDTO listaOrdencompra = new OrdencompraDTO();

                // Include related entities
                Ordencompra query = await _ocRepositorio.Obtener(x=>x.Recepcionada==null && x.Estado=="Aprobada");
          
                 

                // Map entities to DTOs
                listaOrdencompra = _mapper.Map<OrdencompraDTO>(query);

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

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            Respuesta<List<OrdencompraDTO>> _Respuesta = new Respuesta<List<OrdencompraDTO>>();

            try
            {
                List<OrdencompraDTO> listaOrdencompra = new List<OrdencompraDTO>();

                // Include related entities
                IQueryable<Ordencompra> query = await _ocRepositorio.Consultar();
                query = query
                    .Include(e => e.InfoInsumoNavigation)
                    .Include(e => e.InsumoNavigation)
                    .Include(e => e.ProveedorNavigation);

                // Map entities to DTOs
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
        
        [HttpGet("Recepciones")]
        public async Task<IActionResult> GetRecepciones()
        {

            Respuesta<List<OrdencompraDTO>> _Respuesta = new Respuesta<List<OrdencompraDTO>>();

            try
            {
                List<OrdencompraDTO> listaOrdencompra = new List<OrdencompraDTO>();

                // Include related entities
                IQueryable<Ordencompra> query = await _ocRepositorio.Consultar(x=>x.Estado=="Aprobada" && x.Recepcionada==null);
                query = query
                    .Include(e => e.InfoInsumoNavigation)
                    .Include(e => e.InsumoNavigation)
                    .Include(e => e.ProveedorNavigation);

                // Map entities to DTOs
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
        public async Task<IActionResult> Add(Ordencompra model)
        {

            Respuesta<Ordencompra> oRespuesta = new();

            try
            {


                Ordencompra _ocUpdate = new();

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
                _ocUpdate.TipoCuenta = model.TipoCuenta;
                _ocUpdate.Moneda = model.Moneda;
                _ocUpdate.Descuento = model.Descuento;


                var coso = await _ocRepositorio.Crear(_ocUpdate);
                oRespuesta.List = coso;
                oRespuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(OrdencompraDTO model)
        {
            Respuesta<OrdencompraDTO> oRespuesta = new();

            try
            {
                Ordencompra _ocNueva = _mapper.Map<Ordencompra>(model);

                Ordencompra _ocUpdate = await _ocRepositorio.Obtener(x => x.Id == model.Id);

                
                if (_ocUpdate != null)
                {
                    //Como OrdenCompra = OrdenCompraDTO no hace falta nada
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
                    _ocUpdate.TipoCuenta = model.TipoCuenta;
                     _ocUpdate.Moneda = model.Moneda;
                    _ocUpdate.Descuento = model.Descuento;

                }


                await _ocRepositorio.Editar(_ocUpdate);


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
            Respuesta<Ordencompra> oRespuesta = new();
            try
            {
                var oInsumo = await _ocRepositorio.Obtener(x => x.Id == Id);
                await _ocRepositorio.Eliminar(oInsumo);
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
