using MVC.Executor.Login;
using MVC.Executor.Mante;
using MVC.Models;
using MVC.Models.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SeguridadController : Controller
    {
        private PermisosEXEC Permisos;

        public ActionResult Index()
        {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/seguridad");
            ViewBag.mode = "roles";
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            return View();
        }
    }
}