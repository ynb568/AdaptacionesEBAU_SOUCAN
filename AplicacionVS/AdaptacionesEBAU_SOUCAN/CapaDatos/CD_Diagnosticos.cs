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
                            listaDiagnosticos.Add(
                                new Diagnostico()
                                {
                                    IdDiagnostico = Convert.ToInt32(dr["idDiagnostico"]),
                                    NombreDiagnostico = dr["nombreDiagnostico"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    Descripcion = dr["descripcion"].ToString(),
                                    Adaptaciones =,
                                }
                            );
                        }
                    }

                }

            }
            catch
            {
                listaDiagnosticos = new List<Diagnostico>();
            }
            return listaDiagnosticos;
        }
    }
}
