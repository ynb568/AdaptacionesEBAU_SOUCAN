using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    [OverrideActionFilters]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginCE()
        {
            return RedirectToAction(nameof(CentrosEducativosController.LoginCE), "CentrosEducativosController");
        }

        //TODO: Implementar
        public ActionResult LoginSoucan()
        {
            return View("~/Views/Soucan/loginSoucan.cshtml");// Ruta a la vista loginSoucan.cshtml
        }
    }
}