using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;


namespace CapaPresentacion.Controllers
{
    public class CentrosEducativosController : Controller
    {
        
        //static string cadenaCon = "Data Source=3TPC64\SQLEXPRESS;Initial Catalog=AdaptacionesEBAU_SOUCAN;Integrated Security=true";

        private CN_CentrosEducativos cnCentrosEducativos = new CN_CentrosEducativos();
        private CN_Estudiantes cnEstudiantes = new CN_Estudiantes();


        [HttpGet]
        public ActionResult LoginCE()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCE(CentroEducativo ce)
        {
            ce.IdCE = cnCentrosEducativos.LoginCE(ce.Correo, ce.Contrasenha);

            if (ce.IdCE != 0)
            {
                //Crea una sesion para el centro educativo que se logea
                Session["centro educativo"] = ce.IdCE;

                return RedirectToAction(nameof(CentrosEducativosController.ControladorCentro), nameof(HomeController));
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
        }

        [HttpGet]
        public ActionResult ControladorCentro()
        {
            return View();
        }





        [HttpGet]
        public ActionResult EdicionCentro()
        {
            var Id = 1;//(int)Session["centro educativo"];
            var centro = cnCentrosEducativos.obtenCentro(Id);
            if (centro == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(centro);
        }

        [HttpPost]
        public ActionResult EdicionCentro(CentroEducativo modelo)
        {
            var Id = (int)Session["centro educativo"];
            
            var success = cnCentrosEducativos.modificaDatosCentro(
                Id,
                modelo.TelefonoCE,
                modelo.NombreOrientador,
                modelo.ApellidosOrientador,
                modelo.TelefonoOrientador,
                modelo.CorreoOrientador,
                modelo.NombreEquipoDirectivo,
                modelo.ApellidosEquipoDirectivo,
                modelo.TelefonoEquipoDirectivo);
            
            return View();
        }


        [HttpPost]
        public ActionResult CambioContrasenha(CentroEducativo ce, string nuevaContrasenha)
        {
            CN_CentrosEducativos cnCentrosEducativos = new CN_CentrosEducativos();

            string result = cnCentrosEducativos.CambioContrasenha(ce.IdCE, ce.Contrasenha, ce.RepetirContrasenha, nuevaContrasenha);

            if (result == "Success")
            {
                return RedirectToAction("LoginCE", "CentrosEducativos");
            }
            else
            {
                ViewData["Mensaje"] = result;
                return View();
            }
        }



        [HttpPost]
        public ActionResult RegistroEstudiante(int Identificador)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarEstudiante(string dniEstudiante, string nombreEstudiante, string ap1Estudiante, string ap2Estudiante,
       string nombreCompletoT1, string telefonoT1, string nombreCompletoT2, string telefonoT2,
       string convocatoria, int idCentro, string observaciones)
        {

            bool ordinaria = convocatoria == "ordinaria";
            bool extraordinaria = convocatoria == "extraordinaria";

            cnEstudiantes.registraEstudiante(dniEstudiante, nombreEstudiante, ap1Estudiante, ap2Estudiante,
                nombreCompletoT1, telefonoT1, nombreCompletoT2, telefonoT2,
                ordinaria, extraordinaria, idCentro, observaciones);

            return RedirectToAction("EstudiantesCentro");
        }

        public ActionResult EditarEstudiante(int idE)
        {
            var idCentro = (int)Session["centro educativo"];
            var estudiante = cnEstudiantes.obtenEstudianteCentro(idCentro, idE);
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult EditarEstudiante(int idE, string convocatoria, string observaciones)
        {
            bool ordinaria = convocatoria == "ordinaria";
            bool extraordinaria = convocatoria == "extraordinaria";

            cnEstudiantes.modificaDatosEstudiante(idE, ordinaria, extraordinaria, observaciones);

            return RedirectToAction("EstudiantesCentro");
        }

        public JsonResult listaEstudiantes()
        {
            //Crear una variable de sesión
            var IdCentro = (int)Session["centro educativo"];
            List<Estudiante> listaE = new List<Estudiante> ();

            listaE = new CN_Estudiantes().listaEstudiantes(IdCentro);

            return Json(listaE, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EstudiantesCentro()
        { 
            return View();
        }
        [HttpGet]
        public ActionResult InfoCE()
        {
            return View();
        }



    }
}