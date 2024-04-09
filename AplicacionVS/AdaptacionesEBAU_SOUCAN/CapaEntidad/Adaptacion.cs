namespace CapaEntidad
{
    public class Adaptacion
    {
        public int IdAdaptacion {  get; set; }
        public string NombreAdaptacion { get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }
        public bool Excepcional { get; set; }
        public string DescripcionExcepcional { get; set; }

        //FALTA MAPEAR LAS OBSERVACIONES VALIDADO Y DETALLES
        public string Observaciones { get; set; }
        public string Validado { get; set; }
        public string Detalles { get; set; }

    }
}
