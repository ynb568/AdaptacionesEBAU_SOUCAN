using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Municipios
    {
        private CD_Municipios objCD = new CD_Municipios();
        
        /*
         * Obtiene una lista de todos los municipios
         * 
         * @return lista de municipios
        */
        public List<Municipio> listaMunicipios ()
        {
            return objCD.listaMunicipios ();
        }
    }
}
