using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    class PacienteContacto {

        #region Properties
        private Paciente paciente;
        private Contacto contacto;
        private String relacion;
        #endregion

        #region Get & Set
        public Paciente getPaciente() {
            return paciente;
        }

        public void setPaciente(Paciente paciente) {
            this.paciente = paciente;
        }

        public Contacto getContacto() {
            return contacto;
        }

        public void setContacto(Contacto contacto) {
            this.contacto = contacto;
        }

        public String getRelacion() {
            return relacion;
        }

        public void setRelacion(String relacion) {
            this.relacion = relacion;
        }
        #endregion

    }
}
