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

        private readonly BitacoraRUN Bitacora = new BitacoraRUN();
        private EmpleadoRUN Empleado;
        private MantenimientoRUN mantenimientoRUN;
        private PermisosEXEC Permisos;

        [HttpGet]
        public ActionResult Index() {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.empleado = ((Empleado)Session[SessionClaims.empleado]).idEmpleado;
            ViewBag.Title = "Empleado";
            return View();
        }

        [HttpGet]
        public ActionResult Form(Nullable<int> id) {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
            ViewBag.mode = id == null ? "crear" : "editar";
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Empleado";
            if (Permisos.Permited("create") || Permisos.Permited("update")) {
                return View();
            } else {
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado) {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("create")) {
                    var r = Empleado.AgregarEmpleado(empleado.tipoEmpleado.idTipo, empleado.nombre, empleado.usuario, empleado.pass);
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("EmpleadoController", "Create", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult Update(Empleado empleado) {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("update")) {
                    var r = Empleado.ActualizarEmpleado(empleado.idEmpleado, empleado.tipoEmpleado.idTipo, empleado.nombre, empleado.usuario, empleado.pass);
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("EmpleadoController", "Update", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult Delete(int idEmpleado) {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                int id = ((Empleado)Session[SessionClaims.empleado]).idEmpleado;
                if (Permisos.Permited("delete") && idEmpleado != id) {
                    var r = Empleado.EliminarEmpleado(idEmpleado);
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("EmpleadoController", "Create", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult Read() {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                int id = ((Empleado)Session[SessionClaims.empleado]).idEmpleado;
                if (Permisos.Permited("read")) {
                    var r = Empleado.ConsultarEmpleados();
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("EmpleadoController", "Read", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult ReadOne(int idEmpleado) {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                Empleado = new EmpleadoRUN();
                if (Permisos.Permited("read")) {
                    var empleados = Empleado.ConsultarEmpleados();
                    foreach (var item in empleados) {
                        if (item.idEmpleado == idEmpleado) {
                            return Json(new Response() { result = item });
                        }
                    }
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("EmpleadoController", "ReadOne", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult ReadTipoEmpleado() {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/empleado", Session[SessionClaims.rolActual].ToString());
                mantenimientoRUN = new MantenimientoRUN();
                if (Permisos.Permited("read")) {
                    var r = mantenimientoRUN.ObtenerTipoEmpleados(usuario);
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("EmpleadoController", "ReadTipoEmpleado", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

    }
}
