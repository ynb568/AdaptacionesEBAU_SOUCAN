using System;
using System.ComponentModel;

namespace CapaEntidad
{
    public class PlazosRegistro
    {
        public int IdPlazo {  get; set; }
        public bool Activo { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        [DisplayName("Curso de la Convocatoria: ")]
        public string CursoConvocatoria { get; set; }  
    }
}