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
    public class SeguridadController : Controller {

        private readonly BitacoraRUN Bitacora = new BitacoraRUN();
        private PermisosEXEC Permisos;
        private RolRUN rolSec;

        [HttpGet]
        public ActionResult Index() {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/seguridad", Session[SessionClaims.rolActual].ToString());
            ViewBag.mode = "roles";
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Seguridad";
            return View();
        }

        [HttpGet]
        public ActionResult Form(Nullable<int> id) {
            Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/seguridad", Session[SessionClaims.rolActual].ToString());
            ViewBag.mode = id == null ? "crear" : "editar";
            ViewBag.create = Permisos.Permited("create");
            ViewBag.read = Permisos.Permited("read");
            ViewBag.update = Permisos.Permited("update");
            ViewBag.delete = Permisos.Permited("delete");
            ViewBag.Title = "Seguridad";
            if (Permisos.Permited("create") || Permisos.Permited("update")) {
                return View();
            } else {
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult CreateRol(Rol rol) {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/seguridad", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("create")) {
                    rolSec = new RolRUN();
                    bool r = false;
                    var id = rolSec.AgregarRol(rol.nombre);
                    bool addTo = true;
                    if (id != -1) {
                        r = true;
                        rol.idRol = id;
                        foreach (var apar in rol.apartados) {
                            rolSec.AgregarRolApartado(id, apar.idApartado, apar.create, apar.read, apar.update, apar.del);
                        }
                        foreach (var user in rol.usuarios) {
                            if (user.idUsuario == 1) {
                                addTo = false;
                            }
                            rolSec.AgregarRolUsuario(user.idUsuario, id);
                        }
                        if (addTo) {
                            rolSec.AgregarRolUsuario(1, id);
                        }
                    }
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("SeguridadController", "CreateRol", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult UpdateRol(Rol rol) {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/seguridad", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("update")) {
                    rolSec = new RolRUN();
                    var r = rolSec.ActualizarRol(rol.idRol, rol.nombre);
                    bool addTo = true;
                    if (r) {
                        foreach (var apar in rol.apartados) {
                            rolSec.AgregarRolApartado(rol.idRol, apar.idApartado, apar.create, apar.read, apar.update, apar.del);
                        }
                        foreach (var user in rol.usuarios) {
                            if (user.idUsuario == 1) {
                                addTo = false;
                            }
                            rolSec.AgregarRolUsuario(user.idUsuario, rol.idRol);
                        }
                        if (addTo) {
                            rolSec.AgregarRolUsuario(1, rol.idRol);
                        }
                    }
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("SeguridadController", "UpdateRol", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult DeleteRol(int idRol) {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/seguridad", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("delete")) {
                    rolSec = new RolRUN();
                    int r = rolSec.EliminarRol(idRol) ? 1 : 0;
                    var roles = ((Empleado)Session[SessionClaims.empleado]).roles;
                    var temp = String.Empty;
                    foreach (var item in roles) {
                        if (item.nombre.Equals(Session[SessionClaims.rolActual].ToString())) {
                            r = 5;
                            break;
                        } else {
                            temp = item.nombre;
                        }
                    }
                    if (r == 5) {
                        Session[SessionClaims.rolActual] = temp;
                    }
                    return Json(new Response() { result = r });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("SeguridadController", "DeleteRol", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult ReadRol(int idRol) {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/seguridad", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("read")) {
                    rolSec = new RolRUN();
                    int id = ((Empleado)Session[SessionClaims.empleado]).idEmpleado;
                    var roles = rolSec.ConsultarRoles(id);
                    Rol rol = null;
                    List<Apartado> apartados = new List<Apartado>();
                    List<Usuario> usuarios = new List<Usuario>();
                    foreach (var o in roles) {
                        if (o.idRol == idRol) {
                            rol = new Rol {
                                idRol = o.idRol,
                                nombre = o.descripcion,
                                apartados = apartados,
                                usuarios = usuarios
                            };
                            break;
                        }
                    }
                    var aparts = rolSec.ConsultarRolApartados(idRol);
                    foreach (var a in aparts) {
                        Apartado ap = new Apartado {
                            create = a.crear.GetValueOrDefault(),
                            read = a.leer.GetValueOrDefault(),
                            update = a.editar.GetValueOrDefault(),
                            del = a.eliminar.GetValueOrDefault(),
                            idApartado = a.idApartado,
                            nombre = a.nombreApartado
                        };
                        apartados.Add(ap);
                    }
                    var users = rolSec.ConsultarRolUsuarios(idRol);
                    foreach (var u in users) {
                        Usuario us = new Usuario {
                            idUsuario = u.idUsuario,
                            nombre = u.nombre
                        };
                        usuarios.Add(us);
                    }
                    return Json(new Response() { result = rol });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("SeguridadController", "ReadRol", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult ReadRoles() {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                Permisos = new PermisosEXEC((Empleado)Session[SessionClaims.empleado], "/seguridad", Session[SessionClaims.rolActual].ToString());
                if (Permisos.Permited("read")) {
                    rolSec = new RolRUN();
                    int id = ((Empleado)Session[SessionClaims.empleado]).idEmpleado;
                    return Json(new Response() { result = rolSec.ConsultarRoles(id) });
                }
            } catch (Exception e) {
                Bitacora.AgregarRegistro("SeguridadController", "ReadRoles", e.Message, 'E');
            }
            return Json(new Response() { result = false });
        }

        [HttpPost]
        public ActionResult ReadApartados() {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                rolSec = new RolRUN();
                return Json(new Response() { result = rolSec.ConsultarApartados() });
            } catch (Exception e) {
                Bitacora.AgregarRegistro("SeguridadController", "ReadApartados", e.Message, 'E');
                return Json(new Response() { result = false });
            }
        }

        [HttpPost]
        public ActionResult ReadUsuarios() {
            try {
                int usuario = ((Empleado)Session[SessionClaims.empleado]).idUsuario;
                Bitacora.SetUsuario(usuario);
                rolSec = new RolRUN();
                return Json(new Response() { result = rolSec.ConsultarUsuarios() });
            } catch (Exception e) {
                Bitacora.AgregarRegistro("SeguridadController", "ReadUsuarios", e.Message, 'E');
                return Json(new Response() { result = false });
            }
        }
    }

}