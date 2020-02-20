using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Empleado : Persona {

        private int IdEmpleado;
        private decimal Salario;
        private TipoDato TipoEmpleado;
        private List<Apartado> Apartados;

        public void SetApartados(List<Apartado> Apartados) {
            this.Apartados = Apartados;
        }

        public List<Apartado> GetApartados() {
            return Apartados;
        }

        public int GetIdEmpleado() {
            return IdEmpleado;
        }

        public void SetIdEmpleado(int IdEmpleado) {
            this.IdEmpleado = IdEmpleado;
        }

        public decimal GetSalario() {
            return Salario;
        }

        public void SetSalario(decimal Salario) {
            this.Salario = Salario;
        }

        public TipoDato GetTipoEmpleado() {
            return TipoEmpleado;
        }

        public void SetTipoEmpleado(TipoDato TipoEmpleado) {
            this.TipoEmpleado = TipoEmpleado;
        }

    }

}