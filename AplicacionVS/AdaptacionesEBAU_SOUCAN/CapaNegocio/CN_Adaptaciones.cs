﻿using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Adaptaciones
    {
        private CD_Adaptaciones objCD = new CD_Adaptaciones();

        public List<Adaptacion> listaAdaptaciones()
        {
            return objCD.listaAdaptaciones();
        }
    }
}
