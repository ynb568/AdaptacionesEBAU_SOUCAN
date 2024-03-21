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
        public static string cadenaCon = ConfigurationManager.ConnectionStrings["cadena"].ToString();
    }
}
