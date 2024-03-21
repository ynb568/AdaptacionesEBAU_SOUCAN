﻿using System.Collections.Generic;

namespace CapaEntidad
{
    public class Diagnostico
    {
        public int IdDiagnostico { get; set; }
        public string NombreDiagnostico { get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }
        public List<Adaptacion> Adaptaciones { get; set; }
    }
}
