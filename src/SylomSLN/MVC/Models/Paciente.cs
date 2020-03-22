using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Paciente {

        public int idPaciente { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string direccion2 { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public int genero { get; set; }
        public string fechaNacimiento { get; set; }
        public string descripcionPaciente { get; set; }
        public int idTipoPaciente { get; set; }
        public int idInstitucion { get; set; }
        public string descripcionExpediente { get; set; }
    }

}