using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class EmpleadoRUN {

        private readonly LQMantenimientosDataContext mantenimiento;

        public EmpleadoRUN() {
            mantenimiento = new LQMantenimientosDataContext();
        }

        public bool AgregarEmpleado(decimal salario, int idTipoEmpleado, string cedula, string fechaNacimiento, string email, string telefono, string usuario, string contra) {
            try {
                string output = String.Empty;
                mantenimiento.agregarEmpleado(salario, idTipoEmpleado, cedula, fechaNacimiento, email, telefono, usuario, contra, ref output);
                return string.IsNullOrEmpty(output);
            } catch (Exception) {
                //
                return false;
            }
        }

        public bool ActualizarEmpleado(int idEmpleado, decimal salario, int idTipoEmpleado, string fechaNacimiento, string email, string telefono, string usuario, string contra) {
            try {
                mantenimiento.actualizarEmpleado(idEmpleado, salario, idTipoEmpleado, fechaNacimiento, email, telefono, usuario, contra);
                return true;
            } catch (Exception) {
                //
                return false;
            }
        }

        public bool EliminarEmpleado(int idEmpleado) {
            try {
                mantenimiento.eliminarEmpleado(idEmpleado);
                return true;
            } catch (Exception) {
                //
                return false;
            }
        }

        public List<obtenerEmpleadosResult> ConsultarEmpleados() {
            try {
                var r = mantenimiento.obtenerEmpleados().ToList();
                return r;
            } catch (Exception) {
                //
                return null;
            }
        }

        public List<obtenerTipoEmpleadosResult> ConsultarTipoEmpleados() {
            try {
                var r = mantenimiento.obtenerTipoEmpleados().ToList();
                return r;
            } catch (Exception) {
                //
                return null;
            }
        }
    }

}
