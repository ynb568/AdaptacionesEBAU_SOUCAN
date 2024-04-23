using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaPresentacion.ViewModels
{
    public class AdaptacionDiagnosticoViewModel
    {
        public int DiagnosticoId { get; set; }
        public AdaptacionDiagnosticoEstudiante AdaptacionDiagnosticoEstudiante { get; set; }
    }
}