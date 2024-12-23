﻿using Entidades;
using System.Net;
using System.Text.Json.Serialization;

namespace Entidades;

public class Order
{
    public int OrderId { get; set; }

    public string? UserId { get; set; }

    public DateTime CreatedTime { get; set; }

    public Direcciones DeliveryAddress { get; set; } = new Direcciones();

    public LatitudLongitud? DeliveryLocation { get; set; }

    public List<Productos> Productos { get; set; } = new List<Productos>();
    public int CantidadProductos { get; set; }
    public decimal GetPrecioTotal() => Productos.Sum(p => p.ValorCantidad);

    public string GetFormattedTotalPrice() => GetPrecioTotal().ToString("0.00");
    public decimal valorDeliveryMin { get; set; } = 3500; //DEFAULT
    public decimal valorDeliveryMax { get; set; } = 4500; //DEFAULT
    public DateTime FechaReserva { get; set; }
}

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Order))]
[JsonSerializable(typeof(OrderWithStatus))]
[JsonSerializable(typeof(List<OrderWithStatus>))]
[JsonSerializable(typeof(Productos))]
[JsonSerializable(typeof(Dictionary<string, string>))]
public partial class OrderContext : JsonSerializerContext { }