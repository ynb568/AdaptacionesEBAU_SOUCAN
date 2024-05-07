using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaPresentacion.ViewModels
{
    public class FileUploadViewModel
    {
        public Documento Informacion { get; set; }
        public HttpPostedFileBase Contenido { get; set; }
    }
}