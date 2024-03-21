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
        public List<Asignatura> listaAsignaturasSoucan ()
        {   
            return objCD.listaAsignaturas();
        }

        /*
        * Obtiene una lista de todas las asignaturas activas.
        * 
        * @return Lista de asignaturas activas
        */
        public List<Asignatura> listaAsignaturasCE ()
        {
            List<Asignatura> asignaturas = objCD.listaAsignaturas();
            List<Asignatura> asignaturasCE = new List<Asignatura> ();

            foreach (Asignatura a in asignaturas)
            {
                if (a.Activo == true)
                {
                    asignaturasCE.Add (a);
                }
            }
            return asignaturasCE;
        }

        /*
        * Obtiene una lista de asignaturas activas filtradas por fase.
        * 
        * @param fase El número de fase a filtrar. Debe ser 1 o 2.
        * @return Lista de asignaturas de fase indicada.
        * @throws ArgumentException Se lanza si la fase proporcionada no es 1 ni 2.
        */
        public List<Asignatura> listaAsignaturasPorFase (int fase)
        {
            List<Asignatura> asignaturas = listaAsignaturasCE();
            List<Asignatura> asignaturasFase = new List<Asignatura> ();
            if (fase == 1)
            {
                foreach (Asignatura a in asignaturas)
                {
                    if (a.Fase1 == false)
                    {
                        asignaturasFase.Add(a);
                    }
                }

            } else if (fase == 2)
            {
                foreach (Asignatura a in asignaturas)
                {
                    if (a.Fase2 == false)
                    {
                        asignaturasFase.Add(a);
                    }
                }
            } else
            {
                throw new ArgumentException("La fase debe ser 1 o 2", nameof(fase));
            }
            return asignaturasFase;
        }
        
    }
}
