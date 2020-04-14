using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class TipoDato {

        public int idTipo { get; set; }
        public string descripcion { get; set; }

        public TipoDato(int id) {
            this.idTipo = id;
        }

        public TipoDato() {

        }
    }
}