using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CapaEntidad
{
    public class Estudiante
    {
		public int IdEstudiante { get; set; }
        [DisplayName("DNI/NIE/Pasaporte:")]
        public string DniEstudiante { get; set; }
		[DisplayName("Nombre Estudiante:")]
		public string NombreEstudiante { get; set; }
		[DisplayName("Primer Apellido Estudiante:")]
		public string Ap1Estudiante { get; set; }
		[DisplayName("Segundo Apellido Estudiante:")]
		public string Ap2Estudiante { get;set; }
		[DisplayName("Nombre Completo Primer Tutor:")]
		public string NombreCompletoTutor1 { get; set; }
		[DisplayName("Teléfono Primer Tutor:")]
		public string TelefonoTutor1 { get; set; }
		[DisplayName("Nombre Completo Segundo Tutor (Opcional):")]
        public string NombreCompletoTutor2 { get; set; }
		[DisplayName("Teléfono Segundo Tutor (Opcional):")]
        public string TelefonoTutor2 { get; set; }
		public bool? Validado { get; set; } // Nullable
        public bool Ordinaria { get; set; }
		public bool ExtraOrdinaria { get; set; }
		[DisplayName("Curso Convocatoria:")]
		public string CursoConvocatoria { get; set; }
		[DisplayName("Observaciones:")]
		public string Observaciones { get; set; }
		public DateTime FechaRegistro { get; set; }

		public List<Diagnostico> Diagnosticos { get; set; }
		//public List<AdaptacionDiagnosticoEstudiante> AdaptacionesDE { get; set; }
        public List<Asignatura> AsignaturasPrevistas { get; set; }
        public List<Asignatura> AsignaturasMatriculadas { get; set; }
		public List<Apunte> Apuntes { get; set; } 
		public List<Documento> Documentos {  get; set; } 



    }
}
