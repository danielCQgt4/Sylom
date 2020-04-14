using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Executor.Login {

    public class PermisosEXEC {

        private bool create, read, update, delete = false;
        private readonly Empleado empleado;
        private readonly LoginEXEC login;
        private readonly string url;
        private readonly string rolActual;

        public PermisosEXEC(Empleado empleado, string url, string rol) {
            this.empleado = empleado;
            this.url = url;
            this.login = new LoginEXEC();
            this.rolActual = rol;
        }

        private void SetPermisos() {
            try {
                empleado.roles = login.SetPermisos(empleado);
                if (empleado.roles != null) {
                    foreach (var rol in empleado.roles) {
                        if (rol.nombre.Equals(rolActual)) {
                            foreach (var apartado in rol.apartados) {
                                if (apartado.siteUrl.Equals(url)) {
                                    create = apartado.create;
                                    read = apartado.read;
                                    update = apartado.update;
                                    delete = apartado.del;
                                    return;
                                }
                            }
                            break;
                        }
                    }
                }
            } catch (Exception) {
                create = false;
                read = false;
                update = false;
                delete = false;
            }
        }

        public bool Permited(string action) {
            SetPermisos();
            switch (action) {
                case "create":
                    return create;
                case "read":
                    return read;
                case "update":
                    return update;
                case "delete":
                    return delete;
                default:
                    return false;
            }
        }

    }

}