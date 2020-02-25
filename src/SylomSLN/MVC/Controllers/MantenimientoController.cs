using MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models.Session;
using MVC.Executor.Mante;
using MVC.Models;
using MVC.Executor.Login;

namespace MVC.Controllers {

    [SylomAuth]
    public class MantenimientoController : Controller {

        public ActionResult Index() {
            PermisosEXEC permisos = new PermisosEXEC(
                (Empleado)Session[SessionClaims.empleado],
                "/mantenimientos");
            ViewBag.mode = "tipopaciente";
            ViewBag.create = permisos.Permited("create");
            ViewBag.read = permisos.Permited("read");
            ViewBag.update = permisos.Permited("update");
            ViewBag.delete = permisos.Permited("delete");
            return View();
        }

        [HttpGet]
        public ActionResult Index(string mode) {
            PermisosEXEC permisos = new PermisosEXEC(
                (Empleado)Session[SessionClaims.empleado],
                "/mantenimientos");
            ViewBag.mode = string.IsNullOrEmpty(mode) ? "tipopaciente" : mode;
            ViewBag.create = permisos.Permited("create");
            ViewBag.read = permisos.Permited("read");
            ViewBag.update = permisos.Permited("update");
            ViewBag.delete = permisos.Permited("delete");
            return View();
        }

        [HttpPost]
        /*Read*/
        public ActionResult Read(string mode) {
            PermisosEXEC permisos = new PermisosEXEC(
                (Empleado)Session[SessionClaims.empleado],
                "/mantenimientos");
            if (permisos.Permited("read")) {
                string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                MantenimientoEXEC mantenimientoEXEC = new MantenimientoEXEC(usuario);
                var lista = mantenimientoEXEC.ObtenerDatos(mode);
                if (lista != null) {
                    return Json(lista);
                }
            }
            return Json(new object[0]);
        }

        [HttpPost]
        public ActionResult Create(object obj) {
            PermisosEXEC permisos = new PermisosEXEC(
                (Empleado)Session[SessionClaims.empleado],
                "/mantenimientos");
            if (permisos.Permited("create")) {
                dynamic json = obj;
                //Todo terminar
            }
            return Json(new Error {
                result = false
            });
        }
    }

    struct Error {
        public object result;
    }
}