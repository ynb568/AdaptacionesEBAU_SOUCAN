using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Diagnosticos
    {
        private CD_Diagnosticos objCD = new CD_Diagnosticos();

        public List<Diagnostico> listaDiagnosticos()
        {
            return objCD.listaDiagnosticos();
        }
    }
}
