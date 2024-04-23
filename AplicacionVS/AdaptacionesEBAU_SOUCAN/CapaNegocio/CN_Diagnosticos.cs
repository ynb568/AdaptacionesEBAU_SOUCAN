using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Diagnosticos
    {
        private CD_Diagnosticos objCD = new CD_Diagnosticos();

        /*
         * Obtiene una lista de todos los diagnosticos
         * 
         * @return lista de diagnosticos
        */
        public List<Diagnostico> listaDiagnosticos()
        {
            return objCD.listaDiagnosticos();
        }

        /*
         * Obtiene los datos de un diagnostico cuyo id es pasado como parametro
         * 
         * @param idDiagnostico: identificador del diagnostico
         * @return datos del diagnostico
        */
        public Diagnostico obtenDiagnostico(int idDiagnostico)
        {
            return objCD.obtenDiagnostico(idDiagnostico);
        }

        /*
         * Obtiene una lista de diagnosticos activos
         * 
         * @return lista de diagnosticos con el campo Activo a true
        */
        public List<Diagnostico> listaDiagnosticosActivos()
        {
            List<Diagnostico> diagnosticos = objCD.listaDiagnosticos();
            List<Diagnostico> diagnosticosActivos;

            diagnosticosActivos = diagnosticos.
                Where(d => d.Activo)
                .ToList();

            return diagnosticosActivos;
        }
        /*
         * Obtiene una lista de diagnosticos de un estudiante
         * 
         * @param idEstudiante: identificador del estudiante
         * @return lista de diagnosticos de un estudiante
         */
        public List<Diagnostico> listaDiagnosticosEstudiante(int idEstudiante)
        {
            return objCD.listaDiagnosticosEstudiante(idEstudiante);
        }

        /*
         * Elimina un diagnostico de un estudiante cuyo id ha 
         * sido pasado por parámetro junto con sus adaptaciones 
         * 
         * @param idEstudiante: identificador del estudiante
         * @param idDiagnostico: identificador del diagnostico
         * @return true si se ha eliminado correctamente, false en caso contrario
         */
        public bool eliminaDiagnosticoEstudiante(int idEstudiante, int idDiagnostico) 
        { 
            return objCD.eliminaDiagnosticoEstudiante(idEstudiante, idDiagnostico); 
        }



    }
}
