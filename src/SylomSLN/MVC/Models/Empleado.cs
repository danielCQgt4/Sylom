using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Empleado : Persona {

        private int IdEmpleado;
        private TipoDato TipoEmpleado;
        private List<Rol> roles;
        private string IdUsuario;

        public void SetRoles(List<Rol> roles) {
            this.roles = roles;
        }

        public List<Rol> GetRoles() {
            return roles;
        }

        public void SetIdUsuario(string Usuario) {
            this.IdUsuario = Usuario;
        }

        public string GetIdUsuario() {
            return IdUsuario;
        }

        public int GetIdEmpleado() {
            return IdEmpleado;
        }

        public void SetIdEmpleado(int IdEmpleado) {
            this.IdEmpleado = IdEmpleado;
        }

        public TipoDato GetTipoEmpleado() {
            return TipoEmpleado;
        }

        public void SetTipoEmpleado(TipoDato TipoEmpleado) {
            this.TipoEmpleado = TipoEmpleado;
        }

    }

}