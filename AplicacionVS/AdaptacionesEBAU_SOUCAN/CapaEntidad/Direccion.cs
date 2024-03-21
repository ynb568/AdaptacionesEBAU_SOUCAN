namespace CapaEntidad
{
    public class Direccion
    {
        public int IdDireccion {  get; set; }
        public int direccion { get; set; }
        public Municipio Municipio { get; set; }
    }
}
