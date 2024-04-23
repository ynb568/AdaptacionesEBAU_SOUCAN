using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Sedes
    {
        private CD_Sedes objCD = new CD_Sedes();

        /*
         * Obtiene la lista de todas las sedes
         * 
         * @return Lista de sedes completa
         */
        public List<Sede> listaSedes ()
        {
            return objCD.listaSedes();
        }

        /*
         * Obtiene la lista de todas las sedes activas
         * 
         * @return Lista de sedes activas
         */
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
