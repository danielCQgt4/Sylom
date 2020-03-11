using MVC.Executor.Login;
using MVC.Models;
using MVC.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PacienteController : Controller
    {
        private PermisosEXEC Permisos;

        [HttpGet]
        public ActionResult Index()
        {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Pacientes";
            return View();
        }
    }
}