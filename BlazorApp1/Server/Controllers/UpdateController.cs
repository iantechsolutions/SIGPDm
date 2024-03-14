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
    public class UpdateController : ControllerBase
    {
        [HttpPut]
        public IActionResult Edit()
        {
            Respuesta<bool> oRespuesta = new();

            try
            {
                using DiMetalloContext db = new();

                var lstClientes = db.Clientes.ToList();

                foreach (var cliente in lstClientes)
                {
                    if (cliente.Mail == null) cliente.Mail = "no se cargo el mail";
                    if (cliente.NombreEmpresa == null) cliente.NombreEmpresa = "no se cargo el nombre de la empresa";
                    if (cliente.NombreContacto == null) cliente.NombreContacto = "no se cargo el nombre del contacto";
                    if (cliente.Cuit == null) cliente.Cuit = "no se cargo el cuit";
                    if (cliente.Direccion == null) cliente.Direccion = "no se cargo la direccion";
                    if (cliente.Telefono == null) cliente.Telefono = "no se cargo el telefono";
                    if (cliente.Cp == null) cliente.Cp = "no se cargo el codigo postal";
                    if (cliente.RazonSocial == null) cliente.RazonSocial = "no se cargo la razon social";
                    if (cliente.DomicilioEntrega == null) cliente.DomicilioEntrega = "no se cargo el domicilio de entrega";
                    db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                }

                var lstCotizaciones = db.Cotizaciones.ToList();
                foreach (var cotizacion in lstCotizaciones)
                {
                    if (cotizacion.Cliente == null) cotizacion.Cliente = "no se cargo el cliente";
                    if (cotizacion.Titulo == null) cotizacion.Titulo = "no se cargo el titulo";
                    if (cotizacion.Valorpeso == null) cotizacion.Valorpeso = "no se cargo el precio";
                    if (cotizacion.Codigo == null) cotizacion.Codigo = "no se cargo el codigo";
                    if (cotizacion.Cantidad == null) cotizacion.Cantidad = "no se cargo la cantidad";
                    if (cotizacion.Fechaentrega == null) cotizacion.Fechaentrega = DateTime.Now;
                    db.Entry(cotizacion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                //aca faltan todos los que le hayamos agregado campos obligatorios
                var lstMaquinas = db.MaquinasHerramientas.ToList();
                foreach(var maquina in lstMaquinas)
                {
                    if (maquina.Marca == null) maquina.Marca = "no se cargo la marca";
                    if (maquina.Codigo == null) maquina.Codigo = "no se cargo el codigo";
                    if (maquina.Asignacion == null) maquina.Asignacion = "no se cargo la asignacion";
                    //if (maquina.PeriodicidadMantenimiento == null) maquina.PeriodicidadMantenimiento = "no se cargo la periodicidad de manenimiento";
                    if (maquina.DescripcionMantenimiento == null) maquina.DescripcionMantenimiento = "no se cargo la descripcion mantenimiento";
                    if (maquina.Estado == null) maquina.Estado = "no se cargo el estado";
                    if (maquina.Descripcion == null) maquina.Descripcion = "no se cargo la descripcion";
                    if (maquina.FechaIngreso == null) maquina.FechaIngreso = DateTime.Now;
                    db.Entry(maquina).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                var lstProveedore = db.Proveedores.ToList();
                foreach(var proveedore in lstProveedore)
                {
                    if (proveedore.NombreEmpresa == null) proveedore.NombreEmpresa = "no se cargo el nombre de la empresa";
                    if (proveedore.Cuit == null) proveedore.Cuit = "no se cargo el cuit";
                    if (proveedore.Direccion == null) proveedore.Direccion = "no se cargo la direccion";
                    if (proveedore.Mail == null) proveedore.Mail = "no se cargo el mail";
                    if (proveedore.Telefono == null) proveedore.Telefono = "no se cargo el telefono";
                    if (proveedore.Cp == null) proveedore.Direccion = "no se cargo el codigo postal";
                    if (proveedore.NombreContacto == null) proveedore.NombreContacto = "no se cargo el nombre del contacto";
                    if (proveedore.Categorias == null) proveedore.Categorias = "no se cargo la categoria";
                    db.Entry(proveedore).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }


                var lstOt = db.Ordentrabajos.ToList();

                foreach (var item in lstOt)
                {
                    if (item.Estado == "Punzonado") item.Estado = "Oficina tecnica";

                    //aca faltan tambien

                    db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;  //nunca te olvides de esta linea
                }

                var lstIns = db.Insumos.ToList();

                foreach (var item in lstIns)
                {
                    if (item.Codigo == null) item.Codigo = "no se cargo el codigo";
                    if (item.Descripcion == null) item.Descripcion = "no se cargo la descripcion";
                    db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                //no olvidarse de todas las otras cosas que se llenas con serializaciones y hacerlas quedar bien

                db.SaveChanges();

                oRespuesta.List = true;
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