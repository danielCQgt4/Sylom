using SessinTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessinTest.Controllers {
    public class HomeController : Controller {
        
        [HttpGet]
        public ActionResult Index() {
            if (((Temp)Session["Value"]) != null) {
                ViewBag.Value = ((Temp)Session["Value"]).Cadena;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string value) {
            if (!string.IsNullOrEmpty(value)) {
                Temp temp = new Temp();
                temp.Cadena = value;
                Session["value"] = temp;
            } else {
                Session["value"] = null;
            }
            ViewBag.Value = ((Temp)Session["Value"]).Cadena;
            return View();
        }

        [CyCAuth]
        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}