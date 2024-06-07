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

        public CentroEducativo obtenCentro(int idCentro)
        {
            CentroEducativo ce = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenCentro", con);
                    cmd.Parameters.AddWithValue("idCE", idCentro);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            
                            ce = new CentroEducativo()
                            {
                                IdCE = Convert.ToInt32(dr["IdCE"]),
                                Correo = dr["correo"].ToString(),
                                Contrasenha = dr["contrasenha"].ToString(),
                                NombreCE = dr["nombreCE"].ToString(),
                                TelefonoCE = dr["telefonoCE"].ToString(),
                                NombreOrientador = dr["nombreOrientador"].ToString(),
                                ApellidosOrientador = dr["apellidosorientador"].ToString(),
                                TelefonoOrientador = dr["telefonoOrientador"].ToString(),
                                CorreoOrientador = dr["correoOrientador"].ToString(),
                                NombreEquipoDirectivo = dr["nombreEquipoDirectivo"].ToString(),
                                ApellidosEquipoDirectivo = dr["apellidosEquipoDirectivo"].ToString(),
                                TelefonoEquipoDirectivo = dr["telefonoEquipoDirectivo"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["fechaRegistro"])
                            };

                            

                            CD_Direcciones cdDirecciones = new CD_Direcciones();
                            Direccion direccion = cdDirecciones.obtenDireccionCentro(idCentro);
                            ce.Direccion = direccion;

                            CD_Sedes cdSedes = new CD_Sedes();
                            Sede sede = cdSedes.obtenSedeCentro(idCentro);
                            ce.Sede = sede;

                            CD_Estudiantes cdEstudiantes = new CD_Estudiantes();
                            List<Estudiante> estudiantes = cdEstudiantes.listaEstudiantes(idCentro);
                            ce.Estudiantes = estudiantes;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_CentrosEducativos.obtenCentro: " + ex.Message);
            }
            return ce;
        }

        public bool registraCentroEducativo(string nombreCE, string telefonoCE,
            string nombreOrientador, string apellidosOrientador, string telefonoOrientador, string correoOrientador,
            string nombreEquipoDirectivo, string apellidosEquipoDirectivo, string telefonoEquipoDirectivo,
            string direccion, int idMunicipio, int idSede,
            string correo, string contrasenha, string repetirContrasenha)
        {
            bool registro = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_registraCentroEducativo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("nombreCE", nombreCE);
                    cmd.Parameters.AddWithValue("telefonoCE", telefonoCE);
                    cmd.Parameters.AddWithValue("nombreOrientador", string.IsNullOrEmpty(nombreOrientador) ? (object)DBNull.Value : nombreOrientador);
                    cmd.Parameters.AddWithValue("apellidosOrientador", string.IsNullOrEmpty(apellidosOrientador) ? (object)DBNull.Value : apellidosOrientador);
                    cmd.Parameters.AddWithValue("telefonoOrientador", string.IsNullOrEmpty(telefonoOrientador) ? (object)DBNull.Value : telefonoOrientador);
                    cmd.Parameters.AddWithValue("correoOrientador", string.IsNullOrEmpty(correoOrientador) ? (object)DBNull.Value : correoOrientador);
                    cmd.Parameters.AddWithValue("nombreEquipoDirectivo", string.IsNullOrEmpty(nombreEquipoDirectivo) ? (object)DBNull.Value : nombreEquipoDirectivo);
                    cmd.Parameters.AddWithValue("apellidosEquipoDirectivo", string.IsNullOrEmpty(apellidosEquipoDirectivo) ? (object)DBNull.Value : apellidosEquipoDirectivo);
                    cmd.Parameters.AddWithValue("telefonoEquipoDirectivo", string.IsNullOrEmpty(telefonoEquipoDirectivo) ? (object)DBNull.Value : telefonoEquipoDirectivo);
                    cmd.Parameters.AddWithValue("direccion", direccion);
                    cmd.Parameters.AddWithValue("idMunicipio", idMunicipio);
                    cmd.Parameters.AddWithValue("idSede", idSede);
                    cmd.Parameters.AddWithValue("correo", correo);
                    cmd.Parameters.AddWithValue("contrasenha", string.IsNullOrEmpty(contrasenha) ? (object)DBNull.Value : contrasenha);
                    cmd.Parameters.AddWithValue("repetirContrasenha", string.IsNullOrEmpty(repetirContrasenha) ? (object)DBNull.Value : repetirContrasenha);

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
                    registro = Convert.ToBoolean(registradoParameter.Value);

                    Console.WriteLine(mensaje);
                    if (registro)
                    {
                        Console.WriteLine("El centro educativo ha sido registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo registrar el centro educativo.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_CentrosEducativos.registraCentroEducativo: " + ex.Message);
            }
            return registro;
        }

        public bool modificaDatosCentro (int idCE, string telefonoCE, 
               string nombreO, string apellidosO, string telefonoO, string correoO, 
               string nombreED, string apellidosED, string telefonoED)
        {
            bool modificado = false;
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_modificaDatosCentro", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("idCE", idCE);
                    cmd.Parameters.AddWithValue("telefonoCE", string.IsNullOrEmpty(telefonoCE) ? (object)DBNull.Value : telefonoCE);
                    cmd.Parameters.AddWithValue("nomO", string.IsNullOrEmpty(nombreO) ? (object)DBNull.Value : nombreO);
                    cmd.Parameters.AddWithValue("apO", string.IsNullOrEmpty(apellidosO) ? (object)DBNull.Value : apellidosO);
                    cmd.Parameters.AddWithValue("telefonoO", string.IsNullOrEmpty(telefonoO) ? (object)DBNull.Value : telefonoO);
                    cmd.Parameters.AddWithValue("correoO", string.IsNullOrEmpty(correoO) ? (object)DBNull.Value : correoO);
                    cmd.Parameters.AddWithValue("nomED", string.IsNullOrEmpty(nombreED) ? (object)DBNull.Value : nombreED);
                    cmd.Parameters.AddWithValue("apED", string.IsNullOrEmpty(apellidosED) ? (object)DBNull.Value : apellidosED);
                    cmd.Parameters.AddWithValue("telefonoED", string.IsNullOrEmpty(telefonoED) ? (object)DBNull.Value : telefonoED);

                    // Parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParameter);

                    SqlParameter modificadoParameter = new SqlParameter("@Modificado", SqlDbType.Bit);
                    modificadoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(modificadoParameter);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    // Obtener resultados de los parámetros de salida
                    string mensaje = mensajeParameter.Value.ToString();
                    modificado = Convert.ToBoolean(modificadoParameter.Value);

                    Console.WriteLine(mensaje);
                    if (modificado)
                    {
                        Console.WriteLine("Los datos del centro educativo han sido modificados correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudieron modificar los datos del centro educativo.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_CentrosEducativos.modificaDatosCentro: " + ex.Message);
            }
            return modificado;
        }

        public String obtenNombreCentro(int idCentro)
        {
            String nombreCentro = "";
            try
            {
                // Establecer la conexión con la base de datos
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    // Crear un nuevo comando SQL para ejecutar el procedimiento almacenado
                    SqlCommand cmd = new SqlCommand("sp_obtenNombreCentro", con);
                    cmd.Parameters.AddWithValue("@idCE", idCentro);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Definir los parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParameter);

                    SqlParameter completadoParameter = new SqlParameter("@Completado", SqlDbType.Bit);
                    completadoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(completadoParameter);

                    // Abrir la conexión a la base de datos
                    con.Open();

                    // Ejecutar el comando y procesar los resultados
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Asignar el nombre del centro educativo a la variable nombreCentro
                            nombreCentro = dr["nombreCE"].ToString();
                        }
                    }

                    // Gestionar las salidas
                    string mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                    bool completado = Convert.ToBoolean(cmd.Parameters["@Completado"].Value);

                    Console.WriteLine(mensaje);
                    if (completado)
                    {
                        Console.WriteLine("Los datos del centro educativo se han recuperado.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudieron recuperar los datos del centro educativo.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Imprimir cualquier error que ocurra durante la ejecución
                Console.WriteLine("Error en CD_CentrosEducativos.obtenNombreCentroEstudiante: " + ex.Message);
            }
            // Devolver el nombre del centro educativo
            return nombreCentro;
        }


    }
}
