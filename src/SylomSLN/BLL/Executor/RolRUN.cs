using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Executor {

    public class RolRUN {

        private readonly DMZDataContext dMZDataContext;
        private readonly BitacoraRUN bitacora;

        public RolRUN() {
            dMZDataContext = new DMZDataContext();
            bitacora = new BitacoraRUN();
        }

        public int AgregarRol(string nombre) {
            try {
                var r = dMZDataContext.agregarRol(nombre).ToList();
                return r[0].idRol;
            } catch (Exception) {
                //
                return -1;
            }
        }

        public bool AgregarRolApartado(int idRol, int idApartado, bool crear, bool leer, bool editar, bool eliminar) {
            try {
                dMZDataContext.agregarRolApartado(idRol, idApartado, crear, leer, editar, eliminar);
                return true;
            } catch (Exception) {
                //
                return false;
            }
        }

        public bool EliminarRol(int idRol) {
            try {
                dMZDataContext.eliminarRol(idRol);
                return true;
            } catch (Exception) {
                //
                return false;
            }
        }

        public bool EliminarRolApartado(int idRol, int idApartado) {
            try {
                dMZDataContext.eliminarRolApartado(idRol, idApartado);
                return true;
            } catch (Exception) {
                //
                return false;
            }
        }

        public List<consultarRolApartadoByUsuarioResult> ConsultarRolApartado(int idUsuario) {
            try {
                var r = dMZDataContext.consultarRolApartadoByUsuario(idUsuario).ToList();
                return r;
            } catch (Exception) {
                //
                return null;
            }
        }

        public List<consultarRolesResult> ConsultarRoles(int idUsuario) {
            try {
                var r = dMZDataContext.consultarRoles(idUsuario).ToList();
                return r;
            } catch (Exception) {
                //
                return null;
            }
        }
    }

}
