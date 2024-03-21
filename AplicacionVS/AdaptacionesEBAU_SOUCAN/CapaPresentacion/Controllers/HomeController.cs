using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginCE()
        {
            return View("~/Views/CentrosEducativos/loginCE.cshtml"); // Ruta a la vista loginCE.cshtml
        }

        public ActionResult LoginSoucan()
        {
            return View("~/Views/Soucan/loginSoucan.cshtml");// Ruta a la vista loginSoucan.cshtml
        }

        public ActionResult WebUC()
        {
            return Redirect("https://web.unican.es/");
        }

        public ActionResult WebSoucan()
        {
            return Redirect("https://web.unican.es/unidades/soucan");
        }

        public ActionResult Preuniversitarios()
        {
            return Redirect("https://web.unican.es/unidades/soucan/preuniversitarios");
        }

        public ActionResult Estudiantes()
        {
            return Redirect("https://web.unican.es/unidades/soucan/estudiantes/universidad-y-discapacidad");
        }
    }
}