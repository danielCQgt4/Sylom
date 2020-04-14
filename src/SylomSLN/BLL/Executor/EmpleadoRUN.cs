using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class EmpleadoRUN {

        private readonly DMZDataContext dmz;
        private readonly LQMantenimientosDataContext mante;

        public EmpleadoRUN() {
            dmz = new DMZDataContext();
        }

        public bool AgregarEmpleado(int idTipoEmpleado, string nombre, string usuario, string contra) {
            try {
                var en = new LoginRUN();
                dmz.agregarEmpleado(idTipoEmpleado, nombre, en.Encriptar(usuario), en.Encriptar(contra));
                return true;
            } catch (Exception e) {
                //
                return false;
            }
        }

        public bool ActualizarEmpleado(int idEmpleado, int idTipoEmpleado, string nombre, string usuario, string contra) {
            try {
                var en = new LoginRUN();
                dmz.actualizarEmpleado(idEmpleado, idTipoEmpleado, nombre, en.Encriptar(usuario), en.Encriptar(contra));
                return true;
            } catch (Exception) {
                //
                return false;
            }
        }

        public bool EliminarEmpleado(int idEmpleado) {
            try {
                dmz.eliminarEmpleado(idEmpleado);
                return true;
            } catch (Exception) {
                //
                return false;
            }
        }

        public List<obtenerEmpleadosResult> ConsultarEmpleados() {
            try {
                var r = dmz.obtenerEmpleados().ToList();
                return r;
            } catch (Exception) {
                //
                return null;
            }
        }

        public List<obtenerTipoEmpleadosResult> ConsultarTipoEmpleados(int id) {
            try {
                var r = mante.obtenerTipoEmpleados(id).ToList();
                return r;
            } catch (Exception) {
                //
                return null;
            }
        }

        public bool VerificacionContraActual(int idEmpleado, string contra) {
            try {
                Nullable<bool> t = false;
                var en = new LoginRUN();
                var r = mante.verficicarUsuarioEmpleado(idEmpleado, en.Encriptar(contra), ref t);
                return t.GetValueOrDefault();
            } catch (Exception) {
                //
                return false;
            }
        }
    }

}
