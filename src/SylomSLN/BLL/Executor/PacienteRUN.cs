using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {
    public class PacienteRUN {

        private readonly LQProcesosDataContext lQProcesosDataContent = new LQProcesosDataContext();

        public bool AgregarPaciente(string cedula, string nombre, string apellido1, string apellido2, string direccion2, string provincia, string canton, string distrito, int genero, string fechaNacimiento, string descripcionCliente, string descripcionExpediente, int idTipoPaciente, int idInstitucion) {
            try {
                lQProcesosDataContent.agregarPaciente(cedula, nombre, apellido1, apellido2, direccion2, provincia, canton, distrito, genero, fechaNacimiento, descripcionCliente, idTipoPaciente, idInstitucion, descripcionExpediente);
                return true;
            } catch (Exception e) {
                return false;
            }
        }

        public bool EliminarPaciente(int idPaciente) {
            try {
                lQProcesosDataContent.eliminarPaciente(idPaciente);
                return true;
            } catch (Exception) {

                return false;
            }
        }

        public bool HabilitarPaciente(int idPaciente) {
            try {
                lQProcesosDataContent.habilitarPaciente(idPaciente);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public bool ActualizarPaciente(int idPaciente, string cedula, string nombre, string apellido1, string apellido2, string direccion2, string provincia, string canton, string distrito, int genero, string fechaNacimiento, string descripcionCliente, string descripcionExpediente, int idTipoPaciente, int idInstitucion) {
            try {
                lQProcesosDataContent.actualizarPaciente(idPaciente, cedula, nombre, apellido1, apellido2, direccion2, provincia, canton, distrito, genero, fechaNacimiento, descripcionCliente, idTipoPaciente, idInstitucion, descripcionExpediente);
                return true;
            } catch (Exception) {

                return false;
            }
        }

        public List<obtenerPacientesResult> ObtenerPacientes() {
            try {
                var r = lQProcesosDataContent.obtenerPacientes().ToList();
                return r;
            } catch (Exception) {
                return null;
            }
        }

        public obtenerPacienteResult ObtenerPaciente(int id) {
            try {
                var r = lQProcesosDataContent.obtenerPaciente(id).ToList();
                if (r.Count() > 0) {
                    return r[0];
                }
                return null;
            } catch (Exception e) {
                String ex = e.Message;
                return null;
            }
        }

    }
}
