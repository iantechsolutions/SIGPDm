using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Shared.Models;
using BlazorApp1.Server.Context;
using BlazorApp1.Shared.Models.Request;

namespace SGCLv3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AspnetusersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta<List<AspNetUser>> oRespuesta = new Respuesta<List<AspNetUser>>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    var lst = db.AspNetUsers.ToList();
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
        public IActionResult Add(AspNetUser model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    AspNetUser oAspnetuserss = new AspNetUser();
                    oAspnetuserss.AspNetUserRole = model.AspNetUserRole;
                    oAspnetuserss.PhoneNumber = model.PhoneNumber;
                    oAspnetuserss.AccessFailedCount = model.AccessFailedCount;
                    oAspnetuserss.AspNetUserLogins = model.AspNetUserLogins;
                    oAspnetuserss.AspNetUserTokens = model.AspNetUserTokens;
                    oAspnetuserss.Id = model.Id;
                    oAspnetuserss.UserName = model.UserName;
                    oAspnetuserss.TwoFactorEnabled = model.TwoFactorEnabled;
                    oAspnetuserss.SecurityStamp = model.SecurityStamp;
                    oAspnetuserss.Email = model.Email;
                    oAspnetuserss.ConcurrencyStamp = model.ConcurrencyStamp;
                    oAspnetuserss.NormalizedEmail = model.NormalizedEmail;
                    oAspnetuserss.NormalizedUserName = model.NormalizedUserName;
                    oAspnetuserss.PasswordHash = model.PasswordHash;
                    oAspnetuserss.PhoneNumberConfirmed = model.PhoneNumberConfirmed;

                    db.AspNetUsers.Add(oAspnetuserss);
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
        public IActionResult Edit(AspNetUser model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();

            try
            {
                using (DiMetalloContext db = new DiMetalloContext())
                {
                    AspNetUser oAspnetuserss = db.AspNetUsers.Find(model.Id);
                    oAspnetuserss.AspNetUserRole = model.AspNetUserRole;
                    oAspnetuserss.PhoneNumber = model.PhoneNumber;
                    oAspnetuserss.AccessFailedCount = model.AccessFailedCount;
                    oAspnetuserss.AspNetUserLogins = model.AspNetUserLogins;
                    oAspnetuserss.AspNetUserTokens = model.AspNetUserTokens;
                    oAspnetuserss.Id = model.Id;
                    oAspnetuserss.UserName = model.UserName;
                    oAspnetuserss.TwoFactorEnabled = model.TwoFactorEnabled;
                    oAspnetuserss.SecurityStamp = model.SecurityStamp;
                    oAspnetuserss.Email = model.Email;
                    oAspnetuserss.ConcurrencyStamp = model.ConcurrencyStamp;
                    oAspnetuserss.NormalizedEmail = model.NormalizedEmail;
                    oAspnetuserss.NormalizedUserName = model.NormalizedUserName;
                    oAspnetuserss.PasswordHash = model.PasswordHash;
                    oAspnetuserss.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
                    db.Entry(oAspnetuserss).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    AspNetUser oAspnetuserss = db.AspNetUsers.Find(Id);
                    db.Remove(oAspnetuserss);
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
                    var lst = db.AspNetUsers.Find(Id);
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


