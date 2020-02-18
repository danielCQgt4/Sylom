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

        public PadronRUN() {
            this.lQCargaArchivoDataContext = new LQCargaArchivoDataContext();
        }

        public consultaPersonaResult getPersona(string cedula) {
            try {
                return (consultaPersonaResult)lQCargaArchivoDataContext.consultaPersona(cedula);
            } catch (Exception) {
                return null;
            }
        }

        public void manejoActivos() {
            try {
                lQCargaArchivoDataContext.manejoActivos();
            } catch (Exception) {
                //
            }
        }

        public bool AgregarPersona(
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
            try {
                string provincia = direccionPadron.Substring(0, 1);
                string canton = direccionPadron.Substring(1, 3);
                string distrito = direccionPadron.Substring(3, direccionPadron.Length - 1);
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
                //
                return false;
            }
        }
    }
}
