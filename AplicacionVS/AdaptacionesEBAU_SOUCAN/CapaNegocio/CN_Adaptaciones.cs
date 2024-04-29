using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Adaptaciones : ICN_Adaptaciones
    {
        private CD_Adaptaciones objCD = new CD_Adaptaciones();

        public List<Adaptacion> listaAdaptaciones()
        {
            return objCD.listaAdaptaciones();
        }

        public Adaptacion obtenAdaptacion(int idAdaptacion)
        {
            return objCD.obtenAdaptacion(idAdaptacion);
        }

        public List<Adaptacion> listaAdaptacionesDiagnostico(int idDiagnostico)
        {
            return objCD.listaAdaptacionesDiagnostico(idDiagnostico);
        }

        public List<Adaptacion> listaAdaptacionesDiagnosticoActivas(int idDiagnostico)
        {
            List<Adaptacion> adaptaciones = objCD.listaAdaptacionesDiagnostico(idDiagnostico);
            List<Adaptacion> adaptacionesActivas = new List<Adaptacion>();

            adaptacionesActivas = adaptaciones
                .Where(a => a.Activo)
                .ToList();

            return adaptacionesActivas;
        }
    }
}
