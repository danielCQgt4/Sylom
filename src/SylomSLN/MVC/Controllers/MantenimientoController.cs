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
using BLL.Executor;

namespace MVC.Controllers {

    [SylomAuth]
    public class MantenimientoController : Controller {

        private BitacoraRUN Bitacora = new BitacoraRUN();
        private PermisosEXEC Permisos;
        private MantenimientoEXEC mantenimientoEXEC;
        private MantenimientoRUN mantenimientoRUN = new MantenimientoRUN();

        #region Index
        [HttpGet]
        public ActionResult Index(string mode) {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
            ViewBag.mode = string.IsNullOrEmpty(mode) ? "tipopaciente" : mode;
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            return View();
        }
        #endregion

        #region Form
        [HttpGet]
        public ActionResult Form(string mode) {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
            ViewBag.mode = string.IsNullOrEmpty(mode) ? "tipopaciente" : mode;
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.action = "crear";
            if (Permisos.Permited("create")) {
                return View("");
            } else {
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Form2(string mode, int id) {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
            ViewBag.mode = string.IsNullOrEmpty(mode) ? "tipopaciente" : mode;
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.action = "modificar";
            if (Permisos.Permited("update")) {
                return View("Form");
            } else {
                return View("Index");
            }
        }
        #endregion

        #region Actions
        [HttpPost]
        public ActionResult Read(Mantenimiento mantenimiento) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
                string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                Bitacora.SetUsuario(usuario);
                if (Permisos.Permited("read")) {
                    //string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    List<Mantenimiento> list;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            list = new List<Mantenimiento>();
                            var lp = mantenimientoRUN.ObtenerTipoPacientes();
                            foreach (var item in lp) {
                                Mantenimiento m = new Mantenimiento();
                                m.desc = item.descripcion;
                                m.id = item.idTipoPaciente;
                                list.Add(m);
                            }
                            break;
                        case "medicina":
                            list = new List<Mantenimiento>();
                            var lm = mantenimientoRUN.ObtenerMedicinas();
                            foreach (var item in lm) {
                                Mantenimiento m = new Mantenimiento();
                                m.desc = item.descripcion;
                                m.id = item.idMedicina;
                                list.Add(m);
                            }
                            break;
                        case "institucion":
                            list = new List<Mantenimiento>();
                            var li = mantenimientoRUN.ObtenerInstituciones();
                            foreach (var item in li) {
                                Mantenimiento m = new Mantenimiento();
                                m.desc = item.nombreInstitucion;
                                m.id = item.idInstitucion;
                                list.Add(m);
                            }
                            break;
                        case "tipoempleado":
                            list = new List<Mantenimiento>();
                            var le = mantenimientoRUN.ObtenerTipoEmpleados(Convert.ToInt32(usuario));
                            foreach (var item in le) {
                                Mantenimiento m = new Mantenimiento();
                                m.desc = item.descripcion;
                                m.id = item.idTipoEmpleado;
                                list.Add(m);
                            }
                            break;
                        default:
                            list = null;
                            break;
                    }
                    if (list != null) {
                        Bitacora.AgregarRegistro("MantenimientoController", "Read", $"Lecutura de datos {mantenimiento.mode}", 'R');
                        return Json(new Response { result = list });
                    }
                } else {
                    Bitacora.AgregarRegistro("MantenimientoController", "Read", $"Lecutura de datos {mantenimiento.mode}", 'N');
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("MantenimientoController", "Read", e.Message, 'E');
            }
            return Json(new Response { result = new object[0] });
        }

        [HttpPost]
        public ActionResult ReadOne(Mantenimiento mantenimiento) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
                string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                Bitacora.SetUsuario(usuario);
                if (Permisos.Permited("read")) {
                    //string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    Mantenimiento obj;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            obj = new Mantenimiento();
                            var lp = mantenimientoRUN.ObtenerTipoPaciente(mantenimiento.id);
                            obj.id = lp.idTipoPaciente;
                            obj.desc = lp.descripcion;
                            break;
                        case "medicina":
                            obj = new Mantenimiento();
                            var lm = mantenimientoRUN.ObtenerMedicina(mantenimiento.id);
                            obj.id = lm.idMedicina;
                            obj.desc = lm.descripcion;
                            break;
                        case "institucion":
                            obj = new Mantenimiento();
                            var li = mantenimientoRUN.ObtenerInstitucion(mantenimiento.id);
                            obj.id = li.idInstitucion;
                            obj.desc = li.nombreInstitucion;
                            obj.tel = li.telefono;
                            obj.direccion = li.direccion;
                            break;
                        case "tipoempleado":
                            obj = new Mantenimiento();
                            var le = mantenimientoRUN.ObtenerTipoEmpleado(mantenimiento.id); 
                            obj.id = le.idTipoEmpleado;
                            obj.desc = le.descripcion;
                            break;
                        default:
                            obj = null;
                            break;
                    }
                    if (obj != null) {
                        Bitacora.AgregarRegistro("MantenimientoController", "ReadOne", $"Lecutura de datos {mantenimiento.mode}", 'R');
                        return Json(new Response { result = obj });
                    }
                } else {
                    Bitacora.AgregarRegistro("MantenimientoController", "ReadOne", $"Lecutura de datos {mantenimiento.mode}", 'N');
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("MantenimientoController", "ReadOne", e.Message, 'E');
            }
            return Json(new Response { result = false });
        }

        [HttpPost]
        public ActionResult Create(Mantenimiento mantenimiento) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
                if (Permisos.Permited("create")) {
                    string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    bool result;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            result = mantenimientoRUN.AgregarTipoPaciente(mantenimiento.desc);
                            break;
                        case "medicina":
                            result = mantenimientoRUN.AgregarMedicina(mantenimiento.desc);
                            break;
                        case "institucion":
                            result = mantenimientoRUN.AgregarInstitucion(mantenimiento.desc, mantenimiento.direccion, mantenimiento.tel);
                            break;
                        case "tipoempleado":
                            result = mantenimientoRUN.AgregarTipoEmpleado(mantenimiento.desc);
                            break;
                        default:
                            result = false;
                            break;
                    }
                    return Json(new Response { result = result });
                }
            } catch (Exception) {
            }
            return Json(new Response { result = false });
        }

        [HttpPost]
        public ActionResult Update(Mantenimiento mantenimiento) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
                if (Permisos.Permited("update")) {
                    string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    mantenimientoEXEC = new MantenimientoEXEC(usuario);
                    bool result;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            result = mantenimientoRUN.ActualizarTipoPaciente(mantenimiento.id, mantenimiento.desc);
                            break;
                        case "medicina":
                            result = mantenimientoRUN.ActualizarMedicina(mantenimiento.id, mantenimiento.desc);
                            break;
                        case "institucion":
                            result = mantenimientoRUN.ActualizarInstitucion(mantenimiento.id, mantenimiento.desc, mantenimiento.direccion, mantenimiento.tel);
                            break;
                        case "tipoempleado":
                            result = mantenimientoRUN.ActualizarTipoEmpleado(mantenimiento.id, mantenimiento.desc);
                            break;
                        default:
                            result = false;
                            break;
                    }
                    return Json(new Response { result = result });
                }
            } catch (Exception) {
            }
            return Json(new Response { result = false });
        }

        [HttpPost]
        public ActionResult Delete(Mantenimiento mantenimiento) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos");
                if (Permisos.Permited("delete")) {
                    string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    bool result;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            result = mantenimientoRUN.EliminarTipoPaciente(mantenimiento.id);
                            break;
                        case "medicina":
                            result = mantenimientoRUN.EliminarMedicina(mantenimiento.id);
                            break;
                        case "institucion":
                            result = mantenimientoRUN.EliminarIntitucion(mantenimiento.id);
                            break;
                        case "tipoempleado":
                            result = mantenimientoRUN.EliminarTipoEmpleado(mantenimiento.id);
                            break;
                        default:
                            result = false;
                            break;
                    }
                    return Json(new Response { result = result });
                }
            } catch (Exception) {
            }
            return Json(new Response { result = false });
        }
        #endregion

    }

}