using Mapify.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoApi.Brokers.Storage;

public partial class PersistenceBroker
{
    public DbSet<GeoLookup> GeoLookup { get; set; }

    public IQueryable<GeoLookup> SelectAllGeos() => GeoLookup.AsQueryable();
}