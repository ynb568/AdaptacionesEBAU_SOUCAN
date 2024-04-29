using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ICN_Estudiantes
    {
        /// <summary>
        /// Obtiene una lista de todos los estudiantes de un centro
        /// cuyo identificador se pasa como parámetro
        /// </summary>
        /// <param name="idCentro">identificador del centro</param>
        /// <returns>lista de estudiantes de un centro</returns>
        List<Estudiante> listaEstudiantes(int idCentro);

        /// <summary>
        /// Obtiene los datos de un estudiante cuyo id es pasado como parametro
        /// junto con el id del centro al que pertenece
        /// </summary>
        /// <param name="idCentro">identificador del estudiante</param>
        /// <param name="idEstudiante">identificador del centro</param>
        /// <returns>datos del estudiante</returns>
        Estudiante obtenEstudianteCentro(int idCentro, int idEstudiante);

        /// <summary>
        /// Registra un estudiante junto con sus datos
        /// </summary>
        /// <param name="dniEstudiante">dni del estudiante</param>
        /// <param name="nombreEstudiante">nombre del estudiante</param>
        /// <param name="ap1Estudiante">primer apellido del estudiante</param>
        /// <param name="ap2Estudiante">segundo apellido del estudiante</param>
        /// <param name="nombreCompletoT1">nombre completo del tutor 1</param>
        /// <param name="telefonoT1">telefono del tutor 1</param>
        /// <param name="nombreCompletoT2">nombre completo del tutor 2</param>
        /// <param name="telefonoT2">telefono del tutor 2</param>
        /// <param name="ordinaria">convocatoria ordinaria</param>
        /// <param name="extraordinaria">convocatoria extraordinaria</param>
        /// <param name="idCE">identificador del centro</param>
        /// <param name="observaciones">observaciones del estudiante</param>
        /// <returns>true si se ha insertado correctamente, false en caso contrario</returns>
        bool registraEstudiante(string dniEstudiante, string nombreEstudiante, string ap1Estudiante, string ap2Estudiante,
            string nombreCompletoT1, string telefonoT1, string nombreCompletoT2, string telefonoT2,
            bool ordinaria, bool extraordinaria, int idCE, string observaciones);
        /// <summary>
        /// Modifica los datos de un estudiante cuyo id es pasado como parametro
        /// </summary>
        /// <param name="idE">identificador del estudiante</param>
        /// <param name="ordinaria">convocatoria ordinaria</param>
        /// <param name="extraordinaria">convocatoria extraordinaria</param>
        /// <param name="observaciones">observaciones del estudiante</param>
        /// <returns>true si se ha modificado correctamente, false en caso contrario</returns>
        /// <throws>ArgumentException si el id del estudiante es 0 o si la convocatoria es incorrecta</throws>
        bool modificaDatosEstudiante(int idE, bool ordinaria, bool extraordinaria, string observaciones);
    }
}
