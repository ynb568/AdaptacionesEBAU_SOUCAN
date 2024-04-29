using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public interface ICN_Apuntes
    {
        /// <summary>
        /// Obtiene una lista de todos los apuntes de un estudiante
        /// </summary>
        /// <param name="idEstudiante">identificador del estudiante</param>
        /// <returns>lista de apuntes de un estudiante</returns>
        List<Apunte> listaApuntesEstudiante(int idEstudiante);
    }
}
