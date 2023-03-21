using Microsoft.EntityFrameworkCore;

namespace GeoApi.Brokers.Storage;

public partial class PersistenceBroker : DbContext, IPersistenceBroker
{
    public PersistenceBroker(DbContextOptions<PersistenceBroker> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedGeos(modelBuilder);
    }
}