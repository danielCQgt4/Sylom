using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Empleado : Persona {

        public int idEmpleado { get; set; }
        public TipoDato tipoEmpleado { get; set; }
        public List<Rol> roles { get; set; }
        public string idUsuario { get; set; }

    }

}