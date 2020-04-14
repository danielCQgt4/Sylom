using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CitaController : Controller
    {
        // GET: Cita
        public ActionResult Index()
        {
            ViewBag.create = true;
            ViewBag.read = true;
            ViewBag.update = true;
            ViewBag.delete = true;
            ViewBag.Title = "Pacientes";
            return View();
        }
    }
}