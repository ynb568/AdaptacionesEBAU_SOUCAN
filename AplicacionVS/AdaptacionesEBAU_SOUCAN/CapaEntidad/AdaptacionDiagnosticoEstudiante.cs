using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class AdaptacionDiagnosticoEstudiante
    {
        public Adaptacion Adaptacion { get; set; }
        public bool? Validado { get; set; }
        public string Observaciones { get; set; }
        public string Revision { get; set; }
    }
}
