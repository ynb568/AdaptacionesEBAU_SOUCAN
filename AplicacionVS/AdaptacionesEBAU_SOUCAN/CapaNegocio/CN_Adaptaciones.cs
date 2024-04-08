using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Adaptaciones
    {
        private CD_Adaptaciones objCD = new CD_Adaptaciones();

        public List<Adaptacion> listaAdaptaciones()
        {
            return objCD.listaAdaptaciones();
        }

        public List<Adaptacion> listaAdaptacionesDiagnostico(int idDiagnostico)
        {
            return objCD.listaAdaptacionesDiagnostico(idDiagnostico);
        }

        public List<Adaptacion> listaAdaptacionesDiagnosticoActivas (int idDiagnostico) {
            List<Adaptacion> adaptaciones = objCD.listaAdaptacionesDiagnostico(idDiagnostico);
            List<Adaptacion> adaptacionesActivas = new List<Adaptacion>();

            adaptacionesActivas = adaptaciones
                .Where(a => a.Activo)
                .ToList();

            return adaptacionesActivas;
        }

        public List<Adaptacion> listaAdaptacionesDiagnosticoEstudiante(int idEstudiante, int idDiagnostico)
        {
            return objCD.listaAdaptacionesDiagnosticoEstudiante(idEstudiante, idDiagnostico);
        }

        public bool registraAdaptacionDiagnosticoEstudiante(int idEestudiante, int idDiagnostico, int idAdaptacion, string observaciones)
        {
            return objCD.registraAdaptacionDiagnosticoEstudiante(idEestudiante, idDiagnostico, idAdaptacion, observaciones);
        }
    }
}
