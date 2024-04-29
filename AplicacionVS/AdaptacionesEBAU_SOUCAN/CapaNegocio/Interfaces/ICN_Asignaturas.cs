using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ICN_Asignaturas
    {
        /// <summary>
        ///  Obtiene una lista de todas las asignaturas.
        /// </summary>
        /// <returns>Lista de asignaturas completa</returns>
        List<Asignatura> listaAsignaturas();

        /// <summary>
        /// Obtiene una lista de todas las asignaturas activas.
        /// </summary>
        /// <returns>Lista de asignaturas activas</returns>
        List<Asignatura> listaAsignaturasActivas();

        /// <summary>
        /// Obtiene una lista de asignaturas activas filtradas por fase.
        /// </summary>
        /// <param name="fase">El número de fase a filtrar. Debe ser 1 o 2.</param>
        /// <returns>Lista de asignaturas de fase indicada.</returns>
        /// <throws>ArgumentException Se lanza si la fase proporcionada no es 1 ni 2.</throws>
        List<Asignatura> listaAsignaturasPorFase(int fase);

        /// <summary>
        /// Obtiene una lista de todas las asignaturas previstas de un estudiante 
        /// cuyo id se pasa como parámetro.
        /// </summary>
        /// <param name="idEstudiante">identificador del estudiante</param>
        /// <returns>lista de asignaturas previstas de un estudiante</returns>
        List<Asignatura> listaAsignaturasPrevistasEstudiante(int idEstudiante);

        /// <summary>
        /// Obtiene una lista de asignaturas previstas de un estudiante filtradas por fase.
        /// </summary>
        /// <param name="idEstudiante">identificador del estudiante</param>
        /// <param name="fase">El número de fase a filtrar. Debe ser 1 o 2.</param>
        /// <returns>Lista de asignaturas previstas de fase indicada.</returns>
        /// <throws>ArgumentException Se lanza si la fase proporcionada no es 1 ni 2.</throws>
        List<Asignatura> listaAsignaturasPrevistasEstudiantePorFase(int idEstudiante, int fase);

        /// <summary>
        /// Obtiene una lista de todas las asignaturas matriculadas de un estudiante 
        /// cuyo id se pasa como parámetro.
        /// </summary>
        /// <param name="idEstudiante">identificador del estudiante</param>
        /// <returns>lista de asignaturas matriculadas de un estudiante</returns>
        List<Asignatura> listaAsignaturasMatriculadasEstudiante(int idEstudiante);


        /// <summary>
        /// Registra una asignatura prevista de un estudiante en las fases que sean indicadas
        /// </summary>
        /// <param name="idEstudiante">identificador del estudiante</param>
        /// <param name="idAsignatura">identificador de la asignatura</param>
        /// <param name="fase1">booleano que indica si se quiere registrar asigatura en la fase 1</param>
        /// <param name="fase2">booleano que indica si se quiere registrar asigatura en la fase 2</param>
        /// <returns>true si se ha insertado correctamente, false en caso contrario</returns>
        bool registraAsignaturaPrevistaEstudiante(int idEstudiante, int idAsignatura, bool fase1, bool fase2);

        /// <summary>
        /// Elimina las asignaturas prevista de un estudiante 
        /// cuyo id se pasa como parámetro.
        /// </summary>
        /// <param name="idEstudiante">identificador del estudiante</param>
        /// <returns>true si se ha eliminado correctamente, false en caso contrario</returns>
        bool eliminaAsignaturasPrevistasEstudiante(int idEstudiante);
    }
}
