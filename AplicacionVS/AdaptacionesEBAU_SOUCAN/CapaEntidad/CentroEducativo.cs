﻿using System.Collections.Generic;

namespace CapaEntidad
{
    public class CentroEducativo : Usuario
    {
        public CentroEducativo(string correo, string contrasenha) : base(correo, contrasenha)
        {
        }
		public string NombreCE {  get; set; }

		public Sede Sede { get; set; }
		public string TelefonoCE { get; set; }
		public string NombreOrientador { get; set; }
		public string ApellidosOrientador { get; set; }
		public string TelefonoOrientador { get; set; }
		public string CorreoOrientador { get; set; }
		public string NombreEquipoDirectivo { get; set; }
		public string ApellidosEquipoDirectivo { get; set; }
		public string TelefonoEquipoDirectivo { get; set; }
		public Direccion Direccion { get; set; }

		public List<Estudiante> Estudiantes { get; set; }
    }
}
