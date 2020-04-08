using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Security;
using System.Security.Claims;

namespace API.Controllers {

    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController {

        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing() {
            return Ok(true);
        }
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser() {
            Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user:{identity.Name}-IsAuthenticated:{identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticated(LoginRequest login) {
            if (login == null) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var clave = Seguridad.Encriptar("123");
            var desClave = Seguridad.DesEncriptar(clave);
            //Validamos las credenciales correctas, solooooo!!!! para el demo.
            bool isCredentialValid = (login.Password == "123456");


            if (isCredentialValid) {
                var token = TokenGenerator.GenerateTokenJwt(login.UserName);

                //try {
                //    WindowsIdentity.GetCurrent().AddClaim(new Claim(ClaimTypes.Name, login.UserName));
                //    Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                    //Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                    return Ok(token);
                //} catch (Exception e) {
                //    return BadRequest("Estamos mal");
                //}
            } else {
                return Unauthorized();
            }
        }

    }
}
