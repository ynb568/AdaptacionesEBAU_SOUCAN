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
    public class CD_Apuntes
    {
        public List<Apunte> listaApuntesEstudiante(int idEstudiante)
        {
            List<Apunte> listaApuntes = new List<Apunte>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaApuntesEstudiante", con);
                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaApuntes.Add(
                                new Apunte()
                                {
                                    IdApunte = Convert.ToInt32(dr["idApunte"]),
                                    Descripcion = dr["descripcion"].ToString(),
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Apuntes.listaApuntesEstudiante: " + ex.Message);
            }
            return listaApuntes;
        }
    }
}
