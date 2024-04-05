using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class Estudiante
    {
		public int IdEstudiante { get; set; }
		public string DniEstudiante { get; set; }
		public string NombreEstudiante { get; set; }
		public string Ap1Estudiante { get; set; }
		public string Ap2Estudiante { get;set; }
		public string NombreCompletoTutor1 { get; set; }
		public string TelefonoTutor1 { get; set; }
        public string NombreCompletoTutor2 { get; set; }
        public string TelefonoTutor2 { get; set; }
		//public CentroEducativo Centro { get; set; }


		public bool? Validado { get; set; } // Nullable
        public bool Ordinaria { get; set; }
		public bool ExtraOrdinaria { get; set; }
		public string CursoConvocatoria { get; set; }
		public string Observaciones { get; set; }
		public DateTime FechaRegistro { get; set; }

		public List<Diagnostico> Diagnosticos { get; set; }
		public List<Adaptacion> Adaptaciones { get; set; }
        public List<Asignatura> AsignaturasPrevistas { get; set; }
        public List<Asignatura> AsignaturasMatriculadas { get; set; }
		public List<Apunte> Apuntes { get; set; } 
		public List<Documento> Documentos {  get; set; } 



    }
}
