namespace Entidades
{
    internal class Usuarios
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario {get; set;}
        public string Password {get; set;}
        public int RutUsuario {get; set;}
        public string DvUsuario {get; set;}
        public string DireccionUsuario {get; set;}
        public string CorreoUsuario {get; set;}
        public string TelefonoUsuario {get; set;}
        public int TipoUsuario {get; set;}
        public string Intragram {get; set;}
        public string Facebook { get; set;}
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEdicion { get; set; }
        public bool Estado {  get; set; }

    }
}
