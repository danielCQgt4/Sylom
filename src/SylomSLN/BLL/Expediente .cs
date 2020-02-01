using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    class Expediente {

        #region Properties
        private int idExpediente;
        private String descripcion;
        private Paciente paciente;
        #endregion

        #region Get & Set
        public int getIdExpediente() {
            return idExpediente;
        }

        public void setIdExpediente(int idExpediente) {
            this.idExpediente = idExpediente;
        }

        public String getDescripcion() {
            return descripcion;
        }

        public void setDescripcion(String descripcion) {
            this.descripcion = descripcion;
        }

        public Paciente getPaciente() {
            return paciente;
        }

        public void setPaciente(Paciente paciente) {
            this.paciente = paciente;
        }

        #endregion

    }
}
