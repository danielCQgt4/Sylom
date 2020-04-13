using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Executor;
using DAL;
using MVC.Models;

namespace MVC.Executor.Login {

    public class LoginEXEC {

        private readonly LoginRUN Log;

        public LoginEXEC() {
            Log = new LoginRUN();
        }

        public Empleado IniciarSesion(string usuario, string contra) {
            Empleado empleado = new Empleado();
            var result = Log.IniciarSesion(usuario, contra, true);
            if (result != null) {
                empleado.SetIdEmpleado(result.idEmpleado);
                empleado.SetNombre(result.nombre);
                empleado.SetIdUsuario(result.idUsuario.ToString());
                empleado.SetTipoEmpleado(new TipoDato(result.idTipoEmpleado));
                empleado.SetRoles(SetPermisos(empleado));
                if (empleado.GetRoles() != null) {
                    return empleado;
                }
            }
            return null;
        }

        public List<Rol> SetPermisos(Empleado empleado) {
            if (empleado != null) {
                var result = Log.GetPermisos(empleado.GetIdEmpleado());
                string nombreRol = String.Empty;
                if (result != null) {
                    List<Rol> roles = new List<Rol>();
                    List<Apartado> apartados = new List<Apartado>();
                    foreach (var permiso in result) {
                        var temp = permiso;
                        if (!permiso.descripcion.Equals(nombreRol)) {
                            nombreRol = permiso.descripcion;
                            Rol rol = new Rol();
                            rol.SetNombre(permiso.descripcion);
                            apartados = new List<Apartado>();
                            rol.SetApartados(apartados);
                            roles.Add(rol);
                        }
                        Apartado apartado = new Apartado();
                        apartado.SetIdApartado(permiso.idApartado);
                        apartado.SetNombre(permiso.nombreApartado);
                        apartado.SetSiteUrl(permiso.siteUrl);
                        apartado.SetIcon(permiso.icon);
                        apartado.SetCreate(permiso.crear.GetValueOrDefault());
                        apartado.SetRead(permiso.leer.GetValueOrDefault());
                        apartado.SetUpdate(permiso.editar.GetValueOrDefault());
                        apartado.SetDelete(permiso.eliminar.GetValueOrDefault());
                        apartados.Add(apartado);
                    }
                    if (roles.Count() > 0) {
                        return roles;
                    }
                }
            }
            return null;
        }
    }
}