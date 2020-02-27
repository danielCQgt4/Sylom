using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class LoginRUN {

        private readonly DMZDataContext Sec;
        private readonly BitacoraRUN Bitacora;

        public LoginRUN() {
            Sec = new DMZDataContext();
            Bitacora = new BitacoraRUN();
            Bitacora.SetUsuario(null);
        }

        public consultaLoginAuthResult IniciarSesion(string usuario, string contra) {
            try {
                //Contemplar encriptacion
                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contra)) {
                    var r = Sec.consultaLoginAuth(usuario, contra).ToList();
                    if (r.Count() == 0) {
                        return null;
                    }
                    return r[0];
                }
                return null;
            } catch (Exception e) {
                Bitacora.AgregarRegistro("LoginRUN", $"IniciarSesion({usuario},*)", e.ToString(), 'E');
                return null;
            }
        }

        public List<consultaLoginPermisosResult> GetPermisos(int idEmpleado) {
            try {
                var r = Sec.consultaLoginPermisos(idEmpleado);
                return r.ToList();
            } catch (Exception e) {
                Bitacora.AgregarRegistro("LoginRUN,", $"GetPermisos({idEmpleado})", e.ToString(), 'E');
                return null;
            }
        }
    }
}
