using CapaDatos;
using CapaEntidad;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Sedes : ICN_Sedes
    {
        private CD_Sedes objCD = new CD_Sedes();

        public List<Sede> listaSedes ()
        {
            return objCD.listaSedes();
        }

        public List<Sede> listaSedesActivas ()
        {
            List<Sede> sedes = objCD.listaSedes();
            List<Sede> sedesActivas = new List<Sede>();

            sedesActivas = sedes
                .Where(s => s.Activo)
                .ToList();

            return sedesActivas;
        }
    }
}
