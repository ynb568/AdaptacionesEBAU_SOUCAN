using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_AdaptacionesDiagnosticoEstudiante
    {
        private CD_AdaptacionesDiagnosticoEstudiante objCD = new CD_AdaptacionesDiagnosticoEstudiante();

        /*
         * Obtiene una lista de todas las adaptaciones de un diagnostico de un estudiante
         * 
         * @param idEstudiante: identificador del estudiante
         * @param idDiagnostico: identificador del diagnostico
         * @return lista de adaptaciones de un diagnostico de un estudiante
        */
        public List<AdaptacionDiagnosticoEstudiante> listaAdaptacionesDiagnosticoEstudiante(int idEstudiante, int idDiagnostico)
        {
            return objCD.listaAdaptacionesDiagnosticoEstudiante(idEstudiante, idDiagnostico);
        }

        /*
         * Inserta una adaptacion de un diagnostico de un estudiante junto con sus observaciones
         * 
         * @param idEestudiante: identificador del estudiante
         * @param idDiagnostico: identificador del diagnostico
         * @param idAdaptacion: identificador de la adaptacion
         * @param observaciones: string de observaciones de la adaptacion
         * 
         * @return true si se ha insertado correctamente, false en caso contrario
        */
        public bool registraAdaptacionDiagnosticoEstudiante(int idEestudiante, int idDiagnostico, int idAdaptacion, string observaciones)
        {
            return objCD.registraAdaptacionDiagnosticoEstudiante(idEestudiante, idDiagnostico, idAdaptacion, observaciones);
        }
    }
}
