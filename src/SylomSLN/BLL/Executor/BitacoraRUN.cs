using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class BitacoraRUN {

        private readonly LQBitacoraDataContext lQBitacoraDataContext;
        private int Usuario;

        public void SetUsuario(int Usuario) {
            if (Usuario > 0) {
                this.Usuario = Usuario;
            } else {
                this.Usuario = -1;
            }
        }

        public BitacoraRUN() {
            lQBitacoraDataContext = new LQBitacoraDataContext();
        }

        public bool AgregarRegistro(string Controlador, string Metodo, string Msj, char Tipo) {
            try {
                //S: success, E: error, N: not authorized, O:Unknown
                if (Tipo != 'S' && Tipo != 'E' && Tipo != 'N' && Tipo != 'C' && Tipo != 'R' && Tipo != 'U' && Tipo != 'D') {
                    Tipo = 'O';
                }
                lQBitacoraDataContext.agregarRegistroBitacora(Controlador, Metodo, Msj, Usuario > 0 ? Usuario.ToString() : "Uknown", Tipo);
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
