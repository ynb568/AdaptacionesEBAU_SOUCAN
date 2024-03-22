using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; //Uso de referencias a todos los elementos de la bbdd
using System.Data;

namespace CapaDatos
{
    public class CD_Estudiantes
    {

        public List<Estudiante> listaEstudiantes (int idCentro)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaEstudiantesCentro", con);
                    cmd.Parameters.AddWithValue("idCE", idCentro);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        //Para leer múltiples filas
                        while (dr.Read())
                        {
                            Estudiante e = new Estudiante()
                            {
                                IdEstudiante = Convert.ToInt32(dr["idEstudiante"]),
                                NombreEstudiante = dr["nombreEstudiante"].ToString(),
                                Ap1Estudiante = dr["ap1Estudiante"].ToString(),
                                Ap2Estudiante = dr["ap2Estudiante"].ToString(),
                                NombreCompletoTutor1 = dr["nombreCompletoTutor1"].ToString(),
                                TelefonoTutor1 = dr["telefonoTutor1"].ToString(),
                                NombreCompletoTutor2 = dr["nombreCompletoTutor2"].ToString(),
                                TelefonoTutor2 = dr["telefonoTutor2"].ToString(),
                                CursoConvocatoria = dr["cursoConvocatoria"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["fechaRegistro"]),
                                Ordinaria = Convert.ToBoolean(dr["ordinaria"]),
                                ExtraOrdinaria = Convert.ToBoolean(dr["extraOrdinaria"]),
                            };

                            int idEstudiante = e.IdEstudiante;

                            CD_Asignaturas cdAsignaturas = new CD_Asignaturas();
                            List<Asignatura> asignaturasPrevistas = cdAsignaturas.listaAsignaturasPrevistasEstudiante(idEstudiante);
                            e.AsignaturasPrevistas = asignaturasPrevistas;
                            List<Asignatura> asignaturasMatriculadas = cdAsignaturas.listaAsignaturasMatriculadasEstudiante(idEstudiante);
                            e.AsignaturasMatriculadas = asignaturasMatriculadas;


                            CD_Apuntes cdApuntes = new CD_Apuntes();
                            List<Apunte> apuntes = cdApuntes.listaApuntesEstudiante(idEstudiante);
                            e.Apuntes = apuntes;

                            CD_Documentos cdDocumentos = new CD_Documentos();
                            List<Documento> documentos = cdDocumentos.listaDocumentosEstudiante(idEstudiante);
                            e.Documentos = documentos;

                            estudiantes.Add(e);
                        }
                    }
                }
            } catch
            {
                estudiantes = new List<Estudiante>();
            }


            return estudiantes;
        }
    }
}
