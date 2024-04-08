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

        public List<Documento> listaDocumentosEstudiante (int idEstudiante)
        {
            return objCD.listaDocumentosEstudiante(idEstudiante);
        }

        public bool registraDocumentoEstudiante(int idEstudiante, int idDocumennto, string rutaDocumento)
        {
            return objCD.registraDocumentoEstudiante(idEstudiante, idDocumennto, rutaDocumento);
        }
    }
}
