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
        /// Obtiene una lista de todos los centros educativos.
        /// </summary>
        /// <returns>Lista de centros educativos completa</returns>
        List<CentroEducativo> listaCentros();

        /// <summary>
        /// Obtiene un centro educativo cuyo id es pasado como parametro
        /// </summary>
        /// <param name="idCentroEducativo">identificador del centro educativo</param>
        /// <returns>datos del centro educativo</returns>
        CentroEducativo obtenCentro(int idCentroEducativo);
        
        /// <summary>
        /// Registra un centro educatvo junto con sus datos
        /// </summary>
        /// <param name="nombreCE">nombre del centro educativo</param>
        /// <param name="telefonoCE">telefono del centro educativo</param>
        /// <param name="nombreOrientador">nombre del orientador</param>
        /// <param name="apellidosOrientador">apellidos del orientador</param>
        /// <param name="telefonoOrientador">telefono del orientador</param>
        /// <param name="correoOrientador">correo del orientador</param>
        /// <param name="nombreEquipoDirectivo">nombre del equipo directivo</param>
        /// <param name="apellidosEquipoDirectivo">apellidos del equipo directivo</param>
        /// <param name="telefonoEquipoDirectivo">telefono del equipo directivo</param>
        /// <param name="direccion">direccion del centro educativo</param>
        /// <param name="idMunicipio">identificador del municipio para la dirección</param>
        /// <param name="idSede">identificador de la sede asignada al centro educativo</param>
        /// <param name="correo">correo del centro educativo</param>
        /// <param name="contrasenha">contrasenha del centro educativo</param>
        /// <param name="repetirContrasenha">repetir contrasenha del centro educativo</param>
        /// <returns>true si se ha registrado correctamente, false en caso contrario</returns>
        bool registraCentroEducativo(string nombreCE, string telefonoCE,
            string nombreOrientador, string apellidosOrientador, string telefonoOrientador, string correoOrientador,
            string nombreEquipoDirectivo, string apellidosEquipoDirectivo, string telefonoEquipoDirectivo,
            string direccion, int idMunicipio, int idSede,
            string correo, string contrasenha, string repetirContrasenha);
        
        /// <summary>
        /// Modifica los datos acerca de un centro educativo
        /// </summary>
        /// <param name="idCE">identificador del centro educativo</param>
        /// <param name="telefonoCE">telefono del centro educativo</param>
        /// <param name="nombreO">nombre del orientador</param>
        /// <param name="apellidosO">apellidos del orientador</param>
        /// <param name="telefonoO">telefono del orientador</param>
        /// <param name="correoO">correo del orientador</param>
        /// <param name="nombreED">nombre del equipo directivo</param>
        /// <param name="apellidosED">apellidos del equipo directivo</param>
        /// <param name="telefonoED">telefono del equipo directivo</param>
        /// <returns>true si se ha modificado correctamente, false en caso contrario</returns>
        bool modificaDatosCentro(int idCE, string telefonoCE,
            string nombreO, string apellidosO, string telefonoO, string correoO,
            string nombreED, string apellidosED, string telefonoED);
        
        /// <summary>
        /// Obtiene el id del centro educativo una vez ha iniciado sesión
        /// </summary>
        /// <param name="correo">correo del centro educativo</param>
        /// <param name="contrasenha">contrasenha del centro educativo</param>
        /// <returns>id del centro educativo logeado</returns>
        int LoginCE(string correo, string contrasenha);

        /// <summary>
        /// Cambia la contrasenha de un centro educativo
        /// </summary>
        /// <param name="idCE">identificador del centro educativ</param>
        /// <param name="contrasenha">contrasenha actual del centro educativo</param>
        /// <param name="nuevaContrasenha">nueva contrasenha del centro educativo</param>
        /// <param name="repetirContrasenha">repetir nueva contrasenha del centro educativo</param>
        /// <returns>true si se ha cambiado correctamente, false en caso contrario</returns>
        bool CambioContrasenha(int idCE, string contrasenha, string nuevaContrasenha, string repetirContrasenha);
    }
}
