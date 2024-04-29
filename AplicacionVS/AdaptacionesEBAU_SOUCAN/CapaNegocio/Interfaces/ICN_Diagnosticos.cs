using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ICN_Diagnosticos
    {
        /// <summary>
        /// Obtiene una lista de todos los diagnosticos
        /// </summary>
        /// <returns>lista de diagnosticos</returns>
        List<Diagnostico> listaDiagnosticos();

        /// <summary>
        /// Obtiene los datos de un diagnostico cuyo id es pasado como parametro
        /// </summary>
        /// <param name="idDiagnostico">identificador del diagnostico</param>
        /// <returns>datos del diagnostico</returns>
        Diagnostico obtenDiagnostico(int idDiagnostico);

        /// <summary>
        /// Obtiene una lista de diagnosticos activos
        /// </summary>
        /// <returns>lista de diagnosticos con el campo Activo a true</returns>
        List<Diagnostico> listaDiagnosticosActivos();

        /// <summary>
        /// Obtiene una lista de diagnosticos de un estudiante
        /// </summary>
        /// <param name="idEstudiante">identificador del estudiante</param>
        /// <returns>lista de diagnosticos de un estudiante</returns>
        List<Diagnostico> listaDiagnosticosEstudiante(int idEstudiante);

        /// <summary>
        /// Elimina un diagnostico de un estudiante cuyo id ha sido pasado como parametro
        /// junto con sus adaptaciones
        /// </summary>
        /// <param name="idEstudiante">identificador del estudiante</param>
        /// <param name="idDiagnostico">identificador del diagnostico</param>
        /// <returns>true si se ha eliminado correctamente, false en caso contrario</returns>
        bool eliminaDiagnosticoEstudiante(int idEstudiante, int idDiagnostico);

    }
}
