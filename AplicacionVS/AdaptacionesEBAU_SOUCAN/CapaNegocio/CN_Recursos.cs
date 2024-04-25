using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace CapaNegocio
{
    public class CN_Recursos
    {
        /*
         * Método que encripta un texto utilizando el algoritmo SHA256.
         * 
         * @param c_base: Texto a encriptar.
         * @return: Cadena de texto encriptada en formato hexadecimal.
        */
        public static string convertirSha256 (string c_base)
        {
            StringBuilder sb = new StringBuilder ();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] c_result = hash.ComputeHash(enc.GetBytes (c_base));

                foreach (byte b in c_result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString ();
        }

        public static string ConvertirArchivoABinario(string rutaDocumento)
        {
            byte[] binaryData = File.ReadAllBytes(rutaDocumento);
            return Convert.ToBase64String(binaryData);
        }
    }
}
