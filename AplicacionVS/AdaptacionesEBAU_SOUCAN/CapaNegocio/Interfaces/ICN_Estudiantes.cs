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
        /// cuyo identificador se pasa como parámetro.
        /// </summary>
        /// <param name="idCentro">Identificador del centro.</param>
        /// <returns>Lista de estudiantes de un centro.</returns>
        List<Estudiante> listaEstudiantes(int idCentro);

        /// <summary>
        /// Obtiene los datos de un estudiante cuyo id es pasado como parametro
        /// junto con el id del centro al que pertenece.
        /// </summary>
        /// <param name="idCentro">Identificador del estudiante.</param>
        /// <param name="idEstudiante">Identificador del centro.</param>
        /// <returns>Datos del estudiante.</returns>
        Estudiante obtenEstudianteCentro(int idCentro, int idEstudiante);

        /// <summary>
        /// Registra un estudiante junto con sus datos.
        /// </summary>
        /// <param name="dniEstudiante">DNI/NIF/NIE del estudiante.</param>
        /// <param name="nombreEstudiante">Nombre del estudiante.</param>
        /// <param name="ap1Estudiante">Primer apellido del estudiante.</param>
        /// <param name="ap2Estudiante">Segundo apellido del estudiante.</param>
        /// <param name="nombreCompletoT1">Nombre completo del tutor 1.</param>
        /// <param name="telefonoT1">Telefono del tutor 1.</param>
        /// <param name="nombreCompletoT2">Nombre completo del tutor 2.</param>
        /// <param name="telefonoT2">Telefono del tutor 2.</param>
        /// <param name="ordinaria">Convocatoria ordinaria.</param>
        /// <param name="extraordinaria">Convocatoria extraordinaria.</param>
        /// <param name="idCE">Identificador del centro.</param>
        /// <param name="observaciones">Observaciones del estudiante.</param>
        /// <returns>Dni/NIF/NIE del estudiante registrado.</returns>
        int registraEstudiante(string dniEstudiante, string nombreEstudiante, string ap1Estudiante, string ap2Estudiante,
            string nombreCompletoT1, string telefonoT1, string nombreCompletoT2, string telefonoT2,
            bool ordinaria, bool extraordinaria, int idCE, string observaciones);
        /// <summary>
        /// Modifica los datos de un estudiante cuyo id es pasado como parametro.
        /// </summary>
        /// <param name="idE">Identificador del estudiante.</param>
        /// <param name="ordinaria">Convocatoria ordinaria.</param>
        /// <param name="extraordinaria">Convocatoria extraordinaria.</param>
        /// <param name="observaciones">Observaciones del estudiante.</param>
        /// <returns>True si se ha modificado correctamente, false en caso contrario.</returns>
        /// <throws>ArgumentException si el id del estudiante es 0 o si la convocatoria es incorrecta.</throws>
        bool modificaDatosEstudiante(int idE, bool ordinaria, bool extraordinaria, string observaciones);
    }
}
