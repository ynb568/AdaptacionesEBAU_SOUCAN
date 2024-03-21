using System;

namespace CapaEntidad
{
    public class PlazosRegistro
    {
        public int IdPlazo {  get; set; }
        public bool Activo { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public string CursoConvocatoria { get; set; }  
    }
}