using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {

    class Sesion {
        #region Properties
        private int idSesion;
        private String fechaHoraInicio;
        private String fechaHoraFin;
        private String sala;
        private Expediente expediente;
        private TipoDato tipoDato;
        private Usuario usuario;
        #endregion

        #region Get & Set
        public int getIdSesion() {
            return idSesion;
        }

        public void setIdSesion(int idSesion) {
            this.idSesion = idSesion;
        }

        public String getFechaHoraInicio() {
            return fechaHoraInicio;
        }

        public void setFechaHoraInicio(String fechaHoraInicio) {
            this.fechaHoraInicio = fechaHoraInicio;
        }

        public String getFechaHoraFin() {
            return fechaHoraFin;
        }

        public void setFechaHoraFin(String fechaHoraFin) {
            this.fechaHoraFin = fechaHoraFin;
        }

        public String getSala() {
            return sala;
        }

        public void setSala(String sala) {
            this.sala = sala;
        }

        public Expediente getExpediente() {
            return expediente;
        }

        public void setExpediente(Expediente expediente) {
            this.expediente = expediente;
        }

        public TipoDato getTipoDato() {
            return tipoDato;
        }

        public void setTipoDato(TipoDato tipoDato) {
            this.tipoDato = tipoDato;
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
