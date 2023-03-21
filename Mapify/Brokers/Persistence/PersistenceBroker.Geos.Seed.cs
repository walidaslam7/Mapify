using Mapify.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace GeoApi.Brokers.Storage;

public partial class PersistenceBroker
{
    private static void SeedGeos(ModelBuilder modelBuilder)
    {
        string jsonData = File.ReadAllText(@"JsonFiles//PakistanData.json");
        List<GeoLookup> allGeos = JsonSerializer.Deserialize<List<GeoLookup>>(jsonData) ?? new();
        modelBuilder.Entity<GeoLookup>().HasData(allGeos);
    }
}