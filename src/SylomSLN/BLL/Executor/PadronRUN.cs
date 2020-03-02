using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class PadronRUN {

        private readonly LQCargaArchivoDataContext CargaArchivoDataContext;
        private readonly BitacoraRUN Bitacora;

        public PadronRUN() {
            CargaArchivoDataContext = new LQCargaArchivoDataContext();
            Bitacora = new BitacoraRUN();
            Bitacora.SetUsuario(null);
        }

        public List<consultaPersonaResult> getPersona(string cedula) {
            try {
                return CargaArchivoDataContext.consultaPersona(cedula).ToList();
            } catch (Exception e) {
                Bitacora.AgregarRegistro("PadronRUN", $"getPersona({cedula})", e.ToString(), 'E');
                return null;
            }
        }

        public bool MantenimientoPersonas(
            string cedula,
            string nombre,
            string apellido1,
            string apellido2,
            string direccionPadron,
            string direccion2,
            int genero,
            DateTime fechaNacimiento,
            string email,
            string telefono) {
            string provincia = direccionPadron.Substring(0, 1);
            string canton = direccionPadron.Substring(1, 2);
            string distrito = direccionPadron.Substring(3, 3);
            try {
                CargaArchivoDataContext.mantenimientoPersonas(
                    cedula,
                    nombre,
                    apellido1,
                    apellido2,
                    direccionPadron,
                    direccion2,
                    provincia,
                    canton,
                    distrito,
                    genero,
                    fechaNacimiento,
                    email,
                    telefono,
                    true
                );
                return true;
            } catch (Exception e) {
                Bitacora.AgregarRegistro("PadronRUN", $"MantenimientoPersonas({cedula},{ nombre},{apellido1},{ apellido2},{ direccionPadron},{ direccion2},{ provincia},{ canton},{ distrito},{ genero},{ fechaNacimiento},{ email},{ telefono},{true}", e.ToString(), 'E');
                return false;
            }
        }
    }
}
