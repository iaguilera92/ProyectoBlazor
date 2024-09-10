using Entidades;

namespace SitioWeb;

public class Principal
{
    public bool ShowingConfigureDialog { get; set; }

    public static List<Productos> Productos { get; set; }

    public Order Order { get; set; } = new Order();

    //TEST
    public static Productos GetProducto(string nombre, int precio)
    {
        var producto = new Productos
        {
            IdProducto = 1,
            NombreProducto = nombre,
            Descripcion = "Esta es una descripción del producto en stock, click para agregar al carrito.",
            Valor = precio
            //ImageUrl = "https://t1.gstatic.com/licensed-image?q=tbn:ANd9GcSVhJ46pOBVylg5_ZnYilSr14xSgJwSZ386f8C6hRKrA0MRiCpn2ozG-Bfcxa3bSdJ-",               
        };
        return producto;
    }

    public void CancelarConfiguracion()
    {
        ShowingConfigureDialog = false;
    }

    public void ConfirmarConfiguracion()
    {        
        ShowingConfigureDialog = false;
    }

    public void RemoverProducto(Productos producto)
    {
        Productos.Remove(producto);
    }

    public void Limpiar()
    {
        Productos = new List<Productos>();
    }   
}
