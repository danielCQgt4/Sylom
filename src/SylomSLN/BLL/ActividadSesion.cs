using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    class ActividadSesion {

        #region Properties
        private Actividad actividad;
        private Sesion sesion;
        private String notas;
        #endregion

        #region Get & Set
        public Actividad getActividad() {
            return actividad;
        }

        public void setActividad(Actividad actividad) {
            this.actividad = actividad;
        }

        public Sesion getSesion() {
            return sesion;
        }

        public void setSesion(Sesion sesion) {
            this.sesion = sesion;
        }

        public String getNotas() {
            return notas;
        }

        public void setNotas(String notas) {
            this.notas = notas;
        }
        #endregion
    }

}
