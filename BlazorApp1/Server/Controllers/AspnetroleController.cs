
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models;
using BlazorApp1.Shared.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspNetRoleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<AspNetRole>> oRespuesta = new Respuesta<List<AspNetRole>>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    var lst = db.AspNetRoles.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.List = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpPost]
        public IActionResult Add(AspNetRole model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    AspNetRole oAspNetRoles = new AspNetRole();
                    oAspNetRoles.AspNetUserRoles = model.AspNetUserRoles;
                    oAspNetRoles.AspNetRoleClaims = model.AspNetRoleClaims;
                    oAspNetRoles.Id = model.Id;
                    oAspNetRoles.ConcurrencyStamp = model.ConcurrencyStamp;

                    db.AspNetRoles.Add(oAspNetRoles);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpPut]
        public IActionResult Edit(AspnetroleRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    AspNetRole oAspNetRoles = db.AspNetRoles.Find(model.Id);
                    oAspNetRoles.AspNetUserRoles = model.Aspnetuserroles;
                    oAspNetRoles.AspNetRoleClaims = model.Aspnetroleclaims;
                    oAspNetRoles.ConcurrencyStamp = model.ConcurrencyStamp;
                    db.Entry(oAspNetRoles).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    AspNetRole oAspNetRoles = db.AspNetRoles.Find(Id);
                    db.Remove(oAspNetRoles);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    var lst = db.AspNetRoles.Find(Id);
                    oRespuesta.Exito = 1;
                    oRespuesta.List = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

    }

}


