using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class PadronRUN {

        private LQCargaArchivoDataContext lQCargaArchivoDataContext;
        private BitacoraRUN bitacora;

        public PadronRUN() {
            lQCargaArchivoDataContext = new LQCargaArchivoDataContext();
            bitacora = new BitacoraRUN();
            bitacora.SetUsuario(null);
        }

        public List<consultaPersonaResult> getPersona(string cedula) {
            try {
                return lQCargaArchivoDataContext.consultaPersona(cedula).ToList();
            } catch (Exception e) {
                bitacora.AgregarRegistro("PadronRUN", $"getPersona({cedula})", e.ToString(), 'E');
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
            string canton = direccionPadron.Substring(1, 3);
            string distrito = direccionPadron.Substring(3, direccionPadron.Length - 1);
            try {
                lQCargaArchivoDataContext.mantenimientoPersonas(
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
                bitacora.AgregarRegistro("PadronRUN", $"MantenimientoPersonas({cedula},{ nombre},{apellido1},{ apellido2},{ direccionPadron},{ direccion2},{ provincia},{ canton},{ distrito},{ genero},{ fechaNacimiento},{ email},{ telefono},{true}", e.ToString(), 'E');
                return false;
            }
        }
    }
}
