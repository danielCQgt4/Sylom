using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class BitacoraRUN {

        private LQBitacoraDataContext lQBitacoraDataContext;
        private string Usuario;

        public void SetUsuario(string Usuario) {
            this.Usuario = Usuario;
        }

        public BitacoraRUN() {
            lQBitacoraDataContext = new LQBitacoraDataContext();
        }

        public bool AgregarRegistro(string controlador, string metodo, string msj, char tipo) {
            try {
                //S: success, E: error, N: not authorized, O:Unknown
                if (tipo != 'S' && tipo != 'E' && tipo != 'N') {
                    tipo = 'O';
                }
                lQBitacoraDataContext.agregarRegistroBitacora(controlador, metodo, msj, tipo);
                return true;
            } catch (Exception e) {
                return false;
            }
        }

        public List<verRegistroBitacoraResult> VerRegistros() {
            try {
                return lQBitacoraDataContext.verRegistroBitacora().ToList();
            } catch (Exception e) {
                return null;
            }
        }
    }
}
