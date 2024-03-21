using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Asignatura
    {
        public int IdAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
        public bool Activo { get; set; }
        public bool Fase1 { get; set; }
        public bool Fase2 { get; set;}

    }
}
