using System.ComponentModel;

namespace CapaEntidad
{
    public class Adaptacion
    {
        public int IdAdaptacion {  get; set; }
        public string NombreAdaptacion { get; set; }
        public bool Activo { get; set; }
        [DisplayName("Descripción: ")]
        public string Descripcion { get; set; }
        public bool Excepcional { get; set; }
        [DisplayName("Descripción excepcional: ")]
        public string DescripcionExcepcional { get; set; }
    }
}
