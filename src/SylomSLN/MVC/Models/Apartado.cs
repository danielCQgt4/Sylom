using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Apartado {

        public int idApartado { get; set; }
        public string nombre { get; set; }
        public string siteUrl { get; set; }
        public string icon { get; set; }
        public bool create { get; set; }
        public bool read { get; set; }
        public bool update { get; set; }
        public bool del { get; set; }

    }
}