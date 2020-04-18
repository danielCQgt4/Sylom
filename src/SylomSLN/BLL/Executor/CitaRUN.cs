using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Executor {
    public class CitaRUN {

        private readonly LQProcesosDataContext Context = new LQProcesosDataContext();

        public bool AgregarCita(string asunto, string fecha, string hora, string notas, string sintomas, int idExpediente, int idUsuario) {
            try {
                Context.agregarSesion(asunto, fecha, hora, notas, sintomas, idExpediente, idUsuario);
                return true;
            } catch (Exception e) {
                //
                return false;
            }
        }

        public bool CancelarCita(int idCita) {
            try {
                Context.cancelarSesion(idCita);
                return true;
            } catch (Exception e) {
                //
                return false;
            }
        }

        public List<consultaSesionesResult> ConsultarCitas() {
            try {
                var r = Context.consultaSesiones().ToList();
                return r;
            } catch (Exception e) {
                //
                return null;
            }
        }
    }
}
