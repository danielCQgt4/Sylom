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

        private PermisosEXEC Permisos;
        private MantenimientoEXEC mantenimientoEXEC;

        [HttpGet]
        public ActionResult Index(string mode) {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
            ViewBag.mode = string.IsNullOrEmpty(mode) ? "tipopaciente" : mode;
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Mantenimiento";
            return View();
        }

        [HttpPost]
        public ActionResult Read(string mode) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
                if (Permisos.Permited("read")) {
                    string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    mantenimientoEXEC = new MantenimientoEXEC(usuario) {
                        IdEmpleado = ((Empleado)Session[SessionClaims.empleado]).GetIdEmpleado()
                    };
                    var lista = mantenimientoEXEC.ObtenerDatos(mode);
                    if (lista != null) {
                        return Json(lista);
                    }
                }
            } catch (Exception) {
            }
            return Json(new object[0]);
        }

        [HttpPost]
        public ActionResult Create(string mode, int id, string desc) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
                if (Permisos.Permited("create")) {
                    string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    mantenimientoEXEC = new MantenimientoEXEC(usuario);
                    bool result = mantenimientoEXEC.AccionMantenimiento(mode, "create", id, desc);
                    if (result) {
                        return Json(new Response { result = true });
                    }
                }
            } catch (Exception) {
            }
            return Json(new Response { result = false });
        }

        [HttpPost]
        public ActionResult Update(string mode, int id, string desc) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
                if (Permisos.Permited("update")) {
                    string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    mantenimientoEXEC = new MantenimientoEXEC(usuario);
                    bool result = mantenimientoEXEC.AccionMantenimiento(mode, "update", id, desc);
                    if (result) {
                        return Json(new Response { result = true });
                    }
                }
            } catch (Exception) {
            }
            return Json(new Response { result = false });
        }

        [HttpPost]
        public ActionResult Delete(string mode, int id, string desc) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
                if (Permisos.Permited("delete")) {
                    string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    mantenimientoEXEC = new MantenimientoEXEC(usuario) {
                        IdEmpleado = ((Empleado)Session[SessionClaims.empleado]).GetIdEmpleado()
                    };
                    bool result = mantenimientoEXEC.AccionMantenimiento(mode, "delete", id, desc);
                    if (result) {
                        return Json(new Response { result = true });
                    }
                }
            } catch (Exception) {
            }
            return Json(new Response { result = false });
        }

    }

}