﻿using CapaDatos;
using CapaEntidad;
using CapaNegocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Municipios : ICN_Municipios
    {
        private CD_Municipios objCD = new CD_Municipios();
        
        public List<Municipio> listaMunicipios ()
        {
            return objCD.listaMunicipios ();
        }
    }
}
