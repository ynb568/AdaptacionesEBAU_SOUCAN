using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace CapaDatos
{
    public class Conexion
    {
        //Obtiene la cadena de conexión que proviene de Web.Config
        /* Cadena de conexión con la BBDD
         * Data source = nombre del servidor
         * Initial Catalog = nombre de BBDD
         * Integrated Security = Tipo de autenticación (Windows = true)
         */
        public static string cadenaCon = ConfigurationManager.ConnectionStrings["cadena"].ToString();
    }
}
