using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models {

    public class Apartado {

        private int IdApartado;
        private string Nombre;
        private string SiteUrl;
        private string icon;
        private bool Create;
        private bool Read;
        private bool Update;
        private bool Delete;

        public int getIdApartado() {
            return IdApartado;
        }

        public void setIdApartado(int IdApartado) {
            this.IdApartado = IdApartado;
        }

        public string getNombre() {
            return Nombre;
        }

        public void setNombre(string Nombre) {
            this.Nombre = Nombre;
        }

        public string getSiteUrl() {
            return SiteUrl;
        }

        public void setSiteUrl(string SiteUrl) {
            this.SiteUrl = SiteUrl;
        }

        public string getIcon() {
            return icon;
        }

        public void setIcon(string icon) {
            this.icon = icon;
        }

        public bool isCreate() {
            return Create;
        }

        public void setCreate(bool Create) {
            this.Create = Create;
        }

        public bool isRead() {
            return Read;
        }

        public void setRead(bool Read) {
            this.Read = Read;
        }

        public bool isUpdate() {
            return Update;
        }

        public void setUpdate(bool Update) {
            this.Update = Update;
        }

        public bool isDelete() {
            return Delete;
        }

        public void setDelete(bool Delete) {
            this.Delete = Delete;
        }

    }
}