using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {
    public class Provincia {
        public string idProvincia { get; set; }

        public string nombre { get; set; }
    }

    public class Canton {
        public string idCanton { get; set; }

        public string nombre { get; set; }

        public string idProvincia { get; set; }
    }

    public class Distrito {
        public string idDistrito { get; set; }

        public string nombre { get; set; }

        public string idProvincia { get; set; }

        public string idCanton { get; set; }
    }
}