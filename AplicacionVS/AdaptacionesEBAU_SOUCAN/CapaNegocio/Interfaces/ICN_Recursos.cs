using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ICN_Recursos
    {
        /// <summary>
        /// Método que encripta un texto utilizando el algoritmo SHA256.
        /// </summary>
        /// <param name="c_base">Texto a encriptar.</param>
        /// <returns>Cadena de texto encriptada en formato hexadecimal.</returns>
        string convertirSha256(string c_base);

        /// <summary>
        /// Método que convierte un archivo a base 64.
        /// </summary>
        /// <param name="rutaDocumento">Ruta del documento a transformar.</param>
        /// <returns>Archivo en binario.</returns>
        string ConvertirArchivoABinario(string rutaDocumento);
    }
}
