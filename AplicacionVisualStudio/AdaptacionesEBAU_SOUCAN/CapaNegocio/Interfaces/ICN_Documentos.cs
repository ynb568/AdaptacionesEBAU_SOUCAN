﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ICN_Documentos
    {
        /// <summary>
        /// Obtiene una lista de todos los documentos.
        /// </summary>
        /// <returns>lista de documentos.</returns>
        List<Documento> listaDocumentos();

        /// <summary>
        /// Obtiene una lista de los documentos de un estudiante cuyo id
        /// es pasado como parámetro.
        /// </summary>
        /// <param name="idEstudiante">Identificador del estudiante.</param>
        /// <returns>Lista de documentos de un estudiante.</returns>
        List<Documento> listaDocumentosEstudiante(int idEstudiante);

        /// <summary>
        /// Registra un documento de un estudiante junto con su ruta de acceso.
        /// </summary>
        /// <param name="idEstudiante">Identificador del estudiante.</param>
        /// <param name="idDocumennto">Identificador del documento.</param>
        /// <param name="rutaDocumento">True si se ha insertado correctamente, false en caso contrario.</param>
        /// <returns>True si se ha registrado correctamente, false en caso contrario.</returns>
        bool registraDocumentoEstudiante(int idEstudiante, int idDocumennto, string rutaDocumento);
        /// <summary>
        /// Elimina un documento de un estudiante cuyo id es pasado como parametro.
        /// </summary>
        /// <param name="idEstudiante">Identificador del estudiante.</param>
        /// <returns>True si se ha eliminado correctamente, false en caso contrario.</returns>
        bool eliminaDocumentosEstudiante(int idEstudiante);
    }
}
