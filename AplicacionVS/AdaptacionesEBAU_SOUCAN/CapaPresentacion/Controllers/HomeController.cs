using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class HomeController : Controller
    {
        private CN_Estudiantes cn_estudiantes = new CN_Estudiantes();

        public ActionResult Index()
        {
             List<Estudiante> lista = cn_estudiantes.listaEstudiantes(1);
            var i = 2;

            var viewModel = new ViewModels.IndexViewModel
            {
                Estudiantes = lista,
                i = i
            };

            return View(viewModel);
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