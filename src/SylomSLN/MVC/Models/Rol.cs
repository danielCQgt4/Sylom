using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {
    public class Rol {

        public int idRol { get; set; }
        public string nombre { get; set; }
        public List<Apartado> apartados { get; set; }
        public List<Usuario> usuarios { get; set; }

    }
}