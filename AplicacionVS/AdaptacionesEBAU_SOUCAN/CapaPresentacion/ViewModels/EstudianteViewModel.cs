using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaPresentacion.ViewModels
{
    public class EstudianteViewModel
    {
        public CentroEducativo CE { get; set; }
        public Estudiante Estudiante { get; set; }
        public List<Diagnostico> Diagnosticos { get; set; }
        public List<Documento> Documentos { get; set; }
        public PlazosRegistro Plazos { get; set; }

    }
}