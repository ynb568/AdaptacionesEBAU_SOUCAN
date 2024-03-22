using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Apuntes
    {
        private CD_Apuntes objCD = new CD_Apuntes();

        /*
         * Obtiene una lista de todos los apuntes de un estudiante
         * 
         * @param idEstudiante: estudiante del que se quiere obtener la lista
         * @return lista de apuntes de un estudiante
         */
        public List<Apunte> listaApuntesEstudiante (int idEstudiante)
        {
            return objCD.listaApuntesEstudiante(idEstudiante);
        }
    }
}
