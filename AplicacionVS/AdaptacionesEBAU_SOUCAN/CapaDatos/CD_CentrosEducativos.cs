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
                            CentroEducativo ce = new CentroEducativo()
                            {
                                Correo = dr["correo"].ToString(),
                                Contrasenha = dr["contrasenha"].ToString(),
                                IdCE = Convert.ToInt32(dr["IdCE"]),
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
                            int idCentro = ce.IdCE;

                            CD_Direcciones cdDirecciones = new CD_Direcciones();
                            Direccion direccion = cdDirecciones.obtenDireccionCentro(idCentro);
                            ce.Direccion = direccion;

                            CD_Sedes cdSedes = new CD_Sedes();
                            Sede sede = cdSedes.obtenSedeCentro(idCentro);
                            ce.Sede = sede;

                            CD_Estudiantes cdEstudiantes = new CD_Estudiantes();
                            List<Estudiante> estudiantes = cdEstudiantes.listaEstudiantes(idCentro);
                            ce.Estudiantes= estudiantes;

                            centros.Add(ce);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                centros = new List<CentroEducativo>();
                Console.WriteLine("Error en CD_CentrosEducativos.listaCentros: " + ex.Message);
            }
            return centros;
        }

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
                ce = new CentroEducativo();
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
                    cmd.Parameters.AddWithValue("nombreOrientador", nombreOrientador);
                    cmd.Parameters.AddWithValue("apellidosOrientador", apellidosOrientador);
                    cmd.Parameters.AddWithValue("telefonoOrientador", telefonoOrientador);
                    cmd.Parameters.AddWithValue("correoOrientador", correoOrientador);
                    cmd.Parameters.AddWithValue("nombreEquipoDirectivo", nombreEquipoDirectivo);
                    cmd.Parameters.AddWithValue("apellidosEquipoDirectivo", apellidosEquipoDirectivo);
                    cmd.Parameters.AddWithValue("telefonoEquipoDirectivo", telefonoEquipoDirectivo);
                    cmd.Parameters.AddWithValue("direccion", direccion);
                    cmd.Parameters.AddWithValue("idMunicipio", idMunicipio);
                    cmd.Parameters.AddWithValue("idSede", idSede);
                    cmd.Parameters.AddWithValue("correo", correo);
                    cmd.Parameters.AddWithValue("contrasenha", contrasenha);
                    cmd.Parameters.AddWithValue("repetirContrasenha", repetirContrasenha);

                    con.Open();

                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        registro = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_CentrosEducativos.registraCentroEducativo: " + ex.Message);
            }
            return registro;

        }
    }
}
