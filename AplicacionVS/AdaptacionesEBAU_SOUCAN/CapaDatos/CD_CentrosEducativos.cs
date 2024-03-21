using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_CentrosEducativos
    {

        public List<CentroEducativo> listaCentros()
        {
            List<CentroEducativo> centros = new List<CentroEducativo>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    //string query = "..."
                    SqlCommand cmd = new SqlCommand("sp_listaCentrosEducativos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandType = CommandType.Text;

                    con.Open();
                    //Sirve para mapear la información de las tablas
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        //Para leer múltiples filas
                        while (dr.Read())
                        {
                            centros.Add(
                                new CentroEducativo()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdCE"]),
                                    NombreCE = dr["nombreCE"].ToString(),
                                    Sede = ,
                                    TelefonoCE = dr["telefonoCE"].ToString(),
                                    NombreOrientador = dr["nombreOrientador"].ToString(),
                                    ApellidosOrientador = dr["apellidosorientador"].ToString(),
                                    TelefonoOrientador = dr["telefonoOrientador"].ToString(),
                                    CorreoOrientador = dr["correoOrientador"].ToString(),
                                    NombreEquipoDirectivo = dr["nombreEquipoDirectivo"].ToString(),
                                    ApellidosEquipoDirectivo = dr["apellidosEquipoDirectivo"].ToString(),
                                    Direccion = ,
                                    Estudiantes = 

                                }
                                );
                        }
                    }

                }
            }
            catch
            {
                centros = new List<CentroEducativo>();
            }


            return centros;
        }
    }
}
