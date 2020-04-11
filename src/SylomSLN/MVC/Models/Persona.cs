using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Persona {

        private int idPersona;
        private string cedula;
        private string nombre;
        private string apellido1;
        private string apellido2;
        private string direccionPadron;
        private string direccion2;
        private string provincia;
        private string canton;
        private string distrito;
        private int genero;
        private string fechaNacimiento;

        public int GetIdPersona() {
            return idPersona;
        }

        public void SetIdPersona(int IdPersona) {
            this.idPersona = IdPersona;
        }

        public string GetCedula() {
            return cedula;
        }

        public void SetCedula(string Cedula) {
            this.cedula = Cedula;
        }

        public string GetNombre() {
            return nombre;
        }

        public void SetNombre(string Nombre) {
            this.nombre = Nombre;
        }

        public string GetApellido1() {
            return apellido1;
        }

        public void SetApellido1(string apellido1) {
            this.apellido1 = apellido1;
        }

        public string GetApellido2() {
            return apellido2;
        }

        public void SetApellido2(string apellido2) {
            this.apellido2 = apellido2;
        }

        public string GetDireccionPadron() {
            return direccionPadron;
        }

        public void SetDireccionPadron(string direccionPadron) {
            this.direccionPadron = direccionPadron;
        }

        public string GetDireccion2() {
            return direccion2;
        }

        public void SetDireccion2(string direccion2) {
            this.direccion2 = direccion2;
        }

        public string GetProvincia() {
            return provincia;
        }

        public void SetProvincia(string provincia) {
            this.provincia = provincia;
        }

        public string GetCanton() {
            return canton;
        }

        public void SetCanton(string canton) {
            this.canton = canton;
        }

        public string GetDistrito() {
            return distrito;
        }

        public void SetDistrito(string distrito) {
            this.distrito = distrito;
        }

        public int GetGenero() {
            return genero;
        }

        public void SetGenero(int genero) {
            this.genero = genero;
        }

        public string GetFechaNacimiento() {
            return fechaNacimiento;
        }

        public void SetFechaNacimiento(string fechaNacimiento) {
            this.fechaNacimiento = fechaNacimiento;
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