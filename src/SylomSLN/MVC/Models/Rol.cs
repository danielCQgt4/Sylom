using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {
    public class Rol {

        private int IdRol;
        private string Nombre;
        private List<Apartado> Apartados;

        public void SetApartados(List<Apartado> Apartados) {
            this.Apartados = Apartados;
        }

        public List<Apartado> GetApartados() {
            return Apartados;
        }

        public void SetNombre(string nombre) {
            this.Nombre = nombre;
        }

        public void SetIdRol(int IdRol) {
            this.IdRol = IdRol;
        }

        public int GetIdRol() {
            return IdRol;
        }

        public string GetNombre() {
            return Nombre;
        }
    }
}