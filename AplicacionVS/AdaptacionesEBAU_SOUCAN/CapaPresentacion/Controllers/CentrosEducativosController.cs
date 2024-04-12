using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;
using System.Collections;


namespace CapaPresentacion.Controllers
{
    public class CentrosEducativosController : Controller
    {
        
        //static string cadenaCon = "Data Source=3TPC64\SQLEXPRESS;Initial Catalog=AdaptacionesEBAU_SOUCAN;Integrated Security=true";

        private CN_CentrosEducativos cnCentrosEducativos = new CN_CentrosEducativos();
        private CN_Estudiantes cnEstudiantes = new CN_Estudiantes();
        private CN_Diagnosticos cnDiagnosticos = new CN_Diagnosticos();
        private CN_Documentos cnDocumentos = new CN_Documentos();


        [HttpGet]
        public ActionResult LoginCE()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCE(string correo, string contrasenha)
        {
            int idCE = cnCentrosEducativos.LoginCE(correo, contrasenha);

            if (idCE > 0)
            {
                //Crea una sesion para el centro educativo que se logea
                Session["centro educativo"] = idCE;

                return RedirectToAction(nameof(CentrosEducativosController.ControladorCentro), "CentrosEducativos");
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
            int id = (int)Session["centro educativo"];
            var centro = cnCentrosEducativos.obtenCentro(id);
            if (centro == null)
            {
                return RedirectToAction(nameof(HomeController.LoginCE), "Home");
            }
            return View(centro);
        }
        
        //TODO: investigar como poner para mensaje de error y ok
        //  No recupera los datos que no son editables
        [HttpPost]
        public ActionResult EdicionCentro(CentroEducativo ce)
        {
            var Id = (int)Session["centro educativo"];
                        
            var success = cnCentrosEducativos.modificaDatosCentro(
                Id,
                ce.TelefonoCE,
                ce.NombreOrientador,
                ce.ApellidosOrientador,
                ce.TelefonoOrientador,
                ce.CorreoOrientador,
                ce.NombreEquipoDirectivo,
                ce.ApellidosEquipoDirectivo,
                ce.TelefonoEquipoDirectivo);

            if (success)
            {

                ViewData["MensajeOk"] = "Cambios realizados correctamente";
                return RedirectToAction(nameof(CentrosEducativosController.ControladorCentro), "CentrosEducativos");
                //return View(ce);
            }
            else
            {
                ViewData["Mensaje"] = "Error al modificar los datos";
                return View(ce);
            }
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



        [HttpGet]
        public ActionResult RegistroEstudiante()
        {
            int id = (int)Session["centro educativo"];
            var centro = cnCentrosEducativos.obtenCentro(id);

            if (centro == null)
            {
                return RedirectToAction(nameof(HomeController.LoginCE), "Home");
            }

            var viewModel = new ViewModels.EstudianteViewModel
            {
                CE = centro,
                Estudiante = new Estudiante(),
                Diagnosticos = cnDiagnosticos.listaDiagnosticosActivos(),
                Documentos = cnDocumentos.listaDocumentos()

            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult RegistroEstudiante(string dniEstudiante, string nombreEstudiante, string ap1Estudiante, string ap2Estudiante,
       string nombreCompletoT1, string telefonoT1, string nombreCompletoT2, string telefonoT2,
       string convocatoria, string observaciones)
        {
            int idCentro = (int)Session["centro educativo"];
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