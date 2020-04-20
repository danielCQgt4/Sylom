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

        private readonly BitacoraRUN Bitacora = new BitacoraRUN();
        private PermisosEXEC Permisos;
        private readonly MantenimientoRUN Mante = new MantenimientoRUN();

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
                    List<Mantenimiento> list;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            list = new List<Mantenimiento>();
                            var lp = Mante.ObtenerTipoPacientes();
                            foreach (var item in lp) {
                                Mantenimiento m = new Mantenimiento {
                                    desc = item.descripcion,
                                    id = item.idTipoPaciente,
                                    activo = item.activo
                                };
                                list.Add(m);
                            }
                            break;
                        case "medicina":
                            list = new List<Mantenimiento>();
                            var lm = Mante.ObtenerMedicinas();
                            foreach (var item in lm) {
                                Mantenimiento m = new Mantenimiento {
                                    desc = item.descripcion,
                                    id = item.idMedicina,
                                    activo = item.activo
                                };
                                list.Add(m);
                            }
                            break;
                        case "institucion":
                            list = new List<Mantenimiento>();
                            var li = Mante.ObtenerInstituciones();
                            foreach (var item in li) {
                                Mantenimiento m = new Mantenimiento {
                                    desc = item.nombreInstitucion,
                                    id = item.idInstitucion,
                                    activo = item.activo
                                };
                                list.Add(m);
                            }
                            break;
                        case "tipoempleado":
                            list = new List<Mantenimiento>();
                            var le = Mante.ObtenerTipoEmpleados(Convert.ToInt32(usuario));
                            foreach (var item in le) {
                                Mantenimiento m = new Mantenimiento {
                                    desc = item.descripcion,
                                    id = item.idTipoEmpleado,
                                    activo = item.activo
                                };
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
                    Mantenimiento obj = null;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            var lp = Mante.ObtenerTipoPaciente(mantenimiento.id);
                            if (lp != null) {
                                obj = new Mantenimiento {
                                    id = lp.idTipoPaciente,
                                    desc = lp.descripcion,
                                    activo = lp.activo
                                };
                            }
                            break;
                        case "medicina":
                            var lm = Mante.ObtenerMedicina(mantenimiento.id);
                            if (lm != null) {
                                obj = new Mantenimiento {
                                    id = lm.idMedicina,
                                    desc = lm.descripcion,
                                    activo = lm.activo
                                };
                            }
                            break;
                        case "institucion":
                            var li = Mante.ObtenerInstitucion(mantenimiento.id);
                            if (li != null) {
                                obj = new Mantenimiento {
                                    id = li.idInstitucion,
                                    desc = li.nombreInstitucion,
                                    tel = li.telefono,
                                    direccion = li.direccion,
                                    activo = li.activo
                                };
                            }
                            break;
                        case "tipoempleado":
                            var le = Mante.ObtenerTipoEmpleado(mantenimiento.id);
                            if (le != null) {
                                obj = new Mantenimiento {
                                    id = le.idTipoEmpleado,
                                    desc = le.descripcion,
                                    activo = le.activo
                                };
                            }
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
        public ActionResult Reactivate(Mantenimiento mantenimiento) {
            try {
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/mantenimientos", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("delete")) {
                    int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                    bool result;
                    switch (mantenimiento.mode) {
                        case "tipopaciente":
                            result = Mante.EliminarMedicina(mantenimiento.id);
                            break;
                        case "medicina":
                            result = Mante.HabilitarMedicina(mantenimiento.id);
                            break;
                        case "institucion":
                            result = Mante.HabilitarIntitucion(mantenimiento.id);
                            break;
                        case "tipoempleado":
                            result = Mante.HabilitarTipoEmpleado(mantenimiento.id);
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