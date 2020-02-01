using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    class Empleado : Persona {

        #region Properties
        private int idEmpleado;
        private double salario;
        private String fechaEntrada;
        private String fechaSalida;
        private TipoDato tipoDato;
        #endregion

        #region Get & Set
        public int getIdEmpleado() {
            return idEmpleado;
        }

        public void setIdEmpleado(int idEmpleado) {
            this.idEmpleado = idEmpleado;
        }

        public double getSalario() {
            return salario;
        }

        public void setSalario(double salario) {
            this.salario = salario;
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

        public TipoDato getTipoDato() {
            return tipoDato;
        }

        public void setTipoDato(TipoDato tipoDato) {
            this.tipoDato = tipoDato;
        }
        #endregion
    }
}
