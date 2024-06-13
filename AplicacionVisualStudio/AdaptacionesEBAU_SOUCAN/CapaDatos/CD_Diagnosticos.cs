using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Diagnosticos
    {
        public List<Diagnostico> listaDiagnosticos()
        {
            List<Diagnostico> listaDiagnosticos = new List<Diagnostico>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaDiagnosticos", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Diagnostico d = new Diagnostico()
                            {
                                IdDiagnostico = Convert.ToInt32(dr["idDiagnostico"]),
                                NombreDiagnostico = dr["nombreDiagnostico"].ToString(),
                                Activo = Convert.ToBoolean(dr["activo"]),
                                Descripcion = dr["descripcion"].ToString()
                            };
                            int idDiagnostico = d.IdDiagnostico;

                            CD_Adaptaciones cdAdaptaciones = new CD_Adaptaciones();
                            List<Adaptacion> adaptaciones = cdAdaptaciones.listaAdaptacionesDiagnostico(idDiagnostico);
                            d.Adaptaciones = adaptaciones;
                            listaDiagnosticos.Add(d);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Diagnosticos.listaDiagnosticos: " + ex.Message);
            }
            return listaDiagnosticos;
        }

        public Diagnostico obtenDiagnostico (int idDiagnostico)
        {
            Diagnostico d = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenDiagnostico", con);
                    cmd.Parameters.AddWithValue("idD", idDiagnostico);

                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParameter);

                    SqlParameter modificadoParameter = new SqlParameter("@Completado", SqlDbType.Bit);
                    modificadoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(modificadoParameter);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            d = new Diagnostico()
                            {
                                IdDiagnostico = Convert.ToInt32(dr["idDiagnostico"]),
                                NombreDiagnostico = dr["nombreDiagnostico"].ToString(),
                                Activo = Convert.ToBoolean(dr["activo"]),
                                Descripcion = dr["descripcion"].ToString()
                            };
                            CD_Adaptaciones cdAdaptaciones = new CD_Adaptaciones();
                            List<Adaptacion> adaptaciones = cdAdaptaciones.listaAdaptacionesDiagnostico(idDiagnostico);
                            d.Adaptaciones = adaptaciones;
                            dr.Close();
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Diagnosticos.obtenDiagnostico: " + ex.Message);
            }
            return d;
        }


        public List<Diagnostico> listaDiagnosticosEstudiante (int idEstudiante)
        {
            List<Diagnostico> listaDiagnosticos = new List<Diagnostico>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaDiagnosticosEstudiante", con);
                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Diagnostico d = new Diagnostico()
                            {
                                IdDiagnostico = Convert.ToInt32(dr["idDiagnostico"]),
                                NombreDiagnostico = dr["nombreDiagnostico"].ToString(),
                                Activo = Convert.ToBoolean(dr["activo"]),
                                Descripcion = dr["descripcion"].ToString()    
                            };
                            int idDiagnostico = d.IdDiagnostico;

                            CD_AdaptacionesDiagnosticoEstudiante cdAdaptaciones = new CD_AdaptacionesDiagnosticoEstudiante();
                            List<AdaptacionDiagnosticoEstudiante> adaptaciones = cdAdaptaciones.listaAdaptacionesDiagnosticoEstudiante(idEstudiante, idDiagnostico);
                            d.AdaptacionesEstudiante = adaptaciones;
                            listaDiagnosticos.Add(d);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Diagnosticos.: " + ex.Message);
            }
            return listaDiagnosticos;
        }
        public bool eliminaDiagnosticosEstudiante(int idEstudiante)
        {
            bool eliminado = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminaDiagnosticoEstudiante", con);
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
                        Console.WriteLine("El diagnóstico ha sido eliminado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo eliminar el diagnóstico.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Diagnosticos.eliminaDiagnosticoEstudiante: " + ex.Message);
            }
            return eliminado;
        }

    }
}
