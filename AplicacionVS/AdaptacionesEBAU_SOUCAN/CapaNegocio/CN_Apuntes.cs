using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Apuntes : ICN_Apuntes
    {
        private CD_Apuntes objCD = new CD_Apuntes();

        public List<Apunte> listaApuntesEstudiante (int idEstudiante)
        {
            return objCD.listaApuntesEstudiante(idEstudiante);
        }
    }
}
