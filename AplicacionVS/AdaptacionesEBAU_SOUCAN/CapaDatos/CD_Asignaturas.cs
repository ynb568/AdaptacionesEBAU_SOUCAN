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

        public bool registraAsignaturaPrevistaEstudiante (int idEstudiante,int idAasignatura, bool fase1,bool fase2)
        {
            bool registro = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_registraAsignaturaPrevistaEstudiante", con);
                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.Parameters.AddWithValue("idA", idAasignatura);
                    cmd.Parameters.AddWithValue("fase1", fase1);
                    cmd.Parameters.AddWithValue("fase2", fase2);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        registro = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Asignaturas.registraAsignaturaPrevistaEstudiante: " + ex.Message);
            }
            return registro;
        }

    }
}
