using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace CapaDatos
{
    public class CD_Documentos
    {
        public List<Documento> listaDocumentos ()
        {
            List<Documento> documentos = new List<Documento>();
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaDocumentos", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        //Para leer múltiples filas
                        while (dr.Read())
                        {
                            documentos.Add(
                                new Documento()
                                {
                                    IdDocumento = Convert.ToInt32(dr["idDocumento"]),
                                    NombreDocumento = dr["nombreDocumento"].ToString()
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Documentos.listaDocumentos: " + ex.Message);
            }
            return documentos;
        }



        public List<Documento> listaDocumentosEstudiante(int idEstudiante)
        {
            List<Documento> documentos = new List<Documento>();
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaDocumentosEstudiante", con);
                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        //Para leer múltiples filas
                        while (dr.Read())
                        {
                            documentos.Add(
                                new Documento()
                                {
                                    IdDocumento = Convert.ToInt32(dr["idDocumento"]),
                                    NombreDocumento = dr["nombreDocumento"].ToString(),
                                    RutaDocumento = dr["rutaDocumento"].ToString(),
                                    Validado = Convert.ToInt32(dr["validado"])
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Documentos.listaDocumentosEstudiante: " + ex.Message);
            }
            return documentos;
        }

        public bool registraDocumentoEstudiante(int idEstudiante, int idDocumento, string rutaDocumento)
        {
            bool registro = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_registraDocumentoEstudiante", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.Parameters.AddWithValue("idD", idDocumento);
                    cmd.Parameters.AddWithValue("rutaD", rutaDocumento);

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
                        Console.WriteLine("El documento ha sido registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo registrar el documento.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Documentos.registraDocumentoEstudiante: " + ex.Message);
            }
            return registro;
        }

        public bool eliminaDocumentosEstudiante (int idEstudiante)
        {
            bool eliminado = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_eliminaDocumentosEstudiante", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("idE", idEstudiante);

                    // Parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParameter);

                    SqlParameter eliminadoParameter = new SqlParameter("@Eliminado", SqlDbType.Bit);
                    eliminadoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(eliminadoParameter);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    // Obtener resultados de los parámetros de salida
                    string mensaje = mensajeParameter.Value.ToString();
                    eliminado = eliminadoParameter.Value != DBNull.Value ? Convert.ToBoolean(eliminadoParameter.Value) : false;

                    Console.WriteLine(mensaje);
                    if (eliminado)
                    {
                        Console.WriteLine("Los documentos han sido eliminados correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudieron eliminar los documentos.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Documentos.eliminaDocumentosEstudiante: " + ex.Message);
            }
            return eliminado;
        }

    }
}
