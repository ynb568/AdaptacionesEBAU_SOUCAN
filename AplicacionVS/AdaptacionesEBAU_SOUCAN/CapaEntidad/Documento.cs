namespace CapaEntidad
{
    public class Documento
    {
        public int IdDocumento { get; set; }
        public string NombreDocumento { get; set; }
        public string RutaDocumento { get; set; }
        public byte[] Contenido { get; set; }
        public int Validado { get; set; } 
    }
}
