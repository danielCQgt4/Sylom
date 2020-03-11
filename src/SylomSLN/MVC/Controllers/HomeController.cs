using MVC.Executor.Login;
using MVC.Models;
using MVC.Models.Session;
using MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Login(string user, string pass) {
            try {
                ViewBag.Title = "Sylom";
                ViewBag.Usuario = user;
                ViewBag.Contra = pass; 
                ViewBag.EMensaje = String.Empty;
                LoginEXEC log = new LoginEXEC();
                Session[SessionClaims.empleado] = log.IniciarSesion(user, pass);
                if (Session[SessionClaims.empleado] != null) {
                    Session[SessionClaims.rolActual] = ((Empleado)Session["empleado"]).GetRoles()[0].GetNombre();
                    return RedirectToAction("Index");
                }
            } catch (Exception e) {
                //Log
            }
            ViewBag.EMensaje = "Usuario o contraseña incorrectos";
            return View();
        }

        public ActionResult Logout() {
            Session[SessionClaims.empleado] = null;
            return RedirectToAction("Index");
        }
    }

    struct Response {
        public object result;
    }
}