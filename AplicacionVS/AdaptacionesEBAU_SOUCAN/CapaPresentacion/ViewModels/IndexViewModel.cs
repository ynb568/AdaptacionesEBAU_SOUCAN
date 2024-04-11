using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaPresentacion.ViewModels
{
    public class IndexViewModel
    {
        public List<Estudiante> Estudiantes { get; set; }
        public int i { get; set; }
    }
}