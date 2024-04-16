using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_PlazosRegistro
    {
        public PlazosRegistro obtenPlazoRegistroActivo()
        {
            PlazosRegistro pr = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenPlazoRegistroActivo", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            pr = new PlazosRegistro()
                            {
                                IdPlazo = Convert.ToInt32(dr["idPlazo"]),
                                FechaIni = Convert.ToDateTime(dr["fechaIni"]),
                                FechaFin = Convert.ToDateTime(dr["fechaFin"]),
                                CursoConvocatoria = dr["cursoConvocatoria"].ToString(), 
                                Activo = Convert.ToBoolean(dr["activo"])
                            };
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error en CD_PlazosRegistro.obtenPlazoRegistroActivo: " + ex.Message);
                pr = new PlazosRegistro();
            }
            return pr;
        }
    }
}
