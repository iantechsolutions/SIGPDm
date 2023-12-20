using AutoMapper;
using BlazorApp1.Server.Repositorio.Contrato;
using BlazorApp1.Server.Repositorio.Implementacion;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateBBDDController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInsumoRepositorio _InsumoRepositorio;
        public UpdateBBDDController(IInsumoRepositorio InsumoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _InsumoRepositorio = InsumoRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            Respuesta<InsumoDTO> oRespuesta = new();
            try
            {
                var insumo = await _InsumoRepositorio.Lista();

                foreach (var item in insumo)
                {
                    try
                    {
                        var lotes = JsonSerializer.Deserialize<List<LotesOld>>(item.Lotes);
                        Lote loteNew = new Lote();
                        List<Lote> listLoteNew = new List<Lote>();
                        foreach (var loteOld in lotes)
                        {

                            Console.WriteLine(loteOld.NroRemito);
                            if (loteOld.NroRemito != null)
                            {
                                loteNew.NroRemito = loteOld.NroRemito.ToString();
                                Console.WriteLine(item.Codigo);
                            }
                            else loteNew.NroRemito = "";

                            loteNew.Numero = loteOld.Numero;
                            loteNew.Alto = loteOld.Alto;
                            loteNew.Ancho = loteOld.Ancho;
                            loteNew.OC = loteOld.OC;
                            loteNew.Cantidad = loteOld.Cantidad;
                            loteNew.Tipo = loteOld.Tipo;
                            loteNew.FechaIngreso = loteOld.FechaIngreso;
                            loteNew.Proveedor = loteOld.Proveedor;
                            listLoteNew.Add(loteNew);
                        }
                        var lotesNew = JsonSerializer.Serialize(listLoteNew);
                        item.Lotes = lotesNew;
                        await _InsumoRepositorio.Editar(item);


                        oRespuesta.Exito = 1;
                    }
                    catch (Exception ex)
                    {
                       
                        Console.WriteLine(ex.Message);
                    }
                }
                return Ok("Base actualizada con éxito");

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
                return Ok(oRespuesta);
            }
        }
        //[HttpGet("test")]
        //public async Task<IActionResult> test()
        //{
        //    Respuesta<InsumoDTO> oRespuesta = new();
        //    try
        //    {
        //        string test = "{\"Tipo\":\"Lote unico\",\"Numero\":null,\"Cantidad\":null,\"FechaIngreso\":\"2023-09-25T15:48:03.376-03:00\",\"Alto\":null,\"Ancho\":null,\"NroRemito\":\"\",\"OC\":null,\"Proveedor\":null}";
        //        var lotes = JsonSerializer.Deserialize<List<Lote>>(test);

        //    }
        //    catch (Exception ex)
        //    {
        //        oRespuesta.Mensaje = ex.Message;
        //    }
        //        return Ok(oRespuesta);
        //}
    }




    public class LotesOld
    {
        public string Tipo { get; set; }
        public int? Numero { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Alto { get; set; }
        public int? Ancho { get; set; }
        public int? NroRemito { get; set; }
        public int? OC { get; set; }
        public string? Proveedor { get; set; }
    }
}
