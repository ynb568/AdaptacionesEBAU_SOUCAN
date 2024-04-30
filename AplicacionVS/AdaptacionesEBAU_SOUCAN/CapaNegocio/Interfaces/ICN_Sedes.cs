using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ICN_Sedes
    {
        /// <summary>
        /// Obtiene la lista de todas las sedes.
        /// </summary>
        /// <returns>Lista de sedes completa.</returns>
        List<Sede> listaSedes();
        /// <summary>
        /// Obtiene la lista de todas las sedes activas.
        /// </summary>
        /// <returns>Lista de sedes con campo Activo en true.</returns>
        List<Sede> listaSedesActivas();
    }
}
