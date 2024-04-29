using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public interface ICN_Adaptaciones
    {
        /// <summary>
        /// Obtiene una lista de todas las adaptaciones existentes
        /// </summary>
        /// <returns>lista de adaptaciones</returns>
        List<Adaptacion> listaAdaptaciones();
        /// <summary>
        /// Obtiene los datos de una adaptacion cuyo id es pasado como parametro
        /// </summary>
        /// <param name="idAdaptacion">identificador de la adaptacion</param>
        /// <returns>datos de la adaptacion</returns>
        Adaptacion obtenAdaptacion(int idAdaptacion);
        /// <summary>
        /// Obtiene la lista de adaotaciones de un diagnostico cuyo id es pasado como parámetro
        /// </summary>
        /// <param name="idDiagnostico">identificador del diagnostico</param>
        /// <returns>lista de adaptaciones de un diagnostico</returns>

        List<Adaptacion> listaAdaptacionesDiagnostico(int idDiagnostico);
        /// <summary>
        /// Obtiene la lista de adaptaciones activas de un diagnostico
        /// cuyo id es pasado como parámetro
        /// </summary>
        /// <param name="idDiagnostico">identificador del diagnostico</param>
        /// <returns>lista de adaptaciones activas de un diagnostico</returns>

        List<Adaptacion> listaAdaptacionesDiagnosticoActivas(int idDiagnostico);
    }
}
