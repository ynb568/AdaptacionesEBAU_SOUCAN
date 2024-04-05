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
                listaDiagnosticos = new List<Diagnostico>();
                Console.WriteLine("Error en CD_Diagnosticos.listaDiagnosticos: " + ex.Message);
            }
            return listaDiagnosticos;
        }
    }
}
