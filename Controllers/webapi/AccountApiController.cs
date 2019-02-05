using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using ComputosPJ.Models;
using System.Linq;

namespace ComputosPJ.Controllers.Seguridad
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountApiController : ApiController
    {
        private ComputosPJEntities db = new ComputosPJEntities();
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;

        public AccountApiController()
        {
        }

        public AccountApiController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UsuarioApi usuarioApi)
        {
            if (usuarioApi.x == "76b32470-e66e-4408-8541-5c36a173fff0")
            {
                AspNetUsers aspNetUsers = db.AspNetUsers.FirstOrDefault(us=> us.UserName == usuarioApi.username);
                if (aspNetUsers != null)
                {
                    aspNetUsers.FirstName = usuarioApi.nombre;
                    aspNetUsers.LastName = usuarioApi.apellido;
                    aspNetUsers.Dni = usuarioApi.dni;
                    aspNetUsers.Foto = usuarioApi.foto;
                    aspNetUsers.Email = usuarioApi.email;
                    db.SaveChanges();
                    return Ok("usuario modificado");
                }
                else {

                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var user = new ApplicationUser() { FirstName = usuarioApi.nombre, LastName = usuarioApi.apellido, UserName = usuarioApi.username, Email = usuarioApi.email, Dni = usuarioApi.dni, Foto = usuarioApi.foto };

                    IdentityResult result = await UserManager.CreateAsync(user, usuarioApi.password);

                    if (!result.Succeeded)
                    {
                        return GetErrorResult(result);
                    }

                    return Ok();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public string AppVersion()
        {

            if (db.Version.Find(1) != null)
            {
                return db.Version.Find(1).Version1;
            }
            else
            {
                return "error";
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Aplicaciones auxiliares
        

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No hay disponibles errores ModelState para enviar, por lo que simplemente devuelva un BadRequest vacío.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }


        #endregion
    }
}
