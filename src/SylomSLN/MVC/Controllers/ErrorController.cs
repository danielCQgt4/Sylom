using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers {
    public class ErrorController : Controller {
        // GET: Error
        public ActionResult Index(int error = 0) {
            ViewBag.error = error;
            switch (error) {
                case 505:
                    ViewBag.Title = "Version de http no soportada";
                    ViewBag.description = "Ponte en contacto y dinos el problema, para una mejor experiencia !!";
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.description = "El contenido buscado no existe";
                    break;

                default:
                    ViewBag.title = "Error innesperado";
                    ViewBag.description = "Ponte en contacto y dinos el problema, para una mejor experiencia !!";
                    break;
            }
            return View();
        }
    }
}