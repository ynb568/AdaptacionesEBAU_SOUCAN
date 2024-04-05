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
                                DniEstudiante = dr["dniEstudiante"].ToString(),
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
                                ExtraOrdinaria = Convert.ToBoolean(dr["extraordinaria"]),
                                Validado = dr["validado"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dr["validado"]),
                                Observaciones = dr["observaciones"].ToString()
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
            } 
            catch (Exception ex)
            {
                estudiantes = new List<Estudiante>();
                Console.WriteLine("Error en CD_Estudiantes.listaEstudiantes: " + ex.Message);
            }


            return estudiantes;
        }

        public Estudiante obtenEstudianteCentro(int idCentro, int idEstudiante)
        {
            Estudiante e = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenEstudianteCentro", con);
                    cmd.Parameters.AddWithValue("idCE", idCentro);
                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            e = new Estudiante()
                            {
                                IdEstudiante = Convert.ToInt32(dr["idEstudiante"]),
                                DniEstudiante = dr["dniEstudiante"].ToString(),
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
                                Validado = dr["validado"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dr["validado"]),
                                Observaciones = dr["observaciones"].ToString()
                            };

                            /* CONSIDERAR SI ES NECESARIO RECUPERAR EL CENTRO EDUCATIVO
                            CD_CentrosEducativos cdCentros = new CD_CentrosEducativos();
                            CentroEducativo ce = cdCentros.obtenCentro(idCentro);
                            e.Centro = ce;
                            */
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

                            CD_Diagnosticos cdDiagnosticos = new CD_Diagnosticos();
                            List<Diagnostico> diagnosticos = cdDiagnosticos.listaDiagnosticosEstudiante(idEstudiante);
                            e.Diagnosticos = diagnosticos;
                            CD_Adaptaciones cdAdaptaciones = new CD_Adaptaciones();
                            foreach (Diagnostico d in diagnosticos)
                            {
                                List<Adaptacion> adaptaciones = cdAdaptaciones.listaAdaptacionesDiagnosticoEstudiante(idEstudiante, d.IdDiagnostico);
                            }
                            
                        }
                        //AÑADIR AL RESTO DE LISTAS
                        dr.Close();
                        con.Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                e = new Estudiante();
                Console.WriteLine("Error en CD_Estudiantes.obtenEstudianteCentro: " + ex.Message);
            }
            return e;
        }
         
        public void RegistrarEstudiante(Estudiante e, int idCentro)
        {
            using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
            {
                using (SqlCommand command = new SqlCommand("sp_registraEstudiante", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    command.Parameters.Add("@nombreEstudiante", SqlDbType.VarChar).Value = e.NombreEstudiante;
                    command.Parameters.Add("@dniEstudiante", SqlDbType.VarChar).Value = e.DniEstudiante;
                    command.Parameters.Add("@ap1Estudiante", SqlDbType.VarChar).Value = e.Ap1Estudiante;
                    command.Parameters.Add("@ap2Estudiante", SqlDbType.VarChar).Value = e.Ap2Estudiante;
                    command.Parameters.Add("@nombreCompletoT1", SqlDbType.VarChar).Value = e.NombreCompletoTutor1;
                    command.Parameters.Add("@telefonoT1", SqlDbType.VarChar).Value = e.TelefonoTutor1;
                    command.Parameters.Add("@nombreCompletoT2", SqlDbType.VarChar).Value = e.NombreCompletoTutor2;
                    command.Parameters.Add("@telefonoT2", SqlDbType.VarChar).Value = e.TelefonoTutor2;
                    command.Parameters.Add("@idCE", SqlDbType.Int).Value = idCentro;

                    // Parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(mensajeParameter);

                    SqlParameter registradoParameter = new SqlParameter("@Registrado", SqlDbType.Bit);
                    registradoParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(registradoParameter);

                    con.Open();
                    command.ExecuteNonQuery();

                    // Obtener resultados de los parámetros de salida
                    string mensaje = mensajeParameter.Value.ToString();
                    bool registrado = Convert.ToBoolean(registradoParameter.Value);

                    Console.WriteLine(mensaje);
                    if (registrado)
                    {
                        Console.WriteLine("El estudiante ha sido registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo registrar al estudiante.");
                    }
                }
            }
        }
    }
}
