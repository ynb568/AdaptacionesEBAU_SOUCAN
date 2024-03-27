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

        public List<Estudiante> listaEstudiantes (int idCentro)
        {
            return objCD.listaEstudiantes(idCentro);
        }

        public Estudiante obtenEstudianteCentro (int idCentro, int idEstudiante)
        {
            return objCD.obtenEstudianteCentro(idCentro, idEstudiante);
        }
    }
}
