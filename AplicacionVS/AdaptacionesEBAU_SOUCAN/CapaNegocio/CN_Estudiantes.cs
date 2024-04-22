using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Estudiantes
    {
        private CD_Estudiantes objCD = new CD_Estudiantes();

        /*
         * Obtiene una lista de todos los estudiantes de un centro
         * cuyo id es pasado como parametro
         * 
         * @param idCentro: identificador del centro
         * @return lista de estudiantes de un centro
         */
        public List<Estudiante> listaEstudiantes(int idCentro)
        {
            return objCD.listaEstudiantes(idCentro);
        }

        /*
         * Obtiene los datos de un estudiante cuyo id es pasado como parametro
         * junto con el id del centro al que pertenece
         * 
         * @param idEstudiante: identificador del estudiante
         * @param idCentro: identificador del centro
         * @return datos del estudiante
         */
        public Estudiante obtenEstudianteCentro(int idCentro, int idEstudiante)
        {
            return objCD.obtenEstudianteCentro(idCentro, idEstudiante);
        }

        /*
         * Registra un estudiante junto con sus datos
         * 
         * @param dniEstudiante: dni del estudiante
         * @param nombreEstudiante: nombre del estudiante
         * @param ap1Estudiante: primer apellido del estudiante
         * @param ap2Estudiante: segundo apellido del estudiante
         * @param nombreCompletoT1: nombre completo del tutor 1
         * @param telefonoT1: telefono del tutor 1
         * @param nombreCompletoT2: nombre completo del tutor 2
         * @param telefonoT2: telefono del tutor 2
         * @param ordinaria: convocatoria ordinaria
         * @param extraordinaria: convocatoria extraordinaria
         * @param idCE: identificador del centro
         * @param observaciones: observaciones del estudiante
         * @return true si se ha insertado correctamente, false en caso contrario
        */
        public bool registraEstudiante(string dniEstudiante, string nombreEstudiante, string ap1Estudiante, string ap2Estudiante,
            string nombreCompletoT1, string telefonoT1, string nombreCompletoT2, string telefonoT2,
            bool ordinaria, bool extraordinaria, int idCE, string observaciones)
        {
            return objCD.registraEstudiante(dniEstudiante, nombreEstudiante, ap1Estudiante, ap2Estudiante,
                nombreCompletoT1, telefonoT1, nombreCompletoT2, telefonoT2,
                ordinaria, extraordinaria, idCE, observaciones);
        }

        /*
         * Modifica los datos de un estudiante cuyo id es pasado como parametro
         * 
         * @param idE: identificador del estudiante
         * @param ordinaria: convocatoria ordinaria
         * @param extraordinaria: convocatoria extraordinaria
         * @param observaciones: observaciones del estudiante
         * @return true si se ha modificado correctamente, false en caso contrario
         * @throws ArgumentException si el id del estudiante es 0 o si la convocatoria es incorrecta
         */
        public bool modificaDatosEstudiante(int idE, bool ordinaria, bool extraordinaria, string observaciones)
        {
            if (idE == 0)
                throw new ArgumentException("El id del estudiante no puede ser 0.");
            if (ordinaria == false && extraordinaria == false)
                throw new ArgumentException("El estudiante debe tener al menos una convocatoria.");
            if (ordinaria == true && extraordinaria == true)
                throw new ArgumentException("El estudiante no puede tener ambas convocatorias.");

            return objCD.modificaDatosEstudiante(idE, ordinaria, extraordinaria, observaciones);
        }
    }
}
