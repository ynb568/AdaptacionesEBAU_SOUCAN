using CapaDatos;
using CapaEntidad;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Asignaturas : ICN_Asignaturas
    {
        private CD_Asignaturas objCD = new CD_Asignaturas();

        public List<Asignatura> listaAsignaturas ()
        {   
            return objCD.listaAsignaturas();
        }

        public List<Asignatura> listaAsignaturasActivas ()
        {
            List<Asignatura> asignaturas = objCD.listaAsignaturas();
            List<Asignatura> asignaturasCE = new List<Asignatura> ();

            asignaturasCE = asignaturas
                .Where (a => a.Activo)
                .ToList ();

            return asignaturasCE;
        }

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

        public List<Asignatura> listaAsignaturasPrevistasEstudiante(int idEstudiante)
        {
            return objCD.listaAsignaturasPrevistasEstudiante(idEstudiante);
        }

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

        public List<Asignatura> listaAsignaturasMatriculadasEstudiante(int idEstudiante)
        {
            return objCD.listaAsignaturasMatriculadasEstudiante(idEstudiante);
        }

        public bool registraAsignaturaPrevistaEstudiante(int idEstudiante, int idAsignatura, bool fase1, bool fase2)
        {
            return objCD.registraAsignaturaPrevistaEstudiante(idEstudiante, idAsignatura, fase1, fase2);
        }

        public bool eliminaAsignaturasPrevistasEstudiante(int idEstudiante) 
        { 
            return objCD.eliminaAsignaturasPrevistasEstudiante(idEstudiante); 
        }

    }
}
