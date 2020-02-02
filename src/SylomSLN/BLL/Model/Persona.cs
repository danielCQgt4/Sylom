using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    class Persona {

        private String cedula;
        private String nombre;
        private String direccion;
        private String telefono;
        private String email;
        private int edad;

        public void setCedula(String cedula) {
            this.cedula = cedula;
        }

        public void setNombre(String nombre) {
            this.nombre = nombre;
        }

        public void setDireccion(String direccion) {
            this.direccion = direccion;
        }

        public void setEdad(int edad) {
            this.edad = edad;
        }

        public void setTelefono(String telefono) {
            this.telefono = telefono;
        }

        public void setEmail(String email) {
            this.email = email;
        }

        public String setCedula() {
            return this.cedula;
        }

        public String setNombre() {
            return this.nombre;
        }

        public String setDireccion() {
            return this.direccion;
        }

        public int setEdad() {
            return this.edad;
        }

        public String setTelefono() {
            return this.telefono;
        }

        public String getEmail() {
            return this.email;
        }
    }
}
