using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ICN_PlazosRegistro
    {
        /// <summary>
        /// Obtiene el plazo de registro activo actual
        /// </summary>
        /// <returns>plazo de registro activo</returns>
        PlazosRegistro obtenPlazoRegistroActivo();
    }
}
