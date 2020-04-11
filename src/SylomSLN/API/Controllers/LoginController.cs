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
using BLL.Executor;

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
            var dbContenxt = new LoginRUN();

            var log = dbContenxt.IniciarSesion(login.user, login.pass, false);

            if (log != null) {
                var token = TokenGenerator.GenerateTokenJwt(login.user);

                return Ok(token);
            } else {
                return Unauthorized();
            }
        }

    }
}
