using BLL.Executor;
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
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado");
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            return View();
        }

        [HttpPost]
        public ActionResult Create(decimal salario, int idTipoEmpleado, string cedula, string fecha, string email, string telefono, string usuario, string contra) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado");
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("create")) {
                    var r = Empleado.AgregarEmpleado(salario, idTipoEmpleado, cedula, fecha, email, telefono, usuario, contra);
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                var strg = e.ToString();
                //
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult Update(int idEmpleado, decimal salario, int idTipoEmpleado, string fecha, string email, string telefono, string usuario, string contra) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado");
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("update")) {
                    if (string.IsNullOrEmpty(fecha)) {
                        fecha = "0001/01/01";
                    }
                    var r = Empleado.ActualizarEmpleado(idEmpleado, salario, idTipoEmpleado, fecha, email, telefono, usuario, contra);
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                var strg = e.ToString();
                //
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult Delete(int idEmpleado) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado");
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("delete")) {
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
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado");
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("read")) {
                    var r = Empleado.ConsultarEmpleados();
                    return Json(r);
                }
            } catch (Exception) {

            }
            return Json(new object[0]);
        }

        [HttpPost]
        public ActionResult ReadTipoEmpleado() {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado");
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("read")) {
                    var r = Empleado.ConsultarTipoEmpleados(0);
                    return Json(r);
                }
            } catch (Exception) {

            }
            return Json(new object[0]);
        }

    }
}
