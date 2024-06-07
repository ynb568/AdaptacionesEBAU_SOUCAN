using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ICN_CentrosEducativos
    {

        /// <summary>
        /// Obtiene un centro educativo cuyo id es pasado como parÁmetro.
        /// </summary>
        /// <param name="idCentroEducativo">Identificador del centro educativo.</param>
        /// <returns>Datos del centro educativo.</returns>
        CentroEducativo obtenCentro(int idCentroEducativo);
        
        /// <summary>
        /// Registra un centro educatvo junto con sus datos.
        /// </summary>
        /// <param name="nombreCE">Nombre del centro educativo.</param>
        /// <param name="telefonoCE">Telefono del centro educativo.</param>
        /// <param name="nombreOrientador">Nombre del orientador.</param>
        /// <param name="apellidosOrientador">Apellidos del orientador.</param>
        /// <param name="telefonoOrientador">Telefono del orientador.</param>
        /// <param name="correoOrientador">Correo del orientador.</param>
        /// <param name="nombreEquipoDirectivo">Nombre del equipo directivo.</param>
        /// <param name="apellidosEquipoDirectivo">Apellidos del equipo directivo.</param>
        /// <param name="telefonoEquipoDirectivo">Telefono del equipo directivo.</param>
        /// <param name="direccion">Direccion del centro educativo.</param>
        /// <param name="idMunicipio">Identificador del municipio para la dirección.</param>
        /// <param name="idSede">Identificador de la sede asignada al centro educativo.</param>
        /// <param name="correo">Correo del centro educativo.</param>
        /// <param name="contrasenha">Contrasenha del centro educativo.</param>
        /// <param name="repetirContrasenha">Repetir contrasenha del centro educativo.</param>
        /// <returns>True si se ha registrado correctamente, false en caso contrario.</returns>
        bool registraCentroEducativo(string nombreCE, string telefonoCE,
            string nombreOrientador, string apellidosOrientador, string telefonoOrientador, string correoOrientador,
            string nombreEquipoDirectivo, string apellidosEquipoDirectivo, string telefonoEquipoDirectivo,
            string direccion, int idMunicipio, int idSede,
            string correo, string contrasenha, string repetirContrasenha);
        
        /// <summary>
        /// Modifica los datos acerca de un centro educativo.
        /// </summary>
        /// <param name="idCE">Identificador del centro educativo.</param>
        /// <param name="telefonoCE">Telefono del centro educativo.</param>
        /// <param name="nombreO">Nombre del orientador.</param>
        /// <param name="apellidosO">Apellidos del orientador.</param>
        /// <param name="telefonoO">Telefono del orientador.</param>
        /// <param name="correoO">Correo del orientador.</param>
        /// <param name="nombreED">Nombre del equipo directivo.</param>
        /// <param name="apellidosED">Apellidos del equipo directivo.</param>
        /// <param name="telefonoED">Telefono del equipo directivo.</param>
        /// <returns>True si se ha modificado correctamente, false en caso contrario.</returns>
        bool modificaDatosCentro(int idCE, string telefonoCE,
            string nombreO, string apellidosO, string telefonoO, string correoO,
            string nombreED, string apellidosED, string telefonoED);
        
        /// <summary>
        /// Obtiene el id del centro educativo una vez ha iniciado sesión.
        /// </summary>
        /// <param name="correo">Correo del centro educativo.</param>
        /// <param name="contrasenha">Contrasenha del centro educativo.</param>
        /// <returns>Id del centro educativo logeado, que será utilizado como variable de sesión.</returns>
        int LoginCE(string correo, string contrasenha);

        /// <summary>
        /// Obtiene el nombre del centro de un identificador en concreto.
        /// </summary>
        /// <param name="idCentro">Identificador del centroen concreto.</param>
        /// <returns></returns>
        string obtenNombreCentro(int idCentro);


        /// <summary>
        /// Cambia la contrasenha de un centro educativo.
        /// </summary>
        /// <param name="idCE">Identificador del centro educativo.</param>
        /// <param name="contrasenha">Contrasenha actual del centro educativo.</param>
        /// <param name="nuevaContrasenha">Nueva contrasenha del centro educativo.</param>
        /// <param name="repetirContrasenha">Repetir nueva contrasenha del centro educativo.</param>
        /// <returns>True si se ha cambiado correctamente, false en caso contrario.</returns>
        bool CambioContrasenha(int idCE, string contrasenha, string nuevaContrasenha, string repetirContrasenha);
    }
}
