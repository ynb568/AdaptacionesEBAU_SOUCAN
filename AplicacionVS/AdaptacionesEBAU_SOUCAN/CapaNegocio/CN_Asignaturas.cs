using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Asignaturas
    {
        private CD_Asignaturas objCD = new CD_Asignaturas();

        /*
         * Obtiene una lista de todas las asignaturas.
         * 
         * @return Lista de asignaturas completa
        */
        public List<Asignatura> listaAsignaturas ()
        {   
            return objCD.listaAsignaturas();
        }

        /*
         * Obtiene una lista de todas las asignaturas activas.
         * 
         * @return Lista de asignaturas activas
        */
        public List<Asignatura> listaAsignaturasActivas ()
        {
            List<Asignatura> asignaturas = objCD.listaAsignaturas();
            List<Asignatura> asignaturasCE = new List<Asignatura> ();

            asignaturasCE = asignaturas
                .Where (a => a.Activo)
                .ToList ();

            return asignaturasCE;
        }

        /*
         * Obtiene una lista de asignaturas activas filtradas por fase.
         * 
         * @param fase: El número de fase a filtrar. Debe ser 1 o 2.
         * @return Lista de asignaturas de fase indicada.
         * @throws ArgumentException Se lanza si la fase proporcionada no es 1 ni 2.
        */
        public List<Asignatura> listaAsignaturasPorFase (int fase)
        {
            List<Asignatura> asignaturas = listaAsignaturasActivas();
            List<Asignatura> asignaturasFase = new List<Asignatura> ();

            if (fase == 1)
            {
                asignaturasFase = asignaturas
                    .Where(a => a.Fase1)
                    .ToList();
            } else if (fase == 2)
            {
                asignaturasFase = asignaturas
                    .Where(a => a.Fase2)
                    .ToList();
            } else
            {
                throw new ArgumentException("La fase debe ser 1 o 2", nameof(fase));
            }
            return asignaturasFase;
        }
        /*
         * Obtiene una lista de todas las asignaturas previstas de un estudiante 
         * cuyo id es pasado como parametro
         * 
         * @param idEstudiante: identificador del estudiante
         * @return lista de asignaturas previstas de un estudiante
        */
        public List<Asignatura> listaAsignaturasPrevistasEstudiante(int idEstudiante)
        {
            return objCD.listaAsignaturasPrevistasEstudiante(idEstudiante);
        }

        /*
         * Obtiene una lista de asignaturas previstas de un estudiante filtradas por fase.
         * 
         * @param idEstudiante: identificador del estudiante
         * @param fase: El número de fase a filtrar. Debe ser 1 o 2.
         * @return Lista de asignaturas previstas de fase indicada.
         * @throws ArgumentException Se lanza si la fase proporcionada no es 1 ni 2.
        */
        public List<Asignatura> listaAsignaturasPrevistasEstudiantePorFase (int idEstudiante, int fase)
        {
            List<Asignatura> asignaturas = listaAsignaturasPrevistasEstudiante(idEstudiante);
            List<Asignatura> asignaturasFase = new List<Asignatura>();

            if (fase == 1)
            {
                asignaturasFase = asignaturas
                    .Where(a => a.Fase1)
                    .ToList();
            }
            else if (fase == 2)
            {
                asignaturasFase = asignaturas
                    .Where(a => a.Fase2)
                    .ToList();
            }
            else
            {
                throw new ArgumentException("La fase debe ser 1 o 2", nameof(fase));
            }
            return asignaturasFase;
        }
        /*
         * Obtiene una lista de todas las asignaturas matriculadas de un estudiante 
         * cuyo id es pasado como parametro
         * 
         * @param idEstudiante: identificador del estudiante
         * @return lista de asignaturas matriculadas de un estudiante
        */
        public List<Asignatura> listaAsignaturasMatriculadasEstudiante(int idEstudiante)
        {
            return objCD.listaAsignaturasMatriculadasEstudiante(idEstudiante);
        }

        /*
         * Registra una asignatura prevista de un estudiante en las fases que sean indicadas
         * por parámetro
         * 
         * @param idEstudiante: identificador del estudiante
         * @param fase1: booleano que indica si se quiere registrar asigatura en la fase 1
         * @param fase2: booleano que indica si se quiere registrar asigatura en la fase 2
         * @return true si se ha insertado correctamente, false en caso contrario
        */
        public bool registraAsignaturaPrevistaEstudiante(int idEstudiante, int idAasignatura, bool fase1, bool fase2)
        {
            return objCD.registraAsignaturaPrevistaEstudiante(idEstudiante, idAasignatura, fase1, fase2);
        }

        /*
         * Elimina las asignaturas prevista de un estudiante 
         * cuyo id sea pasado por parámetro
         * 
         * @param idEstudiante: identificador del estudiante
         * @return true si se ha eliminado correctamente, false en caso contrario
        */
        public bool eliminaAsignaturasPrevistasEstudiante(int idEstudiante) 
        { 
            return objCD.eliminaAsignaturasPrevistasEstudiante(idEstudiante); 
        }

    }
}
