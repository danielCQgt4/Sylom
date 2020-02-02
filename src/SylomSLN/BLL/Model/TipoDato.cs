using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    class TipoDato {

        #region Properties
        protected int idTipo;
        protected string tipoDescripcion;
        #endregion

        #region Get & Set
        public string getDescripcion() {
            return this.tipoDescripcion;
        }

        public int getIdTipo() {
            return this.idTipo;
        }

        public void setDescripcion(String tipoDescripcion) {
            this.tipoDescripcion = tipoDescripcion;
        }

        public void setIdTipo(int idTipo) {
            this.idTipo = idTipo;
        }
        #endregion

    }
}
