using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasConsola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ASIGNATURAS
            // Crear una instancia de la clase de lógica de negocio
            CN_Asignaturas cnAsignaturas = new CN_Asignaturas();

            // Llamar al método listaAsignaturas() para obtener la lista de asignaturas
            List<Asignatura> asignaturas = cnAsignaturas.listaAsignaturas();

            // Imprimir los datos en la consola
            foreach (var a in asignaturas)
            {
                Console.WriteLine($"ID: {a.IdAsignatura}, Nombre: {a.NombreAsignatura}, Activo: {a.Activo}, Fase1: {a.Fase1}, Fase2: {a.Fase2}");
            }

            //ADAPTACIONES
            CN_Adaptaciones cnAdaptaciones = new CN_Adaptaciones();

            List<Adaptacion> adaptaciones = cnAdaptaciones.listaAdaptaciones();

            foreach (var a in adaptaciones)
            {
                Console.WriteLine($"ID: {a.IdAdaptacion}, Nombre: {a.NombreAdaptacion}, Descripcion: {a.Descripcion}, Activo: {a.Activo}");
            }

            //CENTROS EDUCATIVOS
            CN_CentrosEducativos cnCentros = new CN_CentrosEducativos();

            List<CentroEducativo> centros = cnCentros.listaCentros();

            foreach (var ce in centros)
            {
                Console.WriteLine($"ID: {ce.IdUsuario}, correo: {ce.Correo}, contrasenha: {ce.Contrasenha}");
                Console.WriteLine($"Nombre: {ce.NombreCE}, Sede: {ce.Sede.NombreSede}, telefono: {ce.TelefonoCE}");
                Console.WriteLine($"Orientador: {ce.NombreOrientador} {ce.ApellidosOrientador}, telefonoO:{ce.TelefonoOrientador}, correoO. {ce.CorreoOrientador}");
                Console.WriteLine($"ED: {ce.NombreEquipoDirectivo} {ce.ApellidosEquipoDirectivo}, telefonoED:{ce.TelefonoEquipoDirectivo}");
                Console.WriteLine($"Direccion: {ce.Direccion.NombreDireccion}, Municipio: {ce.Direccion.Municipio.NombreMunicipio}");
                Console.WriteLine($"ESTUDIANTES");
                if (ce.Estudiantes.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes del centro");
                }
                foreach (var e in ce.Estudiantes)
                {
                    Console.WriteLine($"Nombre: {e.NombreEstudiante} {e.Ap1Estudiante} {e.Ap2Estudiante}");
                }
            }

            CN_Diagnosticos cnDiagosticos = new CN_Diagnosticos();

            List<Diagnostico> diagnosticos = cnDiagosticos.listaDiagnosticos();

            foreach (var d in diagnosticos)
            {
                Console.WriteLine($"ID: {d.IdDiagnostico}, Nombre: {d.NombreDiagnostico}, Descripcion: {d.Descripcion}");
                Console.WriteLine("ADAPTACIONES");
                if (d.Adaptaciones.Count == 0)
                {
                    Console.WriteLine("No hay adaptaciones del diagnostico");
                }
                foreach (var a in d.Adaptaciones)
                {
                    Console.WriteLine($"Nombre: {a.NombreAdaptacion}");
                }
            }

            CN_Estudiantes cnEstudiantes = new CN_Estudiantes();
            List<Estudiante> estudiantes = cnEstudiantes.listaEstudiantes(1);
            foreach (var e in estudiantes)
            {
                Console.WriteLine($"ID: {e.IdEstudiante}, Nombre: {e.NombreEstudiante} {e.Ap1Estudiante} {e.Ap2Estudiante}");
                Console.WriteLine($"Tutor1: {e.NombreCompletoTutor1}, Telefono: {e.TelefonoTutor1}");
                Console.WriteLine($"Tutor2: {e.NombreCompletoTutor2}, Telefono: {e.TelefonoTutor2}");
                Console.WriteLine($"Curso: {e.CursoConvocatoria}, Fecha: {e.FechaRegistro}");

                Console.WriteLine($"Asignaturas Previstas");
                if (e.AsignaturasPrevistas.Count == 0)
                {
                    Console.WriteLine("No hay asignaturas previstas");
                }
                foreach (var a in e.AsignaturasPrevistas)
                {
                    Console.WriteLine($"Nombre: {a.NombreAsignatura}");
                }
                Console.WriteLine($"Asignaturas Matriculadas");
                if (e.AsignaturasMatriculadas.Count == 0)
                {
                    Console.WriteLine("No hay asignaturas matriculadas");
                }
                foreach (var a in e.AsignaturasMatriculadas)
                {
                    Console.WriteLine($"Nombre: {a.NombreAsignatura}");
                }
                Console.WriteLine($"Apuntes");
                if (e.Apuntes.Count == 0)
                {
                    Console.WriteLine("No hay apuntes");
                }
                foreach (var a in e.Apuntes)
                {
                    Console.WriteLine($"Nombre: {a.Descripcion}");
                }

                Console.WriteLine($"Documentos");
                if (e.Documentos.Count == 0)
                {
                    Console.WriteLine("No hay documentos");
                }
                foreach (var a in e.Documentos)
                {
                    Console.WriteLine($"Nombre: {a.IdDocumento}, {a.NombreDocumento},{a.RutaDocumento}, {a.Validado} ");
                }
                Console.ReadKey();
            }
        }
    }
}
