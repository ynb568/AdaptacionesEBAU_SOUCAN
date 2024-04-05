using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;


namespace CapaPresentacion.Controllers
{
    public class CentrosEducativosController : Controller
    {
        /* Cadena de conexión con la BBDD
         * Data source = nombre del servidor
         * Initial Catalog = nombre de BBDD
         * Integrated Security = Tipo de autenticación (Windows = true)
         */
        //static string cadenaCon = "Data Source=3TPC64\SQLEXPRESS;Initial Catalog=AdaptacionesEBAU_SOUCAN;Integrated Security=true";
        
        [HttpPost]
        public ActionResult LoginCE(CentroEducativo ce)
        {
            ce.Contrasenha = CN_Recursos.convertirSha256(ce.Contrasenha);

            using (SqlConnection con = new SqlConnection(cadenaCon))
            {
                SqlCommand cmd = new SqlCommand("sp_validarCentroEducativo", con);
                cmd.Parameters.AddWithValue("correo", ce.Correo);
                cmd.Parameters.AddWithValue("contrasenha", ce.Contrasenha);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                ce.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString()); // Solo lee 1 fila y 1 columna
            }

            if (ce.IdCE != 0)
            {
                //Crea una sesion para el centro educativo que se logea
                Session["centro educativo"] = ce.IdCE;

                return RedirectToAction("Index", "Home"); //CAMBIAR A CONTROLADOR DE CENTRO
            } else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();

            }
        }

        [HttpPost]
        public ActionResult RegistroEstudiante(int Identificador)
        {
            return View();
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
        [HttpPost]
        public ActionResult CambioContrasenha(CentroEducativo ce, string nuevaContrasenha)
        {
            bool completado;

            if (ce.Contrasenha == ce.RepetirContrasenha)
            {
                ce.Contrasenha = CN_Recursos.convertirSha256(ce.Contrasenha);
                nuevaContrasenha = CN_Recursos.convertirSha256(nuevaContrasenha);
            } else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            using (SqlConnection con = new SqlConnection(cadenaCon))
            {
                SqlCommand cmd = new SqlCommand("sp_modificarContrasenha", con);
                cmd.Parameters.AddWithValue("IdCE", ce.IdCE); 
                cmd.Parameters.AddWithValue("contrasenha", nuevaContrasenha);
                cmd.Parameters.Add("completado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                cmd.ExecuteNonQuery();

                completado = Convert.ToBoolean(cmd.Parameters["completado"].Value);
            }

            if (completado)
            {
                return RedirectToAction("LoginCE", "CentrosEducativos");
            } else
            {
                ViewData["Mensaje"] = "No ha sido posible cambiar la contraseña";
                return View();
            }
        }


    }
}