using MVC.Executor.Login;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            return View();
        }

        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string pass) {
            try {
                LoginEXEC log = new LoginEXEC();
                Session["empleado"] = log.IniciarSesion(user, pass);
                if (Session["empleado"] != null) {
                    log.SetPermisos((Empleado)Session["empleado"]);
                    var empleado = (Empleado)Session["empleado"];
                    if (empleado.GetRoles().Count() > 0) {
                        return View("Index");
                    }
                }
                return View();
            } catch (Exception e) {
                return View();
            }
        }
    }
}