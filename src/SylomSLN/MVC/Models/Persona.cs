using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Persona {

        public int idPersona { get; set; }

        public string cedula { get; set; }

        public string nombre { get; set; }

        public string apellido1 { get; set; }

        public string apellido2 { get; set; }

        public string direccionPadron { get; set; }

        public string direccion2 { get; set; }

        public string provincia { get; set; }

        public string canton { get; set; }

        public string distrito { get; set; }

        public int genero { get; set; }

        public string fechaNaciemiento { get; set; }

        public bool activo { get; set; }

    }

    
}