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
    public class PacienteController : Controller {

        private PermisosEXEC Permisos;
        private readonly PacienteRUN pacienteRUN = new PacienteRUN();

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

        [HttpPost]
        public ActionResult Form2(Nullable<int> idPaciente) {
            if (idPaciente == null) {
                return View("Index");
            }
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Pacientes";
            ViewBag.mode = "editar";
            if (Permisos.Permited("update")) {
                return View("Form");
            } else {
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Create(Paciente paciente) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
                var r = false;
                if (Permisos.Permited("create")) {
                    r = pacienteRUN.AgregarPaciente(paciente.cedula, paciente.nombre, paciente.apellido1, paciente.apellido2, paciente.direccion2, paciente.provincia, paciente.canton, paciente.distrito, paciente.genero, paciente.fechaNacimiento, paciente.descripcionPaciente, paciente.descripcionExpediente, paciente.idTipoPaciente, paciente.idInstitucion);
                }
                return Json(new Response { result = r });
            } catch (Exception) {
                //
                return Json(new Response { result = false });
            }
        }

        [HttpPost]
        public ActionResult Update(Paciente paciente) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
                var r = false;
                if (Permisos.Permited("update")) {
                    r = pacienteRUN.ActualizarPaciente(paciente.idPaciente, paciente.cedula, paciente.nombre, paciente.apellido1, paciente.apellido2, paciente.direccion2, paciente.provincia, paciente.canton, paciente.distrito, paciente.genero, paciente.fechaNacimiento, paciente.descripcionPaciente, paciente.descripcionExpediente, paciente.idTipoPaciente, paciente.idInstitucion);
                }
                return Json(new Response { result = r });
            } catch (Exception) {
                //
                return Json(new Response { result = false });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(Paciente paciente) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
                var r = false;
                if (Permisos.Permited("delete")) {
                    r = pacienteRUN.EliminarPaciente(paciente.idPaciente);
                }
                return Json(new Response { result = r });
            } catch (Exception) {
                //
                return Json(new Response { result = false });
            }
        }

        [HttpPost]
        public ActionResult Read() {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
                List<Paciente> pacientes = new List<Paciente>();
                if (Permisos.Permited("read")) {
                    var r = pacienteRUN.ObtenerPacientes();
                    foreach (var obj in r) {
                        Paciente paciente = new Paciente();
                        paciente.idPaciente = obj.idPaciente;
                        paciente.cedula = obj.cedula;
                        paciente.nombre = obj.nombre;
                        paciente.apellido1 = obj.apellido1;
                        paciente.apellido2 = obj.apellido2;
                        paciente.canton = obj.canton;
                        paciente.distrito = obj.distrito;
                        paciente.fechaNacimiento = obj.fechaNacimiento;
                        paciente.descripcionPaciente = obj.descripcionPaciente;
                        paciente.idTipoPaciente = obj.idTipoPaciente;
                        paciente.idInstitucion = obj.idInstitucion;
                        paciente.descripcionExpediente = obj.descripcionExpediente;
                    }
                }
                return Json(new Response { result = pacientes });
            } catch (Exception) {

                return Json(new Response { result = new object[0] });
            }
        }

        [HttpPost]
        public ActionResult ReadOne(Paciente p) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
                Paciente paciente = new Paciente();
                if (Permisos.Permited("read")) {
                    var r = pacienteRUN.ObtenerPaciente(p.idPaciente);
                    paciente.idPaciente = r.idPaciente;
                    paciente.cedula = r.cedula;
                    paciente.nombre = r.nombre;
                    paciente.apellido1 = r.apellido1;
                    paciente.apellido2 = r.apellido2;
                    paciente.canton = r.canton;
                    paciente.distrito = r.distrito;
                    paciente.fechaNacimiento = r.fechaNacimiento;
                    paciente.descripcionPaciente = r.descripcionPaciente;
                    paciente.idTipoPaciente = r.idTipoPaciente;
                    paciente.idInstitucion = r.idInstitucion;
                    paciente.descripcionExpediente = r.descripcionExpediente;
                    return Json(new Response { result = paciente });
                }
            } catch (Exception) {
            }
            return Json(new Response { result = false });
        }
    }
}