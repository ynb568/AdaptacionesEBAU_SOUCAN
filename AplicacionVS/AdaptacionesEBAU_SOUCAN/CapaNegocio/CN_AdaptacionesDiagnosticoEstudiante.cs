using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_AdaptacionesDiagnosticoEstudiante
    {
        private CD_AdaptacionesDiagnosticoEstudiante objCD = new CD_AdaptacionesDiagnosticoEstudiante();
        public List<AdaptacionDiagnosticoEstudiante> listaAdaptacionesDiagnosticoEstudiante(int idEstudiante, int idDiagnostico)
        {
            return objCD.listaAdaptacionesDiagnosticoEstudiante(idEstudiante, idDiagnostico);
        }

        public bool registraAdaptacionDiagnosticoEstudiante(int idEestudiante, int idDiagnostico, int idAdaptacion, string observaciones)
        {
            return objCD.registraAdaptacionDiagnosticoEstudiante(idEestudiante, idDiagnostico, idAdaptacion, observaciones);
        }
    }
}
