using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class TipoDato {

        private int IdTipo;
        private string Descripcion;

        public int GetIdTipo() {
            return IdTipo;
        }

        public void SetIdTipo(int IdTipo) {
            this.IdTipo = IdTipo;
        }

        public string GetDescripcion() {
            return Descripcion;
        }

        public void SetDescripcion(string Descripcion) {
            this.Descripcion = Descripcion;
        }
    }
}