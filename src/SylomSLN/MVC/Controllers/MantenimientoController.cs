using MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [SylomAuth]
    public class MantenimientoController : Controller
    {
        
        public ActionResult Temp() {
            return View("Index");
        }
    }
}