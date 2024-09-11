using Entidades;

namespace SitioWeb;

public class Principal
{
    public bool ShowingConfigureDialog { get; set; }

    public static List<Productos> Productos { get; set; }

    public Order Order { get; set; } = new Order();
    public event Action OnChange; //INYECCIÓN DE DEPENDENCIAS
    //TEST
    public List<Productos> GetProductos()
    {
        return Productos;
    }

    public void AgregarProducto(Productos producto)
    {
        Productos.Add(producto);
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke(); //CAMBIO DE ESTADO

    
    public static Productos GetProducto(int idProducto, int precio)
    {
        var producto = new Productos
        {
            IdProducto = idProducto,
            NombreProducto = $"Producto {idProducto}",
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
