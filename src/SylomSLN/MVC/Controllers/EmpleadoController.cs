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
        public ActionResult Create(Nullable<decimal> salario, Nullable<int> idTipoEmpleado, string cedula, string fecha, string email, string telefono, string usuario, string contra, string contra2) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                fecha = string.IsNullOrEmpty(fecha) ? "1900/01/01" : fecha;
                if (Permisos.Permited("create")
                    && Validation.Valid(salario, idTipoEmpleado, cedula, fecha, email, telefono, usuario, contra)
                    && (contra.Length >= 8 && usuario.Length >= 8)
                    && Validation.OnlyNumber(false, telefono, salario)) {
                    if (contra == contra2) {
                        var r = Empleado.AgregarEmpleado(salario.GetValueOrDefault(), idTipoEmpleado.GetValueOrDefault(0), cedula, fecha, email, telefono, usuario, contra);
                        return Json(new Response() { result = r });
                    }
                }
            } catch (Exception e) {
                var strg = e.ToString();
                //
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult Update(Nullable<int> idEmpleado, Nullable<decimal> salario, Nullable<int> idTipoEmpleado, string fecha, string email, string telefono, string usuario, string contra, string contra2) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                fecha = string.IsNullOrEmpty(fecha) ? "1900/01/01" : fecha;
                if (Permisos.Permited("update")
                    && Validation.Valid(idEmpleado, salario, idTipoEmpleado, fecha, email, telefono)
                    && Validation.OnlyNumber(false, telefono, salario)) {
                    bool ac = false;
                    if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contra) && !string.IsNullOrEmpty(contra2)) {
                        if (contra != contra2) {
                            ac = Empleado.VerificacionContraActual(idEmpleado.GetValueOrDefault(0), contra);
                        }
                    } else {
                        usuario = null;
                        contra = null;
                        contra2 = null;
                        ac = true;
                    }
                    if (ac) {
                        var r = Empleado.ActualizarEmpleado(idEmpleado.GetValueOrDefault(0), salario.GetValueOrDefault(0), idTipoEmpleado.GetValueOrDefault(0), fecha, email, telefono, usuario, contra2);
                        return Json(new Response() { result = r });
                    }
                }
            } catch (Exception e) {
                var strg = e.ToString();
                //
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult Delete(Nullable<int> idEmpleado) {
            try {
                if (idEmpleado != null) {
                    Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                    Empleado = new EmpleadoRUN();
                    int id = ((Empleado)Session[SessionClaims.empleado]).idEmpleado;
                    if (Permisos.Permited("delete") && idEmpleado != id) {
                        var r = Empleado.EliminarEmpleado(idEmpleado.GetValueOrDefault(0));
                        return Json(new Response() { result = r });
                    }
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
                    return Json(r);
                }
            } catch (Exception) {

            }
            return Json(new object[0]);
        }

        [HttpPost]
        public ActionResult ReadTipoEmpleado() {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
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
