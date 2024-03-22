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
                                    Descripcion = dr["descripcion"].ToString()
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
                    SqlCommand cmd = new SqlCommand("sp_listaAdaptaciones", con);
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
                                    Descripcion = dr["descripcion"].ToString()
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
    }
}
