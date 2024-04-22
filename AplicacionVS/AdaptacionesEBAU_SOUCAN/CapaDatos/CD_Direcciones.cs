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
    public class CD_Direcciones
    {
        public Direccion obtenDireccionCentro(int idCentro)
        {
            Direccion direccion = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenDireccionCentro", con);
                    cmd.Parameters.AddWithValue("idCE", idCentro);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            direccion = new Direccion()
                            {
                                IdDireccion = Convert.ToInt32(dr["idDireccion"]),
                                NombreDireccion = dr["nombreDireccion"].ToString(),
                            };
                            int idDireccion = direccion.IdDireccion;
                            CD_Municipios cdMunicipios = new CD_Municipios();
                            Municipio municipio = cdMunicipios.obtenMunicipioDirecccion(idDireccion);
                            direccion.Municipio = municipio;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Direcciones.obtenDireccionCentro: " + ex.Message);
            }
            return direccion;
        }
    }
}
