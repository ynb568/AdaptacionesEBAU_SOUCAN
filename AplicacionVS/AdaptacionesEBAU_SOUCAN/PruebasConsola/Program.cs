using CapaDatos;
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
            /*
            //ASIGNATURAS (CORRECTO)
            // Crear una instancia de la clase de lógica de negocio
            CN_Asignaturas cnAsignaturas = new CN_Asignaturas();

            // Llamar al método listaAsignaturas() para obtener la lista de asignaturas
            List<Asignatura> asignaturas = cnAsignaturas.listaAsignaturas();

            // Imprimir los datos en la consola
            foreach (var a in asignaturas)
            {
                Console.WriteLine($"ID: {a.IdAsignatura}, Nombre: {a.NombreAsignatura}, Activo: {a.Activo}, Fase1: {a.Fase1}, Fase2: {a.Fase2}");
            }
            
            //MUNICIPIOS (CORRECTO)
            CN_Municipios cnMunicipios = new CN_Municipios();
            List<Municipio> municipios = cnMunicipios.listaMunicipios();
            foreach (var m in municipios)
            {
                Console.WriteLine($"ID: {m.IdMunicipio}, Nombre: {m.NombreMunicipio}");
            }

            //SEDES (CORRECTO)
            CN_Sedes cnSedes = new CN_Sedes();
            List<Sede> sedes = cnSedes.listaSedes();
            foreach (var s in sedes)
            {
                Console.WriteLine($"ID: {s.IdSede}, Nombre: {s.NombreSede}, Activo: {s.Activo}");
            }

            //ADAPTACIONES (CORRECTO)
            CN_Adaptaciones cnAdaptaciones = new CN_Adaptaciones();
            List<Adaptacion> adaptaciones = cnAdaptaciones.listaAdaptaciones();
            foreach (var a in adaptaciones)
            {
                Console.WriteLine($"ID: {a.IdAdaptacion}, Nombre: {a.NombreAdaptacion}, Descripcion: {a.Descripcion}, Activo: {a.Activo}");
            }

            //DIAGNOSTICOS (FALTA GESTIONAR EL CASO DE QUE SEAN EXCEPCIONALES)
            CN_Diagnosticos cnDiagnosticos = new CN_Diagnosticos();
            List<Diagnostico> diagnosticos = cnDiagnosticos.listaDiagnosticos();
            foreach (var d in diagnosticos)
            {
                Console.WriteLine($"ID: {d.IdDiagnostico}, Nombre: {d.NombreDiagnostico}, Descripcion: {d.Descripcion}, Activo: {d.Activo}");
                foreach (var a in d.Adaptaciones)
                {
                    Console.WriteLine($"\tAdaptacion: {a.NombreAdaptacion}, {a.Descripcion}");
                }
            }

            
            //CENTROS EDUCATIVOS(CORRECTO)
            CN_CentrosEducativos cnCentros = new CN_CentrosEducativos();

            CentroEducativo centro = cnCentros.obtenCentro(1);
            Console.WriteLine("obtenCentro");
            Console.WriteLine($"ID: {centro.IdCE}, correo: {centro.Correo}, contrasenha: {centro.Contrasenha}");
            Console.WriteLine($"Nombre: {centro.NombreCE}, Sede: {centro.Sede.NombreSede}, telefono: {centro.TelefonoCE}");
            Console.WriteLine($"Orientador: {centro.NombreOrientador} {centro.ApellidosOrientador}, telefonoO:{centro.TelefonoOrientador}, correoO. {centro.CorreoOrientador}");
            Console.WriteLine($"ED: {centro.NombreEquipoDirectivo} {centro.ApellidosEquipoDirectivo}, telefonoED:{centro.TelefonoEquipoDirectivo}");
            Console.WriteLine($"Direccion: {centro.Direccion.NombreDireccion}, Municipio: {centro.Direccion.Municipio.NombreMunicipio}");
            Console.WriteLine($"FechaRegistro: {centro.FechaRegistro}");


            List<CentroEducativo> centros = cnCentros.listaCentros();
            Console.WriteLine("listaCentros");
            foreach (var ce in centros)
            {
                Console.WriteLine($"ID: {ce.IdCE}, correo: {ce.Correo}, contrasenha: {ce.Contrasenha}");
                Console.WriteLine($"Nombre: {ce.NombreCE}, Sede: {ce.Sede.NombreSede}, telefono: {ce.TelefonoCE}");
                Console.WriteLine($"Orientador: {ce.NombreOrientador} {ce.ApellidosOrientador}, telefonoO:{ce.TelefonoOrientador}, correoO. {ce.CorreoOrientador}");
                Console.WriteLine($"ED: {ce.NombreEquipoDirectivo} {ce.ApellidosEquipoDirectivo}, telefonoED:{ce.TelefonoEquipoDirectivo}");
                Console.WriteLine($"Direccion: {ce.Direccion.NombreDireccion}, Municipio: {ce.Direccion.Municipio.NombreMunicipio}");
                Console.WriteLine($"FechaRegistro: {ce.FechaRegistro}");
                Console.WriteLine($"\tESTUDIANTES");
                if (ce.Estudiantes.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes del centro");
                }
                foreach (var e in ce.Estudiantes)
                {
                    Console.WriteLine($"\tNombre: {e.NombreEstudiante} {e.Ap1Estudiante} {e.Ap2Estudiante}");
                }
            }

            //ESTUDIANTES
            CN_Estudiantes cnEstudiantes = new CN_Estudiantes();
            List<Estudiante> estudiantes = cnEstudiantes.listaEstudiantes(1);
            Console.WriteLine("listaEstudiantes");
            foreach (var e in estudiantes)
            {
                Console.WriteLine($"ID: {e.IdEstudiante}, DNI: {e.DniEstudiante}, Nombre: {e.NombreEstudiante} {e.Ap1Estudiante} {e.Ap2Estudiante}");
                //Console.WriteLine($"Centro Estudiante: {e.Centro.NombreCE}");
                Console.WriteLine($"Tutor1: {e.NombreCompletoTutor1}, Telefono: {e.TelefonoTutor1}");
                Console.WriteLine($"Tutor2: {e.NombreCompletoTutor2}, Telefono: {e.TelefonoTutor2}");
                Console.WriteLine($"Curso: {e.CursoConvocatoria}, Ordinaria: {e.Ordinaria}, Extraordinaria: {e.ExtraOrdinaria},Fecha: {e.FechaRegistro}");
                Console.WriteLine($"Observaciones: {e.Observaciones}");
                //APUNTES
                Console.WriteLine($"\tAPUNTES");
                foreach (var a in e.Apuntes)
                {
                    Console.WriteLine($"\tIdApunte:{a.IdApunte}, Descripcion: {a.Descripcion}");
                }
                //DOCUMENTOS
                Console.WriteLine($"\tDOCUMENTOS");
                foreach (var d in e.Documentos)
                {
                    Console.WriteLine($"\tIdDocumento:{d.IdDocumento}, Nombre: {d.NombreDocumento}, Ruta: {d.RutaDocumento}, Validado: {d.Validado}");
                }
                //ASIGNATURAS PREVISTAS
                Console.WriteLine($"\tASIGNATURAS PREVISTAS");
                foreach (var a in e.AsignaturasPrevistas)
                {
                    Console.WriteLine($"\tNombre: {a.NombreAsignatura}, Fase1: {a.Fase1}, Fase2: {a.Fase2}");
                }
                //ASIGNATURAS MATRICULADAS
                Console.WriteLine($"\tASIGNATURAS MATRICULADAS");
                foreach (var a in e.AsignaturasMatriculadas)
                {
                    Console.WriteLine($"\tNombre: {a.NombreAsignatura}, Fase1: {a.Fase1}, Fase2: {a.Fase2}");
                }

                //DIAGNOSTICOS
                Console.WriteLine($"\tDIAGNOSTICOS");
                foreach (var d in e.Diagnosticos)
                {
                    Console.WriteLine($"\tNombre: {d.NombreDiagnostico}, Descripcion: {d.Descripcion}");
                    Console.WriteLine($"\t\tADAPTACIONES");
                    foreach (var a in d.AdaptacionesEstudiante) { 
                        Console.WriteLine($"\t\tAdaptacion: {a.Adaptacion.NombreAdaptacion}, Activo: {a.Adaptacion.Activo}, Descripcion: {a.Adaptacion.Descripcion}, Validado: {a.Validado}, Observaciones: {a.Observaciones}, Revision: {a.Revision}"); 
                    }
                }
            }

            Estudiante estudiante = cnEstudiantes.obtenEstudianteCentro(1,1);
            Console.WriteLine("obtenEstudianteCentro");
            Console.WriteLine($"ID: {estudiante.IdEstudiante}, DNI: {estudiante.DniEstudiante}, Nombre: {estudiante.NombreEstudiante} {estudiante.Ap1Estudiante} {estudiante.Ap2Estudiante}");
            

            //PRUEVAS DE REGISTRO
            // Crear una instancia de las clases de lógica de negocio
            
            CN_CentrosEducativos cnCentros = new CN_CentrosEducativos();
            CN_Estudiantes cnEstudiantes = new CN_Estudiantes();
            CN_Documentos cnDocumentos = new CN_Documentos();
            CN_Asignaturas cnAsignaturas = new CN_Asignaturas();
            CN_Diagnosticos cnDiagnosticos = new CN_Diagnosticos();
            CN_AdaptacionesDiagnosticoEstudiante cnAdaptacionesDE = new CN_AdaptacionesDiagnosticoEstudiante();

            // Llamar a los métodos de registro
            
            bool registroCentro = cnCentros.registraCentroEducativo("nombreCE_REG", "111222333",
                "nombreOrientador_REG", "apellidosOrientador_REG", "444333555", "correoOrientador@REG.com",
                "nombreEquipoDirectivo_REG", "apellidosEquipoDirectivo_REG", "222333444",
                "direccion_REG", 1, 1,
                "correo@REG.com", "contrasenha_REG", "contrasenha_REG");

            bool registroEstudiante = cnEstudiantes.registraEstudiante("dniEstudiante_REG", "nombreEstudiante_REG", "ap1Estudiante_REG", "ap2Estudiante_REG",
                "nombreCompletoT1_REG", "999888777", "nombreCompletoT2_REG", "888777666",
                true, false, 1, "observaciones_REG");

            bool registroAsignatura = cnAsignaturas.registraAsignaturaPrevistaEstudiante(1, 1, true, false);
            
            bool registroDocumento = cnDocumentos.registraDocumentoEstudiante(1, 1, "rutaDocumento_REG");
            
            bool registroAdaptacion = cnAdaptacionesDE.registraAdaptacionDiagnosticoEstudiante(1, 1, 1, "observaciones_REG");

            // Imprimir los resultados en la consola
            Console.WriteLine($"Registro de centro educativo: {(registroCentro ? "Exitoso" : "Fallido")}");
            Console.WriteLine($"Registro de estudiante: {(registroEstudiante ? "Exitoso" : "Fallido")}");
            Console.WriteLine($"Registro de asignatura prevista: {(registroAsignatura ? "Exitoso" : "Fallido")}");
            Console.WriteLine($"Registro de documento: {(registroDocumento ? "Exitoso" : "Fallido")}"); 
            Console.WriteLine($"Registro de adaptación: {(registroAdaptacion ? "Exitoso" : "Fallido")}");
            

            bool eliminaDiagnosticoEstudiante = cnDiagnosticos.eliminaDiagnosticoEstudiante(1, 1);

            Console.WriteLine($"Eliminación de diagnóstico de estudiante: {(eliminaDiagnosticoEstudiante ? "Exitosa" : "Fallida")}");
            */

            //PRUEBAS MODIFICACION
            // Prueba para modificaDatosCentro
            var cnCentrosEducativos = new CN_CentrosEducativos();
            bool resultadoCentro = cnCentrosEducativos.modificaDatosCentro(1, "345678923", "Juan", "Perez", "987654321", "juan.perez@example.com", "Ana", "Gomez", "987987987");
            Console.WriteLine("Resultado de modificaDatosCentro: " + resultadoCentro);


            var cnEstudiantes = new CN_Estudiantes();
            bool resultadoEstudiante = cnEstudiantes.modificaDatosEstudiante(1, true, false, "Nuevas observaciones estudiante");
            Console.WriteLine("Resultado de modificaDatosEstudiante: " + resultadoEstudiante);

            // Prueba para eliminaDocumentosEstudiante
            var cnDocumentos = new CN_Documentos();
            bool resultadoDocumentos = cnDocumentos.eliminaDocumentosEstudiante(1);
            Console.WriteLine("Resultado de eliminaDocumentosEstudiante: " + resultadoDocumentos);

            // Prueba para eliminaAsignaturasPrevistasEstudiante
            var cnAsignaturas = new CN_Asignaturas();
            bool resultadoAsignaturas = cnAsignaturas.eliminaAsignaturasPrevistasEstudiante(1);
            Console.WriteLine("Resultado de eliminaAsignaturasPrevistasEstudiante: " + resultadoAsignaturas);
            Console.ReadKey(); 
            
            Console.ReadKey();
            }
        }
    }
