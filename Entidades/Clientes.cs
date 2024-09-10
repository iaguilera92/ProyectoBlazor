namespace Entidades
{
    internal class Clientes
    {
        public int IdCliente { get; set; }
        public string NombreCliente  { get; set; }
        public int RutCliente { get; set; }
        public int DvCliente { get; set; }
        public string DireccionCliente  { get; set; }
        public string CorreoCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string DireccionCompra {  get; set; }
        public int EstadoCliente { get; set; }
        public bool Estado {  get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaEdicion { get; set; }
        public int PreferenciaCompra { get; set; }
        
    }
}
