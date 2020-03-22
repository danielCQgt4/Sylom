using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Executor {
    public class LugaresRUN {

        private readonly LQProcesosDataContext lQProcesosDataContent = new LQProcesosDataContext();

        public List<consultarProvinciasResult> ConsultarProvincias() {
			try {
                var r = lQProcesosDataContent.consultarProvincias().ToList();
                return r;
			} catch (Exception) {
                return null;
			}
        }

        public List<consultarCantonesResult> ConsultarCantones(string idProvincia) {
            try {
                var r = lQProcesosDataContent.consultarCantones(idProvincia).ToList();
                return r;
            } catch (Exception) {
                return null;
            }
        }

        public List<consultarDistritosResult> ConsultarDistritos(string idProvincia, string idCanton) {
            try {
                var r = lQProcesosDataContent.consultarDistritos(idProvincia, idCanton).ToList();
                return r;
            } catch (Exception) {
                return null;
            }
        }
    }
}
