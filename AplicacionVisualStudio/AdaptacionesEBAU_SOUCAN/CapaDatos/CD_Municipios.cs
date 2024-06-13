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
    public class CD_Municipios
    {
        public List<Municipio> listaMunicipios()
        {
            List<Municipio> listaMunicipios = new List<Municipio>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listamunicipios", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaMunicipios.Add(
                                new Municipio()
                                {
                                    IdMunicipio = Convert.ToInt32(dr["idMunicipio"]),
                                    NombreMunicipio = dr["nombreMunicipio"].ToString()
                                }
                            );
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Municipios.listaMunicipios: " + ex.Message);
            }
            return listaMunicipios;
        }

        public Municipio obtenMunicipioDirecccion(int idDireccion)
        {
            Municipio municipio = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenMunicipioDireccion", con);
                    cmd.Parameters.AddWithValue("idD", idDireccion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            municipio = new Municipio()
                            {
                                IdMunicipio = Convert.ToInt32(dr["idMunicipio"]),
                                NombreMunicipio = dr["nombreMunicipio"].ToString()
                            };
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Municipios.obtenMunicipioDirecccion: " + ex.Message);
            }
            return municipio;
        }
    }
}
