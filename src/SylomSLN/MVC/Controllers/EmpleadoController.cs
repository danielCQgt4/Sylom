using BLL.Executor;
using MVC.Executor;
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

    [SylomAuth]
    public class EmpleadoController : Controller {

        private EmpleadoRUN Empleado;
        private PermisosEXEC Permisos;

        [HttpGet]
        public ActionResult Index() {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Empleado";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("create")) {
                    var r = Empleado.AgregarEmpleado(empleado.tipoEmpleado.idTipo, empleado.nombre, empleado.usuario, empleado.pass);
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                //
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult Update(Empleado empleado) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("update")) {
                    var r = Empleado.ActualizarEmpleado(empleado.idEmpleado, empleado.tipoEmpleado.idTipo, empleado.nombre, empleado.usuario, empleado.pass);
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                //
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult Delete(int idEmpleado) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                int id = ((Empleado)Session[SessionClaims.empleado]).idEmpleado;
                if (Permisos.Permited("delete") && idEmpleado != id) {
                    var r = Empleado.EliminarEmpleado(idEmpleado);
                    return Json(new Response() { result = r });
                }
            } catch (Exception) {
                //
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult Read() {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                int id = ((Empleado)Session[SessionClaims.empleado]).idEmpleado;
                if (Permisos.Permited("read")) {
                    var r = Empleado.ConsultarEmpleados();
                    return Json(new Response() { result = r });
                }
            } catch (Exception) {

            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult ReadTipoEmpleado() {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("read")) {
                    var r = Empleado.ConsultarTipoEmpleados(0);
                    return Json(new Response() { result = r });
                }
            } catch (Exception) {

            }
            return Json(new Response() { result = false });
        }

    }
}
