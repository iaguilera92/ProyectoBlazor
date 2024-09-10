namespace Entidades;

public class LatitudLongitud
{
    public LatitudLongitud()
    {
    }

    public LatitudLongitud(double latitude, double longitude) : this()
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public static LatitudLongitud Interpolate(LatitudLongitud start, LatitudLongitud end, double proportion)
    {
        return new LatitudLongitud(
                start.Latitude + (end.Latitude - start.Latitude) * proportion,
                start.Longitude + (end.Longitude - start.Longitude) * proportion);
    }
}