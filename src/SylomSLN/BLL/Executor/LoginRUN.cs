using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {
    public class LoginRUN {

        private DMZDataContext sec = new DMZDataContext();

        public List<consultaLoginAuthResult> IniciarSesion(string usuario, string contra) {
            try {
                //Contemplar encriptacion
                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contra)) {
                    var r = sec.consultaLoginAuth(usuario, contra);
                    if (r.ToString().Equals("Not authorized")) {
                        return null;
                    }
                    return r.ToList();
                }
                return null;
            } catch (Exception e) {
                new BitacoraRUN().agregarRegistro("LoginRUN", $"IniciarSesion({usuario},*)", e.ToString(), 'E');
                return null;
            }
        }

        public List<consultaLoginPermisosResult> GetPermisos(int idEmpleado) {
            try {
                var r = sec.consultaLoginPermisos(idEmpleado);
                return r.ToList();
            } catch (Exception e) {
                new BitacoraRUN().agregarRegistro("LoginRUN,", $"GetPermisos({idEmpleado})", e.ToString(), 'E');
                return null;
            }
        }
    }
}
