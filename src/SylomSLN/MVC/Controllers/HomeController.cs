using BLL.Executor;
using MVC.Executor.Login;
using MVC.Models;
using MVC.Models.Session;
using MVC.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            ViewBag.Title = "Sylom";
            return View();
        }

        public ActionResult About() {
            ViewBag.Title = "Sylom";
            return View();
        }

        [HttpGet]
        public ActionResult Login() {
            ViewBag.Title = "Sylom";
            ViewBag.EMensaje = String.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usu) {
            try {
                ViewBag.Title = "Sylom";
                ViewBag.Usuario = usu.user;
                ViewBag.Contra = usu.pass;
                ViewBag.EMensaje = String.Empty;
                LoginEXEC log = new LoginEXEC();

                string baseUrl = ConfigurationManager.AppSettings["URL_API"];
                //crea el el encabezado
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                var context = new LoginRUN();
                Usuario usuApi = new Usuario();
                usuApi.user = context.Encriptar(usu.user);
                usuApi.pass = context.Encriptar(usu.pass);

                string stringData = JsonConvert.SerializeObject(usuApi);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                try {
                    HttpResponseMessage response = client.PostAsync("/api/login/authenticate", contentData).Result;
                    var stringJWT = response.Content.ReadAsStringAsync().Result;

                    Session[SessionClaims.token] = stringJWT.Replace("\"", String.Empty);


                    if (!string.IsNullOrEmpty(Session[SessionClaims.token].ToString())) {
                        Session[SessionClaims.empleado] = log.IniciarSesion(usu.user, usu.pass);
                    }

                    if (Session[SessionClaims.empleado] != null) {
                        Session[SessionClaims.rolActual] = ((Empleado)Session["empleado"]).GetRoles()[0].GetNombre();
                        return RedirectToAction("Index");
                    }
                } catch (Exception e) {
                    ViewBag.EMensaje = "Hubo fallo en la autenticacion";
                }
            } catch (Exception e) {
                ViewBag.EMensaje = "Hubo fallo en la autenticacion";
            }
            ViewBag.EMensaje = "Las credenciaces son incorrectos";
            return View();
        }

        public ActionResult Logout() {
            Session[SessionClaims.empleado] = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CambioRol(string rol) {
            Empleado e = (Empleado)Session[SessionClaims.empleado];
            foreach (var item in e.GetRoles()) {
                if (item.GetNombre().Equals(rol)) {
                    Session[SessionClaims.rolActual] = rol;
                    break;
                }
            }
            return Json(new Response { result = true });
        }
    }

    struct Response {
        public object result;
    }
}