using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Estudiantes
    {
        private CD_Estudiantes objCD = new CD_Estudiantes();

        public List<Estudiante> listaEstudiantes(int idCentro)
        {
            return objCD.listaEstudiantes(idCentro);
        }

        public Estudiante obtenEstudianteCentro(int idCentro, int idEstudiante)
        {
            return objCD.obtenEstudianteCentro(idCentro, idEstudiante);
        }

        public bool registraEstudiante(string dniEstudiante, string nombreEstudiante, string ap1Estudiante, string ap2Estudiante,
            string nombreCompletoT1, string telefonoT1, string nombreCompletoT2, string telefonoT2,
            bool ordinaria, bool extraordinaria, int idCE, string observaciones)
        {
            return objCD.registraEstudiante(dniEstudiante, nombreEstudiante, ap1Estudiante, ap2Estudiante,
                nombreCompletoT1, telefonoT1, nombreCompletoT2, telefonoT2,
                ordinaria, extraordinaria, idCE, observaciones);
        }

        public bool modificaDatosEstudiante(int idE, bool ordinaria, bool extraordinaria, string observaciones)
        {
            if (idE == 0)
                throw new ArgumentException("El id del estudiante no puede ser 0.");
            if (ordinaria == false && extraordinaria == false)
                throw new ArgumentException("El estudiante debe tener al menos una convocatoria.");
            if (ordinaria = true && extraordinaria == true)
                throw new ArgumentException("El estudiante no puede tener ambas convocatorias.");

            return objCD.modificaDatosEstudiante(idE, ordinaria, extraordinaria, observaciones);
        }
    }
}
