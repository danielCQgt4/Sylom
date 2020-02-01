using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    class Contacto : Persona {

        #region Properties
        private int _idContacto;
        private String _nombreTrabajo;
        #endregion

        #region Get & Set
        public int getIdContacto() {
            return _idContacto;
        }

        public void setIdContacto(int _idContacto) {
            this._idContacto = _idContacto;
        }

        public String getNombreTrabajo() {
            return _nombreTrabajo;
        }

        public void setNombreTrabajo(String _nombreTrabajo) {
            this._nombreTrabajo = _nombreTrabajo;
        }
        #endregion

    }
}
