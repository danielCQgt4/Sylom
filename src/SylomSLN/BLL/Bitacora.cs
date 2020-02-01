using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    class Bitacora {

        #region Properties
        private int idBitacora;
        private String controlador;
        private String metodo;
        private String msj;
        private String fecha;
        private char tipo;
        private Usuario usuario;
        #endregion

        #region Get & Set
        public int getIdBitacora() {
            return idBitacora;
        }

        public void setIdBitacora(int idBitacora) {
            this.idBitacora = idBitacora;
        }

        public String getControlador() {
            return controlador;
        }

        public void setControlador(String controlador) {
            this.controlador = controlador;
        }

        public String getMetodo() {
            return metodo;
        }

        public void setMetodo(String metodo) {
            this.metodo = metodo;
        }

        public String getMsj() {
            return msj;
        }

        public void setMsj(String msj) {
            this.msj = msj;
        }

        public String getFecha() {
            return fecha;
        }

        public void setFecha(String fecha) {
            this.fecha = fecha;
        }

        public char getTipo() {
            return tipo;
        }

        public void setTipo(char tipo) {
            this.tipo = tipo;
        }

        public Usuario getUsuario() {
            return usuario;
        }

        public void setUsuario(Usuario usuario) {
            this.usuario = usuario;
        }
        #endregion
    }

}
