using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Cita {

        public int idSesion { get; set; }

        public string asunto { get; set; }

        public string fecha { get; set; }

        public string hora { get; set; }

        public string notas { get; set; }

        public string sintomas { get; set; }

        public int idExpediente { get; set; }

        public int idUsuario { get; set; }

        public string color { get; set; }
    }

}