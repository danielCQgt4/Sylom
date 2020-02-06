using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class Persona {

        private static Persona persona;
        private String cedula;
        private String nombre;
        private String apellido1;
        private String apellido2;
        private String direccionPadron;
        private String direccion2;
        private String provincia;
        private String canton;
        private String distrito;
        private int genero;
        private String fechaNamcimiento;
        private String telefono;
        private String email;
        private int edad;

        public Persona() {
            this.cedula = "";
            this.nombre = "";
            this.apellido1 = "";
            this.apellido2 = "";
            this.direccionPadron = "";
            this.direccion2 = "";
            this.provincia = "";
            this.canton = "";
            this.distrito = "";
            this.fechaNamcimiento = "";
            this.telefono = "";
            this.email = "";
            this.genero = 0;
            this.edad = 0;
        }

        public static Persona GetInstance() {
            if (persona == null) {
                persona = new Persona();
            }
            return persona;
        }

        public String GetCedula() {
            return cedula;
        }

        public void SetCedula(String cedula) {
            this.cedula = cedula;
        }

        public String GetNombre() {
            return nombre;
        }

        public void SetNombre(String nombre) {
            this.nombre = nombre;
        }

        public String GetApellido1() {
            return apellido1;
        }

        public void SetApellido1(String apellido1) {
            this.apellido1 = apellido1;
        }

        public String GetApellido2() {
            return apellido2;
        }

        public void SetApellido2(String apellido2) {
            this.apellido2 = apellido2;
        }

        public String GetDireccionPadron() {
            return direccionPadron;
        }

        public void SetDireccionPadron(String direccionPadron) {
            this.direccionPadron = direccionPadron;
            this.provincia = this.direccionPadron.Substring(0, 1);
            this.canton = this.direccionPadron.Substring(1, 2);
            this.distrito = this.direccionPadron.Substring(3);
        }

        public String GetDireccion2() {
            return direccion2;
        }

        public void SetDireccion2(String direccion2) {
            this.direccion2 = direccion2;
        }

        public String GetProvincia() {
            return provincia;
        }

        public String GetCanton() {
            return canton;
        }

        public String GetDistrito() {
            return distrito;
        }

        public void SetGenero(int genero) {
            if (genero == 1 || genero == 2) {
                this.genero = genero;
            } else {
                this.genero = 0;//Genero sin definir
            }
        }

        public int GetGenero() {
            return this.genero;
        }

        public String GetFechaNamcimiento() {
            return fechaNamcimiento;
        }

        public void SetFechaNamcimiento(String fechaNamcimiento) {
            this.fechaNamcimiento = fechaNamcimiento;
        }

        public String GetTelefono() {
            return telefono;
        }

        public void SetTelefono(String telefono) {
            this.telefono = telefono;
        }

        public String GetEmail() {
            return email;
        }

        public void SetEmail(String email) {
            this.email = email;
        }

        public int GetEdad() {
            return edad;
        }

        public void SetEdad(int edad) {
            this.edad = edad;
        }

        public DateTime GetFecha(String fecha) {
            CultureInfo provider = CultureInfo.InvariantCulture;
            if (fecha.Equals(String.Empty)) {
                return DateTime.ParseExact("0001/01/01", "yyyy/MM/dd", provider);
            }
            return DateTime.ParseExact(fecha.Replace("-","/"), "yyyy/MM/dd", provider);
        }

        public void Destroy() {
            persona = null;
        }
    }
}
