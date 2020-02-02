using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    class Actividad {

        #region Properties
        private int idActividad;
        private String descripcion;
        private String notas;
        private TipoDato tipoDato;
        #endregion

        #region Get & Set
        public int getIdActividad() {
            return idActividad;
        }

        public void setIdActividad(int idActividad) {
            this.idActividad = idActividad;
        }

        public String getDescripcion() {
            return descripcion;
        }

        public void setDescripcion(String descripcion) {
            this.descripcion = descripcion;
        }

        public String getNotas() {
            return notas;
        }

        public void setNotas(String notas) {
            this.notas = notas;
        }

        public TipoDato getTipoDato() {
            return tipoDato;
        }

        public void setTipoDato(TipoDato tipoDato) {
            this.tipoDato = tipoDato;
        }
        #endregion
    }

}
