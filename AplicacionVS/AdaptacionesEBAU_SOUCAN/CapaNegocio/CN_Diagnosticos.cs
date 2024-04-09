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

        public List<Diagnostico> listaDiagnosticosActivos()
        {
            List<Diagnostico> diagnosticos = objCD.listaDiagnosticos();
            List<Diagnostico> diagnosticosActivos;

            diagnosticosActivos = diagnosticos.
                Where(d => d.Activo)
                .ToList();

            return diagnosticosActivos;
        }

        public bool eliminaDiagnosticoEstudiante(int idEstudiante, int idDiagnostico) 
        { 
            return objCD.eliminaDiagnosticoEstudiante(idEstudiante, idDiagnostico); 
        }



    }
}
