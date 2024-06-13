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
                                Validado = Convert.ToInt32(dr["validado"]),
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

                            CD_Diagnosticos cdDiagnosticos = new CD_Diagnosticos();
                            List<Diagnostico> diagnosticos = cdDiagnosticos.listaDiagnosticosEstudiante(idEstudiante);
                            e.Diagnosticos = diagnosticos;
                            CD_AdaptacionesDiagnosticoEstudiante cdAdaptaciones = new CD_AdaptacionesDiagnosticoEstudiante();
                            foreach (Diagnostico d in diagnosticos)
                            {
                                List<AdaptacionDiagnosticoEstudiante> adaptaciones = cdAdaptaciones.listaAdaptacionesDiagnosticoEstudiante(idEstudiante, d.IdDiagnostico);
                            }

                            estudiantes.Add(e);
                        }
                    }
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Estudiantes.listaEstudiantes: " + ex.Message);
            }


            return estudiantes;
        }
         //METODO DUPLICADO
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
                                Validado = Convert.ToInt32(dr["validado"]),
                                Observaciones = dr["observaciones"].ToString()
                            };

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
                            CD_AdaptacionesDiagnosticoEstudiante cdAdaptacionesDiagnosticoEstudiante = new CD_AdaptacionesDiagnosticoEstudiante();
                            foreach (Diagnostico d in diagnosticos)
                            {
                                List<AdaptacionDiagnosticoEstudiante> adaptaciones = cdAdaptacionesDiagnosticoEstudiante.listaAdaptacionesDiagnosticoEstudiante(idEstudiante, d.IdDiagnostico);
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
                Console.WriteLine("Error en CD_Estudiantes.obtenEstudianteCentro: " + ex.Message);
            }
            return e;
        }

        public Estudiante obtenInfoEstudianteCentro(int idCentro, int idEstudiante)
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
                                Validado = Convert.ToInt32(dr["validado"]),
                                Observaciones = dr["observaciones"].ToString()
                            };
                        }
                        dr.Close();
                        con.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Estudiantes.obtenEstudianteCentro: " + ex.Message);
            }
            return e;
        }


        public int registraEstudiante(string dniEstudiante, string nombreEstudiante, string ap1Estudiante, string ap2Estudiante,
            string nombreCompletoT1, string telefonoT1, string nombreCompletoT2, string telefonoT2,
            bool ordinaria, bool extraordinaria, int idCE, string observaciones)
        {
            int idENuevo = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_registraEstudiante", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("dniE", dniEstudiante);
                    cmd.Parameters.AddWithValue("nombreE", nombreEstudiante);
                    cmd.Parameters.AddWithValue("ap1E", ap1Estudiante);
                    cmd.Parameters.AddWithValue("ap2E", ap2Estudiante);
                    cmd.Parameters.AddWithValue("nombreT1", string.IsNullOrEmpty(nombreCompletoT1) ? (object)DBNull.Value : nombreCompletoT1);
                    cmd.Parameters.AddWithValue("telefonoT1", string.IsNullOrEmpty(telefonoT1) ? (object)DBNull.Value : telefonoT1);
                    cmd.Parameters.AddWithValue("nombreT2", string.IsNullOrEmpty(nombreCompletoT2) ? (object)DBNull.Value : nombreCompletoT2);
                    cmd.Parameters.AddWithValue("telefonoT2", string.IsNullOrEmpty(telefonoT2) ? (object)DBNull.Value : telefonoT2);
                    cmd.Parameters.AddWithValue("ordinaria", ordinaria);
                    cmd.Parameters.AddWithValue("extraordinaria", extraordinaria);
                    cmd.Parameters.AddWithValue("idCE", idCE);
                    cmd.Parameters.AddWithValue("observaciones", string.IsNullOrEmpty(observaciones) ? (object)DBNull.Value : observaciones);

                    // Parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParameter);

                    SqlParameter registradoParameter = new SqlParameter("@Registrado", SqlDbType.Bit);
                    registradoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(registradoParameter);

                    SqlParameter idENuevoParameter = new SqlParameter("@idE", SqlDbType.Int);
                    idENuevoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(idENuevoParameter);


                    con.Open();

                    cmd.ExecuteNonQuery();

                    // Obtener resultados de los parámetros de salida
                    string mensaje = mensajeParameter.Value.ToString();
                    bool registro = Convert.ToBoolean(registradoParameter.Value);
                    idENuevo = Convert.ToInt32(idENuevoParameter.Value);

                    Console.WriteLine(mensaje);
                    if (registro)
                    {
                        Console.WriteLine("El estudiante ha sido registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo registrar al estudiante.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Estudiantes.registraEstudiante: " + ex.Message);
            }
            return idENuevo;
        }

        public bool modificaDatosEstudiante(int idE, bool ordinaria, bool extraordinaria, string observaciones)
        {
            bool modificado = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_modificaDatosEstudiante", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("idE", idE);
                    cmd.Parameters.AddWithValue("ordinaria", ordinaria);
                    cmd.Parameters.AddWithValue("extraordinaria", extraordinaria);
                    cmd.Parameters.AddWithValue("observaciones", observaciones);

                    // Parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParameter);

                    SqlParameter modificadoParameter = new SqlParameter("@Modificado", SqlDbType.Bit);
                    modificadoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(modificadoParameter);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    // Obtener resultados de los parámetros de salida
                    string mensaje = mensajeParameter.Value.ToString();
                    modificado = Convert.ToBoolean(modificadoParameter.Value);

                    Console.WriteLine(mensaje);
                    if (modificado)
                    {
                        Console.WriteLine("Los datos del estudiante han sido modificados correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudieron modificar los datos del estudiante.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Estudiantes.modificaDatosEstudiante: " + ex.Message);
            }
            return modificado;
        }


    }
}
