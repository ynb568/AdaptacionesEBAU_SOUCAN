using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Documentos : ICN_Documentos
    {
        private CD_Documentos objCD = new CD_Documentos();

        public List<Documento> listaDocumentos()
        {
            return objCD.listaDocumentos();
        }

        public List<Documento> listaDocumentosEstudiante (int idEstudiante)
        {
            return objCD.listaDocumentosEstudiante(idEstudiante);
        }

        public bool registraDocumentoEstudiante(int idEstudiante, int idDocumennto, string rutaDocumento)
        {
            return objCD.registraDocumentoEstudiante(idEstudiante, idDocumennto, rutaDocumento);
        }

        public bool eliminaDocumentosEstudiante(int idEstudiante) 
        { 
            return objCD.eliminaDocumentosEstudiante(idEstudiante);
        }
    }
}
