using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaPresentacion.ViewModels
{
    public class EstudianteViewModel
    {
        public PlazosRegistro PlazoRegistroActivo { get; set; }
        public CentroEducativo CE { get; set; }
        public Estudiante Estudiante { get; set; }
        public List<Asignatura> AsignaturasFase1 { get; set; }
        public List<Asignatura> AsignaturasFase2 { get; set; }
        public List<Diagnostico> Diagnosticos { get; set; }
        public int? SelectedDiagnostico { get; set; }
        public List<Adaptacion> Adaptaciones { get; set; }
        public List<AdaptacionDiagnosticoEstudiante> AdaptacionDiagnosticoEstudiantes { get; set; }
        public PlazosRegistro Plazos { get; set; }
        public bool isOrdinaria { get; set; } = true;
        public List<FileUploadViewModel> Documentos { get; set; }
        public List<AdaptacionDiagnosticoViewModel> SelectedAdaptaciones { get; set; }

    }
}