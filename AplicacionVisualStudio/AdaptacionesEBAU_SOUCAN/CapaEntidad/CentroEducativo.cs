﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad
{
    public class CentroEducativo //: Usuario
    {

		public CentroEducativo()
		{

		}
        public int IdCE { get; set; }
		[DisplayName("Correo del Centro:")]
        public string Correo { get; set; }
		public string Contrasenha { get; set; }
		public string RepetirContrasenha { get; set; }
		[DisplayName("Nombre del Centro:")]
		public string NombreCE {  get; set; }
		[DisplayName("Teléfono del Centro:")]
		public string TelefonoCE { get; set; }
		[DisplayName("Nombre:")]
		public string NombreOrientador { get; set; }
		[DisplayName("Apellidos:")]
		public string ApellidosOrientador { get; set; }
		[DisplayName("Teléfono:")]
		public string TelefonoOrientador { get; set; }
		[DisplayName("Correo:")]
		public string CorreoOrientador { get; set; }
		[DisplayName("Nombre:")]
		public string NombreEquipoDirectivo { get; set; }
		[DisplayName("Apellidos:")]
		public string ApellidosEquipoDirectivo { get; set; }
		[DisplayName("Teléfono:")]
		public string TelefonoEquipoDirectivo { get; set; }
		public DateTime FechaRegistro { get; set; }

        [DisplayName("Sede Asignada:")]
        public Sede Sede { get; set; }
        public Direccion Direccion { get; set; }

        public List<Estudiante> Estudiantes { get; set; }
    }
}
