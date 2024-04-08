using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    //FILTRADO DE DATOS
    public class CN_CentrosEducativos
    {
        private CD_CentrosEducativos objCD = new CD_CentrosEducativos();

        public List<CentroEducativo> listaCentros()
        {
            
            return objCD.listaCentros();
        }

        public CentroEducativo obtenCentro (int idCentroEducativo)
        {
            return objCD.obtenCentro(idCentroEducativo);
        }

        public bool registraCentroEducativo(string nombreCE, string telefonoCE,
            string nombreOrientador, string apellidosOrientador, string telefonoOrientador, string correoOrientador,
            string nombreEquipoDirectivo, string apellidosEquipoDirectivo, string telefonoEquipoDirectivo,
            string direccion, int idMunicipio, int idSede,
            string correo, string contrasenha, string repetirContrasenha)
        {
            return objCD.registraCentroEducativo(nombreCE, telefonoCE,
            nombreOrientador, apellidosOrientador, telefonoOrientador, correoOrientador,
            nombreEquipoDirectivo, apellidosEquipoDirectivo, telefonoEquipoDirectivo,
            direccion, idMunicipio, idSede,
            correo, contrasenha, repetirContrasenha);
        }

    }
}
