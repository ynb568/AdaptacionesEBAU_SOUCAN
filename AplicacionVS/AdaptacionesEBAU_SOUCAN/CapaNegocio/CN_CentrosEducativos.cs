using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using CapaNegocio.Interfaces;

namespace CapaNegocio
{
    public class CN_CentrosEducativos : ICN_CentrosEducativos
    {
        private CD_CentrosEducativos objCD = new CD_CentrosEducativos();
        private ICN_Recursos cnRecursos = new CN_Recursos();

        public List<CentroEducativo> listaCentros()
        {
            
            return objCD.listaCentros();
        }

        public CentroEducativo obtenCentro (int idCentroEducativo)
        {
            return objCD.obtenCentro(idCentroEducativo);
        }

        public bool registraCentroEducativo(string nombreCE, string telefonoCE,
            string nombreOrientador, string apellidosOrientador, string telefonoOrientador, string correoOrientador,
            string nombreEquipoDirectivo, string apellidosEquipoDirectivo, string telefonoEquipoDirectivo,
            string direccion, int idMunicipio, int idSede,
            string correo, string contrasenha, string repetirContrasenha)
        {
            return objCD.registraCentroEducativo(nombreCE, telefonoCE,
                nombreOrientador, apellidosOrientador, telefonoOrientador, correoOrientador,
                nombreEquipoDirectivo, apellidosEquipoDirectivo, telefonoEquipoDirectivo,
                direccion, idMunicipio, idSede,
                correo, contrasenha, repetirContrasenha);
        }

        public bool modificaDatosCentro(int idCE, string telefonoCE,
            string nombreO, string apellidosO, string telefonoO, string correoO,
            string nombreED, string apellidosED, string telefonoED)
        {
            return objCD.modificaDatosCentro(idCE, telefonoCE,
                nombreO, apellidosO, telefonoO, correoO,
                nombreED, apellidosED, telefonoED);
        }

        public int LoginCE(string correo, string contrasenha)
        {
            int idCE = -1;
            contrasenha = cnRecursos.convertirSha256(contrasenha);

            using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
            {
                SqlCommand cmd = new SqlCommand("sp_validarCentroEducativo", con);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@contrasenha", contrasenha);
                cmd.Parameters.Add("@idCE", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                cmd.ExecuteNonQuery();

                if (cmd.Parameters["@idCE"].Value != DBNull.Value)
                {
                    idCE = Convert.ToInt32(cmd.Parameters["@idCE"].Value);
                }
            }

            return idCE;
        }

        public bool CambioContrasenha(int idCE, string contrasenha, string nuevaContrasenha, string repetirContrasenha)
        {
            bool completado = false;

            if (nuevaContrasenha == repetirContrasenha)
            {
                contrasenha = cnRecursos.convertirSha256(contrasenha);
                nuevaContrasenha = cnRecursos.convertirSha256(nuevaContrasenha);

                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_cambiaContrasenha", con);
                    cmd.Parameters.AddWithValue("@idCE", idCE);
                    cmd.Parameters.AddWithValue("@contrasenha", contrasenha);
                    cmd.Parameters.AddWithValue("@nuevaContrasenha", nuevaContrasenha);
                    cmd.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Completado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    cmd.ExecuteNonQuery();

                    if (cmd.Parameters["@Completado"].Value != DBNull.Value)
                    {
                        completado = Convert.ToBoolean(cmd.Parameters["@Completado"].Value);
                    }
                }
            }
            return completado;
        }






    }
}
