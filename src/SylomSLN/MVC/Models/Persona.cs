using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Persona {

        private int IdPersona;
        private string Cedula;
        private string Nombre;
        private string Apellido1;
        private string apellido2;
        private string DireccionPadron;
        private string Direccion2;
        private string Provincia;
        private string Canton;
        private string Distrito;
        private int Genero;
        private string FechaNacimiento;

        public int GetIdPersona() {
            return IdPersona;
        }

        public void SetIdPersona(int IdPersona) {
            this.IdPersona = IdPersona;
        }

        public string GetCedula() {
            return Cedula;
        }

        public void SetCedula(string Cedula) {
            this.Cedula = Cedula;
        }

        public string GetNombre() {
            return Nombre;
        }

        public void SetNombre(string Nombre) {
            this.Nombre = Nombre;
        }

        public string GetApellido1() {
            return Apellido1;
        }

        public void SetApellido1(string apellido1) {
            this.Apellido1 = apellido1;
        }

        public string GetApellido2() {
            return apellido2;
        }

        public void SetApellido2(string apellido2) {
            this.apellido2 = apellido2;
        }

        public string GetDireccionPadron() {
            return DireccionPadron;
        }

        public void SetDireccionPadron(string direccionPadron) {
            this.DireccionPadron = direccionPadron;
        }

        public string GetDireccion2() {
            return Direccion2;
        }

        public void SetDireccion2(string direccion2) {
            this.Direccion2 = direccion2;
        }

        public string GetProvincia() {
            return Provincia;
        }

        public void SetProvincia(string provincia) {
            this.Provincia = provincia;
        }

        public string GetCanton() {
            return Canton;
        }

        public void SetCanton(string canton) {
            this.Canton = canton;
        }

        public string GetDistrito() {
            return Distrito;
        }

        public void SetDistrito(string distrito) {
            this.Distrito = distrito;
        }

        public int GetGenero() {
            return Genero;
        }

        public void SetGenero(int genero) {
            this.Genero = genero;
        }

        public string GetFechaNacimiento() {
            return FechaNacimiento;
        }

        public void SetFechaNacimiento(string fechaNacimiento) {
            this.FechaNacimiento = fechaNacimiento;
        }
    }
}