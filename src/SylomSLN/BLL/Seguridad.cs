using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    class Apartado {
        #region Properties
        protected int idApartado;
        protected string tipoDescripcion;
        #endregion

        #region Get & Set
        public string getDescripcion() {
            return this.tipoDescripcion;
        }

        public int getIdApartado() {
            return this.idApartado;
        }

        public void setDescripcion(String tipoDescripcion) {
            this.tipoDescripcion = tipoDescripcion;
        }

        public void setIdApartado(int idTipo) {
            this.idApartado = idTipo;
        }
        #endregion
    }

    class Accion {
        #region Properties
        protected int idAccion;
        protected string tipoDescripcion;
        #endregion

        #region Get & Set
        public string getDescripcion() {
            return this.tipoDescripcion;
        }

        public int getIdAccion() {
            return this.idAccion;
        }

        public void setDescripcion(String tipoDescripcion) {
            this.tipoDescripcion = tipoDescripcion;
        }

        public void setIdAccion(int idTipo) {
            this.idAccion = idTipo;
        }
        #endregion
    }

    class Rol {
        #region Properties
        protected int idRol;
        protected string tipoDescripcion;
        #endregion

        #region Get & Set
        public string getDescripcion() {
            return this.tipoDescripcion;
        }

        public int getIdRol() {
            return this.idRol;
        }

        public void setDescripcion(String tipoDescripcion) {
            this.tipoDescripcion = tipoDescripcion;
        }

        public void setIdRol(int idTipo) {
            this.idRol = idTipo;
        }
        #endregion
    }

    class RolApartadoAccion {

        private Rol rol;
        private Accion accion;
        private Apartado apartado;

        public Rol getRol() {
            return rol;
        }

        public void setRol(Rol rol) {
            this.rol = rol;
        }

        public Accion getAccion() {
            return accion;
        }

        public void setAccion(Accion accion) {
            this.accion = accion;
        }

        public Apartado getApartado() {
            return apartado;
        }

        public void setApartado(Apartado apartado) {
            this.apartado = apartado;
        }
    }

    class RolUsuario {

        private Rol rol;
        private Usuario usuario;

        public Rol getRol() {
            return rol;
        }

        public void setRol(Rol rol) {
            this.rol = rol;
        }

        public Usuario getUsuario() {
            return usuario;
        }

        public void setUsuario(Usuario usuario) {
            this.usuario = usuario;
        }
    }
}
