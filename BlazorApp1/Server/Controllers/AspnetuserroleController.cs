using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Shared.Models;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models.Request;

namespace SGCLv3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspnetuserroleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<AspNetUserRole>> oRespuesta = new Respuesta<List<AspNetUserRole>>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    var lst = db.AspNetUserRoles.ToList();
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
        public IActionResult Add(AspnetuserrolesRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    AspNetUserRole oAspnetuserroles = new AspNetUserRole();
                    oAspnetuserroles.User = model.User;
                    oAspnetuserroles.Role = model.Role;
                    oAspnetuserroles.UserId = model.UserId;
                    oAspnetuserroles.RoleId = model.RoleId;

                    db.AspNetUserRoles.Add(oAspnetuserroles);
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
        public IActionResult Edit(AspnetuserrolesRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    AspNetUserRole oAspnetuserroles = db.AspNetUserRoles.Find(model.UserId);
                    oAspnetuserroles.User = model.User;
                    oAspnetuserroles.Role = model.Role;
                    oAspnetuserroles.UserId = model.UserId;
                    oAspnetuserroles.RoleId = model.RoleId;
                    db.Entry(oAspnetuserroles).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    AspNetUserRole oAspnetuserroles = db.AspNetUserRoles.Find(Id);
                    db.Remove(oAspnetuserroles);
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
                    var lst = db.AspNetUserRoles.Find(Id);
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


