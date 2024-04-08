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
    public class CD_Adaptaciones
    {
        public List<Adaptacion> listaAdaptaciones()
        {
            List<Adaptacion> listaAdaptaciones = new List<Adaptacion>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaAdaptaciones", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaAdaptaciones.Add(
                                new Adaptacion()
                                {
                                    IdAdaptacion = Convert.ToInt32(dr["idAdaptacion"]),
                                    NombreAdaptacion = dr["nombreAdaptacion"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    Descripcion = dr["descripcion"].ToString(),
                                    Excepcional = Convert.ToBoolean(dr["excepcional"]),
                                    DescripcionExcepcional = dr["descripcionExcepcional"].ToString()
                                }
                            );
                        }
                    }

                }

            }
            catch
            {
                listaAdaptaciones = new List<Adaptacion>();
            }
            return listaAdaptaciones;
        }

        public List<Adaptacion> listaAdaptacionesDiagnostico(int idDiagnostico)
        {
            List<Adaptacion> listaAdaptaciones = new List<Adaptacion>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaAdaptacionesDiagnostico", con);
                    cmd.Parameters.AddWithValue("idD", idDiagnostico);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaAdaptaciones.Add(
                                new Adaptacion()
                                {
                                    IdAdaptacion = Convert.ToInt32(dr["idAdaptacion"]),
                                    NombreAdaptacion = dr["nombreAdaptacion"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    Descripcion = dr["descripcion"].ToString(),
                                    Excepcional = Convert.ToBoolean(dr["excepcional"]),
                                    DescripcionExcepcional = dr["descripcionExcepcional"].ToString()
                                }
                            );
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                listaAdaptaciones = new List<Adaptacion>();
                Console.WriteLine("Error en CD_Adaptaciones.listaAdaptacionesDiagnostico: " + ex.Message);
            }
            return listaAdaptaciones;
        }

        public List<Adaptacion> listaAdaptacionesDiagnosticoEstudiante(int idEstudiante, int idDiagnostico)
        {
            List<Adaptacion> listaAdaptaciones = new List<Adaptacion>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaAdaptacionesDiagnosticoEstudiante", con);
                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.Parameters.AddWithValue("idD", idDiagnostico);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaAdaptaciones.Add(
                                new Adaptacion() 
                                { 
                                    IdAdaptacion = Convert.ToInt32(dr["idAdaptacion"]),
                                    NombreAdaptacion = dr["nombreAdaptacion"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    Descripcion = dr["descripcion"].ToString(),
                                    Excepcional = Convert.ToBoolean(dr["excepcional"]),
                                    DescripcionExcepcional = dr["descripcionExcepcional"].ToString()
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listaAdaptaciones = new List<Adaptacion>();
                Console.WriteLine("Error en CD_Adaptaciones.obtenAdaptacionesEstudiante: " + ex.Message);
            }
            return listaAdaptaciones;
        }

        public bool registraAdaptacionDiagnosticoEstudiante (int idEestudiante,int idDiagnostico,int idAdaptacion,string observaciones)
        {
            bool resultado = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_registraAdaptacionDiagnosticoEstudiante", con);
                    cmd.Parameters.AddWithValue("idE", idEestudiante);
                    cmd.Parameters.AddWithValue("idD", idDiagnostico);
                    cmd.Parameters.AddWithValue("idA", idAdaptacion);
                    cmd.Parameters.AddWithValue("observaciones", observaciones);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Adaptaciones.registraAdaptacionDiagnosticoEstudiante: " + ex.Message);
            }
            return resultado;
        }
    }
}
