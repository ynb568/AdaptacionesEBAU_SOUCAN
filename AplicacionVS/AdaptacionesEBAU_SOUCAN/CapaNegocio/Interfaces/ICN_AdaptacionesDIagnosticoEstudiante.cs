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
        /// Obtiene una lista de todas las adaptaciones de un diagnostico de un estudiante.
        /// </summary>
        /// <param name="idEstudiante">Identificador del estudiante.</param>
        /// <param name="idDiagnostico">Identificador del diagnostico.</param>
        /// <returns>Lista de adaptaciones de un diagnostico de un estudiante.</returns>
        List<AdaptacionDiagnosticoEstudiante> listaAdaptacionesDiagnosticoEstudiante(int idEstudiante, int idDiagnostico);
        /// <summary>
        /// Inserta una adaptacion de un diagnostico de un estudiante junto con sus observaciones.
        /// </summary>
        /// <param name="idEestudiante">Identificador del estudiante.</param>
        /// <param name="idDiagnostico">Identificador del diagnóstico.</param>
        /// <param name="idAdaptacion">Identificador de la adaptación.</param>
        /// <param name="observaciones">Observaciones de la adaptación.</param>
        /// <returns>True si se ha insertado correctamente, false en caso contrario.</returns>

        bool registraAdaptacionDiagnosticoEstudiante(int idEestudiante, int idDiagnostico, int idAdaptacion, string observaciones);
    }
}
