using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Executor;
using DAL;
using MVC.Models;

namespace MVC.Executor.Login {

    public class LoginEXEC {

        private LoginRUN log = new LoginRUN();

        public Empleado IniciarSesion(string usuario, string contra) {
            Empleado empleado = new Empleado();
            var result = log.IniciarSesion(usuario, contra);
            if (result != null) {
                empleado.SetIdEmpleado(result[0].idEmpleado);
                empleado.SetCedula(result[0].cedula);
                empleado.SetNombre(result[0].nombre);
                //TODO seguir con todos los demas
                return empleado;
            }
            return null;
        }

        public void SetPermisos(Empleado empleado) {
            if (empleado != null) {
                var result = log.GetPermisos(empleado.GetIdEmpleado());
                string nombreRol = String.Empty;
                if (result != null) {
                    List<Rol> roles = new List<Rol>();
                    List<Apartado> apartados = new List<Apartado>();
                    Rol rol;
                    foreach (var permiso in result) {
                        Apartado apartado = new Apartado();
                        apartado.setIdApartado(permiso.idApartado);
                        apartado.setNombre(permiso.nombreApartado);
                        apartado.setSiteUrl(permiso.siteUrl);
                        apartado.setIcon(permiso.icon);
                        apartado.setCreate(permiso.crear == null ? false : permiso.crear.GetValueOrDefault());
                        apartado.setRead(permiso.leer == null ? false : permiso.leer.GetValueOrDefault());
                        apartado.setUpdate(permiso.editar == null ? false : permiso.editar.GetValueOrDefault());
                        apartado.setDelete(permiso.eliminar == null ? false : permiso.eliminar.GetValueOrDefault());
                        apartados.Add(apartado);
                        if (permiso.descripcion.Equals(nombreRol)) {
                            rol = new Rol();
                            rol.SetNombre(permiso.descripcion);
                            rol.SetApartados(apartados);
                            roles.Add(rol);
                            apartados = new List<Apartado>();
                        }
                    }
                    empleado.SetRoles(roles);
                }
            }
        }
    }
}