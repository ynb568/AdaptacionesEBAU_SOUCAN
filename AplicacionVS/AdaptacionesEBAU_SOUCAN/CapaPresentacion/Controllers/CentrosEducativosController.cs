using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using CapaNegocio.Interfaces;
using CapaEntidad;
using CapaNegocio;
using System.Collections;
using CapaPresentacion.ViewModels;
using Microsoft.Ajax.Utilities;


namespace CapaPresentacion.Controllers
{
    public class CentrosEducativosController : Controller
    {
        
        //static string cadenaCon = "Data Source=3TPC64\SQLEXPRESS;Initial Catalog=AdaptacionesEBAU_SOUCAN;Integrated Security=true";

        private ICN_CentrosEducativos cnCentrosEducativos = new CN_CentrosEducativos();
        private ICN_Estudiantes cnEstudiantes = new CN_Estudiantes();
        private ICN_Diagnosticos cnDiagnosticos = new CN_Diagnosticos();
        private ICN_Adaptaciones cnAdaptaciones = new CN_Adaptaciones();
        private ICN_Documentos cnDocumentos = new CN_Documentos();
        private ICN_Asignaturas cnAsignaturas = new CN_Asignaturas();
        private ICN_PlazosRegistro cnPlazosRegistro = new CN_PlazosRegistro();
        private ICN_AdaptacionesDiagnosticoEstudiante cnAdaptacionesDiagnosticoEstudiante = new CN_AdaptacionesDiagnosticoEstudiante();
        private ICN_Recursos cnRecursos = new CN_Recursos();

        [OverrideActionFilters] //Filtro para que no se aplique el filtro de CheckSessionFilter
        [HttpGet]
        public ActionResult LoginCE()
        {
            return View();
        }

        [OverrideActionFilters]
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
            /*
            var id = (int)Session["centro educativo"];
            var centro = cnCentrosEducativos.obtenCentro(id);
            if (centro == null)
            {
                return RedirectToAction(nameof(HomeController.LoginCE), "Home");
            }
            */
            PlazosRegistro plazosRegistro = cnPlazosRegistro.obtenPlazoRegistroActivo();
            return View(plazosRegistro);
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
        public ActionResult CambioContrasenha(string ContrasenaActual, string NuevaContrasena, string ConfirmarNuevaContrasena)
        {
            int idCentro = (int)Session["centro educativo"];

            if (ContrasenaActual == null || NuevaContrasena == null || ConfirmarNuevaContrasena == null)
            {
                ViewData["Mensaje"] = "Debe rellenar todos los campos";
                return View("ControladorCentro");
            }

            if (ContrasenaActual == NuevaContrasena)
            {
                ViewData["Mensaje"] = "La nueva contraseña y la anterior coinciden";
                return View("ControladorCentro");
            }

            if (NuevaContrasena != ConfirmarNuevaContrasena)
            {
                ViewData["Mensaje"] = "La nueva contraseña y la confirmación no coinciden.";
                return View("ControladorCentro");
            }
            
            bool result = cnCentrosEducativos.CambioContrasenha(idCentro, ContrasenaActual, NuevaContrasena, ConfirmarNuevaContrasena);

            if (result)
            {
                Session.Clear();
                return RedirectToAction(nameof(CentrosEducativosController.LoginCE), "CentrosEducativos");
            }
            else
            {
                ViewData["Mensaje"] = "No se pudo realizar el cambio de contraseña";
                return View("ControladorCentro");
            }
        }



        [HttpGet]
        public ActionResult RegistroEstudiante()
        {
            int id = 1;//(int)Session["centro educativo"];
            var centro = cnCentrosEducativos.obtenCentro(id);

            if (centro == null)
            {
                return RedirectToAction(nameof(HomeController.LoginCE), "Home");
            }

            var viewModel = new EstudianteViewModel
            {
                PlazoRegistroActivo = cnPlazosRegistro.obtenPlazoRegistroActivo(),
                CE = centro,
                Estudiante = new Estudiante(),
                AsignaturasFase1 = cnAsignaturas.listaAsignaturasPorFase(1),
                AsignaturasFase2 = cnAsignaturas.listaAsignaturasPorFase(2),
                Diagnosticos = cnDiagnosticos.listaDiagnosticosActivos(),
                Adaptaciones = new List<Adaptacion>(),
                AdaptacionDiagnosticoEstudiantes = new List<AdaptacionDiagnosticoEstudiante>(),
                Documentos = cnDocumentos.listaDocumentos()

            };

            return View(viewModel);
        }

        //METODO AUXILIAR PARA OBTENER LAS ADAPTACIONES DE UN DIAGNOSTICO EN EL REGISTRO DE ESTUDIANTE
        [HttpPost]
        public ActionResult SetDiagnostico(int idDiagnostico)
        {
            Diagnostico diagnostico = cnDiagnosticos.obtenDiagnostico(idDiagnostico);            
            return PartialView("_Diagnostico", diagnostico);
        }

        [HttpPost]
        public ActionResult SetAdaptacion(int idAdaptacion, int idDiagnostico)
        {
            var adaptacionDiagnosticoEstudiante = new AdaptacionDiagnosticoEstudiante()
            {
                Adaptacion = cnAdaptaciones.obtenAdaptacion(idAdaptacion)
            };

            var viewModel = new AdaptacionDiagnosticoViewModel()
            {
                AdaptacionDiagnosticoEstudiante = adaptacionDiagnosticoEstudiante,
                DiagnosticoId = idDiagnostico
            };
            return PartialView("_AdaptacionesDiagnosticoEstudiante", viewModel);
        }

        [HttpGet]
        public ActionResult ObtenNombreDiagnostico(int idDiagnostico)
        {
            var diagnostico = cnDiagnosticos.obtenDiagnostico(idDiagnostico);
            var nombreDiagnostico = diagnostico.NombreDiagnostico;
            return View((object)nombreDiagnostico);
        }

        [HttpPost]
        public ActionResult RegistroEstudiante(EstudianteViewModel model)
        {
            int idCentro = (int)Session["centro educativo"];
            bool ordinaria = model.isOrdinaria;

            int idE = cnEstudiantes.registraEstudiante(
                model.Estudiante.DniEstudiante, model.Estudiante.NombreEstudiante, 
                model.Estudiante.Ap1Estudiante, model.Estudiante.Ap2Estudiante,
                model.Estudiante.NombreCompletoTutor1, model.Estudiante.TelefonoTutor1, 
                model.Estudiante.NombreCompletoTutor2, model.Estudiante.TelefonoTutor2,
                ordinaria, !ordinaria, idCentro, model.Estudiante.Observaciones);



            for (int i = 0; i < model.AsignaturasFase1.Count; i++)
            {
                if (model.AsignaturasFase1[i].IsSelected)
                {
                    cnAsignaturas.registraAsignaturaPrevistaEstudiante(idE, 
                        model.AsignaturasFase1[i].IdAsignatura, true, false);

                }
            }
            for (int i = 0; i < model.AsignaturasFase2.Count; i++)
            {
                if (model.AsignaturasFase2[i].IsSelected)
                {
                    cnAsignaturas.registraAsignaturaPrevistaEstudiante(idE, 
                        model.AsignaturasFase2[i].IdAsignatura, false, true);
                }
            }
            for (int i = 0; i < model.SelectedAdaptaciones.Count; i++)
            {
                cnAdaptacionesDiagnosticoEstudiante.registraAdaptacionDiagnosticoEstudiante(idE,
                    model.SelectedAdaptaciones[i].DiagnosticoId,
                                       model.SelectedAdaptaciones[i].AdaptacionDiagnosticoEstudiante.Adaptacion.IdAdaptacion,
                                                          model.SelectedAdaptaciones[i].AdaptacionDiagnosticoEstudiante.Observaciones);            
            }
            for (int i = 0; i < model.Documentos.Count; i++)
            {
                if (model.Documentos[i].RutaDocumento != null)
                {
                    if (!model.Documentos[i].RutaDocumento.IsNullOrWhiteSpace())
                    {
                        var rutaDocumento = Server.MapPath(model.Documentos[i].RutaDocumento);
                        model.Documentos[i].RutaDocumento = cnRecursos.ConvertirArchivoABinario(rutaDocumento);
                        cnDocumentos.registraDocumentoEstudiante(idE, model.Documentos[i].IdDocumento,
                            model.Documentos[i].RutaDocumento);
                    }
                }               
            }

            return RedirectToAction("EstudiantesCentro");
        }

        [HttpGet]
        public ActionResult EstudiantesCentro()
        { 
            var idCentro = (int)Session["centro educativo"];
            var estudiantes = cnEstudiantes.listaEstudiantes(idCentro);
            return View(estudiantes);
        }


        [HttpGet]
        public ActionResult InfoEstudiante(int idE)
        {
            int id = (int)Session["centro educativo"];
            var centro = cnCentrosEducativos.obtenCentro(id);
            var estudiante = cnEstudiantes.obtenEstudianteCentro(id, idE);

            var viewModel = new EstudianteViewModel
            {
                CE = centro,
                Estudiante = estudiante,
                AsignaturasFase1 = cnAsignaturas.listaAsignaturasPrevistasEstudiantePorFase(idE, 1),
                AsignaturasFase2 = cnAsignaturas.listaAsignaturasPrevistasEstudiantePorFase(idE, 2),
                Diagnosticos = cnDiagnosticos.listaDiagnosticosEstudiante(idE),
                Documentos = cnDocumentos.listaDocumentosEstudiante(idE)

            };
            foreach (Diagnostico d in viewModel.Diagnosticos)
            {
                viewModel.AdaptacionDiagnosticoEstudiantes = cnAdaptacionesDiagnosticoEstudiante.listaAdaptacionesDiagnosticoEstudiante(idE, d.IdDiagnostico);
            }
            

            return View(viewModel);
        }

        public ActionResult EdicionEstudiante(int idE)
        {
            int id = (int)Session["centro educativo"];
            var centro = cnCentrosEducativos.obtenCentro(id);
            var estudiante = cnEstudiantes.obtenEstudianteCentro(id, idE);
            PlazosRegistro pr = cnPlazosRegistro.obtenPlazoRegistroActivo();



            if (centro == null || estudiante == null || DateTime.Now  < pr.FechaIni || DateTime.Now > pr.FechaFin)
            {
                return RedirectToAction(nameof(HomeController.LoginCE), "Home");
            }

            var viewModel = new EstudianteViewModel
            {
                CE = centro,
                Estudiante = estudiante,
                AsignaturasFase1 = cnAsignaturas.listaAsignaturasPorFase(1),
                AsignaturasFase2 = cnAsignaturas.listaAsignaturasPorFase(2),
                isOrdinaria = (estudiante.Convocatoria == "Ordinaria"),
                Diagnosticos = cnDiagnosticos.listaDiagnosticosActivos(),
                Documentos = cnDocumentos.listaDocumentos()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EdicionEstudiante(EstudianteViewModel model)
        {
            bool ordinaria = model.isOrdinaria;
            int idE = model.Estudiante.IdEstudiante;
            cnEstudiantes.modificaDatosEstudiante(model.Estudiante.IdEstudiante, ordinaria, !ordinaria, model.Estudiante.Observaciones);

            cnAsignaturas.eliminaAsignaturasPrevistasEstudiante(idE);

            for (int i = 0; i < model.AsignaturasFase1.Count; i++)
            {
                if (model.AsignaturasFase1[i].IsSelected)
                {
                    cnAsignaturas.registraAsignaturaPrevistaEstudiante(idE,
                        model.AsignaturasFase1[i].IdAsignatura, true, false);

                }
            }
            for (int i = 0; i < model.AsignaturasFase2.Count; i++)
            {
                if (model.AsignaturasFase2[i].IsSelected)
                {
                    cnAsignaturas.registraAsignaturaPrevistaEstudiante(idE,
                        model.AsignaturasFase2[i].IdAsignatura, false, true);
                }
            }

            for (int i = 0; i < model.AdaptacionDiagnosticoEstudiantes.Count; i++)
            {
                cnDiagnosticos.eliminaDiagnosticoEstudiante(idE, model.SelectedAdaptaciones[i].DiagnosticoId);
            }
            
            
            for (int i = 0; i < model.SelectedAdaptaciones.Count; i++)
            {
                cnAdaptacionesDiagnosticoEstudiante.registraAdaptacionDiagnosticoEstudiante(idE,
                    model.SelectedAdaptaciones[i].DiagnosticoId,
                                       model.SelectedAdaptaciones[i].AdaptacionDiagnosticoEstudiante.Adaptacion.IdAdaptacion,
                                                          model.SelectedAdaptaciones[i].AdaptacionDiagnosticoEstudiante.Observaciones);
            }
            for (int i = 0; i < model.Documentos.Count; i++)
            {
                if (model.Documentos[i].RutaDocumento != null)
                {
                    if (!model.Documentos[i].RutaDocumento.IsNullOrWhiteSpace())
                    {
                        var rutaDocumento = Server.MapPath(model.Documentos[i].RutaDocumento);
                        model.Documentos[i].RutaDocumento = cnRecursos.ConvertirArchivoABinario(rutaDocumento);
                        cnDocumentos.registraDocumentoEstudiante(idE, model.Documentos[i].IdDocumento,
                            model.Documentos[i].RutaDocumento);
                    }
                }
            }

            return RedirectToAction("EstudiantesCentro");
        }




    }
}