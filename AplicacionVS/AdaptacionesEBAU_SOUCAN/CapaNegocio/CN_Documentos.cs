using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Documentos
    {
        private CD_Documentos objCD = new CD_Documentos();

        /*
         * Obtiene una lista de todos los documentos
         * 
         * @return lista de documentos
         */
        public List<Documento> listaDocumentos()
        {
            return objCD.listaDocumentos();
        }

        /*
         * Obtiene una lista de los documentos de un estudiante cuyo id 
         * es pasado como parametro
         * 
         * @param idEstudiante: identificador del estudiante
         * @return lista de documentos de un estudiante
        */
        public List<Documento> listaDocumentosEstudiante (int idEstudiante)
        {
            return objCD.listaDocumentosEstudiante(idEstudiante);
        }

        /*
         * Registra un documento de un estudiante junto con su ruta de acceso
         * 
         * @param idEstudiante: identificador del estudiante
         * @param idDocumennto: identificador del documento
         * @param rutaDocumento: ruta de acceso al documento
         * @return true si se ha insertado correctamente, false en caso contrario
        */
        public bool registraDocumentoEstudiante(int idEstudiante, int idDocumennto, string rutaDocumento)
        {
            return objCD.registraDocumentoEstudiante(idEstudiante, idDocumennto, rutaDocumento);
        }

        /*
         * Elimina un documento de un estudiante cuyo id es pasado como parametro
         * 
         * @param idEstudiante: identificador del estudiante
         * @param idDocumento: identificador del documento
         * @return true si se ha eliminado correctamente, false en caso contrario
        */
        public bool eliminaDocumentosEstudiante(int idEstudiante) 
        { 
            return objCD.eliminaDocumentosEstudiante(idEstudiante);
        }
    }
}
