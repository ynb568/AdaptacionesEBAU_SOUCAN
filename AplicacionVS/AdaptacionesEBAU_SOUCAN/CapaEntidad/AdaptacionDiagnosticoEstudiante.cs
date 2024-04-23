using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class AdaptacionDiagnosticoEstudiante
    {
        public Adaptacion Adaptacion { get; set; }
        public bool? Validado { get; set; }
        [DisplayName("Observaciones: ")]
        public string Observaciones { get; set; }
        [DisplayName("Observaciones de revisión: ")]
        public string Revision { get; set; }
    }
}
