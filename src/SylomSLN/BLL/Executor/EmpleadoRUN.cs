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

        public bool AgregarEmpleado(decimal salario, int idTipoEmpleado, string cedula, DateTime fechaNacimiento, string email, string telefono, string usuario, string contra) {
            try {
                mantenimiento.agregarEmpleado(salario, idTipoEmpleado, cedula, fechaNacimiento, email, telefono, usuario, contra);
                return true;
            } catch (Exception) {
                //
                return false;
            }
        }

        public bool ActualizarEmpleado(int idEmpleado, decimal salario, int idTipoEmpleado, string email, string telefono, int idUsuario, string usuario, string contra) {
            try {
                mantenimiento.actualizarEmpleado(idEmpleado, salario, idTipoEmpleado, email, telefono, idUsuario, usuario, contra);
                return true;
            } catch (Exception) {
                //
                return false;
            }
        }

        public bool EliminarEmpleado(int idEmpleado,int idUsuario) {
            try {
                mantenimiento.eliminarEmpleado(idEmpleado, idUsuario);
                return true;
            } catch (Exception) {
                //
                return false;
            }
        }

        public List<consultarEmpleadosResult> ConsultarEmpleados() {
            try {
                var r = mantenimiento.consultarEmpleados().ToList();
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
