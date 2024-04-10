using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Asignaturas
    {
        public List<Asignatura> listaAsignaturas()
        {
            List<Asignatura> listaAsignaturas = new List<Asignatura>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaAsignaturas", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaAsignaturas.Add(
                                new Asignatura()
                                {
                                    IdAsignatura = Convert.ToInt32(dr["idAsignatura"]),
                                    NombreAsignatura = dr["nombreAsignatura"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    Fase1 = Convert.ToBoolean(dr["fase1"]),
                                    Fase2 = Convert.ToBoolean(dr["fase2"]),
                                }
                            );
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                listaAsignaturas = new List<Asignatura>();
                Console.WriteLine("Error en CD_Asignaturas.listaAsignaturas: " + ex.Message);
            }
            return listaAsignaturas;
        }

        public List<Asignatura> listaAsignaturasPrevistasEstudiante(int idEstudiante)
        {
            List<Asignatura> listaAsignaturas = new List<Asignatura>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenAsignaturasPrevistasEstudiante", con);
                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaAsignaturas.Add(
                                new Asignatura()
                                {
                                    IdAsignatura = Convert.ToInt32(dr["idAsignatura"]),
                                    NombreAsignatura = dr["nombreAsignatura"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    Fase1 = Convert.ToBoolean(dr["fase1"]),
                                    Fase2 = Convert.ToBoolean(dr["fase2"]),
                                }
                            );
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                listaAsignaturas = new List<Asignatura>();
                Console.WriteLine("Error en CD_Asignaturas.listaAsignaturasPrevistasEstudiante: " + ex.Message);
            }
            return listaAsignaturas;
        }

        public List<Asignatura> listaAsignaturasMatriculadasEstudiante(int idEstudiante)
        {
            List<Asignatura> listaAsignaturas = new List<Asignatura>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenAsignaturasMatriculadasEstudiante", con);
                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaAsignaturas.Add(
                                new Asignatura()
                                {
                                    IdAsignatura = Convert.ToInt32(dr["idAsignatura"]),
                                    NombreAsignatura = dr["nombreAsignatura"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    Fase1 = Convert.ToBoolean(dr["fase1"]),
                                    Fase2 = Convert.ToBoolean(dr["fase2"]),
                                }
                            );
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                listaAsignaturas = new List<Asignatura>();
                Console.WriteLine("Error en CD_Asignaturas.listaAsignaturasMatriculadasEstudiante: " + ex.Message);
            }
            return listaAsignaturas;
        }

        public bool registraAsignaturaPrevistaEstudiante(int idEstudiante, int idAasignatura, bool fase1, bool fase2)
        {
            bool registro = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_registraAsignaturaPrevistaEstudiante", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.Parameters.AddWithValue("idA", idAasignatura);
                    cmd.Parameters.AddWithValue("fase1", fase1);
                    cmd.Parameters.AddWithValue("fase2", fase2);

                    // Parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParameter);

                    SqlParameter registradoParameter = new SqlParameter("@Registrado", SqlDbType.Bit);
                    registradoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(registradoParameter);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    // Obtener resultados de los parámetros de salida
                    string mensaje = mensajeParameter.Value.ToString();
                    registro = registradoParameter.Value != DBNull.Value ? Convert.ToBoolean(registradoParameter.Value) : false;

                    Console.WriteLine(mensaje);
                    if (registro)
                    {
                        Console.WriteLine("La asignatura prevista ha sido registrada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo registrar la asignatura prevista.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Asignaturas.registraAsignaturaPrevistaEstudiante: " + ex.Message);
            }
            return registro;
        }
        
        public bool eliminaAsignaturasPrevistasEstudiante(int idEstudiante)
        {
            bool eliminado = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminaAsignaturasPrevistasEstudiante", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("idE", idEstudiante);

                    // Parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParameter);

                    SqlParameter eliminadoParameter = new SqlParameter("@Eliminado", SqlDbType.Bit);
                    eliminadoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(eliminadoParameter);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    // Obtener resultados de los parámetros de salida
                    string mensaje = mensajeParameter.Value.ToString();
                    eliminado = eliminadoParameter.Value != DBNull.Value ? Convert.ToBoolean(eliminadoParameter.Value) : false;

                    Console.WriteLine(mensaje);
                    if (eliminado)
                    {
                        Console.WriteLine("Las asignaturas previstas han sido eliminadas correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudieron eliminar las asignaturas previstas.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Asignaturas.eliminaAsignaturasPrevistasEstudiante: " + ex.Message);
            }
            return eliminado;
        }

    }
}
