using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    class Anotacion {

        #region Properties
        private int idAnotacion;
        private String descripcion;
        private Expediente expediente;
        #endregion

        #region Get & Set
        public int getIdAnotacion() {
            return idAnotacion;
        }

        public void setIdAnotacion(int idAnotacion) {
            this.idAnotacion = idAnotacion;
        }

        public String getDescripcion() {
            return descripcion;
        }

        public void setDescripcion(String descripcion) {
            this.descripcion = descripcion;
        }

        public Expediente getExpediente() {
            return expediente;
        }

        public void setExpediente(Expediente expediente) {
            this.expediente = expediente;
        }
        #endregion
    }
}
