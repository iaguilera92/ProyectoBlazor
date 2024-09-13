using Entidades;

namespace SitioWeb;

public class Principal
{
    public bool ShowingConfigureDialog { get; set; }

    public static List<Productos> Productos { get; set; }
    public static Order Carrito { get; set; }
    public event Action OnChange; //INYECCIÓN DE DEPENDENCIAS
    //TEST
    public List<Productos> GetProductos()
    {
        return Productos;
    }

    public void AgregarProducto(Productos producto)
    {
        Productos.Add(producto);
        AddStateChanged();
    }

    private void AddStateChanged() => OnChange?.Invoke(); //CAMBIO DE ESTADO
    private void ClearStateChanged() => OnChange?.Invoke(); //CAMBIO DE ESTADO
    private void AddCartChanged() => OnChange?.Invoke();


    public static Productos GetProducto(int idProducto, int precio, int stock = 1)
    {
        var producto = new Productos
        {
            IdProducto = idProducto,
            NombreProducto = $"Producto {idProducto}",
            Descripcion = "Esta es una descripción del producto en stock, click para agregar al carrito.",
            Valor = precio,
            Stock = stock
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
        var primerosProductos = GetProductos().Take(4).ToList();
        var filtrados = GetProductos().Where(p => !primerosProductos.Contains(p)).ToList();
        filtrados.ForEach(producto =>
        {
            RemoverProducto(producto);
        });
        LimpiarCarrito();
        ClearStateChanged();
    }   
    public void LimpiarCarrito()
    {
        if (Carrito != null)
        {
            Carrito.Productos.Clear();
        }
        ClearStateChanged();
    }
    public void AgregarCarrito(Order carrito)
    {
        Carrito = carrito;
        AddCartChanged();
    }
}
