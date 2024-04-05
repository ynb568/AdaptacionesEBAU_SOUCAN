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

    }
}
