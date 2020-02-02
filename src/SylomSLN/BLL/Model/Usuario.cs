using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    class Usuario {

        #region Properties
        private static String usuarioActive;
        private int idUsuario;
        private String usuario;
        private String contra;
        private Empleado empleado;
        #endregion

        #region Get & Set
        public static String getUsuarioActive() {
            return usuarioActive;
        }

        public static void setUsuarioActive(String usuarioActive) {
            Usuario.usuarioActive = usuarioActive;
        }

        public int getIdUsuario() {
            return idUsuario;
        }

        public void setIdUsuario(int idUsuario) {
            this.idUsuario = idUsuario;
        }

        public String getUsuario() {
            return usuario;
        }

        public void setUsuario(String usuario) {
            this.usuario = usuario;
        }

        public String getContra() {
            return contra;
        }

        public void setContra(String contra) {
            this.contra = contra;
        }

        public Empleado getEmpleado() {
            return empleado;
        }

        public void setEmpleado(Empleado empleado) {
            this.empleado = empleado;
        }
        #endregion
    }

}
