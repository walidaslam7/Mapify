namespace Mapify.Models;

public class GeoLookup
{
    public Guid Id { get; set; }
    public string City { get; set; } = null!;
    public string Longitude { get; set; } = null!;
    public string Latitude { get; set; } = null!;
}