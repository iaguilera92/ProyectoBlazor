using Entidades;

namespace SitioWeb;

public class Principal
{
    //PARAMETROS GENERALES (PRINCIPALES)
    public bool MobileMenu { get; set; }
    public static List<Productos> Productos { get; set; }
    public static Order Carrito { get; set; } = new Order();
    public event Action OnChange; //INYECCIÓN DE DEPENDENCIAS
    public Usuarios Usuario { get; set; }

    
    //EVENTOS-ACCIONES
    private void AddStateChanged() => OnChange?.Invoke(); //CARGAR AGREGADO
    private void ClearStateChanged() => OnChange?.Invoke(); //CARGAR LIMPIAR
    public void UpdateCarritoChanged() => OnChange?.Invoke(); //CARGAR CARRITO
    private void AddCartChanged() => OnChange?.Invoke();
    //public event Action<Order> OnCarritoUpdated; //RETORNAR EVENT CARRITO


    //METODOS
    public List<Productos> GetProductos()
    {
        return Productos;
    }

    public void AgregarProducto(Productos producto)
    {
        Productos.Add(producto);
        AddStateChanged();
    }
    public Order GetCarrito()
    {
        return Carrito;
    }
    public static Productos GetProducto(int idProducto, int precio, int imgUrl, int stock = 1, bool conDescuento = false)
    {
        var url = ImgUrlAleatorio(imgUrl);
        var producto = new Productos
        {
            IdProducto = idProducto,
            NombreProducto = $"Producto {idProducto}",
            Descripcion = "Esta es una descripción del producto en stock, click para agregar al carrito.",
            Valor = precio,
            Stock = stock,
            ImageUrl = url,
            ConDescuento = conDescuento
        };
        return producto;
    }
    private static string ImgUrlAleatorio(int imgUrl)
    {
        string url = "https://emprendepyme.net/wp-content/uploads/2023/03/comercializar-productos.jpg";
        if (imgUrl == 2)
        {
            url = "https://www.hostingplus.cl/wp-content/uploads/2023/08/Importancia-del-carrito-de-compra.jpg";
        }
        else if (imgUrl == 3)
        {
            url = "https://logistica360.pe/wp-content/uploads/2023/11/compras-inte.jpg";
        }
        else if (imgUrl == 4)
        {
            url = "https://www.ticobuycr.com/wp-content/uploads/2021/04/venta-por-internet_1.jpg";
        }
        return url;
    }
    public void RemoverProducto(Productos producto)
    {
        if (Carrito.Productos.Any(p => p.IdProducto == producto.IdProducto))
        {
            var productoSeleccionado = Carrito.Productos.Where(p => p.IdProducto == producto.IdProducto).FirstOrDefault();
            if (productoSeleccionado != null)
            {
                Carrito.Productos.Remove(productoSeleccionado);
                AddCartChanged();
            }
        }
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
    public string FormatearPesos(decimal valor)
    {
        var valorPesos = valor.ToString("N0", new System.Globalization.CultureInfo("es-CL"));
        return $"${valorPesos}";
    }    
}
