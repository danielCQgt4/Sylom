using MVC.Executor.Login;
using MVC.Models;
using MVC.Models.Session;
using MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [SylomAuth]
    public class PacienteController : Controller
    {
        private PermisosEXEC Permisos;

        [HttpGet]
        public ActionResult Index(string mode) {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Pacientes";
            switch (mode) {
                case "agregarpaciente":
                    if (Permisos.Permited("create")) {
                        return View("Form");
                    }
                    break;
                default:
                    return View();
            }
            return View();
        }

        [HttpGet]
        public ActionResult Form() {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Pacientes";
            ViewBag.mode = "crear";
            if (Permisos.Permited("create")) {
                return View("Form");
            } else {
                return View("Index");
            }
        }
    }
}