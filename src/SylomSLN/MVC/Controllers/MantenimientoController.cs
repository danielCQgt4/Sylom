using MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models.Session;
using MVC.Models;
using MVC.Executor.Login;
using BLL.Executor;

namespace MVC.Controllers {

    [SylomAuth]
    public class MantenimientoController : Controller {

        private BitacoraRUN Bitacora = new BitacoraRUN();
        private PermisosEXEC Permisos;
        private MantenimientoRUN Mante = new MantenimientoRUN();

        #region Index
        [HttpGet]
        public ActionResult Index(string mode) {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos", Session[SessionClaims.rolActual].ToString());
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
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos", Session[SessionClaims.rolActual].ToString());
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
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos", Session[SessionClaims.rolActual].ToString());
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
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos", Session[SessionClaims.rolActual].ToString());
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                if (Permisos.Permited("read")) {
                    //string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    List<Mantenimiento> list;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            list = new List<Mantenimiento>();
                            var lp = Mante.ObtenerTipoPacientes();
                            foreach (var item in lp) {
                                Mantenimiento m = new Mantenimiento();
                                m.desc = item.descripcion;
                                m.id = item.idTipoPaciente;
                                list.Add(m);
                            }
                            break;
                        case "medicina":
                            list = new List<Mantenimiento>();
                            var lm = Mante.ObtenerMedicinas();
                            foreach (var item in lm) {
                                Mantenimiento m = new Mantenimiento();
                                m.desc = item.descripcion;
                                m.id = item.idMedicina;
                                list.Add(m);
                            }
                            break;
                        case "institucion":
                            list = new List<Mantenimiento>();
                            var li = Mante.ObtenerInstituciones();
                            foreach (var item in li) {
                                Mantenimiento m = new Mantenimiento();
                                m.desc = item.nombreInstitucion;
                                m.id = item.idInstitucion;
                                list.Add(m);
                            }
                            break;
                        case "tipoempleado":
                            list = new List<Mantenimiento>();
                            var le = Mante.ObtenerTipoEmpleados(Convert.ToInt32(usuario));
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
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos", Session[SessionClaims.rolActual].ToString());
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                if (Permisos.Permited("read")) {
                    //string usuario = ((Empleado)Session[SessionClaims.empleado]).GetIdUsuario();
                    Mantenimiento obj;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            obj = new Mantenimiento();
                            var lp = Mante.ObtenerTipoPaciente(mantenimiento.id);
                            obj.id = lp.idTipoPaciente;
                            obj.desc = lp.descripcion;
                            break;
                        case "medicina":
                            obj = new Mantenimiento();
                            var lm = Mante.ObtenerMedicina(mantenimiento.id);
                            obj.id = lm.idMedicina;
                            obj.desc = lm.descripcion;
                            break;
                        case "institucion":
                            obj = new Mantenimiento();
                            var li = Mante.ObtenerInstitucion(mantenimiento.id);
                            obj.id = li.idInstitucion;
                            obj.desc = li.nombreInstitucion;
                            obj.tel = li.telefono;
                            obj.direccion = li.direccion;
                            break;
                        case "tipoempleado":
                            obj = new Mantenimiento();
                            var le = Mante.ObtenerTipoEmpleado(mantenimiento.id); 
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
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("create")) {
                    int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                    bool result;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            result = Mante.AgregarTipoPaciente(mantenimiento.desc);
                            break;
                        case "medicina":
                            result = Mante.AgregarMedicina(mantenimiento.desc);
                            break;
                        case "institucion":
                            result = Mante.AgregarInstitucion(mantenimiento.desc, mantenimiento.direccion, mantenimiento.tel);
                            break;
                        case "tipoempleado":
                            result = Mante.AgregarTipoEmpleado(mantenimiento.desc);
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
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("update")) {
                    int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                    bool result;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            result = Mante.ActualizarTipoPaciente(mantenimiento.id, mantenimiento.desc);
                            break;
                        case "medicina":
                            result = Mante.ActualizarMedicina(mantenimiento.id, mantenimiento.desc);
                            break;
                        case "institucion":
                            result = Mante.ActualizarInstitucion(mantenimiento.id, mantenimiento.desc, mantenimiento.direccion, mantenimiento.tel);
                            break;
                        case "tipoempleado":
                            result = Mante.ActualizarTipoEmpleado(mantenimiento.id, mantenimiento.desc);
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
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("delete")) {
                    int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                    bool result;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            result = Mante.EliminarTipoPaciente(mantenimiento.id);
                            break;
                        case "medicina":
                            result = Mante.EliminarMedicina(mantenimiento.id);
                            break;
                        case "institucion":
                            result = Mante.EliminarIntitucion(mantenimiento.id);
                            break;
                        case "tipoempleado":
                            result = Mante.EliminarTipoEmpleado(mantenimiento.id);
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