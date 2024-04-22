using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_CentrosEducativos
    {
        private CD_CentrosEducativos objCD = new CD_CentrosEducativos();

        /*
         * Obtiene una lista de todos los centros educativos.
         * 
         * @return Lista de centros educativos completa
        */
        public List<CentroEducativo> listaCentros()
        {
            
            return objCD.listaCentros();
        }
        
        /*
         * Obtiene un centro educativo cuyo id es pasado como parametro
         * 
         * @param idCentroEducativo: identificador del centro educativo
         * @return datos del centro educativo
        */
        public CentroEducativo obtenCentro (int idCentroEducativo)
        {
            return objCD.obtenCentro(idCentroEducativo);
        }

        /*
         * Registra un centro educatvo junto con sus datos
         * 
         * @param nombreCE: nombre del centro educativo
         * @param telefonoCE: telefono del centro educativo
         * @param nombreOrientador: nombre del orientador
         * @param apellidosOrientador: apellidos del orientador
         * @param telefonoOrientador: telefono del orientador
         * @param correoOrientador: correo del orientador
         * @param nombreEquipoDirectivo: nombre del equipo directivo
         * @param apellidosEquipoDirectivo: apellidos del equipo directivo
         * @param telefonoEquipoDirectivo: telefono del equipo directivo
         * @param direccion: direccion del centro educativo
         * @param idMunicipio: identificador del municipio para la dirección
         * @param idSede: identificador de la sede asignada al centro educativo
         * @param correo: correo del centro educativo
         * @param contrasenha: contrasenha del centro educativo
         * @param repetirContrasenha: repetir contrasenha del centro educativo
         * 
         * @return true si se ha registrado correctamente, false en caso contrario
        */
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

        /* Modifica los datos acerca de un centro educativo
         * 
         * @param idCE: identificador del centro educativo
         * @param telefonoCE: telefono del centro educativo
         * @param nombreO: nombre del orientador
         * @param apellidosO: apellidos del orientador
         * @param telefonoO: telefono del orientador
         * @param correoO: correo del orientador
         * @param nombreED: nombre del equipo directivo
         * @param apellidosED: apellidos del equipo directivo
         * @param telefonoED: telefono del equipo directivo
         * 
         * @return true si se ha modificado correctamente, false en caso contrario
        */
        public bool modificaDatosCentro(int idCE, string telefonoCE,
            string nombreO, string apellidosO, string telefonoO, string correoO,
            string nombreED, string apellidosED, string telefonoED)
        {
            return objCD.modificaDatosCentro(idCE, telefonoCE,
                nombreO, apellidosO, telefonoO, correoO,
                nombreED, apellidosED, telefonoED);
        }

        /* 
         * Obtiene el id del centro educativo una vez ha iniciado sesión
         * 
         * @param correo: correo del centro educativo
         * @param contrasenha: contrasenha del centro educativo
         * 
         * @return id del centro educativo
        */
        public int LoginCE(string correo, string contrasenha)
        {
            int idCE = -1;
            contrasenha = CN_Recursos.convertirSha256(contrasenha);

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

        /*
         * Cambia la contrasenha de un centro educativo
         * 
         * @param idCE: identificador del centro educativo
         * @param contrasenha: contrasenha actual del centro educativo
         * @param nuevaContrasenha: nueva contrasenha del centro educativo
         * @param repetirContrasenha: repetir nueva contrasenha del centro educativo
         *
         * @return true si se ha cambiado correctamente, false en caso contrario
         */
        public bool CambioContrasenha(int idCE, string contrasenha, string nuevaContrasenha, string repetirContrasenha)
        {
            bool completado = false;

            if (nuevaContrasenha == repetirContrasenha)
            {
                contrasenha = CN_Recursos.convertirSha256(contrasenha);
                nuevaContrasenha = CN_Recursos.convertirSha256(nuevaContrasenha);

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
