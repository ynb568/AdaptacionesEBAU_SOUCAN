using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace CapaEntidad
{
    public class Estudiante
    {
		public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "El DNI/NIE/Pasaporte es obligatorio.")]
        [DisplayName("DNI/NIE/Pasaporte:")]
        public string DniEstudiante { get; set; }
        [Required(ErrorMessage = "El nombre del estudiante es obligatorio.")]
		[DisplayName("Nombre Estudiante:")]
		public string NombreEstudiante { get; set; }
        [Required(ErrorMessage = "El primer apellido del estudiante es obligatorio.")]
		[DisplayName("Primer Apellido Estudiante:")]
		public string Ap1Estudiante { get; set; }
		[DisplayName("Segundo Apellido Estudiante:")]
		public string Ap2Estudiante { get;set; }
        //Propiedad para mostrar el nombre completo del estudiante en la vista
		[DisplayName("Nombre Completo:")]
        public string NombreCompleto
        {
            get
            {
                return $"{NombreEstudiante} {Ap1Estudiante} {Ap2Estudiante}";
            }
        }
        //Propiedad para mostrar la convocatoria en la vista
        [DisplayName("Convocatoria:")]
        public string Convocatoria
        {
            get
            {
                return Ordinaria == true && ExtraOrdinaria == false ? "Ordinaria" : "Extraordinaria";
            }
        }

        [Required(ErrorMessage = "El nombre del tutor 1 es obligatorio.")]
        [DisplayName("Nombre Completo Primer Tutor:")]
		public string NombreCompletoTutor1 { get; set; }
        [Required(ErrorMessage = "El teléfono del tutor 1 es obligatorio.")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "El número de teléfono debe tener exactamente 9 dígitos.")]
        [DisplayName("Teléfono Primer Tutor:")]
		public string TelefonoTutor1 { get; set; }
		[DisplayName("Nombre Completo Segundo Tutor (Opcional):")]
        public string NombreCompletoTutor2 { get; set; }
        
        [RegularExpression(@"^([0-9]{9})?$", ErrorMessage = "El número de teléfono debe tener exactamente 9 dígitos.")]
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
        public List<Asignatura> AsignaturasPrevistas { get; set; }
        public List<Asignatura> AsignaturasMatriculadas { get; set; }
		public List<Apunte> Apuntes { get; set; } 
		public List<Documento> Documentos {  get; set; } 



    }
}
