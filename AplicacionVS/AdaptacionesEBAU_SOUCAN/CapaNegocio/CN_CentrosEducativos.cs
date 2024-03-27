using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    //FILTRADO DE DATOS
    public class CN_CentrosEducativos
    {
        private CD_CentrosEducativos objCD = new CD_CentrosEducativos();

        public List<CentroEducativo> listaCentros()
        {
            
            return objCD.listaCentros();
        }

        public CentroEducativo obtenCentro (int idCentroEducativo)
        {
            return objCD.obtenCentro(idCentroEducativo);
        }

    }
}
