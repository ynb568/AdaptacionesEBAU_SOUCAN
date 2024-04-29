using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public interface ICN_AdaptacionesDiagnosticoEstudiante
    {
        /// <summary>
        /// Obtiene una lista de todas las adaptaciones de un diagnostico de un estudiante
        /// </summary>
        /// <param name="idEstudiante">identificador del estudiante</param>
        /// <param name="idDiagnostico">identificador del diagnostico</param>
        /// <returns>lista de adaptaciones de un diagnostico de un estudiante</returns>
        List<AdaptacionDiagnosticoEstudiante> listaAdaptacionesDiagnosticoEstudiante(int idEstudiante, int idDiagnostico);
        /// <summary>
        /// Inserta una adaptacion de un diagnostico de un estudiante junto con sus observaciones
        /// </summary>
        /// <param name="idEestudiante">identificador del estudiante</param>
        /// <param name="idDiagnostico">identificador del diagnóstico</param>
        /// <param name="idAdaptacion">identificador de la adaptación</param>
        /// <param name="observaciones">string de observaciones de la adaptacion</param>
        /// <returns>true si se ha insertado correctamente, false en caso contrario</returns>

        bool registraAdaptacionDiagnosticoEstudiante(int idEestudiante, int idDiagnostico, int idAdaptacion, string observaciones);
    }
}
