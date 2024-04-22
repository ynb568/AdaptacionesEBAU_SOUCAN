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
    public class CD_Sedes
    {
        public List<Sede> listaSedes()
        {
            List<Sede> listaSedes = new List<Sede>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaSedes", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaSedes.Add(
                                new Sede()
                                {
                                    IdSede = Convert.ToInt32(dr["idSede"]),
                                    NombreSede = dr["nombreSede"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"])                                }
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Sedes.listaSedes: " + ex.Message);
            }
            return listaSedes;
        }

        public Sede obtenSedeCentro(int idCentro)
        {
            Sede sede = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenSedeCentro", con);
                    cmd.Parameters.AddWithValue("idCE", idCentro);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            sede = new Sede()
                            {
                                IdSede = Convert.ToInt32(dr["idSede"]),
                                NombreSede = dr["nombreSede"].ToString(),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Sedes.obtenSedeCentro: " + ex.Message);
            }
            return sede;
        }
    }
}
