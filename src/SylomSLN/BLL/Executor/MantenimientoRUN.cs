using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class MantenimientoRUN {

        private readonly LQMantenimientosDataContext lQMantenimientosDataContext;
        private readonly BitacoraRUN bitacora;

        public MantenimientoRUN(string Usuario) {
            lQMantenimientosDataContext = new LQMantenimientosDataContext();
            bitacora = new BitacoraRUN();
            bitacora.SetUsuario(Usuario);
        }

        #region TipoPaciente
        public bool AgregarTipoPaciente(string desc) {
            try {
                lQMantenimientosDataContext.agregarTipoPaciente(desc);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public bool ActualizarTipoPaciente(int id, string desc) {
            try {
                lQMantenimientosDataContext.actualizarTipoPaciente(desc, id);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public bool EliminarTipoPaciente(int id) {
            try {
                lQMantenimientosDataContext.eliminarTipoPaciente(id);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public List<obtenerTipoPacientesResult> ObtenerTipoPacientes() {
            try {
                return lQMantenimientosDataContext.obtenerTipoPacientes().ToList();
            } catch (Exception) {
                //TODO Bitacora
                return null;
            }
        }
        #endregion

        #region TipoEmpleado
        public bool AgregarTipoEmpleado(string desc) {
            try {
                lQMantenimientosDataContext.agregarTipoEmpleado(desc);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public bool ActualizarTipoEmpleado(int id, string desc) {
            try {
                lQMantenimientosDataContext.actualizarTipoEmpleado(desc, id);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public bool EliminarTipoEmpleado(int id) {
            try {
                lQMantenimientosDataContext.eliminarTipoEmpleado(id);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public List<obtenerTipoEmpleadosResult> ObtenerTipoEmpleados() {
            try {
                return lQMantenimientosDataContext.obtenerTipoEmpleados().ToList();
            } catch (Exception) {
                //TODO Bitacora
                return null;
            }
        }
        #endregion

        #region Medicina
        public bool AgregarMedicina(string desc) {
            try {
                lQMantenimientosDataContext.agregarMedicina(desc);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public bool ActualizarMedicina(int id, string desc) {
            try {
                lQMantenimientosDataContext.actualizarMedicina(desc, id);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public bool EliminarMedicina(int id) {
            try {
                lQMantenimientosDataContext.eliminarMedicina(id);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public List<obtenerMedicinasResult> ObtenerMedicinas() {
            try {
                return lQMantenimientosDataContext.obtenerMedicinas().ToList();
            } catch (Exception) {
                //TODO Bitacora
                return null;
            }
        }
        #endregion
    }

}
