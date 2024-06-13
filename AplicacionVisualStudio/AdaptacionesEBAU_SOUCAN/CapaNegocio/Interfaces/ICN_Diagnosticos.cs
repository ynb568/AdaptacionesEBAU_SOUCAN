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
        /// Obtiene una lista de todos los diagnosticos.
        /// </summary>
        /// <returns>Lista de diagnosticos.</returns>
        List<Diagnostico> listaDiagnosticos();

        /// <summary>
        /// Obtiene los datos de un diagnostico cuyo id es pasado como parametro.
        /// </summary>
        /// <param name="idDiagnostico">Identificador del diagnostico.</param>
        /// <returns>Datos del diagnostico.</returns>
        Diagnostico obtenDiagnostico(int idDiagnostico);

        /// <summary>
        /// Obtiene una lista de diagnosticos activos.
        /// </summary>
        /// <returns>Lista de diagnosticos con el campo Activo a true.</returns>
        List<Diagnostico> listaDiagnosticosActivos();

        /// <summary>
        /// Obtiene una lista de diagnosticos de un estudiante.
        /// </summary>
        /// <param name="idEstudiante">Identificador del estudiante.</param>
        /// <returns>Lista de diagnosticos de un estudiante.</returns>
        List<Diagnostico> listaDiagnosticosEstudiante(int idEstudiante);

        /// <summary>
        /// Elimina los diagnosticos de un estudiante cuyo id ha sido pasado como parametro
        /// junto con sus adaptaciones.
        /// </summary>
        /// <param name="idEstudiante">Identificador del estudiante.</param>
        /// <returns>True si se ha eliminado correctamente, false en caso contrario.</returns>
        bool eliminaDiagnosticosEstudiante(int idEstudiante);

    }
}
