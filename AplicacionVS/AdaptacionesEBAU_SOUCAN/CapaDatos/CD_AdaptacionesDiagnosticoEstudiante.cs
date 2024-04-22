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
    public class CD_AdaptacionesDiagnosticoEstudiante
    {
        public List<AdaptacionDiagnosticoEstudiante> listaAdaptacionesDiagnosticoEstudiante(int idEstudiante, int idDiagnostico)
        {
            List<AdaptacionDiagnosticoEstudiante> listaAdaptacionesDE = new List<AdaptacionDiagnosticoEstudiante>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaAdaptacionesDiagnosticoEstudiante", con);
                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.Parameters.AddWithValue("idD", idDiagnostico);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaAdaptacionesDE.Add(
                                new AdaptacionDiagnosticoEstudiante()
                                {
                                    Adaptacion = new Adaptacion()
                                    {
                                        IdAdaptacion = Convert.ToInt32(dr["idAdaptacion"]),
                                        NombreAdaptacion = dr["nombreAdaptacion"].ToString(),
                                        Activo = Convert.ToBoolean(dr["activo"]),
                                        Descripcion = dr["descripcion"].ToString(),
                                        Excepcional = Convert.ToBoolean(dr["excepcional"]),
                                        DescripcionExcepcional = dr["descripcionExcepcional"].ToString()
                                    },
                                    Validado = dr["validado"] != DBNull.Value ? Convert.ToBoolean(dr["validado"]) : false,
                                    Observaciones = dr["observaciones"].ToString(),
                                    Revision = dr["revision"].ToString()
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Adaptaciones.obtenAdaptacionesEstudiante: " + ex.Message);
            }
            return listaAdaptacionesDE;
        }

        public bool registraAdaptacionDiagnosticoEstudiante(int idEstudiante, int idDiagnostico, int idAdaptacion, string observaciones)
        {
            bool registro = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_registraAdaptacionDiagnosticoEstudiante", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.Parameters.AddWithValue("idD", idDiagnostico);
                    cmd.Parameters.AddWithValue("idA", idAdaptacion);
                    cmd.Parameters.AddWithValue("observaciones", observaciones);

                    // Parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParameter);

                    SqlParameter registradoParameter = new SqlParameter("@Registrado", SqlDbType.Bit);
                    registradoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(registradoParameter);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    // Obtener resultados de los parámetros de salida
                    string mensaje = mensajeParameter.Value.ToString();
                    registro = registradoParameter.Value != DBNull.Value ? Convert.ToBoolean(registradoParameter.Value) : false;

                    Console.WriteLine(mensaje);
                    if (registro)
                    {
                        Console.WriteLine("La adaptación ha sido registrada correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo registrar la adaptación.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Adaptaciones.registraAdaptacionDiagnosticoEstudiante: " + ex.Message);
            }
            return registro;
        }
    }
}
