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
                empleado.idEmpleado = result.idEmpleado;
                empleado.nombre = result.nombre;
                empleado.idUsuario = result.idUsuario.ToString();
                empleado.tipoEmpleado = new TipoDato(result.idTipoEmpleado);
                empleado.roles = SetPermisos(empleado);
                if (empleado.roles != null) {
                    return empleado;
                }
            }
            return null;
        }

        public List<Rol> SetPermisos(Empleado empleado) {
            if (empleado != null) {
                var result = Log.GetPermisos(empleado.idEmpleado);
                string nombreRol = String.Empty;
                if (result != null) {
                    List<Rol> roles = new List<Rol>();
                    List<Apartado> apartados = new List<Apartado>();
                    foreach (var permiso in result) {
                        var temp = permiso;
                        if (!permiso.descripcion.Equals(nombreRol)) {
                            nombreRol = permiso.descripcion;
                            Rol rol = new Rol {
                                nombre = permiso.descripcion
                            };
                            apartados = new List<Apartado>();
                            rol.apartados = apartados;
                            roles.Add(rol);
                        }
                        Apartado apartado = new Apartado {
                            idApartado = permiso.idApartado,
                            nombre = permiso.nombreApartado,
                            siteUrl = permiso.siteUrl,
                            icon = permiso.icon,
                            create = permiso.crear.GetValueOrDefault(),
                            read = permiso.leer.GetValueOrDefault(),
                            update = permiso.editar.GetValueOrDefault(),
                            delete = permiso.eliminar.GetValueOrDefault()
                        };
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