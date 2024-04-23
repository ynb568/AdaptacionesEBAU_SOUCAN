using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Adaptaciones
    {
        private CD_Adaptaciones objCD = new CD_Adaptaciones();

        /*
         * Obtiene una lista de todas las adaptaciones existentes
         * 
         * @return lista de adaptaciones
        */
        public List<Adaptacion> listaAdaptaciones()
        {
            return objCD.listaAdaptaciones();
        }

        /*
         * Obtiene los datos de una adaptacion cuyo id es pasado como parametro
         * 
         * @param idAdaptacion: identificador de la adaptacion
         * @return datos de la adaptacion
        */
        public Adaptacion obtenAdaptacion(int idAdaptacion)
        {
            return objCD.obtenAdaptacion(idAdaptacion);
        }

        /*
         * Obtiene la lista de adaotaciones de un diagnostico
         * cuyo id es pasado como parámetro
         * 
         * @param idDiagnostico: identificador del diagnostico
         * @return lista de adaptaciones de un diagnostico
         *         
        */
        public List<Adaptacion> listaAdaptacionesDiagnostico(int idDiagnostico)
        {
            return objCD.listaAdaptacionesDiagnostico(idDiagnostico);
        }
        /*
         * Obtiene la lista de adaptaciones activas de un diagnostico
         * cuyo id es pasado como parámetro
         * 
         * @param idDiagnostico: identificador del diagnostico
         * @return lista de adaptaciones activas de un diagnostico
         *         
        */
        public List<Adaptacion> listaAdaptacionesDiagnosticoActivas(int idDiagnostico)
        {
            List<Adaptacion> adaptaciones = objCD.listaAdaptacionesDiagnostico(idDiagnostico);
            List<Adaptacion> adaptacionesActivas = new List<Adaptacion>();

            adaptacionesActivas = adaptaciones
                .Where(a => a.Activo)
                .ToList();

            return adaptacionesActivas;
        }
    }
}
