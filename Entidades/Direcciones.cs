using System.ComponentModel.DataAnnotations;

namespace Entidades;

public class Direcciones
{
    public int IdDireccion { get; set; }

    [Required, MaxLength(250)]
    public string Direccion { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string CodigoPostal { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Ciudad { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Comuna { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Region { get; set; } = string.Empty;

}
