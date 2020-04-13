using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Persona {

        private int idPersona;
        private string nombre;

        public int GetIdPersona() {
            return idPersona;
        }

        public void SetIdPersona(int IdPersona) {
            this.idPersona = IdPersona;
        }

        public string GetNombre() {
            return nombre;
        }

        public void SetNombre(string Nombre) {
            this.nombre = Nombre;
        }

    }

    public class Persona2 {
        public int idPersona;

        public string cedula;

        public string nombre;

        public string apellido1;

        public string apellido2;

        public string direccionPadron;

        public string direccion2;

        public string provincia;

        public string canton;

        public string distrito;

        public int genero;

        public string fechaNaciemiento;

        public bool activo;
    }
}