using CapaDatos;
using CapaEntidad;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_PlazosRegistro : ICN_PlazosRegistro
    {
        CD_PlazosRegistro objCD = new CD_PlazosRegistro();

        public PlazosRegistro obtenPlazoRegistroActivo()
        {
            return objCD.obtenPlazoRegistroActivo();
        }
    }
}
