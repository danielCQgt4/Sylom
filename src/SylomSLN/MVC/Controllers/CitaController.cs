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
    public class CitaController : Controller {

        private readonly BitacoraRUN Bitacora = new BitacoraRUN();
        private PermisosEXEC Permisos;
        private readonly CitaRUN cita = new CitaRUN();
        private readonly PacienteRUN pacienteRUN = new PacienteRUN();

        public ActionResult Index() {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/cita", Session[SessionClaims.rolActual].ToString());
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Pacientes";
            return View();
        }

        public ActionResult Create(Cita c) {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/cita", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("create")) {
                    int id = ((Empleado)Session[SessionClaims.empleado]).idEmpleado;
                    var r = cita.AgregarCita(c.asunto, c.fecha, c.hora, c.notas, c.sintomas, c.idExpediente, id);
                    return Json(new Response { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("CitaController", "Create" , e.Message, 'E');
            }
            return Json(new Response { result = false });
        }

        public ActionResult Delete(int idCita) {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/cita", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("delete")) {
                    var r = cita.CancelarCita(idCita);
                    return Json(new Response { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("CitaController", "Delete", e.Message, 'E');
            }
            return Json(new Response { result = false });
        }

        public ActionResult Read() {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/cita", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("read")) {
                    var r = cita.ConsultarCitas();
                    return Json(new Response { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("CitaController", "Read", e.Message, 'E');
            }
            return Json(new Response { result = false });
        }

        [HttpPost]
        public ActionResult ReadPacientes() {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                List<Paciente> pacientes = new List<Paciente>();
                var r = pacienteRUN.ObtenerPacientes();
                foreach (var obj in r) {
                    if (obj.activo) {
                        Paciente paciente = new Paciente {
                            idPaciente = obj.idPaciente,
                            cedula = obj.cedula,
                            nombre = obj.nombre,
                            apellido1 = obj.apellido1,
                            apellido2 = obj.apellido2,
                            canton = obj.canton,
                            distrito = obj.distrito,
                            fechaNacimiento = obj.fechaNacimiento,
                            descripcionPaciente = obj.descripcionPaciente,
                            idTipoPaciente = obj.idTipoPaciente,
                            idInstitucion = obj.idInstitucion,
                            idExpediente = obj.idExpediente,
                            descripcionExpediente = obj.descripcionExpediente
                        };
                        pacientes.Add(paciente);
                    }
                }
                return Json(new Response { result = pacientes });
            } catch (Exception e) {
                Bitacora.AgregarRegistro("CitaController", "ReadPacientes", e.Message, 'E');
                return Json(new Response {
                    result = new object[0]
                });
            }
        }
    }
}