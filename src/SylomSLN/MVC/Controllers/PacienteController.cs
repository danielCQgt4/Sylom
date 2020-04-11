using BLL.Executor;
using MVC.Executor.Login;
using MVC.Models;
using MVC.Models.Session;
using MVC.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers {
    [SylomAuth]
    public class PacienteController : Controller {

        private PermisosEXEC Permisos;
        private readonly PacienteRUN pacienteRUN = new PacienteRUN();
        private readonly LugaresRUN lugares = new LugaresRUN();
        private readonly MantenimientoRUN mantenimiento = new MantenimientoRUN();

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

        [HttpGet]
        public ActionResult Form2(Nullable<int> id) {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Pacientes";
            ViewBag.mode = "editar";
            if (id == null) {
                return View("Index");
            }
            if (Permisos.Permited("update")) {
                return View("Form");
            } else {
                return View("Index");
            }
        }

        #region Paciente
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
        public ActionResult Delete(Paciente paciente) {
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
                        pacientes.Add(paciente);
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
                    if (r != null) {
                        paciente.idPaciente = r.idPaciente;
                        paciente.cedula = r.cedula;
                        paciente.nombre = r.nombre;
                        paciente.apellido1 = r.apellido1;
                        paciente.apellido2 = r.apellido2;
                        paciente.canton = r.canton;
                        paciente.genero = r.genero;
                        paciente.provincia = r.provincia;
                        paciente.direccion2 = r.direccion2;
                        paciente.distrito = r.distrito;
                        paciente.fechaNacimiento = r.fechaNacimiento;
                        paciente.descripcionPaciente = r.descripcionPaciente;
                        paciente.idTipoPaciente = r.idTipoPaciente;
                        paciente.idInstitucion = r.idInstitucion;
                        paciente.descripcionExpediente = r.descripcionExpediente;
                        return Json(new Response { result = paciente });
                    }
                }
            } catch (Exception e) {
                //
            }
            return Json(new Response { result = false });
        }
        #endregion

        #region Lugares
        [HttpPost]
        public ActionResult ReadProvincias() {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
                List<Provincia> provincias = new List<Provincia>();
                if (Permisos.Permited("read")) {
                    var r = lugares.ConsultarProvincias();
                    if (r != null) {
                        foreach (var obj in r) {
                            Provincia p = new Provincia();
                            p.idProvincia = obj.idProvincia;
                            p.nombre = obj.nombre;
                            provincias.Add(p);
                        }
                    }
                }
                return Json(new Response { result = provincias });
            } catch (Exception) {
                //
                return Json(new Response { result = new object[0] });
            }
        }

        [HttpPost]
        public ActionResult ReadCantones(Provincia p) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
                List<Canton> cantones = new List<Canton>();
                if (Permisos.Permited("read")) {
                    var r = lugares.ConsultarCantones(p.idProvincia);
                    if (r != null) {
                        foreach (var obj in r) {
                            Canton c = new Canton();
                            c.idProvincia = obj.idProvincia;
                            c.nombre = obj.nombre;
                            c.idCanton = obj.idCanton;
                            cantones.Add(c);
                        }
                    }
                }
                return Json(new Response { result = cantones });
            } catch (Exception) {
                //
                return Json(new Response { result = new object[0] });
            }
        }

        [HttpPost]
        public ActionResult ReadDistritos(Canton c) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
                List<Distrito> distritos = new List<Distrito>();
                if (Permisos.Permited("read")) {
                    var r = lugares.ConsultarDistritos(c.idProvincia, c.idCanton);
                    if (r != null) {
                        foreach (var obj in r) {
                            Distrito d = new Distrito();
                            d.idCanton = obj.idCanton;
                            d.nombre = obj.nombre;
                            d.idProvincia = obj.idProvincia;
                            d.idDistrito = obj.idDistrito;
                            distritos.Add(d);
                        }
                    }
                }
                return Json(new Response { result = distritos });
            } catch (Exception) {
                //
                return Json(new Response { result = new object[0] });
            }
        }
        #endregion

        #region Extra
        [HttpPost]
        public ActionResult ReadTipoCliente() {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
                if (Permisos.Permited("read")) {
                    mantenimiento.Usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    var r = mantenimiento.ObtenerTipoPacientes();
                    return Json(new Response { result = r });
                }
                return Json(new Response { result = new object[0] });
            } catch (Exception) {
                //
                return Json(new Response { result = new object[0] });
            }
        }

        [HttpPost]
        public ActionResult ReadInstituciones() {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/paciente");
                if (Permisos.Permited("read")) {
                    mantenimiento.Usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    var r = mantenimiento.ObtenerInstituciones();
                    return Json(new Response { result = r });
                }
                return Json(new Response { result = new object[0] });
            } catch (Exception) {
                //
                return Json(new Response { result = new object[0] });
            }
        }

        [HttpPost]
        public ActionResult ReadPersonFromApi(string cedula) {
            try {
                string baseUrl = ConfigurationManager.AppSettings["URL_API"];
                //crea el el encabezado
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(contentType);


                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session[SessionClaims.token].ToString());

                string stringData = JsonConvert.SerializeObject(new ApiRequest { eeHpcXLYQp = cedula });
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("/Sylom/obtenerPersona", contentData).Result;
                var r = response.Content.ReadAsStringAsync().Result;
                var des = JsonConvert.DeserializeObject<List<Persona2>>(r);

                return Json(new Response { result = des });
            } catch (Exception e) {
                return Json(new Response { result = null });
            }
        }

        private struct ApiRequest {
            public string eeHpcXLYQp;
        }
        #endregion
    }
}