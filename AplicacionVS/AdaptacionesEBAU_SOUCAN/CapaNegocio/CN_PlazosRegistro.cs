using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_PlazosRegistro
    {
        CD_PlazosRegistro objCD = new CD_PlazosRegistro();
        /*
         * Obtiene el plazo de registro activo actual
         * 
         * @return plazo de registro activo
        */
        /// <summary>
        /// asdfghjklñ
        /// </summary>
        /// <returns></returns>
        public PlazosRegistro obtenPlazoRegistroActivo()
        {
            return objCD.obtenPlazoRegistroActivo();
        }
    }
}
