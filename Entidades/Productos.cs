using System.Text.Json.Serialization;

namespace Entidades;

public class Productos
{
    //TAMAÑOS
    public const int DefaultSize = 12;
    public const int MinimumSize = 9;
    public const int MaximumSize = 17;

    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = string.Empty;

    public decimal Valor { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = "https://emprendepyme.net/wp-content/uploads/2023/03/comercializar-productos.jpg";

    public int Stock { get; set; }

    public int StockMensual { get; set; }

    public bool Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaEdicion { get; set; }
    public int Categoria { get; set; }
    public int Size { get; set; }
    public int Descuento { get; set; }
    public int Valoracion { get; set; }
    public string Comentario { get; set; }


    public string GetFormattedBasePrice() => Valor.ToString("0.00");


    public decimal GetBasePrice()
    {
        return 0;
    }

    public decimal GetTotalPrice()
    {
        return 0;
    }

    public string GetFormattedTotalPrice()
    {
        return GetTotalPrice().ToString("0.00");
    }
}

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Productos))]
public partial class PizzaContext : JsonSerializerContext { }