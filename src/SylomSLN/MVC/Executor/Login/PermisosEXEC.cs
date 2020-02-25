using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Executor.Login {

    public class PermisosEXEC {

        private bool create, read, update, delete = false;
        private Empleado empleado;
        private string url;

        public PermisosEXEC(Empleado empleado, string url) {
            this.empleado = empleado;
            this.url = url;
        }

        private void setPermisos() {
            foreach (var rol in empleado.GetRoles()) {
                foreach (var apartado in rol.GetApartados()) {
                    if (apartado.GetSiteUrl().Equals(url)) {
                        create = apartado.IsCreate();
                        read = apartado.IsRead();
                        update = apartado.IsUpdate();
                        delete = apartado.IsDelete();
                        return;
                    }
                }
            }
        }

        public bool Permited(string action) {
            setPermisos();
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