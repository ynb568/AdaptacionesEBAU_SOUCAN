namespace CapaEntidad
{
    public abstract class Usuario
    {
        protected Usuario(string correo, string contrasenha)
        {
            Correo = correo;
            Contrasenha = contrasenha;
        }

        public int IdUsuario {  get; set; }
        public string Correo {  get; set; }
        public string Contrasenha { get; set; }

        public string RepetirContrasenha { get; set; }

    }
}
