using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    class Paciente: Persona {

        #region Properties
        private int idPaciente;
        private String fechaNacimiento;
        private String fechaEntrada;
        private String fechaSalida;
        private String descripcion;
        private TipoDato tipoDato;
        #endregion

        #region Get & Set
        public int getIdPaciente() {
            return idPaciente;
        }

        public void setIdPaciente(int idPaciente) {
            this.idPaciente = idPaciente;
        }

        public String getFechaNacimiento() {
            return fechaNacimiento;
        }

        public void setFechaNacimiento(String fechaNacimiento) {
            this.fechaNacimiento = fechaNacimiento;
        }

        public String getFechaEntrada() {
            return fechaEntrada;
        }

        public void setFechaEntrada(String fechaEntrada) {
            this.fechaEntrada = fechaEntrada;
        }

        public String getFechaSalida() {
            return fechaSalida;
        }

        public void setFechaSalida(String fechaSalida) {
            this.fechaSalida = fechaSalida;
        }

        public String getDescripcion() {
            return descripcion;
        }

        public void setDescripcion(String descripcion) {
            this.descripcion = descripcion;
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
