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

        public int GetIdApartado() {
            return IdApartado;
        }

        public void SetIdApartado(int IdApartado) {
            this.IdApartado = IdApartado;
        }

        public string GetNombre() {
            return Nombre;
        }

        public void SetNombre(string Nombre) {
            this.Nombre = Nombre;
        }

        public string GetSiteUrl() {
            return SiteUrl;
        }

        public void SetSiteUrl(string SiteUrl) {
            this.SiteUrl = SiteUrl;
        }

        public string GetIcon() {
            return icon;
        }

        public void SetIcon(string icon) {
            this.icon = icon;
        }

        public bool IsCreate() {
            return Create;
        }

        public void SetCreate(bool Create) {
            this.Create = Create;
        }

        public bool IsRead() {
            return Read;
        }

        public void SetRead(bool Read) {
            this.Read = Read;
        }

        public bool IsUpdate() {
            return Update;
        }

        public void SetUpdate(bool Update) {
            this.Update = Update;
        }

        public bool IsDelete() {
            return Delete;
        }

        public void SetDelete(bool Delete) {
            this.Delete = Delete;
        }

    }
}