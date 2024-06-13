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
    public class CN_Diagnosticos : ICN_Diagnosticos
    {
        private CD_Diagnosticos objCD = new CD_Diagnosticos();

        public List<Diagnostico> listaDiagnosticos()
        {
            return objCD.listaDiagnosticos();
        }

        public Diagnostico obtenDiagnostico(int idDiagnostico)
        {
            return objCD.obtenDiagnostico(idDiagnostico);
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

        public List<Diagnostico> listaDiagnosticosEstudiante(int idEstudiante)
        {
            return objCD.listaDiagnosticosEstudiante(idEstudiante);
        }

        public bool eliminaDiagnosticosEstudiante(int idEstudiante) 
        { 
            return objCD.eliminaDiagnosticosEstudiante(idEstudiante); 
        }



    }
}
