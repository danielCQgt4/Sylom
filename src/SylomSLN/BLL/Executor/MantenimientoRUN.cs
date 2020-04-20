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

        public int Usuario { get; set; }

        public MantenimientoRUN(int Usuario) {
            lQMantenimientosDataContext = new LQMantenimientosDataContext();
            bitacora = new BitacoraRUN();
            bitacora.SetUsuario(Usuario);
        }

        public MantenimientoRUN() {
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

        public bool HabilitarTipoPaciente(int id) {
            try {
                lQMantenimientosDataContext.habilitarTipoPaciente(id);
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

        public obtenerTipoPacienteResult ObtenerTipoPaciente(int id) {
            try {
                return lQMantenimientosDataContext.obtenerTipoPaciente(id).ToList()[0];
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

        public bool HabilitarTipoEmpleado(int id) {
            try {
                lQMantenimientosDataContext.habilitarTipoEmpleado(id);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public List<obtenerTipoEmpleadosResult> ObtenerTipoEmpleados(int IdEmpleado) {
            try {
                return lQMantenimientosDataContext.obtenerTipoEmpleados(IdEmpleado).ToList();
            } catch (Exception) {
                //TODO Bitacora
                return null;
            }
        }

        public obtenerTipoEmpleadoResult ObtenerTipoEmpleado(int id) {
            try {
                return lQMantenimientosDataContext.obtenerTipoEmpleado(id).ToList()[0];
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

        public bool HabilitarMedicina(int id) {
            try {
                lQMantenimientosDataContext.habilitarMedicina(id);
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

        public obtenerMedicinaResult ObtenerMedicina(int id) {
            try {
                return lQMantenimientosDataContext.obtenerMedicina(id).ToList()[0];
            } catch (Exception) {
                //TODO Bitacora
                return null;
            }
        }
        #endregion

        #region Institucion
        public bool AgregarInstitucion(string nombre, string direccion, string tel) {
            try {
                lQMantenimientosDataContext.agregarInstitucion(nombre, direccion, tel);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public bool ActualizarInstitucion(int id, string nombre, string direccion, string tel) {
            try {
                lQMantenimientosDataContext.actualizarInstitucion(nombre, direccion, tel, id);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public bool HabilitarIntitucion(int id) {
            try {
                lQMantenimientosDataContext.habilitarInstitucion(id);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public bool EliminarIntitucion(int id) {
            try {
                lQMantenimientosDataContext.eliminarInstitucion(id);
                return true;
            } catch (Exception e) {
                //TODO Bitacora
                return false;
            }
        }

        public List<obtenerInstitucionesResult> ObtenerInstituciones() {
            try {
                return lQMantenimientosDataContext.obtenerInstituciones().ToList();
            } catch (Exception) {
                //TODO Bitacora
                return null;
            }
        }

        public obtenerInstitucionResult ObtenerInstitucion(int id) {
            try {
                return lQMantenimientosDataContext.obtenerInstitucion(id).ToList()[0];
            } catch (Exception) {
                //TODO Bitacora
                return null;
            }
        }
        #endregion
    }

}
