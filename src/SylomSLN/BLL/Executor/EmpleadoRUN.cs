using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class EmpleadoRUN {

        private readonly DMZDataContext dmz;
        private readonly MantenimientoRUN mante;

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
                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contra)) {
                    usuario = en.Encriptar(usuario);
                    contra = en.Encriptar(contra);
                } else {
                    usuario = null;
                    contra = null;
                }
                dmz.actualizarEmpleado(idEmpleado, idTipoEmpleado, nombre, usuario, contra);
                return true;
            } catch (Exception e) {
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

    }

}
