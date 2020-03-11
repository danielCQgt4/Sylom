using BLL.Executor;
using MVC.Executor.Login;
using MVC.Executor.Mante;
using MVC.Models;
using MVC.Models.Session;
using MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers {

    [SylomAuth]
    public class SeguridadController : Controller {

        //TODO Esto lo dejo de ultimo
        private PermisosEXEC Permisos;
        private RolRUN rolSec;

        public ActionResult Index() {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/seguridad");
            ViewBag.mode = "roles";
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Seguridad";
            return View();
        }

        [HttpGet]
        public ActionResult Index(string mode) {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/seguridad");
            ViewBag.mode = string.IsNullOrEmpty(mode) ? "roles" : mode;
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Seguridad";
            return View();
        }

        [HttpPost]
        public ActionResult CreateRol(string name) {
            try {
                rolSec = new RolRUN();
                return Json(new Response() { result = rolSec.AgregarRol(name) });
            } catch (Exception) {
                return Json(new Response() { result = false });
            }
        }

        [HttpPost]
        public ActionResult CreateRol(int idRol, int idApartado, bool crear, bool leer, bool editar, bool eliminar) {
            try {
                rolSec = new RolRUN();
                var r = rolSec.AgregarRolApartado(idRol, idApartado, crear, leer, editar, eliminar);
                return Json(new Response() { result = r });
            } catch (Exception) {
                return Json(new Response() { result = false });
            }
        }

        [HttpPost]
        public ActionResult DeleteRol(int idRol) {
            try {
                rolSec = new RolRUN();
                return Json(new Response() { result = rolSec.EliminarRol(idRol) });
            } catch (Exception) {
                return Json(new Response() { result = false });
            }
        }

        [HttpPost]
        public ActionResult DeleteRol(int idRol, int idApartado) {
            try {
                rolSec = new RolRUN();
                return Json(new Response() { result = rolSec.EliminarRolApartado(idRol, idApartado) });
            } catch (Exception) {
                return Json(new Response() { result = false });
            }
        }

        [HttpPost]
        public ActionResult ReadRol(string mode) {
            try {
                rolSec = new RolRUN();
                int id = ((Empleado)Session[SessionClaims.empleado]).GetIdEmpleado();
                if (string.IsNullOrEmpty(mode)) {
                    return Json(rolSec.ConsultarRoles(id));
                } else {
                    return Json(rolSec.ConsultarRolApartado(id));
                }
            } catch (Exception) {
                return Json(new object[0]);
            }
        }

    }

}