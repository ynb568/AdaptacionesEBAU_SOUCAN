using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ICN_Municipios
    {
        /// <summary>
        /// Obtiene una lista de todos los municipios
        /// </summary>
        /// <returns>lista de municipios</returns>
        List<Municipio> listaMunicipios();
    }
}
